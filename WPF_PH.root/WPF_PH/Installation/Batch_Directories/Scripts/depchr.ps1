param(
    [string]$1
    )
# file: depchr - upload DEPCHR to f113 in payroll
# 2007/jan/09 b.e. added new param to u132 call
Push-Location
echo "FROM EP NBR (YYYYMM): "
$2 = Read-Host

echo "TO  EP NBR (YYYYMM): "
$3 = Read-Host

&$env:cmd/u132 100 $1 DC
echo Running marydepchr ...
$rcmd = $env:QUIZ + "marydepchr $2 $3"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content marydepchr.txt > depchr.txt

echo Done .. paging depchr.txt report
Get-Content depchr.txt
Pop-Location