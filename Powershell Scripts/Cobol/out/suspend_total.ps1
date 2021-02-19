#-------------------------------------------------------------------------------
# File 'suspend_total.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'suspend_total'
#-------------------------------------------------------------------------------

# 2012/05/01 - include new program suspdtl_2.qtc   and pass the parameter 2 for 'after'  
#              and report program web_before_after.qzc
# 2012/May/10 - include new program web_before_after.qtc to be run before the report
# 2016/Apr/11 MC1 - include the run of suspend_total2.qzc after suspend_total1.qzc

Remove-Item suspdtl.sf*  > $null
Remove-Item suspend_suffix.txt  > $null
Remove-Item suspend_total.txt  > $null
Remove-Item suspend_status.txt  > $null
Remove-Item check_susp_dtl.txt  > $null
Remove-Item web_before_after.txt  > $null

$pipedInput = @"
cancel clear
execute $obj/suspdtl
execute $obj/suspdtl_2 
2
execute $obj/web_before_after
"@

$pipedInput | qtp++

$pipedInput = @"
execute $obj/suspend_total1
execute $obj/suspend_total2
execute $obj/check_susp_dtl
execute $obj/suspend_status 
execute $obj/suspend_suffix
execute $obj/web_before_after
"@

$pipedInput | quiz++

$cmd\resubmits
Get-Contents suspend_total.txt| Out-Printer
Get-Contents check_susp_dtl.txt| Out-Printer
Get-Contents suspend_status.txt| Out-Printer
Get-Contents suspend_suffix.txt| Out-Printer
##lp web_before_after.txt
