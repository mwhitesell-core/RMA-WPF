#-------------------------------------------------------------------------------
# File 'line_no_check.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'line_no_check.com'
#-------------------------------------------------------------------------------

# line_no_check.com
echo "zero line number check programs"

&$env:QUIZ fix_lineno_3

&$env:QTP fix_lineno_4
&$env:QTP fix_lineno_6
&$env:QTP fix_lineno_7

&$env:QUIZ fix_lineno_8

#qutil << QUTIL_EXIT
#create file tmp-counters-alpha
#QUTIL_EXIT

#qtp auto=$obj/fix_lineno_8.qtc
