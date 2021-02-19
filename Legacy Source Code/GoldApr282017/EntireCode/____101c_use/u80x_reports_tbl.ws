* 
*  94/07/25	m.chan	modify clinic 22 monthend reports since the 
*			earnings subsystem has implemented 
*  95/08/17     yas     take out r123a from montend 22 cobol 
*  96/08/19     yas     add r119 to monthend 22 power 
*  97/03/14     yas     change option 10 to 82 mthend instead of 81 mohr 
 
01  reports-table. 
    05  types-table. 
	10  filler				pic x(30)	value 
		"1-OHIP SUBMITTAL CYCLE /COBOL ". 
	10  filler				pic x(70)	value 
		"R001   R001B  R002AA R002AB R004_C R010   R014   R014SM RU701         ". 
	10  filler				pic x(70)	value 
		"                                                                      ". 
	10  filler				pic x(30)	value 
		"2-OHIP SUBMITTAL CYCLE /POWER ". 
	10  filler				pic x(70)	value 
		"RU020A RU020B RU020C RU022A RU022B                                    ". 
	10  filler				pic x(70)	value 
		"                                                                      ". 
	10  filler				pic x(30)	value 
		"3-MONTH END (CLINIC 22) /COBOL". 
	10  filler       			pic x(70)	value 
		"R004   R005   R011   R012   R013   R051CA R051CB R123B  R123C  R123EF ". 
	10  filler				pic x(70)	value 
		"                                                                      ". 
	10  filler				pic x(30)	value 
		"4-MONTH END (CLINIC 22) /POWER". 
	10  filler       			pic x(70)	value 
		"R111B  R120   MOH1A  R119                                             ". 
	10  filler				pic x(70)	value 
		"                                                                      ". 
	10  filler				pic x(30)	value 
		"5-MONTH END (CLINIC 60) /COBOL". 
	10  filler       			pic x(70)	value 
		"R210   R211                                                           ". 
	10  filler       			pic x(70)	value 
		"                                                                      ". 
	10  filler				pic x(30)	value 
		"6-MONTH END (CLINIC 60) /POWER". 
	10  filler       			pic x(70)	value 
		"R004TP R005TP R006TP R011   R012TP R013TP R015TP R051CA R051CB        ". 
	10  filler       			pic x(70)	value 
		"                                                                      ". 
	10  filler				pic x(30)	value 
		"7-ACCOUNTS RECEIVABLE         ". 
	10  filler				pic x(70)	value 
 		"R070                                                                  ". 
	10  filler				pic x(70)	value 
		"                                                                      ". 
	10  filler				pic x(30)	value 
 		"8-MONTH END (CLINIC 80) /COBOL". 
	10  filler				pic x(70)	value 
 		"R004   R011   R012   R013   R051CA R051CB                             ". 
	10  filler				pic x(70)	value 
		"                                                                      ". 
	10  filler				pic x(30)	value 
 		"9-MONTH END (CLINIC 81) /COBOL". 
	10  filler				pic x(70)	value 
 		"R004   R011   R012   R013   R051CA R051CB                             ". 
	10  filler				pic x(70)	value 
                "                                                                      ". 
	10  filler				pic x(30)	value 
 		"10-MONTH END (CLINIC 82)/COBOL". 
	10  filler				pic x(70)	value 
 		"R004   R011   R012   R013   R051CA R051CB                             ". 
	10  filler				pic x(70)	value 
                "                                                                      ". 
 
    05  types-table-r-1 redefines types-table. 
	10  sel-option-1			pic x(30). 
	10  sel-reports-1a			pic x(70). 
	10  sel-reports-1b			pic x(70). 
	10  sel-option-2			pic x(30). 
	10  sel-reports-2a			pic x(70). 
	10  sel-reports-2b			pic x(70). 
	10  sel-option-3			pic x(30). 
	10  sel-reports-3a			pic x(70). 
	10  sel-reports-3b			pic x(70). 
	10  sel-option-4			pic x(30). 
	10  sel-reports-4a			pic x(70). 
	10  sel-reports-4b			pic x(70). 
 	10  sel-option-5			pic x(30). 
 	10  sel-reports-5a			pic x(70). 
 	10  sel-reports-5b			pic x(70). 
 	10  sel-option-6			pic x(30). 
 	10  sel-reports-6a			pic x(70). 
 	10  sel-reports-6b			pic x(70). 
 	10  sel-option-7			pic x(30). 
 	10  sel-reports-7a			pic x(70). 
 	10  sel-reports-7b			pic x(70). 
 	10  sel-option-8			pic x(30). 
 	10  sel-reports-8a			pic x(70). 
 	10  sel-reports-8b			pic x(70). 
 	10  sel-option-9			pic x(30). 
 	10  sel-reports-9a			pic x(70). 
 	10  sel-reports-9b			pic x(70). 
 	10  sel-option-10			pic x(30). 
 	10  sel-reports-10a			pic x(70). 
 	10  sel-reports-10b			pic x(70). 
    05  types-table-r-2 redefines types-table-r-1. 
 	10  types-lit occurs 10 times		pic x(170). 
    05  types-table-r-3 redefines types-table-r-2 occurs 10 times. 
	10  option-type               		pic x(30). 
	10  report-names. 
	    15  report-name occurs 20 times	pic x(7). 
 
