#include <stdio.h>
#include <arpa/pftp.h>
check(code)
int code;
{
char errstring[200];
int errstrlen;
/* Report all errors
*/
if (code == FTP_NO_ERROR) return;
printf("\nFTP FAILURE, error code: %d\n",code);
ftperror(&code, errstring, &errstrlen);
errstring[errstrlen] = '\000';
printf("** %s **\n",errstring);
exit(1);
}
main(argc,argv)
int argc;
char **argv;
{
char username[FTP_USERNAME_LEN];
char password[FTP_PASSWORD_LEN];
char hostname[FTP_HOSTNAME_LEN];
char loc_pathname[FTP_LOC_PATH_LEN];
char rem_pathname[FTP_REM_PATH_LEN];
int code;
char new_pathname[FTP_LOC_PATH_LEN];
char dir_pathname[FTP_LOC_PATH_LEN];
char buff[2048];
int buf_size;
char *ptr;
/* */
/* Prompt the user to enter the name and */
/* password for the remote host, the name of the remote host, */
/* and the name of the file to be transferred. Store this */
/* information in username, password, hostname, and */
/* rem_pathname. */
/* */
printf("remote username? ");
fflush(stdout);
gets(username);
printf("remote password? ");
fflush(stdout);
gets(password);
printf("remote hostname? ");
fflush(stdout);
gets(hostname);
printf("remote file/pathname? ");
fflush(stdout);
gets(rem_pathname);
/* */
/* Get the file (FTP_GET_OP) that the user specified */
/* in rem_pathname and put it into /usr/first_file on the */
/* local host. */
/* */
strcpy(loc_pathname,"/usr/first_file");
printf("\n*** Transfer the file (get) ***\n");
code = FTP_DEBUG | FTP_GET_OP | FTP_STREAM_MODE |
FTP_FILE_STRUCT | FTP_ASCII_NONPRINT_TYPE;
ftp_xfer(username, password, hostname, loc_pathname,
rem_pathname, &code);
check(code);
/* */
/* Put (FTP_PUT_OP) /usr/first_file into /tmp/first_file */
/* on the remote host. */
/* */
strcpy(loc_pathname,"/usr/first_file");
strcpy(rem_pathname,"/tmp/first_file");
printf("\n*** Transfer the file (put) ***\n");
code = FTP_DEBUG | FTP_PUT_OP | FTP_STREAM_MODE |
FTP_FILE_STRUCT | FTP_ASCII_NONPRINT_TYPE | FTP_OVERWRITE;
ftp_xfer(username, password, hostname, loc_pathname,
rem_pathname, &code);
strcpy(loc_pathname,"/usr/first_file");
unlink(loc_pathname);
check(code);
/* */
/* Rename /tmp/first_file to /tmp/second_file on the */
/* remote host. */
/* */
strcpy(rem_pathname,"/tmp/first_file");
strcpy(new_pathname,"/tmp/second_file");
printf("\n*** Rename the file ***\n");
code = FTP_DEBUG;
ftp_rename(username, password, hostname, rem_pathname,
new_pathname, &code);
check(code);
/* */
/* Create the directory /tmp/first_file on the remote */
/* host. */
/* */
printf("\n*** Mkdir the path ***\n");
code = FTP_DEBUG;
ftp_mkdir(username, password, hostname, rem_pathname, &code);
check(code);
/* */
/* List the contents of the /tmp directory on the remote */
/* host. */
/* */
strcpy(dir_pathname,"/tmp");
buf_size = sizeof(buff);
printf("\n*** Dir the path ***\n");
code = FTP_DEBUG;
ftp_dir(username, password, hostname, dir_pathname, buff,
&buf_size, &code);
check(code);
buff[buf_size] = '\000';
printf("\n%s", buff);
/* */
/* Delete /tmp/second_file on the remote host. */
/* */
strcpy(rem_pathname,"/tmp/second_file");
printf("\n*** Delete the file ***\n");
code = FTP_DEBUG;
ftp_del(username, password, hostname, rem_pathname, &code);
check(code);
/* */
/* Remove the /tmp/first_file directory on the remote */
/* host. */
/* */
strcpy(rem_pathname,"/tmp/first_file");
printf("\n*** Rmdir the path ***\n");
code = FTP_DEBUG;
ftp_rmdir(username, password, hostname, rem_pathname, &code);
check(code);
}
