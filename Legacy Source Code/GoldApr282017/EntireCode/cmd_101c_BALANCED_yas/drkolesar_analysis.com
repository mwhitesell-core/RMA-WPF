# 2013/Jul/30  MC - run Dr Kolesar analysis for service date >= 2011/Jul/01
#		  - there are 3 passes to be executed - drkolesar.qts, drkolesar_doc.qts & drkolesar_yr.qts
#		  - drkolesar.qts have catered for next 5 years, modify accordingly if needed
#		  - drkolesar_doc.qts & drkolesar_yr.qts have the 6 doctors exclusion, modify accordingly if needed
#		  - the first pass (drkolesar.qts) should not need to rerun as data should not have changed for previous year
#		    except the recent one
#		  - second(drkolesar_doc.qts) & third (drkolesar_yr.qts) passes can be rerun separately if needed 
#		    but tmp-counter-dup must be recreated via qutil before running because tmp-counters-dup is for
#		    median calculation purpose

echo
date
echo

cd /alpha/rmabill/rmabill101c/src/yas

rm kolesar*.sf*  
rm kolesar*.ps*

qutil << qutil_EXIT
create file tmp-counters-dup
qutil_EXIT

qtp << qtp_EXIT
exe $obj/drkolesar.qtc
exe $obj/drkolesar_doc.qtc
exe $obj/drkolesar_yr.qtc
qtp_EXIT

echo
date
echo
