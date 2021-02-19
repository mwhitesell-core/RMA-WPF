#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <netdb.h>
#include <errno.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#define DEFAULT_PORT 12345

main( argc, argv )
	int argc;
	char *argv[];
{
char c;
int s, ns, retcode, addrlen;
struct sockaddr_in addr;
struct servent *sp;

/*
** Create a new socket.
*/
s = socket( AF_INET, SOCK_STREAM, 0 );
if( s == -1 ){
	fprintf( stderr, "Server can't create socket\n");
	exit(1);
}
/*
** Applications should get the service number from the
** services file. Try the services file first, and upon
** failure use a default port number. This allows the
** example to run without modifying the system environment.
*/
memset(&addr, 0, sizeof(addr));
sp = getservbyname( "example", "tcp" );
if( sp != NULL ) {
	addr.sin_port = sp->s_port;
} else {
	addr.sin_port = htons(DEFAULT_PORT);
}

/*
** Binding assigns the local port number to the socket.
** Clients will try to connect to this port to start a session.
** The address INADDR_ANY means the server is willing to accept
** connection requests arriving at any local interface.
*/
addr.sin_family = AF_INET;
addr.sin_addr.s_addr = INADDR_ANY;

if( bind( s, (struct sockaddr *) &addr, sizeof(addr) ) == -1
){
	perror("bind");
	exit(1);
}

/*
** The listen call sets the number of pending connections
** and changes the socket state to LISTEN - indicating a
** willingness to accept new connections.
*/
if( listen( s,3 ) == -1 ){
	perror("listen");
	exit(1);
}
/*
** The accept call blocks waiting for a new connection.
** After the connection is established, accept returns a
** new socket and the peer address. Typically, servers
** fork() to create a new process to handle the connection
** while the main process goes back into accept waiting for
** more connections. Since this is a simple server, it will
** only process the one request then exit.
*/
addrlen = sizeof( addr );
ns = accept( s, (struct sockaddr *) &addr, &addrlen );
if( ns == -1 ) {
perror("accept");
exit(1);
}
/*
** inet_ntoa() creates a printable IP address from
** a struct in_addr.
*/
fprintf(stdout,
"Connection accepted from IP address%s port %d\n",
inet_ntoa(addr.sin_addr),addr.sin_port);
/*
** Server Main Loop - read characters, uppercase, and
** write back. Unlike the client, the server reads/writes
** 1 byte at a time. Typically applications will want to
** use large buffers, but this demonstrates that TCP does
** not care about record boundaries.
*/
for(;;) {
retcode = recv( ns, &c, 1, 0 );
if ( retcode < 0) {
perror("recv");
exit(1);
}
else if ( retcode ==0 ){ /*EOF*/
break;
}
if ( 'a' <=c &&c <='z' ){
c +='A' - 'a';
}
if ( send( ns, &c, 1,0 )<0 ){
perror("send");
exit(1);
}
}
exit(0);
}

