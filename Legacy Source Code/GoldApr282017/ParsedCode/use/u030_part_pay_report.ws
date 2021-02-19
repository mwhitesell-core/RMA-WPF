
01  PART-HEAD-1.

    05  FILLER				PIC X(6) VALUE "RU030B".
    05  FILLER				PIC X VALUE "/".
    05  PART-H1-CLINIC			PIC X(30).
    05  FILLER				PIC X(29) VALUE 
		"OHIP PARTIAL PAYMENTS  AS AT".
    05  PART-H1-YY			PIC 99.
    05  FILLER				PIC X	VALUE "/".
    05  PART-H1-MM			PIC 99.
    05  FILLER				PIC X	VALUE "/".
    05  PART-H1-DD			PIC 99.
    05  FILLER				PIC X(48) VALUE SPACES.
    05  FILLER				PIC X(5)  VALUE "PAGE".
    05  PART-H1-PAGE			PIC Z,ZZZ.

01  PART-HEAD-2.
    05  FILLER				PIC X(30) VALUE SPACES.
    05  PART-H2-CLINIC			PIC X(50).
    05  FILLER				PIC X(52) VALUE SPACES.

01  PART-HEAD-3.
    05  FILLER				PIC X(16) VALUE "  CLAIM".
    05  FILLER				PIC X(13) VALUE "PATIENT".
    05  FILLER				PIC X(10) VALUE "PATIENT".
    05  FILLER				PIC X(6)  VALUE "DOC".
    05  FILLER				PIC X(9)  VALUE "LOC".
    05  FILLER				PIC X(11) VALUE "CLAIM".
    05  FILLER				PIC X(11) VALUE "AMOUNT".
    05  FILLER				PIC X(12) VALUE "BALANCE".
    05  FILLER				PIC X(11) VALUE "REASON".
    05  FILLER				PIC X(35) VALUE "ADJUST".

01  PART-HEAD-4.
    05  FILLER				PIC X(18) VALUE "  NUMBER".
    05  FILLER				PIC X(13) VALUE "ID".
    05  FILLER				PIC X(8)  VALUE "NAME".
    05  FILLER				PIC X(6)  VALUE "NBR".
    05  FILLER				PIC X(9)  VALUE "NBR".
    05  FILLER				PIC X(12) VALUE "AMOUNT".
    05  FILLER				PIC X(11) VALUE "PAID".
    05  FILLER				PIC X(12) VALUE "OUTSTG".
    05  FILLER				PIC X(11) VALUE "CODE".
    05  FILLER				PIC X(34) VALUE "CODE".

01  PART-DETAIL.
    05  FILLER				PIC X	  VALUE SPACES.
    05  PART-CLAIM-NBR.
	10  PART-CLAIM-CLINIC-NBR-1-2	PIC XX.
	10  PART-CLAIM-DOC-NBR		PIC 999.
	10  PART-CLAIM-WEEK		PIC XX.
	10  PART-CLAIM-DAY		PIC X.
	10  PART-CLAIM-CLAIM-NBR	PIC XX.
    05  FILLER				PIC XX 	  VALUE SPACES.
    05  PART-PAT-ID			PIC X(12).
    05  FILLER				PIC XX	  VALUE SPACES.
    05  PART-PAT-NAME			PIC X(6).
    05  FILLER				PIC X	  VALUE SPACES.
    05  PART-PAT-FIRST-NAME		PIC XXX.
    05  FILLER				PIC XX	  VALUE SPACES.
    05  PART-DOC-NBR			PIC 999. 
    05  FILLER				PIC XX	  VALUE SPACES.
    05  PART-LOC-NBR			PIC XXXX.
    05  FILLER				PIC XX	  VALUE SPACES.
    05  PART-AMT-BILL			PIC ZZ,ZZZ.99-.
    05  FILLER				PIC XX	  VALUE SPACES.
    05  PART-AMT-PAID			PIC ZZ,ZZZ.99-.
    05  FILLER				PIC XX	  VALUE SPACES.
    05  PART-AMT-BALANCE		PIC ZZ,ZZZ.99-.
    05  FILLER				PIC X(6)  VALUE SPACES.
    05  PART-REASON-CODE		PIC XX.
    05  FILLER				PIC X(07) VALUE SPACES.
    05  PART-ADJUST-CODE		PIC X(05).
    05  FILLER				PIC X(28).

01  PART-TOTAL.
    05  FILLER				PIC X(15) VALUE SPACES.
    05  FILLER				PIC X(21) VALUE
		"FINAL TOTAL CLINIC - ".
    05  PART-AMT-CLINIC-NBR		PIC ZZ.        
    05  FILLER				PIC X(9) VALUE SPACES.
    05  PART-TOT-BILL			PIC Z,ZZZ,ZZZ.99-.
    05  PART-TOT-PAID			PIC ZZZZ,ZZZ.99-.
    05  PART-TOT-BALANCE		PIC ZZZZ,ZZZ.99-.
    05  FILLER				PIC X(42) VALUE SPACES.

