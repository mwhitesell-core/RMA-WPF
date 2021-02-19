#-------------------------------------------------------------------------------
# File 'oncall.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'oncall'
#-------------------------------------------------------------------------------

# file: ltd - upload SHIFT to f114 in payroll
# 2007/jan/09 b.e. added new param to u132 call
&$env:cmd\u132 200 $1 SP
echo "Running Oncall......"
&$env:QUIZ oncall
echo "Done .. paging oncall.txt report"
Get-Content oncall.txt
