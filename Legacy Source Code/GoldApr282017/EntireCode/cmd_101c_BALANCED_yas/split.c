#include <stdio.h>
main (argc, argv)
int	argc;
char	**argv;
{

FILE	*infile;
char	infile_name[80];
int	record_length;

/* Test for arguements */
if (argc < 1)
{
	printf ("usage: split filename [record length default 80]\n") ;
	return (1);
}

/* Assign the infile_name to the first arguement */
strcpy(infile_name, argv[1]);

/* If the record length is not given, default to 80. */
if (argc < 2)
	record_length = 80;
else
	record_length = to_num(argv[2]);

printf ("Working on file: %s ...\n\n", infile_name) ;

}
