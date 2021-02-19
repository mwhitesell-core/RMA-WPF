#-------------------------------------------------------------------------------
# File 'r997_clinic22_84J.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'r997_clinic22_84J'
#-------------------------------------------------------------------------------

Set-Location $env:application_production

Remove-Item r997_clinic22_84J.txt

$rcmd = $env:QUIZ + "r997_clinic22_84J_a"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r997_clinic22_84J_b"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r997_clinic22_84J_a.txt > r997_clinic22_84J.txt
Get-Content r997_clinic22_84J_b.txt >> r997_clinic22_84J.txt

Copy-Item r997_clinic22_84J.txt r997g_84J_22
