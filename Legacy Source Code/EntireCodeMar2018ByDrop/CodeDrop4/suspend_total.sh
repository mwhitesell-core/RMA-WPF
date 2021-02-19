# 2012/05/01 - include new program suspdtl_2.qtc   and pass the parameter 2 for 'after'  
#	       and report program web_before_after.qzc
# 2012/May/10 - include new program web_before_after.qtc to be run before the report
# 2016/Apr/11 MC1 - include the run of suspend_total2.qzc after suspend_total1.qzc

rm suspdtl.sf*        1>/dev/null 2>&1  
rm suspend_suffix.txt 1>/dev/null 2>&1  
rm suspend_total.txt 1>/dev/null 2>&1  
rm suspend_status.txt 1>/dev/null 2>&1  
rm check_susp_dtl.txt 1>/dev/null 2>&1  
rm web_before_after.txt 1>/dev/null 2>&1  

qtp << QTP_EXIT 
cancel clear
execute $obj/suspdtl
execute $obj/suspdtl_2 
2
execute $obj/web_before_after
QTP_EXIT

quiz << QUIZ_EXIT
execute $obj/suspend_total1
execute $obj/suspend_total2
execute $obj/check_susp_dtl
execute $obj/suspend_status 
execute $obj/suspend_suffix
execute $obj/web_before_after
QUIZ_EXIT

$cmd/resubmits
lp suspend_total.txt
lp check_susp_dtl.txt   
lp suspend_status.txt
lp suspend_suffix.txt
##lp web_before_after.txt
