# file: gsttax - upload gsttax to f113 in payroll
# 2007/jan/09 b.e. added new param to u132 call
param(
    [string]$1
    )

Push-Location
echo "FROM EP NBR (YYYYMM): "
$2 = Read-Host

echo "TO  EP NBR (YYYYMM): "
$3 = Read-Host
 
&$env:cmd\u132 100 $1 DC
echo Running web ...
$rcmd = $env:QUIZ + "web $2 $3"
invoke-expression $rcmd
echo Done .. paging web.txt report
pg web.txt
Pop-Location