  03  WS-TBL-BRIEF-CLAIMS REDEFINES WS-TBL-VALUES.
    05  WS-TOTAL-NBR-BRIEF-CLAIMS OCCURS 10 TIMES.
	10  WS-TBL-AGENT  		PIC 9.
	10  WS-TBL-CLAIM-BATCH-NBR.
	    15  WS-TBL-CLAIM-CLINIC	PIC 99.
	    15  WS-TBL-CLAIM-DOC-NBR	PIC 999.
	    15  WS-TBL-CLAIM-BATCH	PIC 999.
	10  WS-TBL-CLAIM-CLAIM-NBR	PIC 99.
	10  WS-TBL-RE-CAP.
	    15  WS-TBL-RE-CAP-MM	PIC 99.
	    15  WS-TBL-RE-CAP-DD	PIC 99.
	10  WS-TBL-PED			PIC 9(6).
	10  WS-TBL-DOC-NAME		PIC X(17).
	10  WS-TBL-PAYMENTS		PIC S9(5)V99.
	10  WS-TBL-ORIG-AMT		PIC S9(5)V99.
	10  WS-TBL-BAL-DUE		PIC S9(5)V99.
	10  WS-TBL-DTL1-SVC-DATE	PIC 9(6).
	10  WS-TBL-DTL1-OMA-CD		PIC X(4).
	10  WS-TBL-DTL1-OMA-SUFF	PIC X.
	10  WS-TBL-DTLS-2-6 OCCURS 5 TIMES.
	    15  WS-TBL-DTL-DD		PIC 99.
	    15  WS-TBL-DTL-OMA-CD	PIC X(4).
	    15  WS-TBL-DTL-OMA-SUFF	PIC X.
	10  WS-TBL-DTL-STAR		PIC X.
*   05  FILLER				PIC X(326).
    05  FILLER				PIC X(32).
