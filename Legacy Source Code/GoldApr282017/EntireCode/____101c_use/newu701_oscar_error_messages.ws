
* $use/newu701_oscar_error_messages.ws - this copybook is used in newu701.cbl & u701oscar.cbl

01  error-message-table. 
 
    05  error-messages. 
* #1 
        10  filler. 
            15  err-warn-msg                    pic x(14)  value spaces.
            15  filler                          pic x(08)  value 
                "Batch = ". 
            15  err-msg-pract-nbr               pic x(06). 
            15  filler                          pic x(01)  value "/". 
            15  err-msg-account-id              pic x(08). 
            15  filler                          pic x(95)  value spaces. 
* #2 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(43)  value 
                "**ERROR** - NO SUCH DOCTOR FOUND ON FILE - ". 
            15  err-msg-doc-nbr                 pic x(03). 
            15  filler                          pic x(72)  value spaces. 
* #3 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(61)  value 
                "INVALID LOCATION CODE FOR DOCTOR: BATCH CONTAINED LOCATION - ". 
            15  err-msg-loc-cd                  pic x(04). 
            15  filler                          pic x(53)  value spaces. 
* #4 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(54)  value 
                "INVALID SPECIALITY CODE: BATCH CONTAINED SPECIALITY - ". 
            15  err-msg-batch-spec-cd           pic x(04). 
            15  filler                          pic x(60)  value spaces. 
* #5 
        10 filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(53)  value 
                "                         DOCTOR'S  SPECIALTIES ARE - ". 
            15  err-msg-doc-spec-cd             pic x(04). 
            15  filler                          pic x(03) value " / ". 
            15  err-msg-doc-spec-cd-2           pic x(04). 
            15  filler                          pic x(03) value " / ". 
            15  err-msg-doc-spec-cd-3           pic x(04). 
            15  filler                          pic x(47)  value spaces. 
* #6 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(56)  value 
                "**ERROR** - INVALID CLINIC ID: BATCH CONTAINED CLINIC - ". 
            15  err-msg-clinic-id               pic x(10). 
            15  filler                          pic x(52)  value spaces. 
* #7 
        10  filler                              pic x(132) value 
                "**ERROR** - FIRST RECORD FOUND IN FILE WAS NOT A 'B'ATCH RECORD ". 
* #8 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(40)  value 
                "INVALID OMA CODE - ACCOUNTING NBR = ". 
            15  err-accounting-nbr              pic x(10). 
            15  filler                          pic x(68). 
* #9 
        10  filler                              pic x(132) value 
                "              DUPLICATE ACCOUNT ID FOUND IN SUSPENSE (HEADER) FILE". 
* #10 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(40)  value 
                "INVALID WRITE NEW CLAIMS HDR - 'B' KEY=". 
            15  bkey-clmhdr-err-msg             pic x(20)  value spaces. 
            15  filler                          pic x(58)  value spaces. 
* #11 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(40)  value 
                "INVALID WRITE NEW CLAIMS HDR -'P' KEY = ". 
            15  pkey-clm-err-msg                pic x(20)  value spaces. 
            15  filler                          pic x(58)  value spaces. 
* #12 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(54)  value 
                "INVALID REFERRING PHYSICIAN: BATCH CONTAINED CLINIC - ". 
            15  err-refer-phys-nbr              pic x(6). 
            15  filler                          pic x(58). 
* #13 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(51)  value 
                "INVALID PATIENT OHIP NBR: BATCH CONTAINED CLINIC - ". 
            15  err-ohip-no                     pic x(08). 
            15  filler                          pic x(59). 
* #14 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(51)  value 
                "INVALID DIAG CODE: ". 
            15  err-diag-code                   pic x(03). 
            15  filler                          pic x(64). 
* #15 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(51)  value 
                "INVALID I-O-INDICATOR: ". 
            15  err-i-o-ind                     pic x(01). 
            15  filler                          pic x(66). 
* #16 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(92)  value 
                "NBR OF HEADER1 RECORDS READ IS NOT =  NBR OF HEADER1 RECORDS FROM TRAILER RECORD. ". 
            15  err-ctr-h-count                 pic 99999. 
            15  filler                          pic x(1)  value "/". 
            15  err-trl-h-count                 pic 99999. 
            15  filler                          pic x(15). 
* #17 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(92)  value 
                "NBR OF ITEM RECORDS READ IS NOT =  NBR OF ITEM RECORDS FROM TRAILER RECORD. ". 
            15  err-ctr-t-count                 pic 99999. 
            15  filler                          pic x(1)  value "/". 
            15  err-trl-t-count                 pic 99999. 
            15  filler                          pic x(15). 
* #18 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(92)  value 
                "NBR OF ADDRESS RECORDS IS NOT =  NBR OF ADDRESS RECORDS FROM TRAILER RECORD.  ". 
            15  err-ctr-a-count                 pic 99999. 
            15  filler                          pic x(1)  value "/". 
            15  err-trl-a-count                 pic 99999. 
            15  filler                          pic x(15). 
* #19 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(92)  value 
                "NBR OF BATCH RECORDS READ IS NOT =  NBR OF BATCH RECORDS FROM TRAILER RECORD". 
            15  err-ctr-b-count                 pic 99999. 
            15  filler                          pic x(1)  value "/". 
            15  err-trl-b-count                 pic 99999. 
            15  filler                          pic x(15). 
* #20 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(51)  value 
                "INVALID AGENT CODE:    ". 
            15  err-agent-cd                    pic x(01). 
            15  filler                          pic x(66). 
* #21 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(20)  value 
                "DOCTOR SPECIALITY: ". 
            15  err-21-value-1                  pic x(02). 
            15  filler                          pic x(27)  value 
                "  NOT VALID FOR OHIP CODE: ". 
            15  err-21-value-2                  pic x(04). 
            15  filler                          pic x(33)  value 
                " RANGE: ". 
            15  err-21-value-3                  pic x(02). 
            15  filler                          pic x(06)  value 
                " THRU ". 
            15  err-21-value-4                  pic x(02). 
            15  filler                          pic x(22). 
* #22 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(10) value 
                "OMA CODE: ". 
            15  err-22-oma-cd                   pic x(04). 
            15  filler                          pic x(14) value 
                "  REQUIRES -  ". 
            15  err-22-msg                      pic x(90). 
* #23 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(51)  value 
                "INVALID HOSPITAL NBR: ". 
            15  err-hosp-nbr                    pic x(04). 
            15  filler                          pic x(63). 
* #24 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(45)  value 
* 2013/07/10 - MC27
*                "SERVICE NOT WITHIN 6 MONTHS OF SYSTEM DATE:". 
* MC42/MC47
*                "SERVICE NOT WITHIN 7 MONTHS OF SYSTEM DATE:". 
                "SERVICE NOT WITHIN 231 days OF SYSTEM DATE:". 
* MC42/MC47 - end
* 2013/07/10 - end
            15  err-24-service-date             pic x(08). 
*           15  filler                          pic x(67). 
            15  filler                          pic x(65). 
* #25 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(118)  value 
                "DIRECT BILL CLAIM MISSING - MSG / AUTO LOGOUT / FEE COMPLEXITY / ... INFO". 
* #26 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(22)  value 
                "INVALID -ADMIT- DATE: ". 
            15  err-admit-date                  pic x(08). 
*           15  filler                          pic x(90). 
            15  filler                          pic x(88). 
* #27 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(32)  value 
                "INVALID INITIAL SERVICE DATE:". 
            15  err-27-service-date             pic x(08). 
*           15  filler                          pic x(80). 
            15  filler                          pic x(78). 
* #28 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(42)  value 
                "INVALID CONSECUTIVE SERVICES DATES/SVC'S:". 
            15  err-additional-servs            pic x(09). 
            15  filler                          pic x(67). 
* #29 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(25)  value 
                "INVALID HEALTH CARE NBR:". 
            15  err-health-care-nbr             pic x(10). 
            15  filler                          pic x(83). 
* #30 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(18)  value 
                "INVALID PROVINCE:". 
            15  err-province                    pic x(02). 
            15  filler                          pic x(98). 
* #31 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(27)  value 
                "INVALID MANUAL REVIEW: ". 
            15  err-manual-review               pic x. 
            15  filler                          pic x(90). 
* #32 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(54)  value 
                "INVALID DEPT NO:  BATCH CONTAINED DEPT NO - ". 
            15  err-msg-batch-dept-no           pic x(02). 
            15  filler                          pic x(62)  value spaces. 
* #33 
        10 filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(53)  value 
                "                  DOCTOR'S DEPT NO          - ". 
            15  err-msg-doc-dept-no             pic x(02). 
            15  filler                          pic x(63)  value spaces. 
* #34 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(92)  value 
                "NBR OF HEADER2 RECORDS READ IS NOT =  NBR OF HEADER2 RECORDS FROM TRAILER RECORD.  ". 
            15  err-ctr-r-count                 pic 99999. 
            15  filler                          pic x(1)  value "/". 
            15  err-trl-r-count                 pic 99999. 
            15  filler                          pic x(15). 
 
* #35 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(53)  value 
                "INVALID PROVIDER NO:  BATCH CONTAINED PROVIDER NO - ". 
            15  err-msg-batch-prov-nbr          pic x(06). 
            15  filler                          pic x(59)  value spaces. 
* #36 
        10 filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(53)  value 
                "                  DOCTOR'S PROVIDER NO      - ". 
            15  err-msg-doc-prov-nbr            pic x(06). 
            15  filler                          pic x(59)  value spaces. 
* #37 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(22)  value 
                "INVALID BIRTH DATE:". 
            15  err-birth-date                  pic x(08). 
*           15  filler                          pic x(90). 
            15  filler                          pic x(88). 
* #38 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(28)  value 
                "ZERO NUMBER OF SERVICE". 
            15  err-nbr-of-serv                 pic x(4). 
            15  filler                          pic x(86). 
* #39 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(28)  value 
                "ZERO AMOUNT BILLED". 
*mf         15  err-fee-billed                  pic x(12). 
            15  err-fee-billed                  pic 9(12).
            15  filler                          pic x(78). 
* #40 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(48)  value 
**              "INVALID SIZE OF OHIP NBR". 
                "INVALID SIZE OF HEALTH CARE NBR - Province/Nbr: ". 
            15  err-prov                        pic x(2). 
            15  filler                          pic x(3)   value 
                " / ". 
            15  err-ohip-nbr                    pic x(12). 
            15  filler                          pic x(53). 
* #41 @@ USE 
        10  filler                              pic x(132)  value 
                "CONSTANTS MSTR REC 'LOCKED' -- INFORM OPERATIONS OF PROBLEM". 
* #42  @@ USE 
        10  filler                              pic x(132)  value 
                "SERIOUS ERROR #10 - UNABLE TO READ CONSTANT MSTR REC #2 ". 
* #43 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(53)  value 
                "INVALID GROUP NBR: BATCH CONTAINED GROUP NBR - ". 
            15  err-msg-group-nbr               pic x(06). 
            15  filler                          pic x(59)  value spaces. 
* #44 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(15)  value 
                "SERVICE DATE: ". 
            15  err-44-service-date             pic x(08). 
            15  filler                          pic x(27)  value 
                "IS PRIOR TO ADMIT DATE:". 
            15  err-44-admit-date               pic x(08). 
*           15  filler                          pic x(64). 
            15  filler                          pic x(60). 
* #45 
        10  filler                              pic x(132)  value 
                "SERIOUS ERROR #11 - UNABLE TO READ CONSTANT MSTR REC #1 ". 
* #46 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(27)  value 
                "INVALID RELATIONSHIP: ". 
            15  err-relationship                pic x. 
            15  filler                          pic x(90). 
*** S.B.- start.
* #47
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(23)  value
                "   REFERRING DOCTOR: - ".
                15  err-msg-referring-doc               pic x(06).
            15  filler                                  pic x(37)  value
                " AND PROVIDER DOCTOR ARE THE SAME: - ".
            15  err-msg-provider-doc            pic x(06).
            15  filler                          pic x(46)  value spaces.

* #48
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(22)  value
                "      SERVICE DATE: - ".
            15  err-msg-svr-date                pic x(08).
              15  filler                        pic x(32)  value
                    " IS GREATER THAN SYSTEM DATE: - ".
                15  err-msg-sys-date            pic x(08).
            15  filler                          pic x(48)  value spaces.
* #49
        10  filler.
            15  filler                          pic x(10)  value spaces.
            15  filler                          pic x(18) value
                "OMA CODE I/O IND: ".
            15  err-49-oma-cd                   pic x(04).
            15  filler                          pic x(38) value
                " DOES NOT MATCH CLMHDR-2 REC I/O IND: ".
            15  err-49-hdr-cd                   pic x(04).
            15  filler                          pic x(58).

* #50
        10  filler.
            15  filler                          pic x(12)  value spaces.
            15  filler                          pic x(36)  value
                " MISSING DETAIL RECORDS FOR CLAIM: ".
            15  err-no-detail-claim             pic x(08).
            15  filler                          pic x(76)  value spaces.
* #51
        10  filler.
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(61)  value 
                "INVALID LOCATION CODE: BATCH CONTAINED LOCATION - ". 
            15  err-51-loc-cd                   pic x(04). 
	    15  filler				pic x(53).
* #52 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(35)  value 
                "Incoming fee not = RMA priced fee  ". 
            15  err-52-incoming-fee             pic zzz9.99. 
            15  filler                          pic x(3)  value " / ". 
            15  err-52-ohip-fee                 pic zzz9.99. 
            15  filler                          pic x(66). 

* #53 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(40)  value 
                "Incoming I/O ind not = RMA I/O ind ". 
            15  err-53-incoming-i-o-ind         pic x.        
            15  filler                          pic x(3)  value " / ". 
            15  err-53-i-o-ind                  pic x.
            15  filler                          pic x(73). 
* 2002/06/12 - MC - add error 54
* #54 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(40)  value 
                "Require facility number with premium cd ".
            15  filler                          pic x(3)  value " / ". 
            15  err-54-prem-code                pic x(4).
            15  filler                          pic x(71). 
* 2002/06/12 - end

* 2002/08/21 - MC - add error 55
* #55 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(40)  value 
                "Wrong hospital number with premium cd ".
            15  filler                          pic x(3)  value " / ". 
            15  err-55-hosp-code                pic x(4).
            15  filler                          pic x(3)  value " / ". 
            15  err-55-prem-code                pic x(4).
            15  filler                          pic x(64). 
* 2002/06/12 - end
    
* 2003/06/11 - MC - add error 56
* #56 
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
* 2004/01/20 - MC
*            15  filler                          pic x(40)  value
*               "Wrong location code - must end with 112".
            15  filler                          pic x(60)  value
* 2004/09/27 - MC
*                "Wrong location code - must end with 112/153/400/250/422".
* 2007/10/24 - MC - add 055 as well
*               "Wrong location code - must end with 112/153/400/250/422/401".
* 2007/11/22 - MC -add 326 as well - yas add 122 2008/01/03
*                "Wrong locn code - must end with 112/153/400/250/422/401/055".
             "Wrong locn cd- must with 112/153/400/250/422/401/055/326/122".
* 2007/11/22 - end
* 2007/10/24 - end
* 2004/09/27 - end

* 2008/02/19 - MC - add 344 to the list
	    15 filler				pic x(20) value
* 2008/02/28 - MC add 111 & 354
*		"/344      ".
* 2008/03/18 - MC add 333 
*		"/344/111/354        ".
* 2008/10/22 - MC add 777
*		"/344/111/354/333    ".
		"/344/111/354/333/777".
* 2008/10/22 - end
* 2008/03/18 - end  
* 2008/02/28 - end
* 2008/02/19 -end

* 2004/01/20 - end
            15  filler                          pic x(3)  value " / ".
            15  err-56-loc-code                 pic x(4).
            15  filler                          pic x(3)  value " / ".
            15  err-56-prem-code                pic x(4).
* 2004/01/20 - MC
*            15  filler                          pic x(64). 
* 2008/02/19 - MC
*            15  filler                          pic x(44).
            15  filler                          pic x(24).
* 2008/02/19 - end

* 2004/01/20 - end

* 2003/06/11 - end

* 2003/10/22 - MC - add error 57
* #57
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(56)  value
                "**ERROR** - INVALID CLINIC NBR FOR THE DOCTOR -         ".
            15  err-msg-doc-clinic              pic 9(2).
            15  filler                          pic x(60)  value spaces.
* 2003/10/22 - end
  
* 2004/04/07 - MC - add error 58
* #58
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(15)  value
                "ADMIT DATE: ".
            15  err-58-admit-date               pic x(08).
            15  filler                          pic x(27)  value
                "  IS PRIOR TO BIRTH DATE:".
            15  err-58-birth-date               pic x(08).
            15  filler                          pic x(60).
* 2004/04/07 - end
  
* 2005/03/03 - MC - add error 59 and 60
* #59
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(17)  value
                "Doc Specialty = ".
            15  err-59-doc-spec                 pic 99.   
            15  filler                          pic x(17)  value
                ", Birth date =  ".
            15  err-59-birth-date               pic x(08).
            15  filler                          pic x(27)  value
                "  and age must be >= 60".
            15  filler                          pic x(47).

* #60
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(17)  value
                "Doc Specialty = ".
            15  err-60-doc-spec                 pic 99.   
            15  filler                          pic x(17)  value
                ", Birth date =  ".
            15  err-60-birth-date               pic x(08).
* 2010/04/01 - MC4
*           15  filler                          pic x(27)  value
*                "  and age must be >= 75".
*           15  filler                          pic x(47).
            15  filler                          pic x(74)  value
                "  and age must be >= 65 with diagnostic code 290".
* 2010/04/01 - end
* 2005/03/03 - end
  
* 2005/05/04 - MC - add error 61 and 62
* #61
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(17)  value
                "Service Date  = ".
            15  err-61-serv-date                pic x(08).
            15  filler                          pic x(17)  value
                ", Birth date =  ".
            15  err-61-birth-date               pic x(08).
            15  filler                          pic x(68) value 
                "  and service date must be > birth date".

* #62
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(17)  value
                "Location code = ".      
            15  err-62-loc-code                 pic x(4). 
            15  filler                          pic x(17)  value
                ", clinic nbr = ".  
            15  err-62-clinic-nbr               pic 99.      
            15  filler                          pic x(78)  value
* 2014/04/23
*               "  and wrong location for clinic 61 - 65".
                "  and wrong location for clinic 61 - 74".
* 2014/04/23 - end
* 2005/05/04 - end

* 2005/10/31 - MC - add message 63 and 64 and 65

* #63
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "Oma code = E420, check pricing".
* #64
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "doc nbr = 049 and oma code = Z425 - take out manual review".
* #65
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "check for E078 premium". 
* 2005/10/31 - end 


* 2006/12/13 - MC - add message 66 and 67 and 68

* #66
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "Check C122".                           
* #67
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "Check C123". 
* #68
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "Check C124". 
* 2006/12/13 - end 

* 2008/04/23 - add msg 69 to 84
* #69
        10  filler.
            15  filler                          pic x(14)  value spaces.
* 2013/04/11 - MC25
*           15  filler                          pic x(118) value
*               "Check number of services for E add-on code".
            15  filler                          pic x(58) value
                "Check number of services for C suffix code".
            15  err-oma-cd                      pic x(4). 
            15  err-oma-suff                    pic x. 
	    15  filler				pic x(3) value ' / '. 
            15  err-nbr-serv                    pic x(4). 
	    15  filler				pic x(3) value ' / '. 
            15  err-nbr-serv-incoming           pic x(4). 
	    15  filler				pic x(38) value spaces.
* 2013/04/11 - end
* #70
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "E020C only allowed with E022C, E017C or E016C".
* #71
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "E719 only allowed with Z570".                     
* #72
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "E720 only allowed with Z571".                     
* #73  for edit 5
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
* 2011/11/23 - MC19
*               "E717 only allowed with Z555 or Z580".             
                "E717 only allowed with specific colonsocopy codes".
* 2011/11/23 - end

* #74
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "E702 only allowed with specific codes".           
* #75
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "G123 only allowed with G228".                     
* #76
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "G223 only allowed with G231".                     
* #77
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "G265 only allowed with G264".                     
* #78
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "G385 only allowed with G384".                     
* #79
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "G281 only allowed with G381".                     
* #80
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "Maximum number of services exceeded".             
* #81
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "E793 only allowed with specific procedures".      
* #82
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "P022 deleted as of 2008/02/01".                   
* #83
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
                "K120 deleted as of 2008/02/01".                   
* #84
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118) value
* 2011/08/22 - MC18
*               "A007 only allowed for specialty '00'".            
                "A007 not allowed  for specialty '26'".            
* 2011/08/22 - end

* 2009/05/06 - MC1 - add message 85 to 90
* #85
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                "Check fee and services of E400".
* #86
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                "Check fee and services of E401".
* #87
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                "E798 allowed only with  Z400".
* #88
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                "Check fee of E409/E410".
* #89
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                "Use General Listing code with special visit premium".
* #90  
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                "E450 may only be billed with J315".
* 2009/05/06 - end
            
* 2010/03/31 - MC4 - more edit checks as requested by Yasemin
* #91
        10  filler.
	    15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                "G222 not allowed with G248, G125, G118 or G062".
* #92 - edit 21
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
* 2011/11/23 - MC19 - include A075
*               "A770 or A775 not allowed with special visit premium".
                "A770 or A775 or A075 not allowed with special visit premium".
* 2011/11/23 - end
* #93
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                "Z432C deleted as of 2009/10/01".  
* #94  
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                "H112 / H113 not allowed with another 'H' code".
* #95  
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                "Patient is underage for G489 / S323". 
* #96  
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                "G222, Z804 or Z805 not allowed with P014C or P016C".
* #97  
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
* 2010/09/21 - MC8
*                "H prefixed codes must be agent 2 in clinic 22".
* 2010/12/08 - MC11
*                "H prefixed codes must be agent 2 or 9 in clinic 22".
                "H prefixed E.R. codes must be agent 2 or 9 in clinic 22".
* 2010/12/08 - end
* 2010/09/21 - end
* #98  
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
* 2001/05/18 - MC5 - change message
*                "G221 not allowed with G220". 
                "G221 only allowed with G220". 
* 2010/05/18 - end

* #99  
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                "Patient must be under 16 for service".
* #100 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                "Patient is overage for H267".  
* #101 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                "Reassessment not allowed with resuscitation".
* #102 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                "Assessment included in chemotherapy code".
* #103 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
* 2011/03/21 - MC13
*                "Check suffix on 'G' code". 
                "Check suffix on 'G' code or premium code". 
* 2011/03/31 - end

* #104 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                "Patient must be 16 and under".
* 2010/03/31 - end

* 2011/04/06 - MC13 - add message 105 to 117
* #105 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                "J021 and J022 should be at 50% with J025".
* #106 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                "Referring doctor must be an optometrist".
* #107 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "Referral must be a midwife".   
* #108 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "Referring doctor cannot be an optometrist".
* #109 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "Z611 or Z602 not allowed with Z608".
* #110 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "Z176 or Z154 must have manual review".       
* #111 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "Z175 - Z192 must have manual review".       
* #112 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "Z403 with Z408 must have manual review".       
* #113 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "A195 with K002 requires manual review with times of each service".
* #114 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "Add E083 to MRP code". 
* #115 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "E083 only allowed with specific codes".        
* #116 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "Clarification required to add J021".  
* #117 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "Echo needs admit date for in-patient". 
* 2011/04/06 - end
* 2011/05/18 - MC15 - add message 118 to 119
* #118           
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "Oma code suffix  / SLI  does not have admit date".
* #119 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "Oma code suffix  / SLI  does not require admit date".

* 2011/11/23 - MC19 - add message 120 to 122 for new edits 52 to 63
* #120 - edit 52 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "Patient is overage for service". 
* #121 - edit 53
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "K189 only allowed with specific codes". 
* #122 - edit 54 to 63
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "Travel Premium billed incorrectly". 
* #123 - edit 64
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "Check fee and services for E676B".   
* 2011/11/23 - end

* 2013/04/11 - MC25 - add for edit 66 to 69
* #124 - edit 66 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "Canot use time units calculator for counselling". 
* #125 - edit 67
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "G556 only allowed with Day 1 per diem".
* #126 - edit 68 
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "A120 only allowed with colonscopy codes".
* #127 - edit 69
        10  filler.
            15  filler                          pic x(14)  value spaces.
            15  filler                          pic x(118)       value
                 "Referral cannot be a midwife". 
* 2013/04/11 - end
* 2014/09/08 - MC35/MC40
* #128
        10  filler. 
            15  filler                          pic x(14)  value spaces. 
            15  filler                          pic x(45)  value 
                "DOCTOR HAS BEEN TERMINATED + 6 MONTHS :".          
            15  err-128-term-date               pic x(08). 
            15  filler                          pic x(65). 
* 2014/09/08 - end   

* 2015/01/20 - MC37
* #129 
        10  filler.  
            15  filler                          pic x(14)  value spaces.
            15  filler 				pic x(60)  value
	     	"**FATAL ERROR** - INVALID REC TYPE - RECORD MISALIGNED:  ".
	    15  err-rec-type                    pic x(3).
            15  filler                          pic x(55)  value spaces. 
* MC37 - end
* 2015/03/05 - MC38
* #130 
        10  filler.  
            15  filler                          pic x(14)  value spaces.
            15  filler 				pic x(60)  value
	     	"LOCATION Code not currently active for data entry = ".
	    15  err-130-loc-cd                  pic x(4).
            15  filler                          pic x(54)  value spaces. 
* MC38 - end
    05  error-messages-r redefines error-messages. 
        10  err-msg                             pic x(132) 
                    occurs 130 times.

