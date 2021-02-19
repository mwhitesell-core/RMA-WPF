/*
 * @(#)cmain.c	1.4

      ****************************************************************
      * Copyright Micro Focus Limited 1989-94. All Rights Reserved.  *
      * This demonstration program is provided for use by users of   *
      * Micro Focus products and may be used, modified and           *
      * distributed as part of your application provided that you    *
      * properly acknowledge the copyright of Micro Focus in this    *
      * material.                                                    *
      ****************************************************************

 *
 * demo of interface from C to Cobol.
 *
 *To statically link and run this demo use:
 *	cob -x cmain.c account.cbl
 *	./cmain
 *To link C program to the Cobol libraries and run the demo use:
 *	cob -io crts cmain.c account.cbl -d account -d tally
 *		-d showaccount -d validate
 *	./crts cmain
 *To allow animation of the dynamic loaded Cobol modules use:
 *	cob -ao crts cmain.c account.cbl -d account -d tally
 *		-d showaccount -d validate
 * (- note "cob -a" is the default so the command could be	)
 * (	cob -o crts cmain.c account.cbl -d account -d tally	)
 * (		-d showaccount -d validate			)
 *	COBSW=+A
 *      export COBSW
 *	./crts cmain
 *To sdb C program use:
 *	cob -gx cmain.c account.cbl
 *	sdb cmain
 *To sdb C program and animate Cobol use:
 *	cob -go crts cmain.c account.cbl -d account -d tally
 *		-d showaccount -d validate
 * 	COBSW=+A
 *      export COBSW
 *	./crts cmain
 */
#include <stdio.h>

#define BUFFSZ		80			/* temp buffer size */

extern int account();		/* Cobol program - initialization */
extern int validate();		/* Cobol program - takes account name */
extern int tally();		/* Cobol program - increments total *
extern int showaccount();	/* Cobol program - controls displays */
extern void cobexit();		/* close down Cobol system and exit */
extern int cobprintf();		/* COBOL display from C	*/
extern int cobgetch();		/* COBOL character get */

main()
{
    int status;
    long num;
    char buf[BUFFSZ];
    int strlen();

#ifdef _AIX
    cobinit();
#endif

    if (status = account())		/* Call COBOL to initialize */
	cobexit(status);

    cobprintf("account: ");			/* select account code */
    get_string(buf);

    num = strlen(buf);
    if (status = validate(&num, buf))
	cobexit(status);

    do
    {   cobprintf("cost [0 to end]: ");
	get_string(buf);
    	num = atoi(buf);	/* tally items */
	if (status = tally(&num))
	    cobexit(status);
    } while (num != 0);

    showaccount();				/* display total */

    cobexit(status);
}

get_string(buffer)
char buffer[];
{
	int i=0;
	
	while (((buffer[i] = cobgetch()) != '\n') && i < BUFFSZ)
	    cobprintf("%c",buffer[i++]);
	cobprintf("\n");
	buffer[i] = 0;
}
