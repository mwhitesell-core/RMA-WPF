*  
*	(each position contains:  
*		- maximum nbr of days in month  
*		- non-abreviated spelling of month  
*		- nbr of julian days from jan-01 until last day of month  
*	note: table does not take into consideration leap year)  
*  
01  month-descs-and-max-days-mth.  
    05  mth-desc-max-days.  
	10  filler			pic x(14) value '31  JANUARY031'.  
	10  filler			pic x(14) value '29 FEBRUARY059'.       
	10  filler			pic x(14) value '31    MARCH090'.  
	10  filler			pic x(14) value '30    APRIL120'.  
	10  filler			pic x(14) value '31      MAY151'.  
	10  filler			pic x(14) value '30     JUNE181'.  
	10  filler			pic x(14) value '31     JULY212'.  
	10  filler			pic x(14) value '31   AUGUST243'.  
	10  filler			pic x(14) value '30SEPTEMBER273'.  
	10  filler			pic x(14) value '31  OCTOBER304'.  
	10  filler			pic x(14) value '30 NOVEMBER334'.  
	10  filler			pic x(14) value '31 DECEMBER365'.  
    05  mth-desc-max-days-r   redefines mth-desc-max-days.  
	10  mth-desc-max-days-occur	occurs  12  times.  
	    15  max-nbr-days		pic 99.  
	    15  mth-desc		pic x(9).  
	    15  nbr-julian-days-ytd	pic 9(3).  
  
