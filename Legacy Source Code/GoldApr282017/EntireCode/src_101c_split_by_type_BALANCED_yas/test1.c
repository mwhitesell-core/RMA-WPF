#include <stdio.h>
#include <errno.h>
#include <netdb.h>
#include <sys/socket.h>
#include <netinet/in.h>

int sock_desc; /* Socket descriptor */
int retcode; /* Return code from connect system call */

char *dest_name; /* Pointer to remote hostname */
struct sockaddr_in name; /* Socket name for peer */
struct hostent *dest_addr; /* Address for destination host*/
struct servent *service; /* Port number for server */
struct sockaddr_in to_addr; /* Socket name for destination peer */

/* Open a socket */
sock_desc = socket(AF_INET,SOCK_STREAM,0);
if( -1 == sock_desc )
{
fprintf(stderr,"Cannot open socket, errno %d\n", errno);
exit(1);
}

/* Get port number for the service we want from destination */
service = getservbyname("myservice", "tcp");
if ( NULL == service )
{
fprintf(stderr, "Cannot get port number from getservbyname\n");
exit(1);
}
/* Get the internet address for the destination host */
dest_addr = gethostbyname(dest_name);
if ( NULL == dest_addr )
{
fprintf(stderr, "Cannot get destination address %s \n",
dest_name);
}
/* Set up the sockaddr structure with info about peer */
to_addr.sin_family = dest_addr->h_addrtype;
to_addr.sin_addr.s_addr = *( (int *) dest_addr->h_addr ) ;
to_addr.sin_port = service->s_port;
/* Try to connect to server */
retcode = connect(sock_desc, &to_addr, sizeof(to_addr));
