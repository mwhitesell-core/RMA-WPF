#-------------------------------------------------------------------------------
# File 'generate_r120.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'generate_r120'
#-------------------------------------------------------------------------------

# 2009/jan/21   MC      r121d/e.qzc are no longer needed, instead execute r121c.qzc with nogo
#                       and modify the selection criteria for company
#                       include the new report to r121_$1.txt and r121m.txt
# 2011/Jan/19   MC      include the new program r121b_company.qzs

echo "starting r120.QTS"
Remove-Item r120*
Remove-Item r119*
Remove-Item r121*


$rcmd = $env:QTP + "r120 $1 $1"
invoke-expression $rcmd

echo "starting r120.qzs, r119 & r121"

$rcmd = $env:QUIZ + "r120 $1 $1"
invoke-expression $rcmd

$rcmd = $env:QUIZ + "r119a"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r119b"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r119c"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r121a"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r121b"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r121b_company"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r121c"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r121d"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r121e"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r121f"
invoke-expression $rcmd

echo "finished r121c"

echo "building r120"
Move-Item r120.txt r120_${1}.txt
#lp r120_${1}.txt

echo "building r119"
Get-Content r119a.txt, r119b.txt, r119c.txt  > r119_${1}.txt
#lp r119_${1}.txt

echo "building r121"
#cat r121a.txt r121b.txt r121c.txt r121d.txt >r121_${1}.txt
Get-Content r121a.txt, r121b.txt, r121c.txt, r121d.txt, r121e.txt, r121f.txt  > r121_${1}.txt
#cat r121c.txt r121d.txt r121e.txt > r121m.txt
Get-Content r121c.txt, r121d.txt, r121e.txt, r121f.txt  > r121m.txt

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content r121m.txt | Out-Printer -Name $env:networkprinter
}

Move-Item r121b_company.txt r121b_company_${1}.txt

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content r121b_company_${1}.txt | Out-Printer -Name $env:networkprinter
}

echo "DONE  generate_r120"
