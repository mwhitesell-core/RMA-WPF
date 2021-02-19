/* cpi5.c
 Purpose: provides socket connection to Web and interface to Cobol program
	  to provide CPI (central patient Index) lookup against RMA unix 
	  database
 Modifcation History:
 2002/apr/01 B.E. - original
 2002/jun/30 B.E. - size of patient record/buffer changed to from 343 to 379 
 2003/feb/26 B.E. - pgm renamed to cpi5 to indicate processing 5 MRNs/patient
		    and call made now to cpirma5.


TODO: 'send' uses hard coded patient buffersize - should use CONST


*/
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <netdb.h>
#include <errno.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <string.h>
#include <ctype.h>
#include <stdio.h>
#include <time.h>

/* this length must be kept in sync with changes to length of patient
   record passed in cpirma5.cbl /*
#define MAX_PATIENT_RECORD_SIZE		379
/* this length is 'patient record size'(above) * nbr records in buffer plus
   8 characters for 'count of records return' (7) and 1 byte Y/N flag for
   to indicate if buffer is full and thus another read of further matching
   records should be made)
#define MAX_PATIENT_RECS_BUFFER_SIZE	3798 

#define MAX_SOCKET_BUFFER_SIZE		2056		/* TODO: to long? */

#define DEFAULT_PORT 51118	/* port for service */

extern int cpirma5();            /* Cobol program - */
/*extern int validate();             Cobol program - */
extern int lookup();           /* Cobol program - */
extern void cobexit();		/* close down Cobol system and exit */
extern int cobprintf();         /* COBOL display from C */
extern int cobgetch();          /* COBOL character get */

main( argc, argv )
	int argc;
	char *argv[];
{

  char socketBuffer[MAX_SOCKET_BUFFER_SIZE];
  int s, newSocket, retcode, addrlen, requestLen;
  long bufferCount;
  struct sockaddr_in addr;
  struct servent *sp;
  int ss;
  int strlen();
  int strncmp();
  int keepAcceptingConnections;
  int CobolStatus;
  long requestLength;
  char patientRecsBuffer[MAX_PATIENT_RECS_BUFFER_SIZE];
  int pid;
  char *shutdownString="~RMAshutDOWNcommand!~";
  time_t currentDateTime;
  int runWithForkON;
  int debugON;
  int auditON;
  FILE *auditFile;
  FILE *debugFile;
  FILE *requestsFiles;

  runWithForkON = 0; /* allows disabling of fork when debuging cobol */
  debugON = 2 ;/* ON ONLY for TESTING
		1=write to audit.log
		2= include returned data from cobol pgm
	       */
  auditON = 1 ;	/* should ALWAYS BE ON */

  if (auditON) auditFile = fopen("audit.log", "a");
  if (debugON) debugFile = fopen("debug.log", "a");

  cobinit();

  s = socket( AF_INET, SOCK_STREAM, 0 );

  if(s ==-1 ){
        if (auditON)  {
  	    time(&currentDateTime);
	    fprintf(auditFile,"%s\n",ctime(&currentDateTime));
	    fprintf(auditFile, ": FATAL Error - Server can't create socket\n");
	}
	exit(1);
  }

  memset(&addr, 0, sizeof(addr));
  sp = getservbyname( "webstar", "tcp" );

  if( sp != NULL ) {
	addr.sin_port = sp->s_port;
  } else {
	addr.sin_port = htons(DEFAULT_PORT);
  }

  addr.sin_family = AF_INET;
  addr.sin_addr.s_addr = INADDR_ANY;

  if( bind( s, (struct sockaddr *) &addr, sizeof(addr) ) == -1){
	perror("bind");
	exit(1);
  }

  keepAcceptingConnections = 1;
  do 
  {
	if (auditON) auditFile = fopen("audit.log", "a");
	if (debugON) debugFile = fopen("debug.log", "a");
        /*
        ** The listen call sets the number of pending connections
        ** and changes the socket state to LISTEN - indicating a
        ** willingness to accept new connections.
        */
	if( listen( s,3 )==-1 ){
  	    time(&currentDateTime);
	    fprintf(auditFile,"%s\n",ctime(&currentDateTime));
	    fprintf(auditFile, ": FATAL Error - on LISTEN\n");
  	   perror("listen");
	   exit(1);
	}

	addrlen = sizeof( addr );
	if (debugON) {
	    fprintf(debugFile, "=================================\n");
	    fprintf(debugFile, "BEFORE Accept\n");
	}
	newSocket = accept( s, (struct sockaddr *) &addr, &addrlen );

	if (debugON) {
	    fprintf(debugFile, "AFTER  Accept:s/sock=%d/%d\n",s,newSocket);
	}
	if ( newSocket == -1 ) {
  	    time(&currentDateTime);
	    fprintf(auditFile,"%s\n",ctime(&currentDateTime));
	    fprintf(auditFile, ": FATAL Error - on ACCEPT\n");
	    perror("accept");
	    exit(1);
	}

        if (auditON)  {
  	    time(&currentDateTime);
	    fprintf(auditFile,"%s\n",ctime(&currentDateTime));
	    fprintf(auditFile, 
	    		": Connection accepted from IP address:%s port:%d\n",
	    		inet_ntoa(addr.sin_addr),addr.sin_port);
	}
        if (debugON)  {
  	    time(&currentDateTime);
	    fprintf(debugFile,"%s\n",ctime(&currentDateTime));
	    fprintf(debugFile, 
	    		": Connection accepted from IP address:%s port:%d\n",
	    		inet_ntoa(addr.sin_addr),addr.sin_port);
	}

        /*
        ** Server Main Loop:
	** Program will read the message from the client. 
	**
	** If the "RMA SHUTDOWN" signal is received the program breaks out 
	** of loop and terminates processing. It must be manually started
	** again before any more client requests will be processed.
	**
	** If the message is (NOT "shutdown" the program) AND (the forking
	** option is turned OFF), then the loop is continued indefinitely
	** until the client "disconnects" sending a Return Code of 0. This
	** non-forking option is used only when debuging the code and all
	** requests must be handled by a single process.
	**
	** On the other hand, if the forking option is turned ON, then the
	** process forks and:
	**	- the CHILD Process loops indefinitely in the 'for' loop
	**	  processing requests until a disconnect is received, It
	**	  then terminates the process after having fulfilled the
	**	  client requests.
	**      - the PARENT Process falls out of the 'for' loop and returns
	**	  to the 'keepAcceptingConnections' loop so that the next client
	**	  request can be quickly accepted and processed. 
        */
	for(;;) {
	    retcode=recv( newSocket, &socketBuffer, MAX_SOCKET_BUFFER_SIZE, 0 );
	    if ( retcode < 0) {
                if (auditON)  {
  	    	    time(&currentDateTime);
		    fprintf(auditFile,"%s\n",ctime(&currentDateTime));
                    fprintf(auditFile, ": RECEIVE Error - Return Code= %s, Performing Shutdown\n",retcode);
		}
                close(newSocket);
                newSocket=NULL;
		perror("recv");
		perror("retcode");
		exit(1);
	    }
	    else if ( retcode ==0 )  {  /* EOF */
                    if (debugON)  {
    			time(&currentDateTime);
                        fprintf(debugFile, 
			    "Return Code=0 - Client Requested DISCONNECT at:%s\n",
					ctime(&currentDateTime));
		    }
                    close(newSocket);
                    newSocket=NULL;
		    break;
	    } /* retcode < 0 ? */

	    if ( strlen(socketBuffer) > 0 ) {
		requestLen = strlen(socketBuffer);
		/* blank part of buffer not included in current receive 
		for (ss=0; ss<2056; ss++)  {
		  socketBuffer[ss] = " ";
		} */
		requestsFiles = fopen("requests.log", "a");
		fprintf(requestsFiles,"%s\n", socketBuffer);
		fclose(requestsFiles);

                if (debugON)  {
                        fprintf(debugFile,"RECEIVED=%s\n", socketBuffer);
 		}
                if (!strncmp(shutdownString,socketBuffer,21)) {
                    if (auditON) {
  	    	        time(&currentDateTime);
			fprintf(auditFile,"%s\n",ctime(&currentDateTime));
 			fprintf(auditFile,": RMA Operater requested SHUTDOWN!\n");
		    }
                    close(newSocket);
                    newSocket=NULL;
                    keepAcceptingConnections = 1;
                    break;
                } else if (runWithForkON) {
		         /* fork to create process to handle the request)*/
			if (auditON) fclose(auditFile);
			if (debugON) fclose(debugFile);
			pid = fork();
			if (auditON) auditFile = fopen("audit.log", "a");
			if (debugON) debugFile = fopen("debug.log", "a");

			if ( pid < 0 ) { 
			    if (auditON)  {
  	    	        	time(&currentDateTime);
				fprintf(auditFile,"%s\n",ctime(&currentDateTime));
				fprintf(auditFile, ": FATAL Error - Can't fork\n");
			    }
			    exit(1);
			}
		        /* if not running Child(ie. Parent) loop to get next connection)*/
		        if ( !pid == 0 ) {
			    if (debugON)  { 
  	    	        	time(&currentDateTime);
			        fprintf(debugFile, "PARENT - breaking...%s\n",
						ctime(&currentDateTime));
			    }
                    	    close(newSocket);
                    	    newSocket=NULL;
                   	    keepAcceptingConnections = 1;
                    	    break;
		        } else {
			    if (debugON)  {
  	    	        	time(&currentDateTime);
			        fprintf(debugFile, "Running CHILD...%s\n",
						ctime(&currentDateTime));
			    }	
                   	    keepAcceptingConnections = 0;
		        } /* child or parent process ? /*
		    } else {
		        if (debugON)  {
  	    	       	    time(&currentDateTime);
			    fprintf(debugFile, "forking NOT activated ...%s\n",m
						ctime(&currentDateTime));
		        }
		    } /* forking option ON ? */
		    if (debugON)  {
		        fprintf(debugFile, "after Forking ON test\n");
		    }
                } /* shutdown request? */
		if (debugON)  {
		    fprintf(debugFile, "after shutdown request test\n");
		}

		/* process client's request */
	        if (CobolStatus = cpirma5()) {	/* Call COBOL to initialize */
                    if (auditON)  {
  	    	       	time(&currentDateTime);
			fprintf(auditFile,"%s\n",ctime(&currentDateTime));
			fprintf(auditFile,": 'cpirma5' Fatal Error: %s - shutting down CPI\n",CobolStatus);
		    }
                    close(newSocket);
                    newSocket=NULL;
		    cobexit(CobolStatus);
   		}
	        requestLength= strlen(socketBuffer);
/*
	        if (CobolStatus = validate(&requestLength, socketBuffer)) {
		    if (auditON)  {
  	    	       	time(&currentDateTime);
			fprintf(auditFile,"%s\n",ctime(&currentDateTime));
			fprintf(auditFile,": 'validate' Fatal Error: %s - shutting down CPI\n",CobolStatus);
		    }
                    close(newSocket);
                    newSocket=NULL;
		    cobexit(CobolStatus);
		}
*/

	        bufferCount = 0;
	        do	
	        {   bufferCount = 1;
	    	    if (CobolStatus =	lookup(socketBuffer,
						patientRecsBuffer)) {
                        if (auditON)  {
  	    	       	    time(&currentDateTime);
			    fprintf(auditFile,"%s\n",ctime(&currentDateTime));
			    fprintf(auditFile,": 'lookup' Fatal Error: %s - shutting down CPI\n",CobolStatus);
			}
                        close(newSocket);
                        newSocket=NULL;
	    		cobexit(CobolStatus);
		    }

                    if (debugON > 1 )  {
			fprintf(debugFile,"RETURNED BUFFER=\n%s~\n", patientRecsBuffer);
		    }
                    /* if ( send(newSocket, &patientRecsBuffer,MAX_PATIENT_RECORD_SIZE,0 )<0 ){*/

/*		    if ( send(newSocket, &patientRecsBuffer, 3430, 0 )<0 ) {*/
		    if ( send(newSocket, &patientRecsBuffer, 3798, 0 )<0 ) {
                        if (auditON)  {
  	    	       	    time(&currentDateTime);
			    fprintf(auditFile,"%s\n",ctime(&currentDateTime));
			    fprintf(auditFile,": 'send' Fatal Error\n");
			}
                        close(newSocket);
                        newSocket=NULL;
			perror("send");
			exit(1);
		    }
		    if (debugON)  {
		        fprintf(debugFile, "before END TEST while buffercount\n");
		    }
	        } while (bufferCount == 0);
		if (debugON)  {
		    fprintf(debugFile, "before END TEST socket buff length\n");
		}
	    } /* if socket buffer len > 0 */
	    if (debugON)  {
	       fprintf(debugFile, "before END TEST for;;;\n");
	    }
	} /* for (;;;) */
	if (auditON) fclose(auditFile);
	if (debugON) fclose(debugFile);
	if (debugON)  {
	   fprintf(debugFile, "before END TEST keepAccepting..\n");
	}
  } while (keepAcceptingConnections == 1);
  if (debugON)  {
      fprintf(debugFile, "AFTER END TEST keepAccepting..\n");
  }

close(newSocket);
newSocket=NULL;
if (debugON)  {
    time(&currentDateTime);
    fprintf(debugFile,"%s\n",ctime(&currentDateTime));
    fprintf(debugFile,": Shutting Down CPI Program\n");
}
if (auditON) fclose(auditFile);
if (debugON) fclose(debugFile);
exit(0);
}
