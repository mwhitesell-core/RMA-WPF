#-------------------------------------------------------------------------------
# File 'fix_lineno.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'fix_lineno.com'
#-------------------------------------------------------------------------------

&$env:QUIZ fix_lineno_3

&$env:QTP fix_lineno_4
&$env:QTP fix_lineno_6
&$env:QTP fix_lineno_7

$pipedInput = @"
create file tmp-counters-alpha
"@

$pipedInput | qutil++

&$env:QTP fix_lineno_8 ";exe $obj/fix_lineno_9.qtc"
