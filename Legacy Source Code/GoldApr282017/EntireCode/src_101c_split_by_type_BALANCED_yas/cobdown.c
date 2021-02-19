/* Program Name: cobdown.c
 * copied from phdown.c ($PH_USR/migrate/phdown.c)
 *
 * to compile:  cc cobdown.c -o cobdown
 * cobdown is now the executable -^
 * Adstract:     This routine will downshift every character in a file
 *               to lower case. It will not downshift any characters
 *               surrounded by either double or single quotes (' or "),
 *               or any characters following a comment character (;).
 *               It will read the standard input, and write to standard
 *               output. To recompile this routine and create an output
 *               file called phdown, use the cc 'C' compiler as follows:
 *
 *                  % cc phdown.c -o phdown
 *
 *               This file should reside in a directory specified by the
 *               PATH environment variable.
 */ 

#include <stdio.h>           /* for EOF */
#include <ctype.h>           /* for tolower() */

#define DOUBLE     '"'
#define SINGLE     '\''
#define SEMICOLON  '*'
#define NEWLINE    '\n'
#define FIRSTQUOTE 0
#define LASTQUOTE  2
#define TRUE       1
#define FALSE      0

#define isquote(c) ((c== SINGLE || c == DOUBLE) ? 1 : 0)

int chk_quote();
int chk_comment();

main()
{
   int inchar, outchar;
   int inquote, endquote, incomment;

   inquote = endquote = incomment = 0;

   /* Perform this loop until End Of File is found */
   while((inchar = getchar()) != EOF) {
      outchar = inchar;
      inquote = chk_quote(inchar, inquote, incomment, &endquote);
      incomment = chk_comment(inchar, inquote, incomment);
      if (!inquote && !incomment)
         if (isupper(inchar)) 
            outchar = tolower(inchar);
      putchar(outchar);
   }
}


int chk_quote(c, inqte, incomm, endqte)
int c;
int inqte;
int incomm;
int *endqte;
{

   /* set inquote to one if a single or double quote is encountered,
    * and then to 0 when the next same quote in encountered. 
    */
   if (!incomm) { 
      if (isquote(c)) {
         if (c == *endqte || *endqte == 0) {
            *endqte = c;
            if (++inqte == LASTQUOTE) {
	       *endqte = FIRSTQUOTE;
	       inqte = FALSE;
            }
         }
      }
      if (c == NEWLINE)
         inqte = FALSE;
   }
   return(inqte);
}

int chk_comment(c, inqte, incomm)
int c;
int inqte;
int incomm;
{
   /* set incomment to one when a semicolon is encountered, and not
    * in a quote, and set it back to 0 when a subsequent newline 
    * is encountered
    */
   if (!inqte) {
      if (c == SEMICOLON) 
        incomm = TRUE;
      if (c == NEWLINE)
        incomm = FALSE;  
   }
   return(incomm);
}
