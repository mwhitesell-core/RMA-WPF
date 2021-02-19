echo "ENTER EP NBR (YYYYMM): "
$1 = Read-Host

$rcmd = $env:QTP +  "costing_f119hist $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "costing_f119hist DISC_costing_f119hist.ff"
Invoke-Expression $rcmd

Move-Item -Force costing_f119hist.txt costingf119.txt
Move-Item -Force costing_f119hist.pdf costingf119.pdf