#-------------------------------------------------------------------------------
# File 'suspend_dtl.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'suspend_dtl'
#-------------------------------------------------------------------------------

# 2010/02/23  yas  quiz auto=$obj/dump_tech.qzc ;replaced by the dump_tech.qzu
# 2012/01/06 - comment out suspend_fee.txt - as per Linda O. Renee and Nancy
# 2012/05/01 - include new program suspdtl_2.qtc   and pass the parameter 1 for 'before'

Remove-Item suspdtl.sf* *> $null
Remove-Item suspdtl_all.sf* *> $null
Remove-Item suspdtl_all_sort.sf* *> $null
Remove-Item suspdtl.txt *> $null
Remove-Item web_before_after.txt *> $null

$rcmd = $env:QTP + "suspdtl"
Invoke-Expression $rcmd
$rcmd = $env:QTP + "suspdtl_2 1"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "suspend_dtl1"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "suspend_dtl2"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content suspend_dtl1.txt > suspdtl.txt
Get-Content suspend_dtl2.txt >> suspdtl.txt

$rcmd = $env:QTP + "suspend_agent_detail"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "suspend_agent"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "suspend_agent_detail"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "dump_tech1"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "dump_tech2 DISC_dump_tech.rf"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
# Get-Content dump_tech2.txt > dump_tech.txt

$rcmd = $env:QUIZ + "suspend_desc"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "suspend_suffix"
Invoke-Expression $rcmd
#quiz auto=$obj/suspend_fee.qzc
