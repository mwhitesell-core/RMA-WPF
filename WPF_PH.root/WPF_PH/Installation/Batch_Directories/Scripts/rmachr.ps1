#-------------------------------------------------------------------------------
# File 'rmachr.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'rmachr'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# file: rmachr - upload RMACHR to f113 in payroll
# 2007/jan/09 b.e. added new param to u132 call

Push-Location

echo "FROM EP NBR (YYYYMM): "
$2 = Read-Host

echo "TO  EP NBR (YYYYMM): "
$3 = Read-Host
 
&$env:cmd\u132 100 $1 DC
echo "Running maryrmachr ..."
$rcmd = $env:QUIZ + "maryrmachr $2 $3"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content maryrmachr.txt > rmachr.txt

echo "Done .. paging rmachr.txt report"
Get-Content rmachr.txt 
Pop-Location