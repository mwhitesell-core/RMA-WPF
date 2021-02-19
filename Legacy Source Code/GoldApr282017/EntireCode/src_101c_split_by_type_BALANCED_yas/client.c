#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>
#include <netdb.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>

#define DEFAULT_PORT 12345

main( argc, argv)
int argc;
char * argv[];
{
int s, bufferlen, byteswritten, bytesread, retcode;
char buffer[256];
struct sockaddr_in addr;
struct hostent * hp;
struct servent * sp;

/*
**if( argc !=2 ){
**	fprintf( stderr, "Usage:\t %s host\n", argv[0]);
**	exit (1);
**}
*/

memset( &addr, 0, sizeof(addr));

/*
** Users may specify hosts in 2 different formats:
** hostnames or IP addresses (aka dotted quads).
** First try looking up the host as a hostname, and
** if that fails try as an IP address.
*/

hp = gethostbyname( "rma" );

if (hp !=NULL ){
	addr.sin_family = hp->h_addrtype ;
	addr.sin_addr.s_addr = *((int *) hp ->h_addr);
} else {
	addr.sin_family = AF_INET;
	addr.sin_addr.s_addr = inet_addr( "rma" );
	if (addr.sin_addr.s_addr == -1) {
		fprintf(stderr,"Can't lookup host %s\n","rma");
		exit(1);
	}
}

/*
** Applications should get the service number
** from the services file. Try the services file first,
** and upon failure, use a default port number. This allows
** the example to run without modifying the
** system environment.
*/

sp = getservbyname( "webstar", "tcp" );

if( sp != NULL ) {
	addr.sin_port = sp->s_port;
} else {
	addr.sin_port = htons(DEFAULT_PORT);
}

/*
** Create a socket.
*/
s = socket( AF_INET, SOCK_STREAM, 0 );

if(s ==-1 ){
	perror("socket");
	exit(1);
}

/*
** Connect to the server.
*/
retcode = connect( s, (struct sockaddr *) &addr, sizeof(addr));
if( retcode == -1 ) {
	perror("connect");
	exit(1);
}

printf("Connected to Server, type EOF character to terminate\n");

/* Client Loop -
** Read a line from standard input and send it to the server.
** Read an equivalent number of characters from the server and
** write them to stdout. There are two important things you
** should notice:
** 1) The send() may not process the entire buffer so you must
** be ready to deal with a short write. (This is uncommon
** unless using non-blocking I/O; however, applications
** should always check the return code.)
** 2) TCP doesn't obey record boundaries, so the program
** cannot expect to recv() data with the same boundaries
** with which it was written.
*/

while(!feof(stdin) && !ferror(stdin) && !ferror(stdout)) {
	if( fgets(buffer, sizeof(buffer), stdin) == NULL ){
		continue;
	}
	bufferlen = strlen(buffer);
	byteswritten = 0;
	while ( byteswritten < bufferlen) {
		retcode = send(s, &buffer[byteswritten],
		bufferlen-byteswritten, 0);
		if ( retcode <0 ){
			perror("send");
			exit(1);
		}
		byteswritten += retcode;
	}
	bytesread = 0;
	while( bytesread < byteswritten ) {
		retcode = recv( s, &buffer[bytesread],
		byteswritten-bytesread, 0);
		if ( retcode <0 ){
			perror("recv");
			exit(1);
		}
		bytesread += retcode;
	}
	buffer[bytesread] = 0;
	fputs(buffer, stdout);
}
exit(0);
}

