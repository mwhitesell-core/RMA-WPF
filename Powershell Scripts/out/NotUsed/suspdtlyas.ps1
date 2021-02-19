#-------------------------------------------------------------------------------
# File 'suspdtlyas.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'suspdtlyas'
#-------------------------------------------------------------------------------

# 2010/02/23  yas  quiz auto=$obj/dump_tech.qzc ;replaced by the dump_tech.qzu
# 2012/01/06 - comment out suspend_fee.txt - as per Linda O. Renee and Nancy
# 2012/05/01 - include new program suspdtl_2.qtc   and pass the parameter 1 for 'before'

Remove-Item suspdtl.sf* *> $null
Remove-Item suspdtl.txt *> $null
&$env:QTP suspdtl
&$env:QTP suspdtl_2 1
&$env:QUIZ suspend_dtl
