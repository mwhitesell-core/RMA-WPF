identification division. 
program-id. r051c. 
author. dyad computer systems inc. 
installation. rma. 
date-written. yy/mm/dd. 
date-compiled. 
security. 
* 
*    FILES      : F020 - DOCTOR MASTER 
*               : F040 - OMA FEE MASTER 
*               : F070 - DEPARTMENT MASTER 
*               : F090 - CONSTANTS MASTER 
*               : PARAMETER-FILE 
*               : WORK FILE 
*               : "R051CA" PRINT REPORT FILE1 
*               : "R051CA_SUMM" PRINT SUMMARY FILE 
*               : "R051CB" PRINT REPORT FILE2 
* 
*    PROGRAM PURPOSE :  PRINT THE PRODUCTIVITY ANALYSIS REPORTS. 
*                 THIS IS THE THIRD IN A SERIES OF 3 PROGRAMS. 
*                   IT USES THE SORTED WORK FILE CREATED BY R051B 
*                  TO PRINT THE REPORT. 
* 
*         REV.  MAY/87 (S.B.) - COVERSION FROM AOS to AOS/VS. 
*                               CHANGE FIELD SIZE FOR 
*                               STATUS CLAUSE TO 2 AND 
*                               FEEDBACK CLAUSE TO 4. 
* 
*    89/03/10     S. FADER      - SMS 114 
*                           - STRING THE DOCTOR NAME WITH 2 SPACES 
*                           RATHER THAN 1 SPACE, SO DR. VAN DER 
*                            MEULEN CAN BE PRINTED PROPERLY. 
* 
*   REVISED MARCH/89 : - SMS 115 S.F. 
*                       - MAKE SURE FILE STATUS IS PIC XX ,FEEDBACK IS 
*                   PIC X(4) AND INFOS STATUS IS PIC X(11). 
* 
* 
*   REVISED JAN/92 :   - SMS 8 (HSC ONLY) 
*                   - SUPPRESS THE PRINTING OF SUMMARY PAGE FOR EACH 
*                         DOCTOR ON R051CA, BUT TRANSFER ONTO THE NEW 
*                    REPORT (R051CA_SUMM) 
*
*   APRIL 1998 : J. CHAU - S197 UNIX CONVERSION
*
*   JAN 1999  :  L. SYMONDS - Y2K CONVERSION
*   Aug/08/2007 M. Chan	- reset ws-mtd-avg/perc and ws-ytd-avg/perc to zero
*			  before recalculating the next record

 
environment division. 
input-output section. 
file-control. 
* 
*   PLACE YOUR FILE SELECT STATEMENTS HERE 
* 
* 
    select r051-work-file 
     assign to "r051_sort_work_mstr" 
 organization is sequential. 
* 
 
    select print-file-one 
   assign to printer print-file-name-one 
   file status is status-prt-file-one. 
 
* 
 
    select print-file-summ 
  assign to printer print-file-name-summ 
  file status is status-prt-file-summ. 
 
* 
 
    select print-file-two 
  assign to printer print-file-name-two 
   file status is status-prt-file-two. 
* 
    copy "f020_doctor_mstr.slr". 
* 
    copy "f040_oma_fee_mstr.slr". 
* 
    copy "f070_dept_mstr.slr". 
* 
    copy "f090_constants_mstr.slr". 
* 
    copy "r051_parm_file.slr". 
data division. 
file section. 
* 
    copy 'r051_docrev_work_mstr.fd'. 
* 
    copy 'f020_doctor_mstr.fd'. 
* 
    copy 'f040_oma_fee_mstr.fd'. 
* 
    copy 'f070_dept_mstr.fd'. 
* 
    copy "f090_constants_mstr.fd". 
* 
    copy "f090_const_mstr_rec_4.ws". 
* 
fd  print-file-one 
    record contains 132 characters. 
 
01  print-record-one                              pic x(132). 
* 
fd  print-file-summ 
    record contains 132 characters. 
 
01  print-record-summ                         pic x(132). 
* 
fd  print-file-two 
    record contains 132 characters. 
 
01  print-record-two                           pic x(132). 
* 
    copy "r051_parm_file.fd". 
working-storage section. 
 
77  err-ind                                   pic 99  value zero. 
77  print-file-name-one                              pic x(6) 
        value "r051ca". 
77  print-file-name-summ                 pic x(11) 
       value "r051ca_summ". 
77  print-file-name-two                             pic x(6) 
        value "r051cb". 
77  option                                       pic x. 
77  nbr-of-lines-to-print                 pic 9. 
77  max-nbr-lines                         pic 99   value 60. 
77  ctr-lines                                 pic 99     value 70. 
77  summ-max-nbr-lines                              pic 99   value 60. 
77  summ-ctr-lines                            pic 99     value 70. 
77  parm-rec-nbr                            pic 9. 
77  blank-line                                    pic x(132) value spaces. 
77  subs                                        pic 999 comp. 
77  subs1                                  pic 999 comp. 
77  subs-dept-clinic                               pic 9   comp. 
77  subs-class-code                                pic 99  comp. 
77  subs-present-nbr-classes                       pic 99  comp value zero. 
77  subs-max-nbr-classes                        pic 99  comp value zero. 
77  subs-dept                                   pic 9   comp value 1. 
77  subs-clinic                                    pic 9   comp value 2. 
77  subs-class-total                               pic 99  comp. 
77  subs-print-classes                             pic 99  comp. 
77  hold-dept                                      pic 99. 
77  hold-class-code                              pic x. 
*!77  hold-doc-nbr                          pic 999. 
77  hold-doc-nbr                          pic xxx. 
77  hold-oma-cd                                 pic x(5). 
77  hold-oma-cd-ltr                            pic x. 
77  ws-mtd-svc                                    pic 9(8). 
77  ws-mtd-amt                                 pic s9(9)v99. 
77  ws-mtd-avg                                     pic s9(9)v9999. 
77  ws-mtd-perc                                  pic s999v9999. 
77  ws-mtd-sum-next-level                 pic s9(9)v99. 
77  ws-ytd-svc                                     pic 9(8). 
77  ws-ytd-amt                                 pic s9(9)v99. 
77  ws-ytd-avg                                     pic s9(9)v9999. 
77  ws-ytd-perc                                  pic s999v9999. 
77  ws-ytd-sum-next-level                 pic s9(9)v99. 
77  ws-ohip-code-desc-lit                  pic x(60) value 
 "OHIP  ----------OHIP CODE DESCRIPTION ---------------". 
77  ws-dept-lit                                 pic x(23)       value 
   "DEPARTMENT CLASS TOTALS". 
77  ws-clinic-lit                             pic x(19)       value 
   "CLINIC CLASS TOTALS". 
77  ws-doc-name-inits                             pic x(30). 
77  feedback-oma-fee-mstr                     pic x(4). 
77  feedback-iconst-mstr                       pic x(4). 
 
*  EOF INDICATORS 
* 
77  eof-doctor-mstr                          pic x    value "N". 
77  eof-work-file                            pic x   value "N". 
77  eof-dept-mstr                             pic x   value "N". 
77  eof-oma-mstr                              pic x   value "N". 
* 
*  STATUS FILE INDICATORS 
* 
*mf 77  common-status-file                             pic x(11). 
*mf 77  status-doc-mstr                                pic x(11) value zero. 
*mf 77  status-parm-file                               pic x(11) value zero. 
*mf 77  status-dept-mstr                               pic x(11) value zero. 
*mf 77  status-iconst-mstr                             pic x(11) value zero. 
*mf 77  status-oma-mstr                                pic x(11) value zero. 
 
77  common-status-file                             pic xx. 
77  status-cobol-doc-mstr                          pic xx    value zero. 
77  status-cobol-parm-file                         pic xx    value zero. 
77  status-cobol-dept-mstr                         pic xx    value zero. 
77  status-cobol-iconst-mstr                       pic xx    value zero. 
77  status-cobol-oma-mstr                          pic xx    value zero. 
77  status-prt-file                                pic xx    value zero. 
77  status-prt-file-one                            pic xx    value zero. 
77  status-prt-file-summ                           pic xx    value zero. 
77  status-prt-file-two                            pic xx    value zero. 
 
01  flag-end-work-rec                              pic x. 
    88  flag-end-work-rec-y                       value 'Y'. 
    88  flag-end-work-rec-n                   value 'N'. 
 
01  flag                                      pic x. 
    88  ok                                        value 'Y'. 
    88  not-ok                                        value 'N'. 
 
01  flag-clinic-totals                                pic x. 
    88  flag-clinic-totals-y                      value 'Y'. 
    88  flag-clinic-totals-n                  value 'N'. 
 
 
 
01  totals. 
    05  total-indiv-oma-cd. 
        10  total-indiv-oma-cd-mtd-svc          pic 9(4). 
       10  total-indiv-oma-cd-mtd-amt          pic s9(5)v99. 
   10  total-indiv-oma-cd-ytd-svc          pic 9(6). 
       10  total-indiv-oma-cd-ytd-amt          pic s9(7)v99. 
    05  total-ltr. 
 10  total-ltr-mtd-svc                   pic 9(5). 
       10  total-ltr-mtd-amt                   pic s9(6)v99. 
   10  total-ltr-ytd-svc                   pic 9(7). 
       10  total-ltr-ytd-amt                   pic s9(9)v99. 
    05  total-clinic-dept. 
 10  total-clinic-dept-mtd-svc           pic 9(8). 
       10  total-clinic-dept-mtd-amt           pic s9(8)v99. 
   10  total-clinic-dept-ytd-svc           pic 9(8). 
       10  total-clinic-dept-ytd-amt           pic s9(9)v99. 
    05  total-dept-doc. 
    10  total-dept-doc-mtd-svc              pic 9(6). 
       10  total-dept-doc-mtd-amt              pic s9(8)v99. 
   10  total-dept-doc-ytd-svc              pic 9(7). 
       10  total-dept-doc-ytd-amt              pic s9(9)v99. 
    05  total-class. 
       10  total-class-mtd-svc                 pic 9(6). 
       10  total-class-mtd-amt                 pic s9(8)v99. 
   10  total-class-ytd-svc                 pic 9(7). 
       10  total-class-ytd-amt                 pic s9(9)v99. 
 
 
01  ws-class-codes. 
    05  ws-total-by-dept-clinic occurs 2 times. 
 10  ws-max-class-codes occurs 16 times. 
     15  ws-class-code                   pic x. 
      15  ws-class-code-desc              pic x(24). 
          15  ws-class-mtd-svc                pic 9(8). 
           15  ws-class-mtd-amt                pic s9(9)v99. 
       15  ws-class-ytd-svc                pic 9(8). 
           15  ws-class-ytd-amt                pic s9(9)v99. 
 
*    SMS 114 S.F.   STRING THE DOCTOR NAME WITH 2 SPACES RATHER THAN 1. 
01   ws-xx                  pic xx          value "  ". 
 
*   COUNTERS FOR RECORDS READ/WRITTEN FOR ALL INPUT/OUTPUT FILES 
 
01  counters. 
    05  ctr-work-file-reads                     pic 9(7). 
    05  ctr-doc-mstr-reads                     pic 9(7). 
    05  ctr-pages                              pic 9(3). 
    05  ctr-report-pages                       pic 9(3). 
    05  summ-ctr-pages                         pic 9(3). 
01  error-message-table. 
 
    05  error-messages. 
       10  filler                              pic x(60)   value 
                       "INVALID REPLY". 
        10  filler                              pic x(60)   value 
                       "NO PARAMETER FILE SUPPLIED". 
   10  filler                              pic x(60)   value 
                       "NO SORT WORK FILE FOUND". 
      10  filler                              pic x(60)   value 
                       "INVALID WRITE TO PARAMETER FILE". 
      10  filler                              pic x(60)   value 
                       "INVALID PARAMETER STATUS". 
     10  filler                              pic x(60)   value 
                       "CONSTANTS MASTER READ ERROR". 
  10  filler                              pic x(60)   value 
                       "TOO MANY CLASS CODES FOUND". 
   10  filler                              pic x(60)   value 
                       "DEPARMENT MASTER RECORD NOT FOUND". 
    10  filler                              pic x(60)   value 
                       "*** CAN BE RE-USED ***". 
       10  filler                              pic x(60)   value 
                       "*** CAN BE RE-USED ***". 
       10  filler                              pic x(60)   value 
                       "*** CAN BE RE-USED ***". 
       10  filler                              pic x(60)   value 
                       "*** CAN BE RE-USED ***". 
       10  filler                              pic x(60)   value 
                       "*** CAN BE RE-USED ***". 
       10  filler                              pic x(60)   value 
                       "*** CAN BE RE-USED ***". 
 
    05  error-messages-r redefines error-messages. 
     10  err-msg                             pic x(60) 
                       occurs 14 times. 
 
01  err-msg-comment. 
    05  err-msg-key-type                    pic x(25). 
    05  err-msg-key                           pic x(35). 
 
01  e1-error-line. 
 
    05  e1-error-word                               pic x(13)    value 
                      "***  ERROR - ". 
    05  e1-error-msg                            pic x(119). 
 
 
 
 
    copy "sysdatetime.ws". 
01  h1-head. 
 
    05  h1-report-nbr                         pic x(6). 
    05  filler                                 pic x   value "/". 
    05  h1-clinic-nbr                         pic zz. 
    05  filler                                   pic x(3) value spaces. 
    05  filler                                    pic x(7) value 
          "P.E.D.". 
    05  h1-ped. 
* (y2k)
*       10  h1-ped-yy                           pic 99. 
        10  h1-ped-yy                           pic 9(4). 
 10  filler                              pic x value "/". 
        10  h1-ped-mm                           pic 99. 
 10  filler                              pic x value "/". 
        10  h1-ped-dd                           pic 99. 
*   05  filler                                   pic x(22) value spaces. 
    05  filler                                   pic x(20) value spaces. 
    05  h1-title                         pic x(45). 
    05  filler                                        pic x(11) value 
 "RUN DATE:". 
    05  h1-run-date. 
* (y2k)
*       10  h1-run-date-yy                      pic 99. 
        10  h1-run-date-yy                      pic 9(4). 
 10  filler                              pic x value "/". 
        10  h1-run-date-mm                      pic 99. 
 10  filler                              pic x value "/". 
        10  h1-run-date-dd                      pic 99. 
*   05  filler                                   pic x(6) value spaces. 
    05  filler                                   pic x(4) value spaces. 
    05  filler                                    pic x(5) value "PAGE". 
    05  h1-page-nbr                               pic zz9. 
    05  filler                                  pic x    value "/". 
    05  h1-report-page-nbr                   pic zz9. 
 
01  summ-head. 
 
    05  summ-report-nbr                   pic x(11). 
    05  filler                                        pic x   value "/". 
    05  summ-clinic-nbr                       pic zz. 
    05  filler                                   pic x(3) value spaces. 
    05  filler                                    pic x(7) value 
          "P.E.D.". 
    05  summ-ped. 
* (y2k)
*     10  summ-ped-yy                 pic 99. 
      10  summ-ped-yy                 pic 9(4). 
 10  filler                              pic x value "/". 
        10  summ-ped-mm                 pic 99. 
 10  filler                              pic x value "/". 
        10  summ-ped-dd                 pic 99. 
*   05  filler                                   pic x(17) value spaces. 
    05  filler                                   pic x(15) value spaces. 
    05  summ-title                               pic x(45). 
    05  filler                                        pic x(11) value 
                                         "RUN DATE:". 
    05  summ-run-date. 
* (y2k)
*     10  summ-run-date-yy                    pic 99. 
      10  summ-run-date-yy                    pic 9(4). 
 10  filler                              pic x value "/". 
        10  summ-run-date-mm                    pic 99. 
 10  filler                              pic x value "/". 
        10  summ-run-date-dd                    pic 99. 
*   05  filler                                   pic x(10) value spaces. 
    05  filler                                   pic x(8) value spaces. 
    05  filler                                   pic x(5) value "PAGE". 
    05  summ-page-nbr                     pic zz9. 
 
01  h2-head. 
    05  filler                                      pic x(56) value spaces. 
    05  h2-clinic-name                           pic x(20). 
    05  filler                                        pic x(56) value spaces. 
 
01  h2a-head. 
    05  filler                                      pic x(7)   value 'DOCTOR'. 
*!  05  h2a-doc-nbr                           pic 999. 
    05  h2a-doc-nbr                           pic xxx. 
    05  filler                                  pic x(3) value spaces. 
    05  h2a-doc-name-inits                        pic x(119). 
 
01  h3-head. 
    05  filler                                   pic x(55) value spaces. 
    05  filler                                   pic x(77) value 
 "----------- M . T . D . -----------   -------------- Y . T . D . ------------". 
 
 
01  h4-head. 
    05  filler                                      pic x(56) value spaces. 
    05  filler                                   pic x(40) value 
 "SVC    $ AMT      $ AVG    PERCENT". 
    05  filler                                     pic x(36)  value 
        "SVC     $ AMT       $ AVG    PERCENT". 
 
 
01  h5-head. 
    05  h5-ohip-code-desc-lit                        pic x(81) value spaces. 
    05  h5-doc-dept-lit                          pic x(42) value spaces. 
    05  h5-doc-dept-lit2                 pic x(9)  value spaces. 
 
 
01  h6-head. 
    05  filler                                       pic x(49) value spaces. 
    05  filler                                   pic x(6) value "DEPT #". 
    05  h6-dept-nbr                             pic 99. 
    05  filler                                   pic x(3) value " - ". 
    05  h6-dept-name                               pic x(72). 
 
01  h7-head. 
    05  filler                                    pic x(49) value spaces. 
    05  filler                                   pic x(7) value "CLASS". 
    05  h7-class                         pic x(2). 
    05  filler                                 pic x(2) value "- ". 
    05  h7-class-desc                               pic x(72). 
 
01  h8-head. 
    05  h8-total-lit                              pic x(132). 
01  print-line. 
 
    05  l1-print-line. 
       10  l1-oma-cd                           pic x(6). 
       10  l1-desc                             pic x(49). 
      10  l1-mtd-svc                          pic zzz9. 
       10  filler                              pic x(3). 
       10  l1-mtd-amt                          pic zz,zz9.99-. 
 10  filler                              pic x(2). 
       10  l1-mtd-avg                          pic z,zz9.99-. 
  10  l1-mtd-perc                         pic zz9.99. 
     10  l1-mtd-perc-sign                    pic x(4). 
       10  l1-ytd-svc                          pic z(5)9. 
      10  filler                              pic x(2). 
       10  l1-ytd-amt                          pic zzzz,zz9.99-. 
       10  filler                              pic x. 
  10  l1-ytd-avg                          pic zzz,zz9.99-. 
        10  l1-ytd-perc                         pic zz9.99. 
     10  l1-ytd-perc-sign                    pic x. 
    05  l2-print-line redefines l1-print-line. 
    10  l2-ltr                              pic x. 
  10  l2-dashes                           pic x(6). 
       10  l2-total-lit                        pic x(47). 
      10  l2-mtd-svc                          pic zzzz9. 
      10  filler                              pic xx. 
 10  l2-mtd-amt                          pic zzz,zz9.99-. 
        10  filler                              pic x. 
  10  l2-mtd-avg                          pic zz,zz9.99-. 
 10  l2-mtd-perc                         pic zz9.99. 
     10  l2-mtd-perc-sign                    pic x(3). 
       10  l2-ytd-svc                          pic z(6)9. 
      10  filler                              pic x. 
  10  l2-ytd-amt                          pic z(8)9.99-. 
  10  filler                              pic x. 
  10  l2-ytd-avg                          pic zzz,zz9.99-. 
        10  l2-ytd-perc                         pic zz9.99. 
     10  l2-ytd-perc-sign                    pic x. 
    05  t1-print-line redefines l2-print-line. 
    10  t1-doc-lit                          pic x(8). 
*!     10  t1-doc-nbr                          pic 999. 
       10  t1-doc-nbr                          pic xxx. 
        10  filler                              pic x(3). 
       10  t1-total-lit                        pic x(38). 
      10  t1-mtd-svc                          pic zzz,zz9. 
    10  filler                              pic x. 
  10  t1-mtd-amt                          pic z(7)9.99-. 
  10  filler                              pic x. 
  10  t1-mtd-avg                          pic zz,zz9.99-. 
 10  t1-mtd-perc                         pic zz9.99. 
     10  t1-mtd-perc-sign                    pic x(3). 
       10  t1-ytd-svc                          pic z(6)9. 
      10  filler                              pic x. 
  10  t1-ytd-amt                          pic z(8)9.99-. 
  10  filler                              pic x. 
  10  t1-ytd-avg                          pic z(6)9.99-. 
  10  t1-ytd-perc                         pic zz9.99. 
     10  t1-ytd-perc-sign                    pic x. 
    05  t2-print-line redefines t1-print-line. 
    10  t2-dept-lit                         pic x(51). 
      10  t2-class-code-r redefines t2-dept-lit. 
          15  t2-class-code                   pic x. 
      15  t2-col                          pic x(2). 
           15  t2-class-code-desc              pic x(48). 
      10  t2-mtd-svc                          pic z(7)9. 
      10  filler                              pic x. 
  10  t2-mtd-amt                          pic z(7)9.99-. 
  10  filler                              pic x. 
  10  t2-mtd-avg                          pic zz,zz9.99-. 
 10  t2-mtd-perc                         pic zz9.99. 
     10  t2-mtd-perc-sign                    pic xx. 
 10  t2-ytd-svc                          pic z(7)9. 
      10  filler                              pic x. 
  10  t2-ytd-amt                          pic z(8)9.99-. 
  10  filler                              pic x. 
  10  t2-ytd-avg                          pic z(6)9.99-. 
  10  t2-ytd-perc                         pic zz9.99. 
     10  t2-ytd-perc-sign                    pic x. 
    05  t3-print-line redefines t2-print-line. 
    10  t3-dept-lit                         pic x(51). 
      10  t3-mtd-svc                          pic z(7)9. 
      10  filler                              pic x. 
  10  t3-mtd-amt                          pic z(7)9.99-. 
  10  filler                              pic x. 
  10  t3-mtd-avg                          pic zz,zz9.99-. 
 10  t3-mtd-perc                         pic zz9.99. 
     10  t3-mtd-perc-sign                    pic x(2). 
       10  t3-ytd-svc                          pic z(7)9. 
      10  filler                              pic x. 
  10  t3-ytd-amt                          pic z(8)9.99-. 
  10  filler                              pic x. 
  10  t3-ytd-avg                          pic z(6)9.99-. 
  10  t3-ytd-perc                         pic zz9.99. 
     10  t3-ytd-perc-sign                    pic x. 
    05  t4-print-line redefines t3-print-line. 
    10  t4-clinic-lit                       pic x(51). 
      10  t4-mtd-svc                          pic z(7)9. 
      10  filler                              pic x. 
  10  t4-mtd-amt                          pic z(7)9.99-. 
  10  filler                              pic x. 
  10  t4-mtd-avg                          pic zz,zz9.99-. 
 10  t4-mtd-perc                         pic zz9.99. 
     10  t4-mtd-perc-sign                    pic x(2). 
       10  t4-ytd-svc                          pic z(7)9. 
      10  filler                              pic x. 
  10  t4-ytd-amt                          pic z(8)9.99-. 
  10  filler                              pic x. 
  10  t4-ytd-avg                          pic z(6)9.99-. 
  10  t4-ytd-perc                         pic zz9.99. 
     10  t4-ytd-perc-sign                    pic x. 
screen section. 
 
01  file-status-display. 
    05  line 24 col 56 value "FILE STATUS = ". 
    05  line 24 col 70 pic x(11) from common-status-file    bell blink. 
* 
01  err-msg-line. 
    05  line 24 col 01     value " ERROR -  "      bell blink. 
    05  line 24 col 11       pic x(60)       from err-msg-comment. 
 
01  blank-line-24. 
    05  line 24 col 1    blank line. 
 
01  confirm. 
    05  line 23 col 01 value " ". 
 
01  blank-screen. 
    05  blank screen. 
 
01  program-in-progress. 
    05  blank screen. 
    05  line 24 col 20 value is "PROGRAM R051C IN PROGRESS". 
 
01  scr-closing-screen. 
    05 blank screen. 
    05  line 13 col 20  value "NBR OF DOCTOR-MSTR ACCESSESS = ". 
    05  line 13 col 60  pic 9(7) from ctr-doc-mstr-reads. 
    05  line 15 col 20  value "NBR OF WORK-FILE REC READ = ". 
    05  line 15 col 60  pic 9(7) from ctr-work-file-reads. 
    05  line 21 col 20 value "PROGRAM R051C ENDING". 
* (y2k - auto fix)
*   05  line 21 col 40  pic 99     from sys-yy. 
    05  line 21 col 40  pic 9(4)     from sys-yy. 
*   05  line 21 col 42      value "/". 
    05  line 21 col 44      value "/". 
*   05  line 21 col 43      pic 99  from sys-mm. 
    05  line 21 col 45      pic 99  from sys-mm. 
*   05  line 21 col 45      value "/". 
    05  line 21 col 47      value "/". 
*   05  line 21 col 46        pic 99  from sys-dd. 
    05  line 21 col 48        pic 99  from sys-dd. 
*   05  line 21 col 50      pic 99  from sys-hrs. 
    05  line 21 col 52      pic 99  from sys-hrs. 
*   05  line 21 col 52     value ":". 
    05  line 21 col 54     value ":". 
*   05  line 21 col 53        pic 99  from sys-min.        
    05  line 21 col 55        pic 99  from sys-min.        
 
01  scr-closing-rpt1. 
    05  line 22 col 20 value "PRINT REPORT1 IS IN FILE - ". 
    05  line 22 col 51      pic x(7) from print-file-name-one. 
 
01  scr-closing-rpt2. 
    05  line 22 col 20   value "PRINT REPORT2 IS IN FILE - ". 
    05  line 22 col 51      pic x(7) from print-file-name-two. 
procedure division. 
declaratives. 
 
err-doc-mstr-file section. 
    use after standard error procedure on doc-mstr. 
err-doc-mstr. 
*mf move status-doc-mstr           to common-status-file. 
    move status-cobol-doc-mstr           to common-status-file.
    move status-cobol-doc-mstr     to common-status-file. 
    display file-status-display. 
    stop "ERROR IN ACCESSING DOCTOR MASTER". 
 
err-dept-mstr-file section. 
    use after standard error procedure on dept-mstr. 
err-dept-mstr. 
*mf    move status-dept-mstr                to common-status-file. 
    move status-cobol-dept-mstr          to common-status-file. 
    display file-status-display. 
    stop "ERROR IN ACCESSING DEPARTMENT MASTER". 
 
err-iconst-mstr-file section. 
    use after standard error procedure on iconst-mstr. 
err-iconst-mstr. 
*mf    move status-iconst-mstr            to common-status-file. 
    move status-cobol-iconst-mstr      to common-status-file. 
    display file-status-display. 
    stop "ERROR IN ACCESSING CONSTANTS MASTER". 
 
err-oma-fee-mstr-file section. 
    use after standard error procedure on oma-fee-mstr. 
err-oma-fee-mstr. 
*mf    move status-oma-mstr             to common-status-file. 
    move status-cobol-oma-mstr          to common-status-file. 
    display file-status-display. 
    stop "ERROR IN ACCESSING OMA FEE MASTER". 
 
err-print-file-one section. 
    use after standard error procedure on print-file-one. 
err-file-one. 
    move status-prt-file-one                to common-status-file. 
    display file-status-display. 
    stop "ERROR ON PRINT FILE ONE (R051CA)". 
 
err-print-file-summ section. 
    use after standard error procedure on print-file-summ. 
err-file-summ. 
    move status-prt-file-summ             to common-status-file. 
    display file-status-display. 
    stop "ERROR ON PRINT FILE SUMM (R051CA_SUMM)". 
 
err-print-file-two section. 
    use after standard error procedure on print-file-two. 
err-file-two. 
    move status-prt-file-two           to common-status-file. 
    display file-status-display. 
    stop "ERROR ON PRINT FILE TWO (R051CB)". 
 
end declaratives. 
main-line section. 
mainline. 
 
    perform aa0-initialization           thru aa0-99-exit. 
 
    if parm-status = 1 
    then 
 perform ab0-process-r051ca      thru ab0-99-exit 
                until flag-end-work-rec-y 
    else 
       if parm-status = 3 
      then 
        perform ad0-process-r051cb  thru ad0-99-exit 
                until flag-end-work-rec-y 
       else 
        move 5                      to err-ind 
          perform za0-common-error    thru za0-99-exit 
            go to az0-10-end-of-job. 
*   ENDIF 
*   ENDIF 
 
    perform az0-end-of-job                thru az0-99-exit. 
* 
    stop run. 
aa0-initialization. 
   
    accept sys-date                        from    date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-mm                            to      run-mm 
                                          summ-run-date-mm 
                                                h1-run-date-mm. 
    move sys-dd                          to      run-dd 
                                          summ-run-date-dd 
                                                h1-run-date-dd. 
    move sys-yy                          to      run-yy 
                                          summ-run-date-yy 
                                                h1-run-date-yy. 
 
    accept sys-time                      from    time. 
    move sys-hrs                   to      run-hrs. 
    move sys-min                        to      run-min. 
    move sys-sec                        to      run-sec. 
 
    display program-in-progress. 
 
    open input  r051-work-file 
          dept-mstr 
               oma-fee-mstr 
            iconst-mstr 
             doc-mstr. 
    open i-o   parameter-file. 
 
    move 'N'                             to      flag-clinic-totals. 
 
    move 4                           to      iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
      invalid key 
         move 6                      to      err-ind 
     perform za0-common-error    thru    za0-99-exit 
         go to az0-10-end-of-job. 
 
    move 1                          to      subs-dept-clinic. 
 
    perform xs0-clear-class-tbl                thru    xs0-99-exit 
     varying subs from 1 by 1 
        until subs > const-nbr-classes + 1. 
 
    move 2                           to      subs-dept-clinic. 
 
    perform xs0-clear-class-tbl                thru    xs0-99-exit 
     varying subs from 1 by 1 
        until subs > const-nbr-classes + 1. 
 
    move zero                                to      counters 
                                                totals. 
 
    move 1                               to      ctr-pages 
                                               ctr-report-pages 
                                                summ-ctr-pages 
                                          subs-dept-clinic 
                                                subs-max-nbr-classes 
                                            subs-class-code. 
 
    move spaces                         to      print-line 
                                              work-file-rec. 
 
    perform xc0-read-work-rec             thru    xc0-99-exit. 
 
    if flag-end-work-rec-y 
    then 
  move 3                          to      err-ind 
 perform za0-common-error        thru    za0-99-exit 
     go to az0-10-end-of-job 
    else 
 move wf-dept                    to      hold-dept 
       move wf-class-code              to      hold-class-code 
                                         ws-class-code(subs-dept-clinic,subs-class-code) 
 move wf-doc-nbr                 to      hold-doc-nbr 
    move wf-oma-cd                  to      hold-oma-cd 
     move wf-oma-code-ltr            to      hold-oma-cd-ltr. 
*   ENDIF 
 
    move 1                             to      parm-rec-nbr. 
    read parameter-file 
    invalid key 
         move 2                      to      err-ind 
             perform za0-common-error    thru    za0-99-exit 
         go to az0-10-end-of-job. 
 
*   (OBTAIN CLINIC NAME,NBR AND PERIOD END FROM PARAMETER FILE) 
    move parm-clinic-nbr             to      h1-clinic-nbr 
                                                   summ-clinic-nbr. 
    move parm-clinic-name               to      h2-clinic-name. 
    move parm-ped-yy                     to      h1-ped-yy 
                                               summ-ped-yy. 
    move parm-ped-mm                        to      h1-ped-mm 
                                               summ-ped-mm. 
    move parm-ped-dd                        to      h1-ped-dd 
                                               summ-ped-dd. 
  
 
    if parm-status = 1 
    then 
*     expunge print-file-one 
*  expunge print-file-summ 
 open output print-file-one 
      open output print-file-summ 
     move print-file-name-one        to      h1-report-nbr 
   move print-file-name-summ       to      summ-report-nbr 
    else 
 if parm-status = 3 
      then 
*        expunge print-file-two 
          open output print-file-two 
      move print-file-name-two    to      h1-report-nbr 
   else 
        move 5                      to      err-ind 
     perform za0-common-error    thru    za0-99-exit 
         go to az0-10-end-of-job. 
*   ENDIF 
*   ENDIF 
 
    move ws-ohip-code-desc-lit            to      h5-ohip-code-desc-lit. 
 
aa0-99-exit. 
    exit. 
az0-end-of-job. 
 
    perform ba0-oma-cd-break         thru ba0-99-exit. 
*    PERFORM HA0-OMA-CD-LTR-BREAK      THRU HA0-99-EXIT. 
 
    move 'Y'                           to flag-clinic-totals. 
 
    if parm-status = 1 
    then 
    perform da0-doc-nbr-break       thru da0-99-exit 
        perform fa0-dept-break          thru fa0-99-exit 
        close print-file-one 
    close print-file-summ 
    else 
   move total-class-mtd-amt        to ws-mtd-sum-next-level 
        move total-class-ytd-amt        to ws-ytd-sum-next-level 
        move subs-class-code            to subs-print-classes 
   perform la1-print-totals        thru la1-99-exit 
        perform ea0-dept-break-b        thru ea0-99-exit 
        move 2                          to subs-dept-clinic 
     move ws-clinic-lit              to h8-total-lit 
 move "OF CLINIC"                to h5-doc-dept-lit 
                                         h5-doc-dept-lit2 
     move subs-present-nbr-classes   to subs-max-nbr-classes 
 perform la0-class-totals        thru la0-99-exit 
        perform az3-print-total-clinic  thru az3-99-exit 
        close print-file-two. 
*   ENDIF 
 
    add 1                        to parm-status. 
    move 'R051C'                 to parm-program-nbr. 

* 99/11/12 MC - change from  write to rewrite 
*   write parm-file-rec 
    rewrite parm-file-rec 
     invalid key 
         move 4                      to err-ind 
          perform za0-common-error    thru za0-99-exit. 
 
    display blank-screen. 
    accept sys-time                   from time. 
    display scr-closing-screen. 
 
    if parm-status = 2 
    then 
 display scr-closing-rpt1 
    else 
        display scr-closing-rpt2. 
*   ENDIF 
 
az0-10-end-of-job. 
 
    close r051-work-file 
      parameter-file 
          oma-fee-mstr 
    dept-mstr 
       iconst-mstr 
     doc-mstr. 
 
*   CALL PROGRAM "MENU". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
 
 
 
az3-print-total-clinic. 
 
    move total-clinic-dept-mtd-svc  to ws-mtd-svc. 
    move total-clinic-dept-mtd-amt        to ws-mtd-amt. 
    move total-clinic-dept-ytd-svc        to ws-ytd-svc. 
    move total-clinic-dept-ytd-amt        to ws-ytd-amt. 
 
    perform xd0-calc-avg-perc             thru xd0-99-exit. 
 
    move "** CLINIC GRAND TOTALS **"   to t4-clinic-lit. 
 
    move total-clinic-dept-mtd-svc     to t4-mtd-svc. 
    move total-clinic-dept-mtd-amt        to t4-mtd-amt. 
    move total-clinic-dept-ytd-svc        to t4-ytd-svc. 
    move total-clinic-dept-ytd-amt        to t4-ytd-amt. 
 
    move ws-mtd-avg                       to t4-mtd-avg. 
    move ws-mtd-perc                      to t4-mtd-perc. 
    move ws-ytd-avg                      to t4-ytd-avg. 
    move ws-ytd-perc                      to t4-ytd-perc. 
 
    if ws-mtd-perc < zero 
    then 
        move '-'                        to t4-mtd-perc-sign 
    else 
     move '%'                        to t4-mtd-perc-sign. 
*   ENDIF 
 
    if ws-ytd-perc < zero 
    then 
  move '-'                        to t4-ytd-perc-sign 
    else 
     move '%'                        to t4-ytd-perc-sign. 
*   ENDIF 
 
    move 2                         to nbr-of-lines-to-print. 
    perform xf0-write-print-line-b     thru xf0-99-exit. 
 
az3-99-exit. 
    exit. 
ab0-process-r051ca. 
 
    if hold-dept not = wf-dept 
    then 
        perform ba0-oma-cd-break        thru ba0-99-exit 
*       PERFORM HA0-OMA-CD-LTR-BREAK    THRU HA0-99-EXIT 
        perform da0-doc-nbr-break       thru da0-99-exit 
        move total-clinic-dept-mtd-amt  to ws-mtd-sum-next-level 
        move total-clinic-dept-ytd-amt  to ws-ytd-sum-next-level 
        perform fa0-dept-break          thru fa0-99-exit 
        move 70                         to ctr-lines 
    move 1                          to ctr-pages 
                                       subs-class-code 
                                         subs-max-nbr-classes 
 move ws-ohip-code-desc-lit      to h5-ohip-code-desc-lit 
    else 
        if hold-doc-nbr not = wf-doc-nbr 
        then 
        perform ba0-oma-cd-break    thru ba0-99-exit 
*           PERFORM HA0-OMA-CD-LTR-BREAK 
*                                       THRU HA0-99-EXIT 
            perform da0-doc-nbr-break   thru da0-99-exit 
            perform na0-check-class-code 
                                        thru na0-99-exit 
            move 70                     to ctr-lines 
        move 1                      to ctr-pages 
        move ws-ohip-code-desc-lit  to h5-ohip-code-desc-lit 
        else 
        if hold-oma-cd-ltr not = wf-oma-code-ltr 
        then 
                perform ba0-oma-cd-break 
                                        thru ba0-99-exit 
*               PERFORM HA0-OMA-CD-LTR-BREAK 
*                                   THRU HA0-99-EXIT 
            else 
                if hold-oma-cd not = wf-oma-cd 
          then 
                perform ba0-oma-cd-break 
                                    thru ba0-99-exit 
                else 
                next sentence. 
*             ENDIF 
*      ENDIF 
*      ENDIF 
*   ENDIF 
 
ab0-10-check-rec. 
 
*   ( CLINIC TOTAL ) 
    if wf-dept = zero 
    then 
        perform xc0-read-work-rec       thru xc0-99-exit 
        go to ab0-10-check-rec 
    else 
* ( DEPARTMENT TOTAL ) 
    if wf-class-code = zero 
 then 
        perform xt0-new-dept-head   thru xt0-99-exit 
            perform xp0-clinic-dept-total-rec 
                                   thru xp0-99-exit 
            perform xc0-read-work-rec   thru xc0-99-exit 
            go to ab0-10-check-rec 
      else 
*       ( CLASS TOTAL ) 
         if wf-doc-nbr = zero 
            then 
                perform xu0-new-class-head 
                                      thru xu0-99-exit 
                perform xr0-class-tot-rec 
                                       thru xr0-99-exit 
                perform xc0-read-work-rec 
                                       thru xc0-99-exit 
                go to ab0-10-check-rec 
      else 
*               ( DOCTOR TOTAL ) 
                if wf-oma-cd = zero 
             then 
                perform xq0-dept-doc-total-rec 
                                      thru xq0-99-exit 
                    perform xc0-read-work-rec 
                                   thru xc0-99-exit 
                    go to ab0-10-check-rec 
              else 
                next sentence. 
*             ENDIF 
*      ENDIF 
*      ENDIF 
*   ENDIF 
 
    perform ja0-process-work-rec  thru ja0-99-exit. 
 
    move wf-dept                       to hold-dept. 
    move wf-class-code                     to hold-class-code 
                                         ws-class-code(subs-dept-clinic,subs-class-code). 
    move wf-doc-nbr                  to hold-doc-nbr. 
    move wf-oma-cd                      to hold-oma-cd. 
    move wf-oma-code-ltr         to hold-oma-cd-ltr. 
 
    perform xc0-read-work-rec        thru xc0-99-exit. 
 
ab0-99-exit. 
    exit. 
ad0-process-r051cb. 
 
    if hold-dept not = wf-dept 
    then 
        perform ba0-oma-cd-break        thru ba0-99-exit 
*       PERFORM HA0-OMA-CD-LTR-BREAK    THRU HA0-99-EXIT 
        move total-class-mtd-amt        to ws-mtd-sum-next-level 
        move total-class-ytd-amt        to ws-ytd-sum-next-level 
        move subs-class-code            to subs-print-classes 
   perform la1-print-totals        thru la1-99-exit 
        perform ea0-dept-break-b        thru ea0-99-exit 
        perform xs0-clear-class-tbl     thru xs0-99-exit 
                varying subs from 1 by 1 
                until subs > const-nbr-classes + 1 
      move 70                         to ctr-lines 
    move 1                          to ctr-pages 
                                       subs-class-code 
                                         subs-max-nbr-classes 
 move ws-ohip-code-desc-lit      to h5-ohip-code-desc-lit 
    else 
        if hold-class-code not = wf-class-code 
  then 
        perform ba0-oma-cd-break    thru ba0-99-exit 
            perform la3-bump-totals     thru la3-99-exit 
            move total-class-mtd-amt    to ws-mtd-sum-next-level 
            move total-class-ytd-amt    to ws-ytd-sum-next-level 
            move subs-class-code        to subs-print-classes 
       perform la1-print-totals    thru la1-99-exit 
            add 1                       to subs-class-code 
                                         subs-max-nbr-classes 
     move 70                     to ctr-lines 
        move 1                      to ctr-pages 
        move ws-ohip-code-desc-lit  to h5-ohip-code-desc-lit 
        else 
        if hold-oma-cd-ltr not = wf-oma-code-ltr 
        then 
                perform ba0-oma-cd-break 
                                        thru ba0-99-exit 
*               PERFORM HA0-OMA-CD-LTR-BREAK 
*                                   THRU HA0-99-EXIT 
            else 
                if hold-oma-cd not = wf-oma-cd 
          then 
                perform ba0-oma-cd-break 
                                    thru ba0-99-exit 
                else 
                next sentence. 
*             ENDIF 
*      ENDIF 
*      ENDIF 
*   ENDIF 
 
ad0-10-check-rec. 
 
*   ( CLINIC TOTAL ) 
    if wf-dept = zero 
    then 
        perform xp0-clinic-dept-total-rec 
                                       thru xp0-99-exit 
        perform xc0-read-work-rec       thru xc0-99-exit 
        go to ad0-10-check-rec 
    else 
* ( DEPARTMENT TOTAL ) 
    if wf-class-code = zero 
 then 
        perform xt0-new-dept-head   thru xt0-99-exit 
            perform xq0-dept-doc-total-rec 
                                      thru xq0-99-exit 
            perform xc0-read-work-rec   thru xc0-99-exit 
            go to ad0-10-check-rec 
      else 
*       ( CLASS TOTAL ) 
         if wf-doc-nbr = zero 
            then 
                perform xu0-new-class-head 
                                      thru xu0-99-exit 
                perform xr0-class-tot-rec 
                                       thru xr0-99-exit 
                perform xc0-read-work-rec 
                                       thru xc0-99-exit 
                go to ad0-10-check-rec 
      else 
*               ( DOCTOR TOTAL ) 
                if wf-oma-cd = zero 
             then 
                perform xc0-read-work-rec 
                                   thru xc0-99-exit 
                    go to ad0-10-check-rec 
              else 
                next sentence. 
*             ENDIF 
*      ENDIF 
*      ENDIF 
*   ENDIF 
 
    perform ja0-process-work-rec  thru ja0-99-exit. 
 
    move wf-dept                       to hold-dept. 
    move wf-class-code                     to hold-class-code 
                                         ws-class-code(subs-dept-clinic,subs-class-code). 
    move wf-oma-cd                   to hold-oma-cd. 
    move wf-oma-code-ltr         to hold-oma-cd-ltr. 
 
    perform xc0-read-work-rec        thru xc0-99-exit. 
 
ad0-99-exit. 
    exit. 
ba0-oma-cd-break. 
 
    move total-indiv-oma-cd-mtd-svc     to ws-mtd-svc. 
    move total-indiv-oma-cd-mtd-amt       to ws-mtd-amt. 
    move total-indiv-oma-cd-ytd-svc       to ws-ytd-svc. 
    move total-indiv-oma-cd-ytd-amt       to ws-ytd-amt. 
* ( THIS IS THE TOTAL AMOUNT FOR THE DOCTOR (R051CA) ) 
*   ( THIS IS THE TOTAL AMOUNT FOR THE CLASS  (R051CB) ) 
    if parm-status = 1 
    then 
      move total-dept-doc-mtd-amt     to ws-mtd-sum-next-level 
        move total-dept-doc-ytd-amt     to ws-ytd-sum-next-level 
    else 
        move total-class-mtd-amt        to ws-mtd-sum-next-level 
        move total-class-ytd-amt        to ws-ytd-sum-next-level. 
*   ENDIF 
 
    perform xd0-calc-avg-perc         thru xd0-99-exit. 
    perform ba1-print-indiv-oma-cd-line        thru ba1-99-exit. 
    perform ba3-clear-indiv-totals     thru ba3-99-exit. 
 
ba0-99-exit. 
    exit. 
 
 
 
ba1-print-indiv-oma-cd-line. 
 
    move hold-oma-cd                  to l1-oma-cd 
                                       fee-oma-cd. 
    perform xm0-access-oma-fee-mstr       thru xm0-99-exit. 
    move fee-desc                      to l1-desc. 
    move total-indiv-oma-cd-mtd-svc  to l1-mtd-svc. 
    move total-indiv-oma-cd-mtd-amt       to l1-mtd-amt. 
    move total-indiv-oma-cd-ytd-svc       to l1-ytd-svc. 
    move total-indiv-oma-cd-ytd-amt       to l1-ytd-amt. 
 
    move ws-mtd-avg                       to l1-mtd-avg. 
    move ws-mtd-perc                      to l1-mtd-perc. 
    move ws-ytd-avg                      to l1-ytd-avg. 
    move ws-ytd-perc                      to l1-ytd-perc. 
 
    if ws-mtd-perc < zero 
    then 
        move '-'                        to l1-mtd-perc-sign 
    else 
     move '%'                        to l1-mtd-perc-sign. 
*   ENDIF 
 
    if ws-ytd-perc < zero 
    then 
  move '-'                        to l1-ytd-perc-sign 
    else 
     move '%'                        to l1-ytd-perc-sign. 
*   ENDIF 
 
    move 1                         to nbr-of-lines-to-print. 
 
    if parm-status = 1 
    then 
 perform xe0-write-print-line-a  thru xe0-99-exit 
    else 
        perform xf0-write-print-line-b  thru xf0-99-exit. 
*   ENDIF 
 
ba1-99-exit. 
    exit. 
 
 
 
ba3-clear-indiv-totals. 
 
    move zero                             to total-indiv-oma-cd-mtd-svc 
                                      total-indiv-oma-cd-mtd-amt 
                                      total-indiv-oma-cd-ytd-svc 
                                      total-indiv-oma-cd-ytd-amt. 
 
ba3-99-exit. 
    exit. 
da0-doc-nbr-break. 
 
* ( PRINT THE DOCTOR TOTALS ) 
*    ( MOVE DOCTOR VALUES TO CALCULATE VARIABLES ) 
    move total-dept-doc-mtd-svc            to ws-mtd-svc. 
    move total-dept-doc-mtd-amt           to ws-mtd-amt. 
    move total-dept-doc-ytd-svc           to ws-ytd-svc. 
    move total-dept-doc-ytd-amt           to ws-ytd-amt. 
* ( THIS IS THE TOTAL AMOUNT FOR THE DOCTOR ) 
    move total-dept-doc-mtd-amt              to ws-mtd-sum-next-level. 
    move total-dept-doc-ytd-amt                to ws-ytd-sum-next-level. 
    perform xd0-calc-avg-perc          thru xd0-99-exit. 
 
    move "   OF DOC"                   to h5-doc-dept-lit 
                                         h5-doc-dept-lit2. 
    move spaces                             to h5-ohip-code-desc-lit. 
    perform da1-print-doc-total-line   thru da1-99-exit. 
 
 
* 92/02/03 TRANSFER THIS PRINTING ONTO THE NEW REPORT R051CA_SUMM 
 
*     ( PRINT THE DOCTOR PERCENTAGE OF THE DEPARTMENT ) 
*      ( THIS IS THE TOTAL AMOUNT FOR THE CLASS ) 
    move total-class-mtd-amt          to ws-mtd-sum-next-level. 
    move total-class-ytd-amt           to ws-ytd-sum-next-level. 
 
    perform xd0-calc-avg-perc          thru xd0-99-exit. 
    move " OF CLASS"                   to h5-doc-dept-lit 
                                         h5-doc-dept-lit2. 
 
    move spaces                             to h5-ohip-code-desc-lit. 
    if summ-ctr-lines > summ-max-nbr-lines 
    then 
     perform xy0-headings-summ       thru xy0-99-exit. 
*   ENDIF 
 
    perform da2-print-doc-total-line  thru da2-99-exit. 
 
da0-99-exit. 
    exit. 
 
 
 
da1-print-doc-total-line. 
 
    move "DOCTOR"                        to t1-doc-lit. 
    move hold-doc-nbr                     to t1-doc-nbr. 
    move "TOTALS"                 to t1-total-lit. 
    move total-dept-doc-mtd-svc         to t1-mtd-svc. 
    move total-dept-doc-mtd-amt           to t1-mtd-amt. 
    move total-dept-doc-ytd-svc           to t1-ytd-svc. 
    move total-dept-doc-ytd-amt           to t1-ytd-amt. 
 
    move ws-mtd-avg                       to t1-mtd-avg. 
    move ws-mtd-perc                      to t1-mtd-perc. 
    move ws-ytd-avg                      to t1-ytd-avg. 
    move ws-ytd-perc                      to t1-ytd-perc. 
 
    if ws-mtd-perc < zero 
    then 
        move '-'                        to t1-mtd-perc-sign 
    else 
     move '%'                        to t1-mtd-perc-sign. 
*   ENDIF 
 
    if ws-ytd-perc < zero 
    then 
  move '-'                        to t1-ytd-perc-sign 
    else 
     move '%'                        to t1-ytd-perc-sign. 
*   ENDIF 
 
    move 2                         to nbr-of-lines-to-print. 
 
    move zero                          to ctr-lines. 
    perform xe0-write-print-line-a thru xe0-99-exit. 
 
da1-99-exit. 
    exit. 
da2-print-doc-total-line. 
 
    move "DOCTOR"                       to t1-doc-lit. 
    move hold-doc-nbr                     to t1-doc-nbr 
                                      doc-nbr. 
    perform xk0-access-doc-mstr              thru    xk0-99-exit. 
 
    perform xa1-doc-name-inits              thru    xa1-99-exit. 
    move ws-doc-name-inits          to      t1-total-lit. 
    move total-dept-doc-mtd-svc            to t1-mtd-svc. 
    move total-dept-doc-mtd-amt           to t1-mtd-amt. 
    move total-dept-doc-ytd-svc           to t1-ytd-svc. 
    move total-dept-doc-ytd-amt           to t1-ytd-amt. 
 
    move ws-mtd-avg                       to t1-mtd-avg. 
    move ws-mtd-perc                      to t1-mtd-perc. 
    move ws-ytd-avg                      to t1-ytd-avg. 
    move ws-ytd-perc                      to t1-ytd-perc. 
 
    if ws-mtd-perc < zero 
    then 
        move '-'                        to t1-mtd-perc-sign 
    else 
     move '%'                        to t1-mtd-perc-sign. 
*   ENDIF 
 
    if ws-ytd-perc < zero 
    then 
  move '-'                        to t1-ytd-perc-sign 
    else 
     move '%'                        to t1-ytd-perc-sign. 
*   ENDIF 
 
 
    write print-record-summ from print-line after advancing 2 lines. 
    add  2                             to summ-ctr-lines. 
    move spaces                               to print-line. 
 
da2-99-exit. 
    exit. 
ea0-dept-break-b. 
 
    move ws-dept-lit                       to h8-total-lit. 
    move "  OF DEPT"                    to h5-doc-dept-lit 
                                         h5-doc-dept-lit2. 
    move spaces                             to h5-ohip-code-desc-lit. 
 
*      ( THIS IS THE TOTAL AMOUNT FOR THE DEPT ) 
    move total-dept-doc-mtd-amt                to ws-mtd-sum-next-level. 
    move total-dept-doc-ytd-amt                to ws-ytd-sum-next-level. 
 
    perform la0-class-totals           thru la0-99-exit. 
 
*      ( PRINT THE DEPT TOTALS ) 
*      ( MOVE DEPT VALUES TO CALCULATE VARIABLES ) 
    move total-dept-doc-mtd-svc              to ws-mtd-svc. 
    move total-dept-doc-mtd-amt           to ws-mtd-amt. 
    move total-dept-doc-ytd-svc           to ws-ytd-svc. 
    move total-dept-doc-ytd-amt           to ws-ytd-amt. 
    perform xd0-calc-avg-perc             thru xd0-99-exit. 
 
    perform ea1-print-dept-total-line-b        thru ea1-99-exit. 
 
    move "OF CLINIC"                   to h5-doc-dept-lit 
                                         h5-doc-dept-lit2. 
 
*   ( PRINT THE DEPT PERCENTAGE OF THE CLINIC ) 
*    ( THIS IS THE TOTAL AMOUNT FOR THE CLINIC ) 
    move total-clinic-dept-mtd-amt   to ws-mtd-sum-next-level. 
    move total-clinic-dept-ytd-amt     to ws-ytd-sum-next-level. 
 
    perform la0-class-totals           thru la0-99-exit. 
 
    if subs-dept-clinic = subs-dept 
    then 
    perform la3-bump-totals         thru la3-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    move total-dept-doc-mtd-svc             to ws-mtd-svc. 
    move total-dept-doc-ytd-svc           to ws-ytd-svc. 
    move total-dept-doc-mtd-amt           to ws-mtd-amt. 
    move total-dept-doc-ytd-amt           to ws-ytd-amt. 
    move total-clinic-dept-mtd-amt        to ws-mtd-sum-next-level. 
    move total-clinic-dept-ytd-amt     to ws-ytd-sum-next-level. 
 
    perform xd0-calc-avg-perc          thru xd0-99-exit. 
 
    perform ea1-print-dept-total-line-b        thru ea1-99-exit. 
 
ea0-99-exit. 
    exit. 
 
 
 
ea1-print-dept-total-line-b. 
 
    move "** DEPARTMENT TOTALS **"    to t3-dept-lit. 
    move total-dept-doc-mtd-svc          to t3-mtd-svc. 
    move total-dept-doc-mtd-amt           to t3-mtd-amt. 
    move total-dept-doc-ytd-svc           to t3-ytd-svc. 
    move total-dept-doc-ytd-amt           to t3-ytd-amt. 
 
    move ws-mtd-avg                       to t3-mtd-avg. 
    move ws-mtd-perc                      to t3-mtd-perc. 
    move ws-ytd-avg                      to t3-ytd-avg. 
    move ws-ytd-perc                      to t3-ytd-perc. 
 
    if ws-mtd-perc < zero 
    then 
        move '-'                        to t3-mtd-perc-sign 
    else 
     move '%'                        to t3-mtd-perc-sign. 
*   ENDIF 
 
    if ws-ytd-perc < zero 
    then 
  move '-'                        to t3-ytd-perc-sign 
    else 
     move '%'                        to t3-ytd-perc-sign. 
*   ENDIF 
 
    if ctr-lines > 56 
    then 
      perform xb0-headings-b          thru xb0-99-exit 
        move 2                          to nbr-of-lines-to-print 
    else 
        move 3                          to nbr-of-lines-to-print. 
*   ENDIF 
 
    move zero                         to ctr-lines. 
    perform xf0-write-print-line-b thru xf0-99-exit. 
 
ea1-99-exit. 
    exit. 
fa0-dept-break. 
 
    move ws-dept-lit                      to h8-total-lit. 
    move "  OF DEPT"                    to h5-doc-dept-lit 
                                         h5-doc-dept-lit2. 
    move spaces                             to h5-ohip-code-desc-lit. 
 
    perform la0-class-totals           thru la0-99-exit. 
 
*   IF SUBS-DEPT-CLINIC = SUBS-DEPT 
*   THEN 
*   PERFORM LA3-BUMP-TOTALS         THRU LA3-99-EXIT. 
*   (ELSE) 
*   ENDIF 
 
    perform xs0-clear-class-tbl             thru xs0-99-exit 
        varying subs from 1 by 1 
        until   subs > const-nbr-classes + 1. 
 
*  ( PRINT THE DEPT TOTALS ) 
*      ( MOVE DEPT VALUES TO CALCULATE VARIABLES ) 
    move total-clinic-dept-mtd-svc   to ws-mtd-svc. 
    move total-clinic-dept-mtd-amt        to ws-mtd-amt. 
    move total-clinic-dept-ytd-svc        to ws-ytd-svc. 
    move total-clinic-dept-ytd-amt        to ws-ytd-amt. 
* ( THIS IS THE   TOTAL AMOUNT FOR THE DEPT ) 
    move total-clinic-dept-mtd-amt   to ws-mtd-sum-next-level. 
    move total-clinic-dept-ytd-amt     to ws-ytd-sum-next-level. 
 
    perform xd0-calc-avg-perc          thru xd0-99-exit. 
    perform fa1-print-dept-total-line  thru fa1-99-exit. 
 
fa0-99-exit. 
    exit. 
 
 
 
fa1-print-dept-total-line. 
 
    move "** DEPARTMENT TOTALS **"      to t2-dept-lit. 
    move total-clinic-dept-mtd-svc       to t2-mtd-svc. 
    move total-clinic-dept-mtd-amt        to t2-mtd-amt. 
    move total-clinic-dept-ytd-svc        to t2-ytd-svc. 
    move total-clinic-dept-ytd-amt        to t2-ytd-amt. 
 
    move ws-mtd-avg                       to t2-mtd-avg. 
    move ws-mtd-perc                      to t2-mtd-perc. 
    move ws-ytd-avg                      to t2-ytd-avg. 
    move ws-ytd-perc                      to t2-ytd-perc. 
 
    if ws-mtd-perc < zero 
    then 
        move '-'                        to t2-mtd-perc-sign 
    else 
     move '%'                        to t2-mtd-perc-sign. 
*   ENDIF 
 
    if ws-ytd-perc < zero 
    then 
  move '-'                        to t2-ytd-perc-sign 
    else 
     move '%'                        to t2-ytd-perc-sign. 
*   ENDIF 
 
    move 2                         to nbr-of-lines-to-print. 
    perform xe0-write-print-line-a     thru xe0-99-exit. 
 
fa1-99-exit. 
    exit. 
*HA0-OMA-CD-LTR-BREAK. 
 
*  ( PRINT THE OMA CODE LETTER TOTALS ) 
*   ( MOVE OMA CODE LETTER VALUES TO CALCULATE VARIABLES ) 
*    MOVE TOTAL-LTR-MTD-SVC               TO WS-MTD-SVC. 
*    MOVE TOTAL-LTR-MTD-AMT               TO WS-MTD-AMT. 
*    MOVE TOTAL-LTR-YTD-SVC               TO WS-YTD-SVC. 
*    MOVE TOTAL-LTR-YTD-AMT               TO WS-YTD-AMT. 
* ( THIS IS THE TOTAL AMOUNT FOR THE DOCTOR ) 
*    MOVE TOTAL-DEPT-DOC-MTD-AMT             TO WS-MTD-SUM-NEXT-LEVEL. 
*    MOVE TOTAL-DEPT-DOC-YTD-AMT               TO WS-YTD-SUM-NEXT-LEVEL. 
 
*    PERFORM XD0-CALC-AVG-PERC         THRU XD0-99-EXIT. 
*    PERFORM HA1-PRINT-OMA-CD-LTR-LINE THRU HA1-99-EXIT. 
 
*    MOVE ZERO                         TO TOTAL-LTR-MTD-SVC 
*                                      TOTAL-LTR-MTD-AMT 
*                                      TOTAL-LTR-YTD-SVC 
*                                      TOTAL-LTR-YTD-AMT. 
 
*HA0-99-EXIT. 
*    EXIT. 
 
 
 
*HA1-PRINT-OMA-CD-LTR-LINE. 
 
*    MOVE HOLD-OMA-CD-LTR                TO L2-LTR. 
*    MOVE '----'                              TO L2-DASHES. 
 
*    MOVE "TOTALS"                 TO L2-TOTAL-LIT. 
 
*    MOVE TOTAL-LTR-MTD-SVC             TO L2-MTD-SVC. 
*    MOVE TOTAL-LTR-MTD-AMT               TO L2-MTD-AMT. 
*    MOVE TOTAL-LTR-YTD-SVC               TO L2-YTD-SVC. 
*    MOVE TOTAL-LTR-YTD-AMT               TO L2-YTD-AMT. 
 
*    MOVE WS-MTD-AVG                      TO L2-MTD-AVG. 
*    MOVE WS-MTD-PERC                     TO L2-MTD-PERC. 
*    MOVE WS-YTD-AVG                     TO L2-YTD-AVG. 
*    MOVE WS-YTD-PERC                     TO L2-YTD-PERC. 
 
*    IF WS-MTD-PERC < ZERO 
*    THEN 
*     MOVE '-'                        TO L2-MTD-PERC-SIGN 
*    ELSE 
*   MOVE '%'                        TO L2-MTD-PERC-SIGN. 
*   ENDIF 
 
*    IF WS-YTD-PERC < ZERO 
*    THEN 
*       MOVE '-'                        TO L2-YTD-PERC-SIGN 
*    ELSE 
*   MOVE '%'                        TO L2-YTD-PERC-SIGN. 
*   ENDIF 
 
*    MOVE 2                                TO NBR-OF-LINES-TO-PRINT. 
 
*    IF PARM-STATUS = 1 
*    THEN 
*      PERFORM XE0-WRITE-PRINT-LINE-A  THRU XE0-99-EXIT 
*    ELSE 
*      PERFORM XF0-WRITE-PRINT-LINE-B  THRU XF0-99-EXIT. 
*   ENDIF 
 
*    ADD 2                            TO CTR-LINES. 
 
*    IF PARM-STATUS = 1 
*    THEN 
*  WRITE PRINT-RECORD-ONE          FROM BLANK-LINE AFTER ADVANCING 2 LINES 
*    ELSE 
*       WRITE PRINT-RECORD-TWO          FROM BLANK-LINE AFTER ADVANCING 2 LINES. 
*   ENDIF 
 
*HA1-99-EXIT. 
*    EXIT. 
ja0-process-work-rec. 
 
    add wf-mtd-svcs                       to total-indiv-oma-cd-mtd-svc 
                                      total-ltr-mtd-svc 
                                       ws-class-mtd-svc(subs-dept-clinic,subs-class-code). 
    add wf-mtd-amt                        to total-indiv-oma-cd-mtd-amt 
                                      total-ltr-mtd-amt  
                                      ws-class-mtd-amt(subs-dept-clinic,subs-class-code). 
    add wf-ytd-svcs                       to total-indiv-oma-cd-ytd-svc 
                                      total-ltr-ytd-svc  
                                      ws-class-ytd-svc(subs-dept-clinic,subs-class-code). 
    add wf-ytd-amt                        to total-indiv-oma-cd-ytd-amt 
                                      total-ltr-ytd-amt  
                                      ws-class-ytd-amt(subs-dept-clinic,subs-class-code). 
 
ja0-99-exit. 
    exit. 
la0-class-totals. 
 
    if subs-dept-clinic = subs-clinic 
    then 
      move 1                          to      h1-page-nbr 
    else 
     move ctr-pages                  to      h1-page-nbr. 
*   ENDIF 
 
    move ctr-report-pages               to      h1-report-page-nbr. 
 
    if parm-status = 1 
    then 
  write print-record-one from h1-head 
                                     after   advancing page 
  write print-record-one from h2-head 
                                     after   advancing 1 line 
        if flag-clinic-totals-y 
 then 
        write print-record-one from h8-head 
                                 after   advancing 2 lines 
           write print-record-one from h3-head 
                                 after   advancing 2 lines 
           write print-record-one from h4-head 
                                 after   advancing 1 line 
            write print-record-one from h5-head 
                                 after   advancing 1 line 
        else 
        write print-record-one from h6-head 
                                 after   advancing 2 lines 
           write print-record-one from h8-head 
                                 after   advancing 2 lines 
           write print-record-one from h3-head 
                                 after   advancing 2 lines 
           write print-record-one from h4-head 
                                 after   advancing 1 line 
            write print-record-one from h5-head 
                                 after   advancing 1 line 
    else 
        write print-record-two from h1-head 
                                     after   advancing page 
  write print-record-two from h2-head 
                                     after   advancing 1 line 
        if flag-clinic-totals-y 
 then 
        write print-record-two from h8-head 
                                 after   advancing 2 lines 
           write print-record-two from h3-head 
                                 after   advancing 2 lines 
           write print-record-two from h4-head 
                                 after   advancing 1 line 
            write print-record-two from h5-head 
                                 after   advancing 1 line 
        else 
        write print-record-two from h6-head 
                                 after   advancing 2 lines 
           write print-record-two from h8-head 
                                 after   advancing 2 lines 
           write print-record-two from h3-head 
                                 after   advancing 2 lines 
           write print-record-two from h4-head 
                                 after   advancing 1 line 
            write print-record-two from h5-head 
                                 after   advancing 1 line. 
*   ENDIF 
  
    move 10                          to      ctr-lines. 
    add 1                             to      ctr-pages. 
    add 1                             to      ctr-report-pages. 
 
    move 1                             to      subs-print-classes. 
 
la0-10-check-code. 
 
    if subs-print-classes > subs-max-nbr-classes 
    then 
   next sentence 
    else 
   perform la1-print-totals        thru    la1-99-exit 
     add 1                           to      subs-print-classes 
      go to la0-10-check-code. 
*   ENDIF 
 
*   IF SUBS-DEPT-CLINIC = SUBS-DEPT 
*   THEN 
*   PERFORM LA3-BUMP-TOTALS         THRU    LA3-99-EXIT. 
*   (ELSE) 
*   ENDIF 
 
la0-99-exit. 
    exit. 
la1-print-totals. 
 
    move ws-class-mtd-svc (subs-dept-clinic,subs-print-classes) 
                                   to      t2-mtd-svc 
                                              ws-mtd-svc. 
    move ws-class-mtd-amt (subs-dept-clinic,subs-print-classes) 
                                      to      t2-mtd-amt 
                                              ws-mtd-amt. 
    move ws-class-ytd-svc (subs-dept-clinic,subs-print-classes) 
                                      to      t2-ytd-svc        
                                               ws-ytd-svc. 
    move ws-class-ytd-amt (subs-dept-clinic,subs-print-classes) 
                                      to      t2-ytd-amt 
                                              ws-ytd-amt. 
 
    perform xd0-calc-avg-perc                thru    xd0-99-exit. 
 
    move ws-mtd-avg                 to      t2-mtd-avg. 
    move ws-ytd-avg                  to      t2-ytd-avg. 
 
    move ws-mtd-perc                 to      t2-mtd-perc. 
    move ws-ytd-perc                        to      t2-ytd-perc. 
 
    if ws-mtd-perc < zero 
    then 
   move '-'                        to      t2-mtd-perc-sign 
    else 
        move '%'                        to      t2-mtd-perc-sign. 
*   ENDIF 
 
    if ws-ytd-perc < zero 
    then 
     move '-'                        to      t2-ytd-perc-sign 
    else 
        move '%'                        to      t2-ytd-perc-sign. 
*   ENDIF 
 
    move ws-class-code(subs-dept-clinic,subs-print-classes) 
                                   to      t2-class-code. 
    move ': '                             to      t2-col. 
    move ws-class-code-desc(subs-dept-clinic,subs-print-classes) 
                                 to      t2-class-code-desc. 
 
    move 2                           to      nbr-of-lines-to-print. 
 
    if parm-status = 1 
    then 
    perform xe0-write-print-line-a  thru    xe0-99-exit 
    else 
     perform xf0-write-print-line-b  thru    xf0-99-exit. 
*   ENDIF 
 
la1-99-exit. 
    exit. 
la3-bump-totals. 
 
    move 'N'                         to      flag. 
    move 1                         to      subs-class-total. 
 
    if subs-present-nbr-classes not = zero 
    then 
     perform la31-search-class-tbl   thru    la31-99-exit 
            varying subs1 from 1 by 1 
               until   subs1 > subs-present-nbr-classes 
*                    OR WS-CLASS-CODE(SUBS-CLINIC,SUBS-CLASS-TOTAL) = SPACES 
                 or ok. 
*   (ELSE) 
*   ENDIF 
 
    if ok 
    then 
 next sentence 
    else 
   add 1                           to      subs-present-nbr-classes 
        if subs-present-nbr-classes > const-nbr-classes + 1 
     then 
        move 7                      to      err-ind 
     perform za0-common-error    thru    za0-99-exit 
         go to az0-end-of-job 
        else 
        move ws-class-code(subs-dept-clinic,subs-class-code) 
                                        to      ws-class-code(subs-clinic,subs-class-total) 
         move ws-class-code-desc(subs-dept-clinic,subs-class-code) 
                                   to      ws-class-code-desc(subs-clinic,subs-class-total). 
*      ENDIF 
*   ENDIF 
 
    add ws-class-mtd-svc(subs-dept-clinic,subs-class-code) 
                                        to      ws-class-mtd-svc(subs-clinic,subs-class-total). 
    add ws-class-mtd-amt(subs-dept-clinic,subs-class-code) 
                                       to      ws-class-mtd-amt(subs-clinic,subs-class-total). 
    add ws-class-ytd-svc(subs-dept-clinic,subs-class-code) 
                                       to      ws-class-ytd-svc(subs-clinic,subs-class-total). 
    add ws-class-ytd-amt(subs-dept-clinic,subs-class-code) 
                                       to      ws-class-ytd-amt(subs-clinic,subs-class-total). 
 
la3-99-exit. 
    exit. 
 
 
la31-search-class-tbl. 
 
    if ws-class-code(subs-dept-clinic,subs-class-code) = ws-class-code(subs-clinic,subs-class-total) 
    then 
  move 'Y'                        to      flag 
    else 
*   IF WS-CLASS-CODE(SUBS-CLINIC,SUBS-CLASS-TOTAL) = SPACES 
*        THEN 
*       NEXT SENTENCE 
*      ELSE 
        add 1                       to      subs-class-total. 
*      ENDIF 
*   ENDIF 
 
la31-99-exit. 
    exit. 
na0-check-class-code. 
 
    if hold-class-code not = wf-class-code 
    then 
    add 1                           to subs-class-code 
                                         subs-max-nbr-classes 
 perform xu0-new-class-head      thru xu0-99-exit. 
*   (ELSE) 
*   ENDIF 
 
na0-99-exit. 
    exit. 
xa0-headings-a. 
 
    move ctr-pages                     to      h1-page-nbr. 
    move ctr-report-pages           to      h1-report-page-nbr. 
    move "* PHYSICIAN REVENUE ANALYSIS *" 
                                    to      h1-title. 
    move hold-doc-nbr                  to      doc-nbr 
                                         h2a-doc-nbr. 
    perform xk0-access-doc-mstr             thru    xk0-99-exit. 
 
    perform xa1-doc-name-inits              thru    xa1-99-exit. 
    move ws-doc-name-inits          to      h2a-doc-name-inits. 
    move hold-dept                   to      h6-dept-nbr. 
 
    write print-record-one from h1-head after advancing page. 
    write print-record-one from h2-head after advancing 1 line. 
    write print-record-one from h6-head after advancing 2 lines. 
    write print-record-one from h7-head after advancing 1 line. 
    write print-record-one from h2a-head after advancing 2 lines. 
    write print-record-one from h3-head after advancing 1 line. 
    write print-record-one from h4-head after advancing 1 line. 
    write print-record-one from h5-head after advancing 1 line. 
 
    move 10                                to      ctr-lines.   
    add 1                           to      ctr-pages. 
    add 1                             to      ctr-report-pages. 
 
xa0-99-exit. 
    exit. 
 
 
 
xa1-doc-name-inits. 
 
    move spaces                                to      ws-doc-name-inits. 
 
    if doc-init3 not = spaces 
    then 
*    SMS 114 S.F.   STRING THE DOCTOR NAME WITH 2 SPACES RATHER THAN 1. 
*       STRING DOC-NAME                   DELIMITED BY SPACES, 
    string doc-name                 delimited by ws-xx, 
            " "                      delimited by size, 
             doc-init1                delimited by size, 
             "."                      delimited by size, 
             doc-init2                delimited by size, 
             "."                      delimited by size, 
             doc-init3                delimited by size, 
             "."                      delimited by size, 
                                      into    ws-doc-name-inits 
    else 
       if doc-init2 not = spaces 
       then 
*    SMS 114 S.F.   STRING THE DOCTOR NAME WITH 2 SPACES RATHER THAN 1. 
*           STRING DOC-NAME          DELIMITED BY SPACES, 
        string doc-name             delimited by ws-xx, 
         " "                         delimited by size, 
          doc-init1                   delimited by size, 
          "."                         delimited by size, 
          doc-init2                   delimited by size, 
          "."                         delimited by size, 
                                      into    ws-doc-name-inits 
       else 
        if doc-init1 not = spaces 
       then 
*    SMS 114 S.F.   STRING THE DOCTOR NAME WITH 2 SPACES RATHER THAN 1. 
*        STRING DOC-NAME         DELIMITED BY SPACES, 
            string doc-name         delimited by ws-xx, 
             " "                     delimited by size, 
              doc-init1               delimited by size, 
              "."                     delimited by size, 
                                      into    ws-doc-name-inits 
           else 
                move doc-name           to      ws-doc-name-inits. 
*         ENDIF 
*      ENDIF 
*   ENDIF 
 
xa1-99-exit. 
    exit. 
 
 
 
xb0-headings-b.  
 
    move ctr-pages                   to      h1-page-nbr. 
    move ctr-report-pages           to      h1-report-page-nbr. 
    move "* DEPARTMENT PRACTICE ANALYSIS *" 
                                  to      h1-title. 
 
*   MOVE HOLD-DEPT                     TO      DEPT-NBR 
*                                               H6-DEPT-NBR. 
*   PERFORM XI0-ACCESS-DEPT-MSTR    THRU    XI0-99-EXIT. 
*   MOVE DEPT-NAME                  TO      H6-DEPT-NAME. 
 
    write print-record-two from h1-head after advancing page. 
    write print-record-two from h2-head after advancing 1 line. 
    write print-record-two from h6-head after advancing 2 lines. 
    write print-record-two from h7-head after advancing 1 line. 
    write print-record-two from h3-head after advancing 2 lines. 
    write print-record-two from h4-head after advancing 1 line. 
    write print-record-two from h5-head after advancing 1 line. 
    move 9                                to      ctr-lines.   
    add 1                           to      ctr-pages. 
    add 1                             to      ctr-report-pages. 
 
xb0-99-exit. 
    exit. 
xc0-read-work-rec. 
 
    read r051-work-file 
        at end 
      move 'Y'                    to flag-end-work-rec 
        go to xc0-99-exit. 
 
    add 1                         to ctr-work-file-reads. 
 
    if wf-class-code = high-value 
    then 
        move spaces                     to wf-class-code. 
*   (ELSE) 
*   ENDIF 
 
xc0-99-exit. 
    exit. 
xd0-calc-avg-perc. 

* 2007/aug/08 - MC - reset ws-mtd-avg/perc and ws-ytd-avg/perc to 0
*		     before calculating for the record

    move zeros			to ws-mtd-avg
				   ws-mtd-perc
				   ws-ytd-avg
				   ws-ytd-perc.
* 2007/aug/08 - end
 
    divide ws-mtd-svc                       into ws-mtd-amt 
                                 giving ws-mtd-avg rounded. 
 
    divide ws-mtd-sum-next-level      into ws-mtd-amt 
                                 giving ws-mtd-perc rounded. 
 
    multiply ws-mtd-perc             by 100 
                                  giving ws-mtd-perc rounded. 
 
    divide ws-ytd-svc                        into ws-ytd-amt 
                                 giving ws-ytd-avg rounded. 
 
    divide ws-ytd-sum-next-level      into ws-ytd-amt 
                                 giving ws-ytd-perc rounded. 
 
    multiply ws-ytd-perc             by 100 
                                  giving ws-ytd-perc rounded. 
 
xd0-99-exit. 
    exit. 
xe0-write-print-line-a. 
 
    add nbr-of-lines-to-print           to      ctr-lines. 
 
    if ctr-lines > max-nbr-lines 
    then 
      move "   OF DOC"                to      h5-doc-dept-lit 
                                         h5-doc-dept-lit2 
        perform xa0-headings-a          thru    xa0-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    write print-record-one from print-line after advancing nbr-of-lines-to-print line. 
    move spaces                            to      print-line. 
 
xe0-99-exit. 
    exit. 
 
 
 
xf0-write-print-line-b. 
 
    add nbr-of-lines-to-print            to      ctr-lines. 
 
    if ctr-lines > max-nbr-lines 
    then 
      move " OF CLASS"                to      h5-doc-dept-lit 
                                         h5-doc-dept-lit2 
        perform xb0-headings-b          thru    xb0-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    write print-record-two from print-line after advancing nbr-of-lines-to-print line. 
    move spaces                            to      print-line. 
 
xf0-99-exit. 
    exit. 
*XI0-ACCESS-DEPT-MSTR. 
 
*   READ DEPT-MSTR 
*      INVALID KEY 
*        MOVE "UNKNOWN DEPARTMENT"   TO DEPT-NAME. 
 
*XI0-99-EXIT. 
*   EXIT. 
xk0-access-doc-mstr. 
 
    read doc-mstr 
       invalid key 
         move "UNKNOWN DOCTOR"       to doc-name. 
 
xk0-99-exit. 
    exit. 
xm0-access-oma-fee-mstr. 
 
    read oma-fee-mstr 
 invalid key 
         move "UNKNOWN CODE DESCRIPTION" 
                                     to fee-desc. 
 
xm0-99-exit. 
    exit. 
xp0-clinic-dept-total-rec. 
 
    move wf-mtd-svcs                        to total-clinic-dept-mtd-svc. 
    move wf-mtd-amt                        to total-clinic-dept-mtd-amt. 
    move wf-ytd-svcs                       to total-clinic-dept-ytd-svc. 
    move wf-ytd-amt                        to total-clinic-dept-ytd-amt. 
 
xp0-99-exit. 
    exit. 
 
 
 
xq0-dept-doc-total-rec. 
 
    move wf-mtd-svcs                   to total-dept-doc-mtd-svc. 
    move wf-mtd-amt                   to total-dept-doc-mtd-amt. 
    move wf-ytd-svcs                  to total-dept-doc-ytd-svc. 
    move wf-ytd-amt                   to total-dept-doc-ytd-amt. 
 
xq0-99-exit. 
    exit. 
xr0-class-tot-rec. 
 
    move wf-mtd-svcs                  to      total-class-mtd-svc. 
    move wf-mtd-amt                 to      total-class-mtd-amt. 
    move wf-ytd-svcs                        to      total-class-ytd-svc. 
    move wf-ytd-amt                 to      total-class-ytd-amt.  
 
xr0-99-exit. 
    exit. 
xs0-clear-class-tbl. 
 
    move spaces                          to ws-class-code(subs-dept-clinic,subs) 
                                    ws-class-code-desc(subs-dept-clinic,subs). 
 
    move zero                              to ws-class-mtd-svc(subs-dept-clinic,subs) 
                                         ws-class-mtd-amt(subs-dept-clinic,subs) 
                                         ws-class-ytd-svc(subs-dept-clinic,subs) 
                                         ws-class-ytd-amt(subs-dept-clinic,subs). 
 
xs0-99-exit. 
    exit. 
 
 
 
xt0-new-dept-head. 
 
    move wf-dept                      to h6-dept-nbr 
                                     dept-nbr. 
 
    read dept-mstr 
  invalid key 
*        MOVE 8                      TO ERR-IND 
*         PERFORM ZA0-COMMON-ERROR    THRU ZA0-99-EXIT 
            move 'UNKNOWN DEPT'         to dept-name. 
 
    move dept-name                 to h6-dept-name. 
 
xt0-99-exit. 
    exit. 
xu0-new-class-head. 
 
    move 1                             to subs. 
 
xu0-10-get-desc. 
 
    if wf-class-code = const-class-ltr(subs) 
    then 
    move const-class-desc(subs)     to h7-class-desc 
                                           ws-class-code-desc(subs-dept-clinic,subs-class-code) 
    else 
 if subs < const-nbr-classes 
     then 
        add 1                       to subs 
     go to xu0-10-get-desc 
       else 
        move 'UNKNOWN DESC'         to h7-class-desc 
                                           ws-class-code-desc(subs-dept-clinic,subs-class-code). 
*       ENDIF 
*   ENDIF 
 
    move wf-class-code                    to ws-class-code(subs-dept-clinic,subs-class-code) 
                                         h7-class. 
 
xu0-99-exit. 
    exit. 
 
xy0-headings-summ. 
 
    move summ-ctr-pages                     to      summ-page-nbr. 
    move "* PHYSICIAN REVENUE ANALYSIS *" 
                                 to      summ-title. 
 
    write print-record-summ from summ-head after advancing page. 
    write print-record-summ from h2-head after advancing 1 line. 
    write print-record-summ from h3-head after advancing 2 line. 
    write print-record-summ from h4-head after advancing 1 line. 
    write print-record-summ from h5-head after advancing 1 line. 
 
    move 6                           to      summ-ctr-lines. 
    add 1                                to      summ-ctr-pages. 
 
xy0-99-exit. 
    exit. 
 
 
 
za0-common-error. 
 
    move err-msg (err-ind)                to      err-msg-comment. 
    display err-msg-line. 
    display confirm. 
    stop " ". 
    display blank-line-24. 
 
za0-99-exit. 
    exit. 
 
    copy "y2k_default_sysdate_century.rtn".