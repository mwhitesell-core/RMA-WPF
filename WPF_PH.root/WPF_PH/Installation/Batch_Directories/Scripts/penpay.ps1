#-------------------------------------------------------------------------------
# File 'penpay.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'penpay'
#-------------------------------------------------------------------------------

param(
  [string] $1
)
# file: ltd - upload PENPAY premiums to f114 in payroll
# 2007/jan/09 b.e. added new param to u132 call
Push-Location
&$env:cmd\u132 200 $1 SP
echo "Running marypenpay.."
$rcmd = $env:QUIZ + "marypenpay"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content marypenpay.txt > penpay.txt

echo "Done .. paging penpay.txt report"
Get-Content penpay.txt
Pop-Location