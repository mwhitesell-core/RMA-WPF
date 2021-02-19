#-------------------------------------------------------------------------------
# File 'academ.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'academ'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# upload SHIFT to f114 in payroll
# 2007/jan/09 b.e. added new param to u132 call
Push-Location
&$env:cmd\u132 200 $1 SP
echo "Running maryacadem.."
$rcmd = $env:QUIZ + "maryacadem"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content maryacadem.txt > academ.txt

echo "Done .. paging academ.txt report"
Get-Content academ.txt
Pop-Location