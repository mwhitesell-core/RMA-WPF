01  constants-mstr-rec-3. 
* 
*	the percentage code for rma misc code 0 is stored on the 
*	doctor record; misc codes 1 to 9 are stored on this 
*	constants master record                                
* 
*  dec 21/90 (b.m.l.) - increase all decimal places by 2 to allow for 
*                       the g.s.t. 
* 
    05  const-rec-3-rec-nbr				pic 99. 
    05  const-percentages-misc-curr. 
	10  const-misc-curr occurs 9 times		pic 9v9999. 
    05  const-percentages-misc-curr-r redefines const-percentages-misc-curr. 
	10  const-misc-1-curr				pic 9v9999. 
   	10  const-misc-2-curr				pic 9v9999. 
   	10  const-misc-3-curr				pic 9v9999. 
   	10  const-misc-4-curr				pic 9v9999. 
   	10  const-misc-5-curr				pic 9v9999. 
   	10  const-misc-6-curr				pic 9v9999. 
   	10  const-misc-7-curr				pic 9v9999. 
   	10  const-misc-8-curr				pic 9v9999. 
   	10  const-misc-9-curr				pic 9v9999. 
    05  const-percentages-misc-prev. 
	10  const-misc-prev occurs 9 times		pic 9v9999. 
    05  const-percentages-misc-prev-r redefines const-percentages-misc-prev. 
	10  const-misc-1-prev				pic 9v9999. 
   	10  const-misc-2-prev				pic 9v9999. 
   	10  const-misc-3-prev				pic 9v9999. 
   	10  const-misc-4-prev				pic 9v9999. 
   	10  const-misc-5-prev				pic 9v9999. 
   	10  const-misc-6-prev				pic 9v9999. 
   	10  const-misc-7-prev				pic 9v9999. 
   	10  const-misc-8-prev				pic 9v9999. 
   	10  const-misc-9-prev				pic 9v9999. 
    05  filler						pic x(292). 
 
