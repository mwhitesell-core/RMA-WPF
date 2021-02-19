#-------------------------------------------------------------------------------
# File 'agep_canbedel.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'agep_canbedel'
#-------------------------------------------------------------------------------

# file: ltd - upload postgrad     to f114 in payroll
# 2007/feb/12 added new param to u132 call
&$env:cmd\u132 200 $1 SP
echo "Running maryagep.."
&$env:QUIZ maryagep
echo "Done .. paging agep.txt report"
Get-Content agep.txt
