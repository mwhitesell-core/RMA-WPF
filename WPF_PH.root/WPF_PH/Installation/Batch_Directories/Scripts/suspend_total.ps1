#-------------------------------------------------------------------------------
# File 'suspend_total.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'suspend_total'
#-------------------------------------------------------------------------------

# 2012/05/01 - include new program suspdtl_2.qtc   and pass the parameter 2 for 'after'  
#              and report program web_before_after.qzc
# 2012/May/10 - include new program web_before_after.qtc to be run before the report
# 2016/Apr/11 MC1 - include the run of suspend_total2.qzc after suspend_total1.qzc

Remove-Item suspdtl.sf* *> $null
Remove-Item suspend_suffix.txt *> $null
Remove-Item suspend_total.txt *> $null
Remove-Item suspend_status.txt *> $null
Remove-Item check_susp_dtl.txt *> $null
Remove-Item web_before_after.txt *> $null

$rcmd = $env:QTP + "suspdtl"
Invoke-Expression $rcmd
$rcmd = $env:QTP + "suspdtl_2 2"
Invoke-Expression $rcmd
$rcmd = $env:QTP + "web_before_after"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "suspend_total1"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "suspend_total2"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content suspend_total1.txt > suspend_total.txt
Get-Content suspend_total2.txt >> suspend_total.txt

$rcmd = $env:QUIZ + "check_susp_dtl"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "suspend_status"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "suspend_suffix"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "web_before_after DISC_web_before_after.rf"
Invoke-Expression $rcmd

&$env:cmd\resubmits
Get-Content suspend_total.txt | Out-Printer
Get-Content check_susp_dtl.txt | Out-Printer
Get-Content suspend_status.txt | Out-Printer
Get-Content suspend_suffix.txt | Out-Printer
##lp web_before_after.txt
