/* ---------------------------------------------------------------------
 * /T/ u010_outfile.c
 *
 * /A/ SY
 *
 * /P/ Dyad Systems Inc.
 *
 * /Q/ C
 *
 * /M/ Modification History
 * /M/ --------------------
 * /M/ Date     Programmer      Description
 * /M/ 980313   Kevin Miles     Creation.  
 * ---------------------------------------------------------------------
 * /D/                       TRADE SECRET NOTICE
 * /D/
 * /D/  The techniques, algorithms, and processes contained herein, or
 * /D/  any modification, extraction, or extrapolation thereof, are the
 * /D/  proprietary property and trade secrets of Dyad Systems Inc.
 * /D/  and except as provided for by a License Agreement, shall not be
 * /D/  duplicated, used, or disclosed for any purpose, in whole or part
 * /D/  without the express written permission of Dyad Systems Inc.
 * ---------------------------------------------------------------------
 */

#include <stdio.h>
main(argc, argv)
int argc ;
char **argv ;
{
	FILE * stdin_file ;
	char stdin_file_name[80] ;
	char line_buffer[10] ;

	if (argc != 2)
	{
		printf ("usage: %s filename\n", argv[0]) ;
		return (1);
	}
	strcpy(stdin_file_name, argv[1]) ;
	if ((stdin_file = fopen(stdin_file_name, "r")) == NULL)
	{
		printf ("File %s does not exist!^G", stdin_file_name) ;
		return (2) ;
	}

	/* Loop while retrieving line by line */
	while (fgets (line_buffer, 10, stdin_file))     {
		printf ("%s\n", line_buffer) ;
	}
}
