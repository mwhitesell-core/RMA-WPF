# file: ltd - upload SHIFT to f114 in payroll
# 2007/jan/09 b.e. added new param to u132 call
param(
    [string]$1
    )

Push-Location
&$env:cmd\u132 200 $1 SP
echo Running maryperc...
$rcmd = $env:QUIZ + "maryperc"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content maryperc.txt > perc.txt

echo Done .. paging perc.txt report
Get-Content perc.txt
Pop-Location