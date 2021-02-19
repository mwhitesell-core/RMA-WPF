# file: check_for_resubmits  -- alias resubmits
# purpose: update status of suspended claim to "R"esubmit
#	   if accounting number already on f071
#	   print report of resubmitted claims

echo  Select resubmit claims
echo
qtp auto=$obj/u714.qtc

echo
echo  Report selected resubmit claims
echo
rm r715.txt 1>/dev/null 2>&1
quiz auto=$obj/r715.qzc
lp r715.txt
