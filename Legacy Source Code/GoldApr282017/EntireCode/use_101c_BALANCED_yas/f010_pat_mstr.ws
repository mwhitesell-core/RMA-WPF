not used ????

01  WK-PAT-MSTR-REC.

    05  WK-PAT-ACRONYM.
	10  WK-PAT-ACRONYM-FIRST6	PIC X(6).
	10  WK-PAT-ACRONYM-LAST3	PIC XXX.

    05  WK-PAT-OHIP-MMYY.
	10  WK-PAT-OHIP-NBR		PIC 9(8).
	10  WK-PAT-MM			PIC 99.
	10  WK-PAT-YY			PIC 99.
	10  FILLER			PIC XXX.
    05  WK-PAT-OHIP-MMYY-R REDEFINES WK-PAT-OHIP-MMYY.
	10  WK-PAT-OHIP-NBR-ALPHA.
	    15  WK-PAT-OHIP-NBR1-ALPHA	PIC X.
	    15  WK-PAT-OHIP-NBR2-3-ALPHA PIC XX.
	10  WK-PAT-OHIP-LAST-12		PIC X(12).

    05  WK-PAT-CHART-NBR.
	10  WK-PAT-CHART-LTRS-ALL.
	    15  WK-PAT-CHART-LTRS	PIC X.
	    15  WK-PAT-CHART-ALPHA	PIC XX.
	10  WK-PAT-CHART-NBRS		PIC 9(12).
    05  WK-PAT-CHART-NBR-R REDEFINES WK-PAT-CHART-NBR.
	10  FILLER			PIC X.
	10  WK-PAT-CHART-YY		PIC XX.
	10  WK-PAT-CHART-MM		PIC XX.
	10  FILLER			PIC X(10).

    05  WK-PAT-SURNAME			PIC X(15).
    05  WK-PAT-SURNAME-R  REDEFINES  WK-PAT-SURNAME.
	10  WK-PAT-SURNAME-FIRST6	PIC X(6).
	10  WK-PAT-SURNAME-LAST9	PIC X(9).

    05  WK-PAT-GIVEN-NAME		PIC X(12).
    05  WK-PAT-GIVEN-NAME-R  REDEFINES  WK-PAT-GIVEN-NAME.
	10  WK-PAT-GIVEN-NAME-FIRST3	PIC XXX.
	10  WK-PAT-GIVEN-NAME-LAST9	PIC X(9).
    05  WK-PAT-GIVEN-NAME-RR REDEFINES WK-PAT-GIVEN-NAME-R.
	10  WK-PAT-GIVEN-NAME-FIRST1	PIC X.
	10  FILLER			PIC X(11).

    05  WK-PAT-INIT.
	10  WK-PAT-INIT1		PIC X.
	10  WK-PAT-INIT2		PIC X.
	10  WK-PAT-INIT3		PIC X.
    05  WK-PAT-LOCATION-FIELD.
	10  WK-PAT-LOCATION-FIELD-1-3	PIC X(3).
	10  FILLER			PIC X(1).
    05  WK-PAT-LAST-DOC-NBR-SEEN	PIC 9(6).

    05  WK-PAT-BIRTH-DATE		PIC X(6).
    05  WK-PAT-BIRTH-DATE-R  REDEFINES  WK-PAT-BIRTH-DATE.
	10  WK-PAT-BIRTH-DATE-YY	PIC 99.
	10  WK-PAT-BIRTH-DATE-MM	PIC 99.
	10  WK-PAT-BIRTH-DATE-DD	PIC 99.

    05  WK-PAT-DATE-LAST-MAINT          PIC 9(6).
    05  WK-PAT-DATE-LAST-MAINT-R REDEFINES WK-PAT-DATE-LAST-MAINT.
	10  WK-PAT-DATE-LAST-MAINT-YY	PIC 99.
	10  WK-PAT-DATE-LAST-MAINT-MM	PIC 99.
	10  WK-PAT-DATE-LAST-MAINT-DD	PIC 99.

    05  WK-PAT-DATE-LAST-VISIT 		PIC 9(6).
    05  WK-PAT-DATE-LAST-VISIT-R REDEFINES WK-PAT-DATE-LAST-VISIT.
	10  WK-PAT-DATE-LAST-VISIT-YY	PIC 99.
	10  WK-PAT-DATE-LAST-VISIT-MM	PIC 99.
	10  WK-PAT-DATE-LAST-VISIT-DD	PIC 99.    

    05  WK-PAT-DATE-LAST-ADMIT 		PIC 9(6).
    05  WK-PAT-DATE-LAST-ADMIT-R REDEFINES WK-PAT-DATE-LAST-ADMIT.
	10  WK-PAT-DATE-LAST-ADMIT-YY	PIC 99.
	10  WK-PAT-DATE-LAST-ADMIT-MM	PIC 99.              
	10  WK-PAT-DATE-LAST-ADMIT-DD	PIC 99.    

    05  WK-PAT-PHONE-NBR.
	10  WK-PAT-PHONE-NBR-FIRST3	PIC 999.
	10  WK-PAT-PHONE-NBR-LAST4	PIC 9(4).
    05  WK-PAT-TOTAL-NBR-VISIWK		PIC 9(5).
    05  WK-PAT-TOTAL-NBR-CLAIMS		PIC 9(5).
    05  WK-PAT-SEX			PIC X.
    05  WK-PAT-RELATIONSHIP		PIC 9.
    05  WK-PAT-IN-OUT			PIC X. 
    05  WK-PAT-NBR-OUWKTANDING-CLAIMS	PIC 9(4).

