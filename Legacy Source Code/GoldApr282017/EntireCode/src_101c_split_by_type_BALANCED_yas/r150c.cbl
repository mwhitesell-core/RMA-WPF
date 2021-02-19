identification    division. 
program-id.       r150c. 
author.           dyad computer systems inc. 
installation.     rma. 
date-written.     80/10/28. 
date-compiled. 
security. 
* 
*       files   : r150_srt_work_file   - sorted doctor work file 
*               : f020            - doc mstr 
*               : r150ca          - t4'S 
*               : r150cb          - t4 audit report 
*
*      program purpose : this program is the third in a series of 3 programs. 
*                        it uses the sorted work file produced by r150b 
*                        to print the t4'S AND T4 AUDIT REPORT. 
* 
* 
*      revision history: 
* 
*         may/82 (d.m.& i.w.)   - changed to access new doc master 
*                               - program renamed (was r022b) 
* 
*         feb 20/86 (m.s.)      - pdr 300 
*                               - three changes have to be made, and 
*                                 they are as follows: 
*                                 1. change "MCMASTER UNIVERSITY" to 
*                                           "REGIONAL MEDICAL ASSOCIATES" 
*                                 2. do not print income tax deducted 
*                                 3. fix the s.i.n. because it prints 
*                                    the same s.i.n. for each doctor 
* 
*         may 27/87 (s.b.)      - coversion from aos to aos/vs. 
*                                 change field size for 
*                                 status clause to 2 and 
*                                 feedback clause to 4. 
* 
*         feb 13/89 (s.f.)      - t4 forms have changed since 1987 
*                                 made necessary changes to fit new 
*                                 1988 forms 
* 
*   revised march/89 : - sms 115 s.f. 
*                      - make sure file status is pic xx ,feedback is 
*                        pic x(4) and infos status is pic x(11). 
* 
*    april 26/89  s. fader      - sms 116 
*                               - print the dept code and/or name 
* 
* 
*         feb 12/91 (m.c.)      - pdr 479 
*                               - change print format on t4a slips 
* 
* 
*         feb 11/92 (m.c.)      - pdr 547 
*                               - change print format on t4a slips 
* 
* 
*         feb 14/94 (m.c.)      - change print format on t4a slips 
*                               - linda norek requested the changes 
* 
*         feb 09/95 (b.e.)      - change print format on t4a slips 
*	 
*	  jan 15/96 (m.c.)	- allow negative value in earnings & 
*				  tax for each doctor level 
* 
*         feb 2/98  (j.c.)      - s149 unix conversion
*	  jan 15/99 (b.e.)	- new layout of t4a
* 
environment division. 
input-output section. 
file-control. 
 
 
    copy "f020_doctor_mstr.slr". 
 
 
    select doc-work-mstr 
         assign to  work-file-name 
          organization sequential 
          status is status-work-mstr. 
*mf          infos status is status-work-mstr. 
 
 
 
    select print-file 
          assign to printer print-file-name 
          file status is status-prt-file. 
 
    select  print-audit 
          assign to printer print-audit-name 
          file status is status-audit-file. 
data division. 
file section. 
 
    copy "f020_doctor_mstr.fd". 
* 
    copy "r150_chq_doc_mstr.fd". 
* 
 
fd  print-file 
    record contains 132 characters. 
01  prt-line                            pic x(132). 
 
fd  print-audit 
    record contains 132  characters. 
01  prt-audit                           pic x(132). 
 
working-storage section. 
 
*   status file indicators 
*mf 77  status-work-mstr                        pic x(11) value zero. 
*mf 77  common-status-file                      pic x(11) value zero. 
*mf 77  status-doc-mstr                         pic x(11) value zero. 
77  status-audit-file                           pic xx    value zero. 
77  status-prt-file                             pic xx    value zero. 
 
77  common-status-file                         pic x(2) value zero. 
77  status-cobol-doc-mstr                      pic x(2) value zero. 
77  status-work-mstr                           pic x(2) value zero. 

*   flag indicators 
77  err-ind                                     pic 99  value zero. 
 
01  flag-pcode-write                            pic x    value "N". 
    88  write-pcode                             value  "Y". 
    88  not-write-pcode                         value  "N". 
 
01  flag-work-file                              pic x   value "N". 
    88  not-eof-wk-file                         value "N". 
    88  end-wk-file                             value "Y". 
 
01  flag-address                                pic x   value  "Y". 
    88  not-found-addr                          value  "N". 
    88  found-addr                              value  "Y". 
 
01  flag-doc-file                               pic x   value "Y". 
    88  found-doc-nbr                           value "Y". 
    88  not-found-doc-nbr                       value "N". 
 
*  variables 
77  flag-audit-reach-100                        pic x      value "N". 
77  ws-init-name                                pic x(30). 
77  ws-reply                                    pic x. 
77  max-nbr-lines                               pic 99     value 55. 
77  flag-audit-max-writes                       pic 999    value 100. 
 
 
01  ws-initials. 
    05  ws-1st-init. 
        10  ws-init1                            pic x. 
        10  ws-dot1                             pic x. 
    05  ws-2cd-init. 
        10  ws-init2                            pic x. 
        10  ws-dot2                             pic x. 
    05  ws-3rd-init. 
        10  ws-init3                            pic x. 
        10  ws-dot3                             pic x. 
 
01  counters. 
    05  ctr-page                                pic 9999. 
    05  ctr-line                                pic 99. 
    05  ctr-doc-mstr-reads                      pic 9(7). 
    05  ctr-wk-file-reads                       pic 9(7). 
    05  ctr-audit-writes                        pic 9(7). 
    05  ctr-t4-writes                           pic 9(7). 
    05  ctr-flag-audit-writes                   pic 9(7). 
 
* totals 
01  totals. 
    05  total-tax                               pic s9(6)v99. 
    05  total-earnings                          pic s9(8)v99. 
    05  grand-total-tax                         pic s9(8)v99. 
    05  grand-total-earnings                    pic s9(9)v99. 
 
 
* hold area. 
01  hold-area. 
    05  hold-doc-nbr                            pic 9(3). 
    05  hold-doc-name                           pic x(24). 
    05  hold-inits. 
        10  hold-inits-1                        pic x. 
        10  hold-inits-2                        pic x. 
        10  hold-inits-3                        pic x. 
    05  hold-earnings                           pic s9(6)v99. 
    05  hold-tax                                pic s9(5)v99. 
    05  hold-sin-nbr. 
        10  hold-sin-123                        pic 999. 
        10  hold-sin-456                        pic 999. 
        10  hold-sin-789                        pic 999. 
 
 
01  print-file-name. 
    05  printer-file-name                       pic x(6)     value "r150ca". 
 
 
 
01  print-audit-name. 
    05  printer-audit-name                      pic x(6)     value "r150cb". 
 
 
 
01  work-file-name. 
    05  filler                                  pic x(18)    value "r150_srt_work_mstr". 
 
01  blank-line                                  pic x(132)   value spaces. 
 
copy "sysdatetime.ws". 
 
01  head-audit-1. 
    05  filler                                  pic x(7)        value "R150CB/". 
    05  head-aud-clinic-nbr                     pic 99. 
    05  filler                                  pic x(35)       value spaces. 
    05  filler                                  pic x(52)       value "T4  AUDIT  REPORT". 
    05  filler                                  pic x(12)       value "RUN  DATE   ". 
* (y2k)
    05  head-aud-date. 
* (y2k)
        10  head-aud-yy                         pic 99. 
        10  filler                              pic x           value "/". 
        10  head-aud-mm                         pic 99. 
        10  filler                              pic x           value "/". 
        10  head-aud-dd                         pic 99bbbbb. 
    05  filler                                  pic x(5)        value "PAGE ". 
    05  aud-head-page                           pic zzz9. 
 
 
01  head-audit-2. 
    05  filler                                  pic x(23)       value spaces. 
    05  filler                                  pic x(13)       value "DEPARTMENT". 
    05  filler                                  pic x(24)       value "DOCTOR". 
    05  filler                                  pic x(25)       value "DOCTOR". 
    05  filler                                  pic x(14)       value "TOTAL". 
    05  filler                                  pic x(33)       value "INCOME TAX". 
 
 
01  head-audit-3. 
    05  filler                                  pic x(27)       value spaces. 
    05  filler                                  pic x(11)       value "#". 
    05  filler                                  pic x(23)       value "#". 
    05  filler                                  pic x(23)       value "NAME". 
    05  filler                                  pic x(16)       value "EARNINGS". 
    05  filler                                  pic x(32)       value "DEDUCTED". 
 
*01  detail-account-nbr. 
*    05  filler                                  pic x(57)       value spaces. 
*    05  filler                                  pic x(10)       value "ZZF554234". 
 
01  detail-doc-name. 
    05  filler                                  pic x(5)        value spaces. 
    05  d2-doc-name                             pic x(15). 
    05  filler                                  pic x(2)        value spaces. 
    05  d2-doc-lit                              pic x(4). 
    05  d2-init. 
        10  d2-init-1                           pic x. 
        10  d2-init-1-per                       pic x. 
        10  d2-init-2                           pic x. 
        10  d2-init-2-per                       pic x. 
        10  d2-init-3                           pic x. 
        10  d2-init-3-per                       pic x. 
    05  filler                                  pic x           value spaces. 
    05  d2-doc-nbr                              pic 999. 
    05  filler                                  pic x(8)        value spaces. 
*   (1999/jan)
*   05  filler                                  pic x(30)       value "REGIONAL MEDICAL ASSOCIATES". 
 
01  detail-addr-1. 
    05  filler                                  pic x(5)        value spaces. 
    05  d1-addr-1                               pic x(24). 
    05  filler                                  pic x(103)    value spaces. 
 
 
01  detail-addr-2. 
    05  filler                                  pic x(5)        value spaces. 
    05  d2-addr-2                               pic x(24). 
*   05  filler                                  pic x(14)       value spaces. 
    05  filler                                  pic x(103)      value spaces. 
*   05  filler                                  pic x(89)       value "ZZF554234". 
 
 
01  detail-addr-3. 
    05  filler                                  pic x(5)        value spaces. 
    05  d3-addr-3                               pic x(24). 
    05  d3-pcode  redefines d3-addr-3. 
        10  d3-pcode-1                          pic x. 
        10  d3-pcode-2                          pic x. 
        10  d3-pcode-3                          pic x. 
        10  d3-split                            pic x. 
        10  d3-pcode-4                          pic x. 
        10  d3-pcode-5                          pic x. 
        10  d3-pcode-6                          pic x(18). 
    05  filler                                  pic x(103)      value spaces. 
 
 
01  detail-addr-4. 
    05  filler                                  pic x(5)        value spaces. 
*   (1999/jan)
*   05  d4-pcode. 
*       10  d4-pcode-1                          pic x. 
*       10  d4-pcode-2                          pic x. 
*       10  d4-pcode-3                          pic x. 
*       10  d4-split                            pic x. 
*       10  d4-pcode-4                          pic x. 
*       10  d4-pcode-5                          pic x. 
*       10  d4-pcode-6                          pic x. 
*   05  filler                                  pic x(120)      value spaces. 
    05  filler					pic x(39)	value spaces.
    05  filler                                  pic x(90)       value "REGIONAL MEDICAL ASSOCIATES". 
 
01  detail-amt-6. 
*       (1998/jan)
*   05  filler                                  pic x(62)       value spaces. 
    05  d6-earnings                             pic zzz,zz9.99-. 
*   05  filler                                  pic x(60)       value spaces. 
    05  filler                                  pic x(122)      value spaces. 
 
01  detail-soc-nbr. 
*   05  filler                                  	pic x(42)       value spaces. 
*       (1999/jan)
*   05  filler                                  	pic x(53)       value spaces. 
    05  filler                                  pic x(11)       value spaces. 
    05  det-sin. 
        10  det-sin-123                         pic 999. 
        10  filler                              pic x           value spaces. 
        10  det-sin-456                         pic 999. 
        10  filler                              pic x           value spaces. 
        10  det-sin-789                         pic 999. 
*   05  filler                                  	pic x(80)       value spaces. 
*       (1999/jan)
*   05  filler                                  	pic x(68)       value spaces. 
    05  filler                                  pic x(38)       value spaces. 
    05  filler                                  pic x(10)       value "ZZF554234". 
 
** this is added on feb  12/91 for pdr 479 
*01  detail-acct-no. 
*    05  filler                                  pic x(44)       value spaces. 
*    05  filler                                  pic x(88)       value "ZZF554234". 
 
 
01  detail-aud-1. 
 
    05  filler                                  pic x(26)       value spaces. 
    05  d1-aud-doc-dept                         pic 99. 
    05  filler                                  pic x(9)        value spaces. 
*   05  d1-aud-doc-nbr                          pic zz9. 
    05  d1-aud-doc-nbr                          pic 999. 
    05  filler                                  pic x(13)       value spaces. 
    05  d1-aud-doc-init                         pic x(6). 
    05  filler                                  pic x           value spaces. 
    05  d1-aud-doc-name                         pic x(16). 
    05  filler                                  pic x(7)        value spaces. 
    05  d1-aud-earn                             pic zzz,zz9.99-. 
    05  filler                                  pic x(6)        value spaces. 
    05  d1-aud-tax                              pic zz,zz9.99-. 
    05  filler                                  pic x(24)       value spaces. 
 
 
01  tot-audit. 
 
    05  filler                                  pic x(64)       value spaces. 
    05  tot-message                             pic x(12). 
    05  filler                                  pic x(3)        value spaces. 
    05  tot-aud-earn                            pic zzz,zzz,zz9.99bb. 
    05  tot-aud-tax                             pic  zz,zzz,zz9.99b. 
    05  tot-stars                               pic x(23). 
 
01  error-message-table. 
 
    05  error-messages. 
        10  filler                              pic x(60)       value 
                "ERROR NO WORK FILE SUPPLIED". 
        10  filler                              pic x(60)       value 
                "DOCTOR # NOT FOUND IN DOC-MSTR". 
        10  filler                              pic x(60)       value 
                "ERR MESS #3 GOES HERE". 
 
    05  error-messages-r redefines error-messages. 
        10  err-msg                             pic x(60) 
                        occurs 3 times. 
 
01  err-msg-comment                             pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word                           pic x(13)      value 
                "***  ERROR - ". 
    05  e1-error-msg                            pic x(119). 
screen section. 
 
01  program-in-progress. 
    05  blank screen. 
    05  line 01 col 01  value is "R150C". 
    05  line 01 col 25  value is "T4 AND AUDIT STATEMENTS REPORT". 
* (y2k - auto fix)
*   05  line 01 col 70  pic 99 from sys-yy. 
    05  line 01 col 70  pic 9(4) from sys-yy. 
    05  line 01 col 72  value is "/". 
    05  line 01 col 73  pic 99 from sys-mm. 
    05  line 01 col 75  value is "/". 
    05  line 01 col 76  pic 99 from sys-dd. 
    05  line 10 col 25  value is "PART 3 - PRINT T4 AND AUDIT STATEMENTS". 
    05  line 13 col 30 value "PROGRAM R150C IN PROGRESS". 
 
01  confirm. 
    05  line 23 col 01  value " ". 
 
01  blank-screen. 
    05  blank screen. 
 
01  file-status-display. 
    05  line 24 col 56 value "FILE STATUS = ". 
*mf    05  line 24 col 70 pic x(11) from common-status-file  bell blink. 
    05  line 24 col 70 pic x(2) from common-status-file  bell blink. 
 
01  err-msg-line. 
    05  line 24 col 01 value " ERROR - "  bell blink. 
    05  line 24 col 11 pic x(60) from err-msg-comment. 
 
01  blank-line-24. 
    05  line 24 col 1 blank line. 
 
01  blank-screen. 
    05  blank screen. 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line 6 col 20  value "NUMBER OF CHQ-DOC WORK READS    = ". 
    05  line 6 col 60  pic z(6)9 using ctr-wk-file-reads. 
    05  line 7 col 20  value "NUMBER OF DOC-MSTR READS        = ". 
    05  line 7 col 60  pic z(6)9 using ctr-doc-mstr-reads. 
    05  line 8 col 20  value "NUMBER OF T4 REPORT WRITES      = ". 
    05  line 8 col 60  pic z(6)9 using ctr-t4-writes. 
    05  line 9 col 20  value "NUMBER OF AUDIT REPORT WRITES   = ". 
    05  line 9 col 60  pic z(6)9 using ctr-audit-writes. 
    05  line 21 col 20  value "PROGRAM R150C ENDING". 
* (y2k - auto fix)
*   05  line 21 col 42  pic 99 using sys-yy. 
    05  line 21 col 42  pic 9(4) using sys-yy. 
    05  line 21 col 44  value "/". 
    05  line 21 col 45  pic 99  using sys-mm. 
    05  line 21 col 47  value "/". 
    05  line 21 col 48  pic 99  using sys-dd. 
    05  line 21 col 50  pic z9  using sys-hrs. 
    05  line 21 col 52  value ":". 
    05  line 21 col 53  pic 99  using sys-min. 
    05  line 22 col 20  value "REPORTS ARE FOUND IN". 
    05  line 22 col 42  pic x(6) using print-file-name . 
    05  line 23 col 42  pic x(6) using print-audit-name . 
procedure division. 
declaratives. 
 
err-doc-mstr-file section. 
    use after standard error procedure on doc-mstr. 
err-doc-mstr. 
    stop "ERROR IN ACCESSING DOCTOR MASTER ". 
*mf    move status-doc-mstr                        to common-status-file. 
    move status-cobol-doc-mstr                     to common-status-file. 
    display file-status-display. 
    stop run. 
 
err-doc-work-mstr-file section. 
    use after standard error procedure on  doc-work-mstr. 
err-doc-work-mstr. 
    stop "ERROR IN ACCESSING DOCTOR WORK MASTER". 
    move status-work-mstr                       to common-status-file. 
    display file-status-display. 
    stop run. 
 
end declaratives. 
 
 
mainline section. 
 
    perform aa0-initialization                  thru aa0-99-exit. 
    perform  ab0-mainline                       thru ab0-99-exit 
                                                until end-wk-file. 
    perform az0-end-of-job                      thru az0-99-exit. 
    stop run. 
aa0-initialization. 
 
* (y2k)
    accept  sys-date                    from    date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
* (y2k)
    move    sys-yy                      to      run-yy 
* (y2k)
                                                head-aud-yy. 
    move    sys-mm                      to      run-mm 
                                                head-aud-mm. 
    move    sys-dd                      to      run-dd 
                                                head-aud-dd. 
 
    accept  sys-time                    from    time. 
    move    sys-hrs                     to      run-hrs. 
    move    sys-min                     to      run-min. 
    move    sys-sec                     to      run-sec. 
 
*    expunge   print-audit 
*mf              print-file. 
 
    open     input  doc-mstr 
                    doc-work-mstr. 
    open    output  print-file 
                    print-audit. 
    display program-in-progress. 
 
 
    move spaces                         to      prt-line 
                                                prt-audit 
                                                blank-line 
                                                hold-doc-name 
                                                hold-inits. 
 
    move zero                           to      counters 
                                                totals 
                                                hold-doc-nbr 
                                                hold-tax 
                                                hold-earnings. 
 
    move 90                             to      ctr-line. 
 
    read doc-work-mstr 
             at end 
                move  1                 to      err-ind 
                move "Y"                to      flag-work-file 
                perform za0-common-error 
                                        thru    za0-99-exit 
                go to az0-10-continue. 
 
    add 1                               to      ctr-wk-file-reads. 
 
 
    if not-eof-wk-file 
    then 
        move wk-doc-clinic-nbr          to      head-aud-clinic-nbr 
        move wk-doc-inits               to      hold-inits 
        move wk-doc-name                to      hold-doc-name 
        move wk-doc-nbr                 to      hold-doc-nbr 
        move wk-doc-earnings            to      hold-earnings 
        move wk-doc-tax-ded             to      hold-tax 
        move wk-sin                     to      hold-sin-nbr 
        perform xa0-read-wk-file        thru    xa0-99-exit. 
*   (else) 
*   endif 
 
aa0-99-exit. 
  exit. 
ab0-mainline. 
 
    if wk-doc-nbr = hold-doc-nbr 
    then 
        add wk-doc-earnings             to      hold-earnings 
        add wk-doc-tax-ded              to      hold-tax 
    else 
        perform bb0-print-reports       thru    bb0-99-exit 
        perform cb0-clear-hold-area     thru    cb0-99-exit 
        perform cb1-move-rec-to-hold    thru    cb1-99-exit. 
*   endif 
 
ab0-10-continue. 
    perform xa0-read-wk-file            thru    xa0-99-exit. 
 
ab0-99-exit. 
   exit. 
 
bb0-print-reports. 
 
    move "Y"                            to      flag-doc-file. 
    move hold-doc-nbr                   to      doc-nbr. 
 
    perform  xb0-read-doc-mstr          thru    xb0-99-exit. 
 
    perform bc0-print-t4                thru    bc0-99-exit. 
    perform bd0-print-audit             thru    bd0-99-exit. 
 
bb0-99-exit. 
    exit. 
bc0-print-t4. 
 
    move "N"                            to      flag-pcode-write. 
 
    write  prt-line  from  blank-line  after page. 
 
    add hold-earnings, hold-tax         giving  d6-earnings. 

*   (1999/jan/15) 
*   write prt-line from detail-amt-6    after  1  lines. 
    write prt-line from detail-amt-6    after  5  lines. 
 
 
*   (the following 2 lines are commented on 86/02/20 by m.s., 
*    do not print income tax deducted on t4a slips.) 
*   move hold-tax                       to      d7-tax. 
*   write prt-line  from detail-amt-7 after 3 lines. 
 
    move hold-sin-123                   to      det-sin-123. 
    move hold-sin-456                   to      det-sin-456. 
    move hold-sin-789                   to      det-sin-789. 
 
    write  prt-line  from  detail-soc-nbr   after  3  lines. 

*   (1999/jan) 
    write prt-line from detail-addr-4 after 2 line. 
*    write prt-line from detail-account-nbr  after  3  lines. 
 
    move "DR. "                         to      d2-doc-lit. 
    move hold-doc-nbr                   to      d2-doc-nbr. 
 
    move spaces                         to      ws-init-name 
                                                ws-initials. 
 
    if hold-inits-1  not = spaces 
    then 
        move doc-init1                  to      ws-init1 
        move "."                        to      ws-dot1. 
*   (else) 
*   endif 
 
    if hold-inits-2 not = spaces 
    then 
        move doc-init2                  to      ws-init2 
        move "."                        to      ws-dot2. 
*   (else) 
*   endif 
 
    if hold-inits-3 not = spaces 
    then 
        move doc-init3                  to      ws-init3 
        move "."                        to      ws-dot3. 
*   (else) 
*   endif 
    string      ws-1st-init delimited by spaces, 
                ws-2cd-init delimited by spaces, 
                ws-3rd-init delimited by spaces, 
                        into ws-init-name. 
    move ws-init-name                   to      d2-init. 
    move hold-doc-name                  to      d2-doc-name. 
 
    write prt-line  from  detail-doc-name  after 1 lines. 
 
    move doc-addr-home-1                to      d1-addr-1. 
    write prt-line from detail-addr-1   after   1 line. 
 
 
    move doc-addr-home-2                to      d2-addr-2. 
 
    write prt-line from detail-addr-2 after 1 line. 
 
 
    if doc-addr-home-3  not = spaces 
    then 
        move doc-addr-home-3            to      d3-addr-3 
    else 
        if    doc-addr-home-pc  not = spaces 
          and doc-addr-home-pc  not = " 0 0 0" 
        then 
            move spaces                 to      d3-split 
            move doc-addr-home-pc1      to      d3-pcode-1 
            move doc-addr-home-pc2      to      d3-pcode-2 
            move doc-addr-home-pc3      to      d3-pcode-3 
            move doc-addr-home-pc4      to      d3-pcode-4 
            move doc-addr-home-pc5      to      d3-pcode-5 
            move doc-addr-home-pc6      to      d3-pcode-6 
            move "Y"                    to      flag-pcode-write 
        else 
            move spaces                 to      d3-addr-3 
            move "Y"                    to      flag-pcode-write. 
*       endif 
*   endif 
    write prt-line  from detail-addr-3 after 1 line. 
 
 
*   (1999/jan)
*   if write-pcode 
*   then 
*       move spaces                     to      d4-pcode 
*   else 
*       if    doc-addr-home-pc not = spaces 
*         and  doc-addr-home-pc not = " 0 0 0" 
*       then 
*           move spaces                 to      d4-split 
*           move doc-addr-home-pc1      to      d4-pcode-1 
*           move doc-addr-home-pc2      to      d4-pcode-2 
*           move doc-addr-home-pc3      to      d4-pcode-3 
*           move doc-addr-home-pc4      to      d4-pcode-4 
*           move doc-addr-home-pc5      to      d4-pcode-5 
*           move doc-addr-home-pc6      to      d4-pcode-6 
*       else 
*           move spaces                 to      d4-pcode. 
*       endif 
**  endif 
*   write prt-line from detail-addr-4 after 1 line. 
 
bc0-10-continue. 
 
*   write prt-line from detail-addr-5 after 1 line. 
 
 
    add 1                               to      ctr-t4-writes. 
 
bc0-99-exit. 
  exit. 
 
bd0-print-audit. 
 
    perform be0-move-write-audit        thru    be0-99-exit. 
 
    if  ctr-flag-audit-writes = flag-audit-max-writes 
     or ctr-flag-audit-writes > flag-audit-max-writes 
     or end-wk-file 
    then 
        perform bf0-sub-totals          thru    bf0-99-exit. 
*   (else) 
*   endif 
 
bd0-99-exit. 
    exit. 
 
be0-move-write-audit. 
 
    if ctr-line > max-nbr-lines 
    then 
        perform xc0-headings            thru    xc0-99-exit. 
*   (else) 
*   endif 
 
    if not-found-doc-nbr 
    then 
        move "******"                   to      d1-aud-doc-init 
        move "UNKNOWN DOCTOR  "         to      d1-aud-doc-name 
*mf        move "*"                        to      d1-aud-doc-dept 
        move zero                       to      d1-aud-doc-dept 
    else 
        move hold-doc-name              to      d1-aud-doc-name 
        perform be1-inits               thru    be1-99-exit 
        move doc-dept                   to      d1-aud-doc-dept. 
*   endif 
 
    move hold-doc-nbr                   to      d1-aud-doc-nbr. 
    move hold-tax                       to      d1-aud-tax. 
 
*    (for the purposes of the report earnings are added to tax 
*     to obtain gross earnings.) 
 
    add hold-earnings, hold-tax         giving  d1-aud-earn. 
 
    write prt-audit from detail-aud-1 after 1 line. 
 
    add hold-tax                        to      total-earnings. 
    add hold-earnings                   to      total-earnings. 
    add hold-tax                        to      total-tax. 
    add 1                               to      ctr-audit-writes 
                                                ctr-line 
                                                ctr-flag-audit-writes. 
be0-99-exit. 
  exit. 
 
 
 
be1-inits. 
 
    move spaces                         to      ws-initials. 
 
    if hold-inits-1 not = spaces 
    then 
        move hold-inits-1               to      ws-init1 
        move "."                        to      ws-dot1. 
*   (else) 
*   endif 
 
    if hold-inits-2 not = spaces 
    then 
        move hold-inits-2               to      ws-init2 
        move "."                        to      ws-dot2. 
*   (else) 
*   endif 
 
    if hold-inits-3 not = spaces 
    then 
        move hold-inits-3               to      ws-init3 
        move "."                        to      ws-dot3. 
*   (else) 
*   endif 
 
    string      ws-1st-init delimited by spaces, 
                ws-2cd-init delimited by spaces, 
                ws-3rd-init delimited by spaces, 
                        into ws-init-name. 
 
    move ws-init-name                   to      d1-aud-doc-init. 
 
be1-99-exit. 
    exit. 
 
 
bf0-sub-totals. 
    add total-earnings                  to      grand-total-earnings. 
    add total-tax                       to      grand-total-tax. 
    move "  SUB  TOTAL"                 to      tot-message. 
    move total-earnings                 to      tot-aud-earn. 
    move total-tax                      to      tot-aud-tax. 
    move "*"                            to      tot-stars. 
    move zero                           to      total-earnings 
                                                total-tax 
                                                ctr-flag-audit-writes. 
 
    write prt-audit from tot-audit after 2 lines. 
    move 90                             to      ctr-line. 
bf0-99-exit. 
   exit. 
cb0-clear-hold-area. 
 
    move zero                           to      hold-earnings 
                                                hold-tax 
                                                hold-sin-nbr 
                                                hold-doc-nbr. 
 
    move spaces                         to      hold-inits 
                                                hold-doc-name. 
 
cb0-99-exit. 
  exit. 
 
 
cb1-move-rec-to-hold. 
 
    move wk-doc-nbr                     to      hold-doc-nbr. 
    move wk-doc-inits                   to      hold-inits. 
    move wk-doc-name                    to      hold-doc-name. 
    move wk-doc-earnings                to      hold-earnings. 
    move wk-doc-tax-ded                 to      hold-tax. 
 
*   (the following statement is added on 86/02/20 by m.s., 
*    this will print different sin for each doctor.) 
 
    move wk-sin                         to      hold-sin-nbr. 
 
cb1-99-exit. 
   exit. 
xa0-read-wk-file. 
 
    read doc-work-mstr next 
         at end 
            move "Y"                    to      flag-work-file 
            go to az0-end-of-job. 
    add 1                               to      ctr-wk-file-reads. 
 
xa0-99-exit. 
   exit. 
 
 
xb0-read-doc-mstr. 
 
    read doc-mstr 
        invalid key 
                move 2                  to      err-ind 
                move "N"                to      flag-doc-file 
                perform za0-common-error 
                                        thru    za0-99-exit 
                move 0                  to      err-ind 
                move spaces             to      doc-mstr-rec 
                go to xb0-99-exit. 
    add 1                               to      ctr-doc-mstr-reads. 
 
xb0-99-exit. 
   exit. 
 
 
xc0-headings. 
 
    add 1                                       to      ctr-page. 
    move ctr-page                               to      aud-head-page. 
    write prt-audit  from head-audit-1 after advancing page. 
    write prt-audit  from head-audit-2 after 2 lines. 
    write prt-audit  from head-audit-3 after 1 line. 
    write prt-audit  from blank-line   after 1 line. 
    move 5                                      to      ctr-line. 
 
xc0-99-exit. 
   exit. 
za0-common-error. 
 
    move err-msg (err-ind)                      to      err-msg-comment. 
    display confirm. 
    display err-msg-line. 
    stop " ". 
 
za0-99-exit. 
   exit. 
 
 
az0-end-of-job. 
 
    perform bb0-print-reports                   thru    bb0-99-exit. 
 
 
    move "FINAL  TOTAL"                         to      tot-message. 
    move grand-total-earnings                   to      tot-aud-earn. 
    move grand-total-tax                        to      tot-aud-tax. 
    move "**"                                   to      tot-stars. 
    write prt-audit from tot-audit after 2 lines. 
 
az0-10-continue. 
 
    close   print-file 
            print-audit 
            doc-mstr 
            doc-work-mstr. 
 
*    expunge doc-work-mstr. 
* (y2k)
    accept  sys-date                            from    date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    accept  sys-time                            from    time. 
    display scr-closing-screen. 
    display confirm. 
    stop run. 
 
az0-99-exit. 
  exit. 
 

    copy "y2k_default_sysdate_century.rtn".
