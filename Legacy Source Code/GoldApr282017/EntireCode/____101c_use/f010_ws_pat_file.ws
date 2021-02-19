not used ???
01  WS-PAT-MSTR-REC.

    05  WS-PAT-FUNC-CODE                PIC XX.
    05  WS-PAT-SUBSCR-SURNAME
	10  WS-PAT-SUBSCR-SURNAME-6	PIC X(6).
	10  WS-PAT-SUBSCR-SURNAME-18	PIC X(18).
    05  WS-PAT-FIRST-NAME.
	10  WS-PAT-FIRST-NAME-3		PIC X(3).
	10  WS-PAT-FIRST-NAME-21	PIC X(21).
    05  WS-PAT-BIRTH-DATE               PIC X(8).
    05  WS-PAT-BIRTH-DATE-R   REDEFINES WS-PAT-BIRTH-DATE.
	10  WS-PAT-BIRTH-YY             PIC 99.
        10  WS-PAT-SLASH1               PIC X.
	10  WS-PAT-BIRTH-MM             PIC 99.
        10  WS-PAT-SLASH2               PIC X.
	10  WS-PAT-BIRTH-DD             PIC 99.
    05  WS-PAT-SEX                      PIC X.
    05  WS-PAT-ID-NO                    PIC X(9).
    05  WS-PAT-ID-NO-R        REDEFINES WS-PAT-ID-NO.
	10  WS-PAT-ID-NO-FIRST-8-DIGITS.
            15  WS-PAT-ID-NO-YY         PIC 99.
            15  WS-PAT-ID-NO-MM         PIC 99.
	    15  WS-PAT-ID-NO-5-DIGIT	PIC X.
	    15  WS-PAT-ID-NO-6-7-DIGIT	PIC 9(2).
	    15  WS-PAT-ID-NO-8-DIGIT    PIC 9.
	10  WS-PAT-ID-NO-9-DIGIT	PIC X.
    05  WS-PAT-STREET-ADDR              PIC X(28).
    05  WS-PAT-CITY                     PIC X(18).
    05  WS-PAT-PROV                     PIC X(4).
    05  WS-PAT-POSTAL-CODE              PIC X(6).
    05  WS-PAT-POSTAL-CODE-R     REDEFINES WS-PAT-POSTAL-CODE.
        10  WS-PAT-POSTAL-CODE-1	PIC X.
        10  WS-PAT-POSTAL-CODE-2	PIC X.
        10  WS-PAT-POSTAL-CODE-3	PIC X.
        10  WS-PAT-POSTAL-CODE-4	PIC X.
        10  WS-PAT-POSTAL-CODE-5	PIC X.
        10  WS-PAT-POSTAL-CODE-6	PIC X.
    05  WS-PAT-PHONE-NO                 PIC X(10).
    05  WS-PAT-OHIP-NO                  PIC X(8).
    05  WS-PAT-RELATIONSHIP             PIC X.
    05  WS-PAT-LAST-NAME	        PIC X(24).
    05  WS-PAT-SUBSCR-INITIALS          PIC X(3).

