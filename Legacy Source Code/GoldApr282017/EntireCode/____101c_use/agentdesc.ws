*                 AGENT DESCRIPTIONS

*   1990/oct/26 BML   FOR USE WITH R004C
*   1995/oct/01 YAS   ADD AGENT 5 ADN MISC. PAYMENT ALLOCATION
*   2001/nov/06 B.E.  ADD AGENT 3 for clinic 85 (revenue file only)
*

01  AGENT-DESCRIPTION-LINES.
    05  AD-LINE-1                         PIC X(80)    VALUE
               "                     AGENT DESCRIPTIONS".
    05  AD-LINE-2                         PIC X(60)    VALUE
               "0  OHIP BILLING".
    05  AD-LINE-3                         PIC X(60)    VALUE
               "1  DIAGNOSTIC BILLING".
    05  AD-LINE-4                         PIC X(60)    VALUE
               "2  OHIP WCB BILLING".
    05  AD-LINE-5                         PIC X(60)    VALUE
***            "3  RESERVED FOR FUTURE USE".
               "3  ICU (85) DIRECT BILL".
    05  AD-LINE-6                         PIC X(60)    VALUE
               "4  INELIGIBLE OHIP/BILL PATIENT".
    05  AD-LINE-7                         PIC X(60)    VALUE
               "5  MOH REMITTANCE REDUCTION (MOHR)".
    05  AD-LINE-8                         PIC X(60)    VALUE
               "6  PATIENT/INSURANCE BILLING".
    05  AD-LINE-9                         PIC X(60)    VALUE
               "7  MISCELLANEOUS PAYMENT".
    05  AD-LINE-10                        PIC X(70)    VALUE
               "8  NEONATAL (SURROGATE) / GERIATRICS ALTERNATIVE / ICU ALTERNATIVE".
    05  AD-LINE-11                        PIC X(60)    VALUE
               "9  W.C.B. BILLING / W.C.B. MISCELLANEOUS".
    05  AD-LINE-12                        PIC X(60)    VALUE
               "                                        ".
    05  AD-LINE-13                        PIC X(60)    VALUE
               "AGENT 7 MISCELLANEOUS PAYMENT ALLOCATION".
    05  AD-LINE-14                        PIC X(60)    VALUE
               "                                        ".
    05  AD-LINE-15                        PIC X(60)    VALUE
               "MICV  =  HAMILTON CIVIC HOSPITALS".
    05  AD-LINE-16                        PIC X(60)    VALUE
               "MICM  =  CHEDOKE MCMASTER HOSPITALS".
    05  AD-LINE-17                        PIC X(60)    VALUE
               "MISJ  =  ST. JOSEPH'S HOSPITAL".
    05  AD-LINE-18                        PIC X(60)    VALUE
               "MISP  =  ST. PETER'S HOSPITAL".
    05  AD-LINE-19                        PIC X(60)    VALUE
               "MICB  =  CAMBRIDGE".
    05  AD-LINE-20                        PIC X(60)    VALUE
               "MIBR  =  BRANTFORD".
    05  AD-LINE-21                        PIC X(60)    VALUE
               "MINH  =  NORTH HAMILTON COMMUNITY HEALTH CENTRE".

*
01  DOC-MESS-LINE			  PIC X(80)	VALUE
	"SEQUENTIAL SERVICE CODES INCLUDING PSYCHOTHERAPY MAY BE GROUPED".

