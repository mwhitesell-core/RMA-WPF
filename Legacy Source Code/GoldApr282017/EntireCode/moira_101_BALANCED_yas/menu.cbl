identification division. 
program-id. menu.  
author. dyad computer SYSTEMs inc. 
installation. rma. 
date-written. 80/03/11. 
date-compiled. 
security. 
* 
*    program purpose :    program menu 
* 
*  87/09/25  m.s.	- sms 97 
*			  include the f096_ohip_pay_code file as 
*			  part of maintenance screen 
*			  option 'B' is for f096_ohip_pay_code 
* 
*    revised dec/87 (j.l.) - pdr 356 
*			   - after error message is displayed, hit 
*			     space bar to return to keying field 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
*   89/06/02 m. chan	- sms 116 
*			- include 'doctor numbers assignment' as part 
*			  of file maintenance submenu, and also re- 
*			  numbering the sub-menu of option 5, and 
*			  change from 'sub-SYSTEM' to 'sub-menu'. 
* 
*  91/01/22 m. chan    - sms 137 
*                      - call m020 in powerhouse 
* 
*  91/06/13 d.boucek   - sms 136 
*                      - add call m091 in powerhouse 
* 
*  91/10/02 m. chan	- pdr 520 
*			- add call m098 in powerhouse 
* 
*  93/03/22 m. chan	- sms 140 
*			- add call m101 in powerhouse 
* 
*  93/09/03 m. chan	- pdr 590 
*			- add call d713 in powerhouse for diskette 
*			  accounting nbr query 
* 
*  94/03/17 m. chan     - add call in01 for referring physician 
*			  inquiry 
* 
*  94/07/18 m. chan	- add call m100 for earning subSYSTEM 
* 
*  94/08/04 m. chan     - sms 146 
*			- add social contract factor ranges, call m940 
*
*  98/feb   j. chau     - s149 unix conversion
*  99/jan/15 B.E.	- y2k, added "^" as well as "*" to shutdown
*			- changed call's to chain's
*  99/jun/20 B.E.	- added option "H" for Manual Rejected Claims History
*  99/jun/27 B.E.	- corrected calls to wrong program in Costing ba3-
*			  submenus.
*  00/jul/26 M.C.	- comment out the extra call for option B/2 (Claims
*			  Inventory Query)
* 00/oct/13 B.E.	- added "Z" call to m090.qkc
* 01/sep/25 B.E.	- added "P" call to m941.qkc
* 01/oct/23 M.C.	- added "Q" call to m923.qkc
* 02/jan/16 M.C.	- added "R" call to m924.qkc
* 02/mar/20 M.C.	- added utl1002.qkc in administrators sub menu
* 03/jan/23 M.C.	- added "Y" call to m123.qkc
* 03/oct/16 b.e.	- added call to d087_hdr.qkc
* 04/jul/05 b.e.	- added "W" call to m074.qkc
* 04/jul/05 b.e.	- added "X" call to m075.qkc
* 04/sep/22 b.e.	- added "C" - Operator's menu and screen-7 that provide
*			  call to M113.qkc
* 07/sep/11 b.e.	- added "Z" call to password change process
* 09/jun/11 M.C.	- added "V" call to m074a.qkc
* 11/may/18 M.C.	- added "4" in costing sub-system 'A' subscreen to call m201.qkc
* 11/jun/16 MC1 	- added "3" in Administrator utilities Pgms 'C' subscreen to call m200.qkc
* 13/apr/03 M.C.	- added "S" call to m020c.qkc
* 13/jun/25 MC2  	- added 'Bill Direct' sub menu from the main menu, transfer option A/B from
*			  sub-menu 'File Maintenance' to 'Bill Direct' 
* 15/Jan/29 MC3		- added "C" in costing sub-system 'A' subscreen to call m096.qkc
* 17/Mar/14 MC4         - remove option B and sub menus for f084 files
* 17/Mar/21 MC5		- remove option 9 "Documentation Sub-menu", also remove following options from option 5 
*				option I "Referring Physician"
*			        option K "Message Maintenance"
*			        option L "Message Categories"
*			        option P "Proposed MOH Prices"
*			        option R "Non Fee for Service Location"
*			  remove option 3 "Ohip MANUAL Rejections - View/Modify" from option A 
* 17/Apr/04 MC6		- remove option 3 "Doctor Numbers Assignment Submenu" from option 5

environment division. 
configuration section.
special-names.
*       "D050_SCREEN" is screen-dump-file. 

input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
 
* 
data division. 
file section. 
* 
working-storage section. 
77  app-version					pic x(6).
77  app-message					pic x(17).
77  menu-name					pic x(10).
77  menu-desc					pic x(30).

77  err-ind					pic 99 	value zero. 
77  option					pic x. 
77  confirm-space				pic x   value space. 
01  x-environment pic x(80).
01  macro-line.
    02 macro					pic x(50) value space.
    02 macro-null-char 				pic x(1) value x"00".
 
copy "linkage.ws". 
copy "versions.ws".

01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
			"INVALID REPLY". 
	10  filler				pic x(60)   value 
			"UNABLE TO EXECUTE PROGRAM". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 2 times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
 
 
 
copy "sysdatetime.ws". 

screen section. 
 
01  scr-1. 
 
    05  blank screen. 
    05  		line 01 col 79 pic 99 using sys-dd. 
    05  		line 03 col 05 value "1   Claims Data Entry". 
    05  		line 03 col 45 value "A   Costing Sub-System".
    05  		line 05 col 05 value "2   Claims Deletion". 
* MC4
*    05  		line 05 col 45 value "B   Claims Inventory Sub-system".
* MC4 - end
    05  		line 07 col 45 value "C   Administrator Utilities Pgms".
    05  		line 07 col 05 value "3   Claims Query". 
    05  		line 09 col 05 value "4   Adjustments Data Entry". 
    05  		line 09 col 45 value "D   Operator Pgms".
    05  		line 11 col 05 value "5   File Maintenance Sub-menu". 
* 2013/06/25 - MC2
    05  		line 11 col 45 value "E   Bill Direct Sub-menu". 
* 2013/06/25 - end
*    05  		line 11 col 45 value "Z   Password Change process".   
    05  		line 13 col 05 value "6   Physician Payroll Sub-menu". 
*   05  		line 15 col 05 value "7   Appointment Reconciliation sub-menu". 
    05  		line 15 col 05 value "7   Diskette Accounting Number Query". 
    05  		line 17 col 05 value "8   Doctor Revenue Query". 
* MC5
*    05  		line 19 col 05 value "9   Documentation Sub-menu". 
* MC5 - end
    05  		line 21 col 21 value "*/^ Log Out". 
    05  		line 23 col 28 value "OPTION ". 
    05  scr1-option	line 23 col 35 pic  x to option auto required. 
*    05  		line 11 col 45 value "Note: Changes to".
*    05  		line 12 col 45 value "      'File Maintenance Sub-menu'".
*    05  		line 13 col 45 value "      and 'Costing Sub-menu." .
 
*                     
 
01  scr-2. 
 
    05  blank screen. 
    05  		line 03 col 01 value "1   Patient/Subscriber". 
    05  		line 05 col 01 value "2   Doctor Master". 
* MC6
*    05  		line 07 col 01 value "3   Doctor Numbers Assignment Subsystem". 
* MC6 - end
    05  		line 09 col 01 value "4   Location Master". 
    05  		line 11 col 01 value "5   OMA/OHIP Fee Master". 
    05  		line 13 col 01 value "6   Department Master". 
    05  		line 14 col 01 value "Y   Company Master". 
    05  		line 15 col 01 value "7   Bank Master". 
    05  		line 17 col 01 value "8   Constants Master". 
    05  		line 18 col 01 value "Z   Constants Master - all PEDs". 
    05  		line 20 col 01 value "9   Equivalence OHIP Code Master".
    05  		line 21 col 01 value "V   AFP Groups Sort".
    05  		line 22 col 01 value "W   AFP Groups". 
    05  		line 23 col 01 value "X   AFP Doctors with multiple Nbrs". 
* 2013/06/25 - MC2 - transfer to Bill direction sub menu
*   05  		line 02 col 41 value "A   Direct Bills - Message Master". 
*   05  		line 04 col 41 value "B   Subdivision Master". 
* 2013/06/25 - end 
    05  		line 05 col 41 value "C   RAT Potential Auto Adjust Codes". 
    05  		line 06 col 41 value "D   Diagnostic Code Master". 
    05  		line 07 col 41 value "E   Contract Code Master". 
    05  		line 08 col 41 value "F   Client Doctor Master". 
*   05 	line 09 col 41 value "G   Rejected Claims Entry ". 
*   05 	line 10 col 41 value "H   Manual Rejected Claims History". 
* MC5
*   05  		line 09 col 41 value "I   Referring Physician Inquiry". 
    05  		line 10 col 41 value "J   Social Contract Factor Ranges". 
*   05  		line 12 col 41 value "    OHIP Manual Rejections". 
*   05  		line 13 col 41 value "K       - Message Maintenance". 
*   05  		line 14 col 41 value "L       - Message Categories".
* MC5 - end
*   05	line 18 col 41 value "M   Costing Constants Maintenance".
    05  		line 16 col 41 value "N   On-line User Identification".
    05  		line 17 col 41 value "O   Transfer Claim between Patients".
* MC5
*   05  		line 18 col 41 value "P   Proposed MOH Prices - Maintenance".
    05  		line 19 col 41 value "Q   Doctor Revenue Translation Table".
*   05  		line 20 col 41 value "R   Non Fee for Service Location Table".
* MC5 - end
* 2013/04/03 - MC
    05  		line 21 col 41 value "S   Doctor Rpt Master".
* 2013/04/03 - end
    05  		line 23 col 41 value "*/^ Return to Main Menu". 
    05  		line 24 col 28 value "Option ". 
    05  scr2-option	line 24 col 35 pic x to option auto required. 
 
*                     
 
01  scr-3. 
 
    05  blank screen. 
    05  		line 04 col 21 value "1   Ohip RAT Rejections - View/Modify". 
*   05  		line 06 col 21 value "2   Rejected Claims Entry ". 
    05  		line 06 col 21 value "2   Ohip Submission Rejections - View/Modify". 
* MC5
*   05  		line 07 col 21 value "3   Ohip MANUAL Rejections - View/Modify". 
* MC5 - end
* 2011/05/18 - MC
    05			line 09 col 21 value "4   SLI Oma Code Suffix Maintenance".
* 2011/05/18 - end
    05  		line 11 col 21 value "    Ohip MANUAL Rejections". 
    05  		line 12 col 21 value "A       - Message Maintenance".
    05  		line 13 col 21 value "B       - Message Categories".
* 2015/01/29 - MC3
    05  		line 15 col 21 value "C   Ohip RAT Rejection Code Maintenance".
    05  		line 17 col 21 value "Z   Costing Constants Maintenance".
    05  		line 19 col 21 value "*/^ Return to Main Menu". 
    05  		line 21 col 28 value "Option ". 
    05  scr3-option	line 21 col 35 pic x to option auto required. 
* 2015/01/29 - MC3 -end
* 
 
* MC4
*01  scr-4. 
  
*    05  blank screen. 
*    05  		line 05 col 17 value '1   Inventory Entry/Maintenance'. 
*    05  		line 07 col 17 value '2   Inventory Query'. 
*    05  		line 11 col 17 value "*   RETURN TO MAIN MENU". 
*    05  		line 14 col 28 value "OPTION ". 
*    05  scr4-option	line 14 col 35 pic x to option auto required. 
* MC4 - end 
 
* MC5
*01  scr-5. 
 
*    05  blank screen. 
*    05  		line 05 col 21 value "1   ON-LINE DOCUMENTATION". 
*    05  		line 07 col 21 value "2   DATA DICTIONARY". 
*    05  		line 09 col 21 value "*   RETURN TO MAIN MENU". 
*    05  		line 19 col 28 value "OPTION ". 
*    05  scr5-option	line 19 col 35 pic x to option auto required. 
* MC5 - end

01  scr-6. 
 
    05  blank screen. 
    05  		line 05 col 21 value "1   Fix Claim Header/Detail record". 
    05  		line 07 col 21 value "2   Fix Claim Header IKey   record". 
* 2011/06/16 - MC1 - m200
*   05  		line 09 col 21 value "*   RETURN TO MAIN MENU". 
    05  		line 09 col 21 value "3   Oscar Provider MENU". 
    05  		line 11 col 21 value "*   RETURN TO MAIN MENU". 
* 2011/06/15 - end
    05  		line 19 col 28 value "OPTION ". 
    05  scr6-option	line 19 col 35 pic x to option auto required. 


01  scr-7. 
 
    05  blank screen. 
    05  		line 05 col 21 value "1   Speadsheet upload Parameters". 
    05  		line 09 col 21 value "*   RETURN TO MAIN MENU". 
    05  		line 19 col 28 value "OPTION ". 
    05  scr7-option	line 19 col 35 pic x to option auto required. 

* 2013/06/25 - MC2 - bill direct sub menu screen
01  scr-8. 
 
    05  blank screen. 
    05  		line 03 col 21 value "1   Insurance Company Master".
    05  		line 05 col 21 value "2   Direct Bills - Message Master". 
    05  		line 07 col 21 value "3   Subdivision Master". 
    05  		line 09 col 21 value "*   RETURN TO MAIN MENU". 
    05  		line 19 col 28 value "OPTION ". 
    05  scr8-option	line 19 col 35 pic x to option auto required. 
* 2013/06/25 - end

01 scr-line-1-regular. 
    05  		line 01 col 01 pic x(10) from menu-name.
    05  		line 01 col 21 pic x(30) from menu-desc. 
    05  		line 01 col 71 pic 9(4) using sys-yy. 
    05  		line 01 col 75 value "/". 
    05  		line 01 col 76 pic 99 using sys-mm. 
    05  		line 01 col 78 value "/". 
    05  		line 01 col 79 pic 99 using sys-dd.
01 scr-line-1-blinking. 
    05  		line 01 col 01 pic x(10) from menu-name blink.
    05  		line 01 col 11 pic x(30) from menu-desc blink. 
    05			line 01 col 42 pic x(17) from app-message blink.
    05			line 01 col 60 pic x(6) from app-version blink.
    05  		line 01 col 71 pic 9(4) using sys-yy blink. 
    05  		line 01 col 75 value "/" blink. 
    05  		line 01 col 76 pic 99 using sys-mm blink. 
    05  		line 01 col 78 value "/" blink. 
    05  		line 01 col 79 pic 99 using sys-dd blink.
 
01  err-msg-line. 
    05  line 24 col 01	value " ERROR -  "	bell blink. 
    05  line 24 col 11	pic x(60)	using err-msg-comment. 
 
01  confirm. 
    05 line 23 col 01  value " ". 
 
01  blank-line-24. 
    05  line 24 col 1	blank line. 
 
01  blank-screen. 
    05  blank screen. 
 
 
01  scr-closing-screen. 
    05  blank screen. 
 
01  load-message. 
    05  line 24 col 5 value "PROGRAM NOW BEING LOADED". 
 
*  the following is added on 87/09/25 by m.s. for sms 97 
 
01  ph-message. 
    05  line 24 col 5 value "PROGRAM NOW BEING LOADED THRU POWERHOUSE - PLEASE WAIT". 
* 
01   scr-confirm       	line 23 col 1 pic x using confirm-space auto. 
 
 
procedure division. 
 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform az0-end-of-job		thru az0-99-exit. 
* 
    stop run. 
aa0-initialization. 

aa0-6. 
    accept sys-date			from date. 

*   (get the version of the application - if it's the currently defined
*    'live' version, then blank out the message, other allow it to be
*    displayed blinking ie. warn them if they are NOT in live)
 
    display "RMABILL_VERSION" upon environment-name 
	on exception
		display "FATAL ERROR - can't SET the Environment Variable for Version"
	 	display "Please Hit Enter - Application will SHUTDOWN!"
		accept scr-confirm
		stop run.	 

    accept app-version from environment-value 
	on exception
		display "FATAL ERROR - can't READ the Environment Variable for Version"
	 	display "Please Hit Enter - Application will SHUTDOWN!"
		accept scr-confirm
		stop run.	 

.
    if app-version = version-live
    then
 	move " "			to app-message
    else
	move "NOTE Version is: "	to app-message.
*   endif

    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-mm				to run-mm.                 
    move sys-dd				to run-dd. 
    move sys-yy				to run-yy. 
 
    accept sys-time			from time. 
    move sys-hrs			to run-hrs. 
    move sys-min			to run-min. 
    move sys-sec			to run-sec. 
 
aa0-10. 
 
    display scr-1. 
    move "Menu"				  to menu-name.
    move "Regional Medical Associates"	to menu-desc.
    if app-version = version-live
    then
	display scr-line-1-regular
    else
	display scr-line-1-blinking.
*   endif
 
*mf (zero option)
    move 0				to option.
    accept scr1-option.    
 
    move option				to  option. 
 
    if   option =  "*" 
      or option =  "^" 
      or (    option >= "A"
* 2013/06/25 - MC2 - allow option E for bill direct submenu
*         and option <= "D")
          and option <= "E")
* 2013/06/25 - end
      or      option = "Z"
      or (    option numeric 
          and option     >  "0" 
          and option not >  "9" ) 
    then  
        next sentence  
    else 
	move 1 to err-ind 
	perform za0-common-error	thru za0-99-exit 
    	go to aa0-10.        
*   endif 
 
    if option = "1"  
    then 
      display load-message  
      chain "$pb_obj/d001" 
    else 
      if option = "2" 
      then 
	display load-message 
	chain "$pb_obj/d002" 
      else 
	if option = "3" 
	then 
	  display load-message 
	  call "$pb_obj/d003" 
        else 
	  if option = "4" 
	  then 
   	    display load-message 
 	    chain "$pb_obj/d004"     
	  else 
	    if option = "5" 
	    then 
	      perform ba2-screen2		thru	ba2-99-exit 
	    else 
	      if option = "6" 
	      then 
                display load-message 
	        move "quick term=vt220 auto=$pb_obj/m100.qkc" to macro 
                call "SYSTEM" using macro 
	      else 
 	        if option = "7" 
  	        then 
		  display load-message 
		  move 'quick auto=$pb_obj/d713.qkc' 	to macro 
		  call "SYSTEM" using macro 
		else 
		  if option = "8" 
		  then 
	   	    display load-message 
		    chain "$pb_obj/d050" 
                  else 
* MC5
*			if option = "9" 
*			then 
*			    perform ba5-screen5	thru	ba5-99-exit 
*			else 
* MC5 - end
			if option = "A" 
			then 
			    perform ba3-screen3	thru	ba3-99-exit 
			else 
* MC4
* 	        	if option = "B" 
*  	        	then 
* 		            perform ba4-screen4	thru	ba4-99-exit 
*		        else 
* MC4 - end
 	        	if option = "C" 
  	        	then 
 		            perform ba6-screen6	thru	ba6-99-exit 
			else 
 	        	if option = "D" 
  	        	then 
 		            perform ba7-screen7	thru	ba7-99-exit 
			else 
* 2013/06/25 - MC2 - bill direct submenu
 	        	if option = "E" 
  	        	then 
 		            perform ba8-screen8	thru	ba8-99-exit 
			else 
* 2013/06/25 - end
			if option = "Z" 
			then
        			move "passwd"    to macro 
				call "SYSTEM" using macro 
			else
			    if     option = "*" 
				or option = "^"
			    then 
				go to aa0-99-exit 
			    else 
				go to aa0-10. 
*			    endif 
*			endif 
*			endif 
*			endif 
*			endif 
*			endif 
*		  endif 
*		endif 
*	      endif 
*	    endif 
*	  endif 
*	endif 
*     endif 
*   endif 
 
    go to aa0-10. 
 
aa0-99-exit. 
  exit. 


az0-end-of-job. 
    display blank-screen. 
    accept sys-time			from 	time. 
    display scr-closing-screen. 
    display confirm. 
    stop run. 
 
az0-99-exit. 
    exit. 


ba2-screen2. 
 
    display scr-2. 
    move "Menu-1"                         to menu-name.
    move "       RMA File Maintenance - " to menu-desc.
    if app-version = version-live
    then
	display scr-line-1-regular
    else
	display scr-line-1-blinking.
*   endif

 
ba2-10. 
    accept scr2-option. 
 
* MC6
*   if    option = '1' or '2' or '3' or '4' or '5' or '6' or '7' 
    if    option = '1' or '2'        or '4' or '5' or '6' or '7' 
* MC6 - end
* 2013/06/25 - MC2 - ignore 'A', 'a', 'B', 'b'
*		or '8' or '9' or 'A' or 'a' or 'B' or 'b' or 'C' or 'c'
		or '8' or '9' or 'C' or 'c'
* 2013/06/25 - end
		or 'D' or 'd' or 'E' or 'e' or 'F' or 'f' or 'G' or 'g'
* MC5 - exclude option I, K, L, P, R
*		or 'H' or 'h' or 'I' or 'i' or 'J' or 'j' or 'K' or 'k'
*		or 'L' or 'l' or 'M' or 'm' or 'N' or 'n' or "O" or 'o' 
*		or "P" or 'p' or "Q" or 'q' or "R" or 'r' or 'V' or 'v'
		or 'H' or 'h' or               'J' or 'j'                   
		              or 'M' or 'm' or 'N' or 'n' or "O" or 'o' 
		              or "Q" or 'q'               or 'V' or 'v'
* MC5 - end
* 2013/04/03 - MC - include option S or s
*		or 'W' or 'w'
		or 'W' or 'w' or 'S' or 's'
* 2013/04/03 - end
		or 'X' or 'x' or 'Y' or 'y' or 'Z' or 'z' or '*' or '^'
    then 
        next sentence 
    else 
	move 1 to err-ind 
	perform za0-common-error  	thru za0-99-exit 
   	go to ba2-screen2.   
*   endif 
 
    if option = "1"  
    then 
 	display load-message 
	move "MENU"		to	link-flag 
	move spaces		to	link-data 
*       chain "m010" using linkage-data 
        move "quick auto=$pb_obj/m010.qkc" to macro 
	call "SYSTEM" using macro 
    else 
	if option = "2" 
	then 
	    display load-message 
*	    chain "m020" 
            move 'quick auto=$pb_obj/m020.qkc' to macro 
	    call "SYSTEM" using macro 
	else 
* MC6
*	    if option = "3" 
*	    then 
*		display ph-message 
*mf		move 'f021_doc_nbrs.cli' to macro 
*		move '. $cmd/f021_doc_nbrs' to macro 
*		call "SYSTEM" using macro 
*	    else 
* MC6 - end
	    if option = "4" 
	    then 
		display load-message 
		chain "$pb_obj/m030" 
	    else 
 		if option = "5" 
		then 
		    display load-message 
		    chain "$pb_obj/m040" 
		else 
		    if option = "6" 
		    then 
			display load-message 
			chain "$pb_obj/m070" 
		    else 
			if option = "7" 
			then 
			    display load-message 
 			    chain "$pb_obj/m080" 
 			else 
			    if option = "8" 
			    then 
				display load-message 
				chain "$pb_obj/m090" 
			    else 
				if option = "9" 
				then 
				    display load-message 
*				    chain "m010_hso" 
                                    move 'quick auto=$pb_obj/m098.qkc' to macro 
	                            call "SYSTEM" using macro 
				else 
* 2013/06/25 - MC2 - comment out, transfer to bill direct submenu
* 				    if option = "A" or 'a'
*				    then 
*				        display load-message 
*				        chain "$pb_obj/m094" 
*				    else 
*				        if option = "B" or 'b'
*				        then 
*				            display load-message 
*				            chain "$pb_obj/m095" 
*				        else 
* 2013/06/25 - end
					    if option = "C" or 'c'
					    then 
						display ph-message 
*mf					        move 'f096_pay_code.cli' to macro 
					        move '. $cmd/f096_pay_code' to macro 
						call "SYSTEM" using macro 
                                             else 
                                               if option = "D" or 'd'
	                                       then 
	                                           display load-message 
*                                                  chain "m091" 
                                                   move 'quick auto=$pb_obj/m091.qkc' to macro 
	                                           call "SYSTEM" using macro 
					    else 
						if option = "E" or 'e'
						then 
 						    display load-message 
						    move "quick auto=$pb_obj/m101.qkc" to macro 
						    call "SYSTEM" using macro 
					    else 
						if option = "F" or 'f'
						then 
 						    display load-message 
						    move "quick auto=$pb_obj/m102.qkc" to macro 
						    call "SYSTEM" using macro 
					    else 
*		if option = "G"  or 'g'
*	    	then 
* 		    display load-message 
*		    move "quick auto=$pb_obj/d085.qkc" to macro 
*		    call "SYSTEM" using macro 
*	    else 
*		if option = "H" or 'h'
*		then 
* 		    display load-message 
*		    move "quick auto=$pb_obj/d087.qkc" to macro 
*		    call "SYSTEM" using macro 
*	    else 
* MC5
*					        if option = "I" or 'i'
*						then 
* 						    display load-message 
*						    move "quick auto=$pb_obj/in01.qkc" to macro 
*						    call "SYSTEM" using macro 
*
*					    else 
* MC5 - end
						if option = "J" or 'j'
						then 
 						    display load-message 
						    move "quick auto=$pb_obj/m940.qkc" to macro 
						    call "SYSTEM" using macro 
					    else 
* MC5
*						if option = "K" or 'k'
*						then 
* 						    display load-message 
*						    move "quick auto=$pb_obj/m093.qkc" to macro 
*						    call "SYSTEM" using macro 
*					    else 
*						if option = "L" or 'l'
*						then 
* 						    display load-message 
*						    move "quick auto=$pb_obj/m092.qkc" to macro 
*						    call "SYSTEM" using macro 
*					    else
* MC5 - end
						if option = "M" or 'm'
						then 
 						    display load-message 
						    move "quick auto=$pb_obj/m090g.qkc" to macro 
						    call "SYSTEM" using macro 
					    else 
						if option = "N" or 'n'
						then 
 						    display load-message 
						    move "quick auto=$pb_obj/m083.qkc" to macro 
						    call "SYSTEM" using macro 
					    else 
						if option = "O" or 'o'
						then 
 						    display load-message 
						    move "quick auto=$pb_obj/utl1002.qkc" to macro 
						    call "SYSTEM" using macro 
					    else 
						if option = "P" or 'p'
						then 
 						    display load-message 
						    move "quick auto=$pb_obj/m941.qkc" to macro 
						    call "SYSTEM" using macro 
					    else 
						if option = "Q" or 'q'
						then 
 						    display load-message 
						    move "quick auto=$pb_obj/m923.qkc" to macro 
						    call "SYSTEM" using macro 
					    else 
						if option = "R" or 'r'
						then 
 						    display load-message 
						    move "quick auto=$pb_obj/m924.qkc" to macro 
						    call "SYSTEM" using macro 
					    else 
* 2013/04/03 - MC
						if option = "S" or 's'
						then 
 						    display load-message 
						    move "quick auto=$pb_obj/m020c.qkc" to macro 
						    call "SYSTEM" using macro 
					    else 
* 2013/04/03 - end
						if option = "V" or "v"
						then 
 						    display load-message 
						    move "quick auto=$pb_obj/m074a.qkc" to macro 
						    call "SYSTEM" using macro 
					    else 
						if option = "W" or 'w'
						then 
 						    display load-message 
						    move "quick auto=$pb_obj/m074.qkc" to macro 
						    call "SYSTEM" using macro 
					    else 
						if option = "X" or 'x'
						then 
 						    display load-message 
						    move "quick auto=$pb_obj/m075.qkc" to macro 
						    call "SYSTEM" using macro 
					    else 
						if option = "Y" or 'y'
						then 
 						    display load-message 
						    move "quick auto=$pb_obj/m123.qkc" to macro 
						    call "SYSTEM" using macro 
					    else 
						if option = "Z" or 'z'
						then 
 						    display load-message 
						    move "quick auto=$pb_obj/m090.qkc" to macro 
						    call "SYSTEM" using macro 
					    else 
				            	if   option = "*" 
						  or option = "^"
				            	then 
					            go to ba2-99-exit 
				            	else 
					            go to ba2-10. 
*						endif 
*				    		endif 
*					    endif 
*					endif 
*				    endif 
*			        endif 
*			    endif 
*			endif 
*		    endif 
*		endif 
*	    endif 
*	    endif 
*	endif 
*   endif 
 
ba2-99-exit. 
    exit. 



ba3-screen3. 
 
    display scr-3. 
    move "Menu-2"                         to menu-name.
    move "      RMA Costing Subsystem - " to menu-desc.
    if app-version = version-live
    then
	display scr-line-1-regular
    else
	display scr-line-1-blinking.
*   endif

 
ba3-10. 
    accept scr3-option. 
 
    if    option = "*" 
       or option = "^"
       or (    option numeric 
           and option >  "0"      
           and option <= "4"  
  	  ) 
       or (    option >= "A"
* 2015/01/29 - MC3
*	   and option <= "B"
	   and option <= "C"
* 2015/01/29 - MC3 - end
	  )
       or option = "Z"
    then 
	next sentence 
    else 
	move 1					to	err-ind     
	perform za0-common-error		thru	za0-99-exit 
	go to ba3-screen3. 
*   endif 
 
 
    if option = "1" 
    then 
	display load-message 
	move "quick term=vt220 auto=$pb_obj/m088.qkc" to macro 
        call "SYSTEM" using macro 
    else
        if option = "2" 
        then 
	    display load-message 
	    move "quick term=vt220 auto=$pb_obj/d087_hdr.qkc" to macro 
            call "SYSTEM" using macro 
    else
        if option = "3" 
        then 
	    display load-message 
	    move "quick term=vt220 auto=$pb_obj/d087.qkc" to macro 
            call "SYSTEM" using macro 
    else 
* 2011/05/18 - MC
        if option = "4" 
        then 
	    display load-message 
	    move "quick term=vt220 auto=$pb_obj/m201.qkc" to macro 
            call "SYSTEM" using macro 
    else 
* 2011/05/18 - end
        if option = "A" 
        then 
            display load-message 
	    move "quick term=vt220 auto=$pb_obj/m093.qkc" to macro 
            call "SYSTEM" using macro 
    else
        if option = "B" 
        then 
            display load-message 
	    move "quick term=vt220 auto=$pb_obj/m092.qkc" to macro 
            call "SYSTEM" using macro 
    else     
* 2015/01/29 - MC3
        if option = "C"
        then 
            display load-message 
	    move "quick term=vt220 auto=$pb_obj/m096.qkc" to macro 
            call "SYSTEM" using macro 
    else     
* 2015/01/29 - MC3 - end
        if option = "Z" 
        then 
            display load-message 
	    move "quick term=vt220 auto=$pb_obj/m090g.qkc" to macro 
            call "SYSTEM" using macro 
    else     
	if   option = "*"  
       	  or option = "^"
	then 
	   go to ba3-99-exit 
        else 
	   go to ba3-10. 
*   ENDCASE
 
ba3-99-exit. 
    exit. 
ba4-screen4. 
 
* MC4
*    display scr-4. 
* MC4 - end
    move "Menu-3"                         to menu-name.
    move "RMA Claims Inventory System - " to menu-desc.
    if app-version = version-live
    then
	display scr-line-1-regular
    else
	display scr-line-1-blinking.
*   endif

 
ba4-10. 
* MC4
*    accept scr4-option. 
* MC4 - end 
    if    option = "*" 
       or option = "^"
      or (    option numeric 
          and option > "0" 
          and option < "3") 
    then 
	next sentence 
    else 
	move 1					to	err-ind 
	perform za0-common-error		thru	za0-99-exit 
	go to ba4-screen4. 
*   endif 
 
    if option = "1" 
    then 
        display load-message 
	move "quick term=vt220 auto=$pb_obj/d084.qkc" to macro 
        call "SYSTEM" using macro 
    else 
	if option = "2" 
	then 
            display load-message 
	    move "quick term=vt220 auto=$pb_obj/m084a.qkc" to macro 
            call "SYSTEM" using macro 
*2000/07/26 - MC -comment out extra call
*            call "SYSTEM" using macro 
*2000/07/26 - MC 
	else 
		    if    option = "*" 
		       or option = "^"
		    then 
			go to ba4-99-exit 
		    else 
			go to ba4-10. 
*		    endif 
*	endif 
*   endif 
 
ba4-99-exit. 
    exit. 


ba5-screen5. 
 
* MC5
*    display scr-5. 
* MC5 - end
    move "Menu-4"                         to menu-name.
    move "RMA Documentation Sub-System- " to menu-desc.
    if app-version = version-live
    then
	display scr-line-1-regular
    else
	display scr-line-1-blinking.
*   endif

 
ba5-10. 
* MC5
*    accept scr5-option. 
* MC5 - end
 
    if    option = "*" 
       or option = "^"
      or (    option numeric 
          and option > "0" 
          and option < "3") 
    then 
	next sentence 
    else 
	move 1					to	err-ind 
	perform za0-common-error		thru	za0-99-exit 
	go to ba5-screen5. 
*   endif 
 
    if option = "1" 
    then 
	display load-message 
	chain "$pb_obj/m099" 
    else 
	if option = "2" 
	then 
	    display load-message 
	    chain "$pb_obj/d811" 
	else 
	    if   option = "*" 
       	      or option = "^"
	    then 
		go to ba5-99-exit 
	    else 
		go to ba5-10.    
*	    endif 
*	endif 
*   endif 
 
ba5-99-exit. 
    exit. 


ba6-screen6. 
 
    display scr-6. 
    move "Menu-5"                         to menu-name.
    move "Administrator Utilities- " to menu-desc.
    if app-version = version-live
    then
	display scr-line-1-regular
    else
	display scr-line-1-blinking.
*   endif

 
ba6-10. 
    accept scr6-option. 
 
    if    option = "*" 
       or option = "^"
      or (    option numeric 
          and option > "0" 
* 2002/03/20 - M.C.
*         and option < "2") 

* 2011/06/16 - MC1
*         and option < "3") 
          and option < "4") 
* 2011/06/16 - end

* 2002/03/20 - end
    then 
	next sentence 
    else 
	move 1					to	err-ind 
	perform za0-common-error		thru	za0-99-exit 
	go to ba6-screen6. 
*   endif 
 
    if option = "1" 
    then 
        display load-message 
	move "quick term=vt220 auto=$pb_obj/utl1000.qkc" to macro 
        call "SYSTEM" using macro 
    else 
	if option = "2" 
	then 
	    display load-message 
* 2002/03/20 - M.C.
*	    chain "$pb_obj/d811" 
	    move "quick term=vt220 auto=$pb_obj/utl1002.qkc" to macro 
            call "SYSTEM" using macro 
* 2002/03/20 - end 

* 2011/06/16 - MC1 - call m200.qkc
    else 
	if option = "3" 
	then 
	    display load-message 
	    move "quick term=vt220 auto=$pb_obj/m200.qkc"    to macro 
            call "SYSTEM" using macro 
* 2011/06/16 - end 
	else 
	    if   option = "*" 
       	      or option = "^"
	    then 
		go to ba6-99-exit 
	    else 
		go to ba6-10.    
*	    endif 
*	endif 
*   endif 
 
ba6-99-exit. 
    exit. 


ba7-screen7. 
 
    display scr-7. 
    move "Menu-7"                         to menu-name.
    move "Operator Programs" to menu-desc.
    if app-version = version-live
    then
	display scr-line-1-regular
    else
	display scr-line-1-blinking.
*   endif

ba7-10. 
    accept scr7-option. 
 
    if    option = "*" 
       or option = "^"
      or (    option numeric 
          and option > "0" 
          and option <="1") 
    then 
	next sentence 
    else 
	move 1					to	err-ind 
	perform za0-common-error		thru	za0-99-exit 
	go to ba7-screen7. 
*   endif 
 
    if option = "1" 
    then 
        display load-message 
	move "quick term=vt220 auto=$pb_obj/m113.qkc" to macro 
        call "SYSTEM" using macro 
    else 
	    if   option = "*" 
       	      or option = "^"
	    then 
		go to ba7-99-exit 
	    else 
		go to ba7-10.    
*	    endif 
*	endif 
*   endif 
 
ba7-99-exit. 
    exit. 


* 2013/06/25 - MC2 -  bill direct submenu
ba8-screen8. 
 
    display scr-8. 
    move "Menu-8"                    to menu-name.
    move "Bill Direct Submenu      " to menu-desc.
    if app-version = version-live
    then
	display scr-line-1-regular
    else
	display scr-line-1-blinking.
*   endif

 
ba8-10. 
    accept scr8-option. 
 
    if    option = "*" 
       or option = "^"
      or (    option numeric 
          and option > "0" 
          and option <="3") 
    then 
	next sentence 
    else 
	move 1					to	err-ind 
	perform za0-common-error		thru	za0-99-exit 
	go to ba8-screen8. 
*   endif 
 
    if option = "1" 
    then 
        display load-message 
	move "quick term=vt220 auto=$pb_obj/m076.qkc" to macro 
        call "SYSTEM" using macro 
    else
        if option = "2"
        then 
            display load-message 
            chain "$pb_obj/m094" 
         else 
	    if option = "3"
	    then 
	        display load-message 
                chain "$pb_obj/m095" 
            else 
	        if   option = "*" 
       	          or option = "^"
	        then 
		    go to ba8-99-exit 
	        else 
		    go to ba8-10.    
*	        endif 
*	    endif 
*       endif 
*   endif 

ba8-99-exit.
    exit.
 
* 2013/06/25 - end


za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment. 
    display err-msg-line. 
    accept scr-confirm. 
*   display confirm. 
*   stop " ". 
    display blank-line-24. 
 
za0-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".