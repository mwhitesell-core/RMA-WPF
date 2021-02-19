01  key-dictionary-mstr. 
*	 key type: 'a' = pgm name - variable (data) 
*		   'b' = variable (data) - pgm name 
    05  key-dict-type				pic x. 
    05  key-dict-pgm-name-data. 
	10  key-dict-pgm-name			pic x(5). 
	10  key-dict-pgm-data			pic x(40). 
    05  key-dict-pgm-name-data-r redefines key-dict-pgm-name-data. 
	10  key-dict-pgm-data-r			pic x(40). 
	10  key-dict-pgm-name-r			pic x(5). 
 
01  key-dictionary-b-mstr. 
*	key type: 'b' = variable (data) - pgm name 
    05  key-dict-b-type				pic x. 
    05  key-dict-b-pgm-data-name. 
	10  key-dict-b-pgm-data			pic x(40). 
	10  key-dict-b-pgm-name			pic x(5). 
 
