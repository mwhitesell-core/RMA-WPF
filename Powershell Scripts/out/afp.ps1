#-------------------------------------------------------------------------------
# File 'afp.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'afp'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# file: ltd - upload AFPCON premiums to f114 in payroll
# 2007/jan/09 b.e. added new param to u132 call
Push-Location
&$env:cmd\u132 200 $1 SP
echo "Running maryafp.."
$rcmd = $env:QUIZ + "maryafp"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content maryafp.txt > afp.txt

echo "Done .. paging afp.txt report"
Get-Content afp.txt
Pop-Location