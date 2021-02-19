#-------------------------------------------------------------------------------
# File 'mohr.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'mohr'
#-------------------------------------------------------------------------------

# file: ltd - upload postgrad     to f114 in payroll
# 2007/feb/12 added new param to u132 call
&$env:cmd\u132 200 $1 SP
echo "Running marymohr.."
&$env:QUIZ marymohr
echo "Done .. paging mohr.txt report"
Get-Content mohr.txt
