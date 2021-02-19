#-------------------------------------------------------------------------------
# File 'suronc.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'suronc'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# file: ltd - upload AFPCON premiums to f114 in payroll
# 2007/jan/09 b.e. added new param to u132 call
Push-Location
&$env:cmd\u132 200 $1 SP
echo "Running suronc .."
$rcmd = $env:QUIZ + "suronc"
Invoke-Expression $rcmd
echo "Done .. paging suronc.txt report"
Get-Content suronc.txt
Pop-Location