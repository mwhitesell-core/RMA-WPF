#-------------------------------------------------------------------------------
# File 'suspend_dtl.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'suspend_dtl'
#-------------------------------------------------------------------------------

# 2010/02/23  yas  quiz auto=$obj/dump_tech.qzc ;replaced by the dump_tech.qzu
# 2012/01/06 - comment out suspend_fee.txt - as per Linda O. Renee and Nancy
# 2012/05/01 - include new program suspdtl_2.qtc   and pass the parameter 1 for 'before'

Remove-Item suspdtl.sf*  > $null
Remove-Item suspdtl_all.sf*  > $null
Remove-Item suspdtl_all_sort.sf*  > $null
Remove-Item suspdtl.txt  > $null
Remove-Item web_before_after.txt  > $null

$pipedInput = @"
cancel clear
execute $obj/suspdtl
execute $obj/suspdtl_2  
1
"@

$pipedInput | qtp++
$pipedInput = @"
use $obj/suspend_dtl.qzu
"@

$pipedInput | quiz++
qtp++ $obj\suspend_agent_detail
quiz++ $obj\suspend_agent
quiz++ $obj\suspend_agent_detail
quiz++ $obj\dump_tech
quiz++ $obj\suspend_desc
quiz++ $obj\suspend_suffix
#quiz auto=$obj/suspend_fee.qzc
