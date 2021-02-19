#-------------------------------------------------------------------------------
# File 'suspend_total.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'suspend_total.bk1'
#-------------------------------------------------------------------------------

# 2012/05/01 - include new program suspdtl_2.qtc   and pass the parameter 2 for 'after'  
#              and report program web_before_after.qzc
# 2012/May/10 - include new program web_before_after.qtc to be run before the report

Remove-Item suspdtl.sf* *> $null
Remove-Item suspend_suffix.txt *> $null
Remove-Item suspend_total.txt *> $null
Remove-Item suspend_status.txt *> $null
Remove-Item check_susp_dtl.txt *> $null
Remove-Item web_before_after.txt *> $null

&$env:QTP suspdtl
&$env:QTP suspdtl_2 2
&$env:QTP web_before_after

&$env:QUIZ suspend_total1
&$env:QUIZ check_susp_dtl
&$env:QUIZ suspend_status
&$env:QUIZ suspend_suffix
&$env:QUIZ web_before_after

&$env:cmd\resubmits
Get-Content suspend_total.txt | Out-Printer
Get-Content check_susp_dtl.txt | Out-Printer
Get-Content suspend_status.txt | Out-Printer
Get-Content suspend_suffix.txt | Out-Printer
##lp web_before_after.txt
