#-------------------------------------------------------------------------------
# File 'gsttax.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'gsttax'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# file: gsttax - upload gsttax to f113 in payroll
# 2007/jan/09 b.e. added new param to u132 call
Push-Location
echo "FROM EP NBR (YYYYMM): "
$2 = Read-Host

echo "TO  EP NBR (YYYYMM): "
$3 = Read-Host

&$env:cmd\u132 100 $1 DC
echo "Running marygsttax ..."
$rcmd = $env:QUIZ + "marygsttax $2 $3"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content marygsttax.txt > gsttax.txt

echo "Done .. paging gsttax.txt report"
Get-Content gsttax.txt
Pop-Location
