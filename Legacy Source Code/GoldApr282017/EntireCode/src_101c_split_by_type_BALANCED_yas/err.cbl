* msg #5
                "INVALID DATE".
                "DATE CAN'T BE IN THE FUTURE (ie. > CURRENT SYSTEM DATE)".
                "INVALID DOCTOR NUMBER".
                "OMA CODES INPUT REQUIRE NON-ZERO DIAGNOSTIC CODE".
                ""
* msg #10
                "INVALID LOCATION for batch's DOCTOR".
                "OMA Code requires a HOSPITAL Code - is LOCATION correct?".
                "IN/OUT PATIENT INDICATOR MUST BE 'I'N, 'O'UT, OR 'B'OTH".
                "INVALID OHIP Nbr / Chart ID -- please correct".
                "AGENT IS 'OHIP' -- Patient doesn't have OHIP or Health Nbr".
* msg #15
                "CONSTANTS MSTR REC 'LOCKED' -- INFORM OPERATIONS OF PROBLEM".
                "PATIENT NOT ON FILE".
                "PATIENT OHIP NBR DOESN'T EXIST".
                "PATIENT CHART NBR DOESN'T EXIST".
                "LOOK OUT !!  PREMIUM CODE. IS IT AN 'IN' OR 'E.R.' PATIENT ?".
* msg #20
                "INVALID 2 DIGIT CLINIC IDENTIFIER".
                ""
                "CLAIM AGENT CODE = 'OHIP' -- BUT PATIENT'S OHIP # IS INVALID".
                "MUST SUPPLY REFERRING DOCTOR FOR CLINIC 61 TO 65".
                "CAN'T KEY 'CV' or 'SP' SERVICES FOR CLINIC 61 TO 65".
* msg #25
                "'B' OR 'C' SUFFIX NOT ALLOWED WITH CONSULTATIONS AND VISITS".
                "Ohip # 11111119 valid only for ALTERNATIVE FUNDING Agent".
                "SURNAME INPUT NOT = SURNAME OF PATIENT ON FILE".
                "INVALID OMA CODE".
                ""
* msg #30
                ""
                "SERIOUS ERROR #6 !! -- INVALID WRITE ON CLAIMS DETAIL REC".
                "# SERVICES FROM DAY DOES NOT FALL WITHIN # DAYS IN MONTH".
                "SERVICE DATE < ADMIT DATE".
                "'OHIP' AGENT REQUIRES A REFERRING PHYSICAN".
* msg #35
                ""
                "'OHIP' AGENT REQUIRES A PATIENT I/O INDICATOR OF 'I'".
                "'OHIP' AGENT REQUIRES A PATIENT I/O INDICATOR OF 'O'".
                "'OHIP' AGENT REQUIRES AN ADMIT DATE".
                "'OHIP' AGENT REQUIRES DOCTOR SPECIALTY CODE BE WITHIN RANGE".
* msg #40
                "'OHIP' AGENT REQUIRES SERVICE WITHIN 6 MTHS OF SYSTEM DATE".
                "DAY INPUT FALLS WITHIN PREVIOUS CONSECUTIVE DAY RANGE".
                ""
                ""
                "INVALID DIAGNOSTIC Code".
* msg #45
                "SERVICE DATE > SYSTEM DATE".
                "SERIOUS ERROR #8 !! - ERROR IN DELETING BATCH CONTROL RECORD".
                "OMA CODE'S SUFFIX MUST BE 'A','B','C', OR 'M'".
                "SERIOUS ERROR #9 !! - ERROR IN RE-WRITING PATIENT'S RECORD".
                "DIALYSIS PATIENT NOT FOUND, WITH ENTERED ACRONYM".
* msg #50
                "LOOK OUT !! OMA CODE'S BASIC VALUE = ZERO !".
                "UNABLE TO ACCESS BATCH -- STATUS IS NOT UNBALANCED/BALANCED".
                "MAXIMUM OF 99 CLAIMS HAVE BEEN ENTERED FOR BATCH - SHUT DOWN".
                "NEXT CLAIM ALREADY EXISTS! - SHUTDOWN AND START A NEW BATCH".
                "INVALID Doctor DEPARTMENT number".
* msg #55
                "SERIOUS ERROR #10 !! - ERROR IN RE-WRITING DOCTOR RECORD".
                "EXISTING OR ZERO MESSAGE NUMBER REQUIRED".
                "Existing SUBDIVISION Number required".
                "CAN NOT ENTER ZERO FEE".
                "FEE VALUE OF ZERO FOUND".
* msg # 60
                "SYSTEM DATE GREATER THAN PERIOD-END-DATE".
                "BATCTRL AMT > 99999.99, RE-ENTER CLAIM WITH NEW BATCH".
                "WARNING - CAN'T MANUALLY CONTINUE DISKETTE BATCH ".
                "PATIENT HEALTH NBR DOES NOT EXIST".
                "ONLY CLINIC NBR 22 OR 61 TO 65 IS VALID".
* msg # 65
                "CAN'T ENTER OHIP OR WCB CLAIMS WITH 'PQ' PROV CODE".
                "HEALTH NBR IS EXPIRED".
                "REFERRING DOC # CAN'T THE SAME AS DOC # OF THE CLAIM".
                "MANUAL REVIEW CAN ONLY BE 'Y' OR ' '".
                "INVALID HEALTH CARE NUMBER --PLEASE CORRECT".
* msg # 70
                "PATIENT MUST HAVE HEALTH # FOR SERVICES AFTER 91/06/30".
                "INVALID SPECIALTY Code for this DoctoR".
                "INVALID CLINIC Nbr for this Doctor".
                "BIRTH YEAR > SYSTEM YEAR".
                "BIRTH DATE > SYSTEM DATE".
* msg # 75
                "INVALID EXPIRY MONTH".
                "NBR OF SERV MUST BE EITHER NUMERIC OR '*'".
                "ENTERED SERV NOT EQUAL TO COMPUTED SERV".
                "INVALID WRITE INVERTED TO PAT MSTR ACRONYM".
                "CAN'T DELETE OLD ACRONYM KEY".
* msg # 80
                "INVALID READ ON PATIENT ACRONYM".
                "REACH TO THE END OF ACRONYM PAT MSTR".
                "ACRONYM READ IS NOT THE SAME AS THE ORIG ACRONYM".
		"Oma Code is NOT ACTIVE for data entry".
                "Doctor fails mod10 check. Are you sure number is correct?".
* msg # 85
                "You must enter a HEALTH # OR an out-of-province patient id".
                "INCREASING OMA  fee to MINIMUM value specified in Fee Master".
                "INCREASING OHIP fee to MINIMUM value specified in Fee Master".
                "DECREASING OMA  fee to MAXIMUM value specified in Fee Master".
                "DECREASING OHIP fee to MAXIMUM value specified in Fee Master".
* msg # 90
                "basic fee (yb0-) ...".
		"ICC sort flag have been determined (yd0-) ...".
                "group reductions (ye0-) ...".
		"add ons (yf0-) ...".
		"find highest group within section (yh0-) ...".
* msg # 95
		"sectional reduction (yi0-) ...".
		"special AddOn (yf1-) ...".
		"BEFORE min/maximums testing ...".
		"AFTER  min/maximums testing ...".
		"Technical prices calulated (ya3-) ....".
* msg # 100
		"sorted back into original sequence (yj0-) ...".
		"This code expands to 2 lines, split claim into a 2nd claim".
		"INVALID LOCATION Code - code is not in Location Master".
		"LOCATION Code not currently active for data entry".
		"'A' for 'regular clinic 22' / 'B' for ICU payroll".
* msg # 105
		"ICU payroll payroll doctor - use Payroll 'B'".
		"Warning - verify these claims aren't for Payroll 'B'".
		"Warning -  doctor is TERMINATED!".
		"Prefix must be either '!' or '$' ".
                        occurs 108 times.

