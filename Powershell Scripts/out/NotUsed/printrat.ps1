#-------------------------------------------------------------------------------
# File 'printrat.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'printrat'
#-------------------------------------------------------------------------------


Set-Location $env:application_production
Get-Content u030.ls | Out-Printer
Remove-Item ru030a_22
Move-Item -Force ru030a.txt ru030a_22
Get-Content ru030a_22 | Out-Printer
Remove-Item ru030b_22
Move-Item -Force ru030b.txt ru030b_22
Get-Content ru030b_22 | Out-Printer
Remove-Item ru030c_22
Move-Item -Force ru030c.txt ru030c_22
Get-Content ru030c_22 | Out-Printer
Remove-Item ru030d_22
Move-Item -Force ru030d.txt ru030d_22
Get-Content ru030d_22 | Out-Printer
Remove-Item ru030e_22
Move-Item -Force ru030e.txt ru030e_22
Get-Content ru030e_22 | Out-Printer
Remove-Item ru030f_22
Move-Item -Force ru030f.txt ru030f_22
Get-Content ru030f_22 | Out-Printer
Remove-Item r997_22
Move-Item -Force r997.txt r997_22
Get-Content r997_22 | Out-Printer
echo ""
