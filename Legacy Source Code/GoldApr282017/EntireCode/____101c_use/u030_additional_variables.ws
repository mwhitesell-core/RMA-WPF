77   FEEDBACK-OMA-FEE-MSTR			PIC X(4).
77   STATUS-OMA-MSTR				PIC X(4) VALUE ZERO.

01   HOLD-OMA-DATA.
     05  HOLD-FEE-OHIP				PIC S9(5)V99.
     05  HOLD-TEMP-FEE 				PIC S9(5)V99.
     05  HOLD-BASIC-TECH			PIC S9(5)V99.
     05  HOLD-BASIC-PROF			PIC S9(5)V99.
     05  HOLD-BASIC-FEE				PIC S9(5)V99.
     05  HOLD-RAT-OMA-CD.
         10  HOLD-OMA-CD 			PIC X(4).
         10  HOLD-OMA-SUFF			PIC X.
     05  HOLD-ICC-CD.
         10  HOLD-ICC-SEC			PIC XX.
         10  HOLD-ICC-GRP			PIC 99.

01   ICONST-FLAG 				PIC X.
     88  ICONST-FOUND				VALUE 'Y'.
     88  ICONST-NOT-FOUND			VALUE 'N'.

01   OMA-FEE-FLAG				PIC X.
     88  OMA-FOUND				VALUE 'Y'.
     88  OMA-NOT-FOUND				VALUE 'N'.
