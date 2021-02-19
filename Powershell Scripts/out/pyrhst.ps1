#-------------------------------------------------------------------------------
# File 'pyrhst.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'pyrhst'
#-------------------------------------------------------------------------------

# file: gsttax - upload gsttax to f113 in payroll
# 2007/jan/09 b.e. added new param to u132 call
&$env:cmd\u132 100 $1 DC
echo "Running pryhst ..."
&$env:QUIZ pyrhst
echo "Done .. paging pyrhst.txt report"
Get-Content pyrhst.txt
