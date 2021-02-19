#-------------------------------------------------------------------------------
# File 'shift.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'shift'
#-------------------------------------------------------------------------------

param(
    [string]$1
    )
Push-Location
# file: ltd - upload SHIFT to f114 in payroll
# 2007/jan/09 b.e. added new param to u132 call
&$env:cmd\u132 200 $1 SP
echo "Running shift.."
$rcmd = $env:QUIZ + "maryshift"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content maryshift.txt > shift.txt

echo "Done .. paging shift.txt report"
Get-Content shift.txt
Pop-Location