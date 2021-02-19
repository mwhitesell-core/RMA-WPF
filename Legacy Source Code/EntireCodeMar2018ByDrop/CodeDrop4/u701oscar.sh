#   NAME: u701oscar
# 
#   PURPOSE: OHIP DISKETTE (from OSCAR EMR) INPUT INTO RMA SYSTEM
#            THIS MACRO WILL TAKE A FILE FOR A SPECIFIED DOCTOR
# 		  AND MOVE ALL CLAIMS INTO THE SUSPENSE FILES, APPLY
# 		  THE PATIENTS WITHIN BATCH AGAINST THE PATIENT/SUBSCRIBER
# 		  MASTERS, AND FINALLY UPDATE THE SUSPENSE RECORDS WITH THE
# 		  ID's OF THE PATIENTS.
#   MODIFICATION HISTORY
#      DATE   PERSON        DESCRIPTION (PDR/SMS #)
#   90/JUL/01 B. ELLIOTT    ORIGINAL
#   90/OCT/31 Y. BOCCIA     ADD QPRINT R707.TXT
#   98/JAN/21 KEVIN MILES   MODIFIED FOR UNIX
#   00/sep/21 B.E.	    - added processing of 'description' records
#   May/25/2010 Yas         - Add ru701_acr sorted by pat acrynm then by accounting number
#   2011/jan/30 brad1	  - cloned from newu701

if [ "$1" = "" ]
then
	echo 
	echo 
	echo "**ERROR**"
	echo You must supply the 6 digit Doctor OHIP number for the batch to be processed!
	echo
	echo Valid Format:	u701oscar	bx999999
	exit
else
	if [ ! -f f002_submit_disk_${1}.in ]
	then
		echo  
		echo  "**ERROR** No such batch found!"
		echo 
		exit
	else
	if ( [ -f submit_disk_susp.in ] !! [ -f submit_disk_desc.in ] )
	then
		echo  
		echo 
		echo  "**ERROR** Unprocessed suspense batch found !"
		echo            You must manually re-process the batch
		echo		 submit_disk_susp.in / submit_disk_mr.in
		echo            before re-running u701oscar
		echo 
		exit
	else
       		mv f002_submit_disk_${1}.in submit_disk_susp.in
       		mv f002_submit_desc_${1}.in submit_disk_desc.in 1>/dev/null 2>/dev/null
		echo 
		echo 
		echo  Place claims into suspense files ...
		cobrun $obj/u701oscar
		echo 
		echo  print status report ...
		ls -laF ru701_oscar 1>/dev/null 2>&1
#		lp ru701_oscar
		if [ -f submit_disk_desc.in ] 
		then
		  echo "Continue ? "
		  read garbage
		  echo  Place Description records into suspense ...
	  	  qtp auto=$obj/newu701.qtc
		else
		  echo  No Description records to process
		fi

		#cat ru701_cycle ru701_oscar >/usr/tmp/ru701_cycle.tmp  
		#mv /usr/tmp/ru701_cycle.tmp  ru701_cycle
		cat ru701_cycle ru701_oscar > newu701.tmp
		mv                      newu701.tmp  ru701_cycle
		echo "Continue ? "
		read garbage
		echo 
		echo 
		$cmd/check_for_resubmits

		echo 
#		echo  Select special oma codes
#		qtp auto=$obj/u710.qtc
#		echo 
#		echo  Report selected special oma codes
#		rm r711.txt 1>/dev/null 2>&1
#		quiz auto=$obj/r711.qzc
#		echo 
#		ls -laF r711.txt 1>/dev/null 2>&1
#		lp r711.txt 1>/dev/null 2>&1
		echo 
		echo 
		echo  Report duplicate claims
		rm r712.txt 1>/dev/null 2>&1

		quiz auto=$obj/r712.qzc
		echo 
		ls -laF r712.txt 1>/dev/null 2>&1
#		lp r712.txt
		echo 
		echo 
		echo  Extract batch\'s Patient data
		rm submit_disk_pat_in.sf* 1>/dev/null 2>&1
		quiz auto=$obj/r702.qzc
#		#quiz auto=$obj/me.qzc
		echo 
		echo  Extracted patient data file:
		ls -laF submit_disk_pat_in.sf*
#b		echo "Continue ? "
#b		read garbage
		echo 
		echo 
		echo  Process batch\'s Patient data against RMA\'s patient/subscriber database
		echo 
		rm submit_disk_pat_out 1>/dev/null 2>&1
		cobrun $obj/u703oscar
		ls -laF ru703[a-z0-9] 1>/dev/null 2>&1
#		lp ru703a
#		lp ru703c
#b		echo "Continue ? "
#b		read garbage
		echo 
		echo  Processed patient data:
		ls -laF submit_disk_pat_out 1>/dev/null 2>&1
		echo 
		echo 
		echo  Apply processed patients against suspense files
		echo 
		qtp auto=$obj/u704.qtc
		echo 
		rm r707.txt 1>/dev/null 2>&1
		quiz auto=$obj/r707.qzc
#		lp r707.txt
#b		echo "Continue ? "
#b		read garbage
		echo 
		qtp auto=$obj/u705.qtc
		echo 
		echo  "cleanup: rename input file as successfully processed"
		mv submit_disk_susp.in submit_disk_${1}.out
		mv submit_disk_desc.in submit_desc_${1}.out 1>/dev/null 2>/dev/null
#		lp ru703c.txt 1>/dev/null 2>&1
		echo "running r710 to highlight claims with Percentage add-ons"
		echo "    that will likely need pricing attention..."
		quiz auto=$obj/r710.qzc
#		lp r710.txt

######### Add ru701_acr May 25, 2010  sorted by pat acronym  then by accounting number
                quiz auto=$obj/ru701_acr.qzc

		fi
	fi
fi
echo 
echo 
#b echo "Continue ? "
#b read garbage
echo 
echo 
