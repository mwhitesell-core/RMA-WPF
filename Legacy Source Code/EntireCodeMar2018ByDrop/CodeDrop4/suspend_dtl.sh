# 2010/02/23  yas  quiz auto=$obj/dump_tech.qzc ;replaced by the dump_tech.qzu
# 2012/01/06 - comment out suspend_fee.txt - as per Linda O. Renee and Nancy
# 2012/05/01 - include new program suspdtl_2.qtc   and pass the parameter 1 for 'before'

rm suspdtl.sf* 1>/dev/null 2>&1
rm suspdtl_all.sf* 1>/dev/null 2>&1
rm suspdtl_all_sort.sf* 1>/dev/null 2>&1
rm suspdtl.txt 1>/dev/null 2>&1  
rm web_before_after.txt 1>/dev/null 2>&1  

qtp << QTP_EXIT 
cancel clear
execute $obj/suspdtl
execute $obj/suspdtl_2  
1
QTP_EXIT
quiz << QUIZ_EXIT
use $obj/suspend_dtl.qzu
QUIZ_EXIT
qtp auto=$obj/suspend_agent_detail.qtc
quiz auto=$obj/suspend_agent.qzc
quiz auto=$obj/suspend_agent_detail.qzc
quiz auto=$obj/dump_tech.qzu
quiz auto=$obj/suspend_desc.qzc
quiz auto=$obj/suspend_suffix.qzc
#quiz auto=$obj/suspend_fee.qzc
