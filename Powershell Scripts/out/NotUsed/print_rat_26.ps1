#-------------------------------------------------------------------------------
# File 'print_rat_26.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'print_rat_26'
#-------------------------------------------------------------------------------

echo ""
Set-Location $env:application_production\26
#lp u030.ls
Remove-Item ru030a_26
Move-Item -Force ru030a.txt ru030a_26
Get-Content ru030a_26 | Out-Printer
Remove-Item ru030b_26
Move-Item -Force ru030b.txt ru030b_26
Get-Content ru030b_26 | Out-Printer
Remove-Item ru030c_26
Move-Item -Force ru030c.txt ru030c_26
Get-Content ru030c_26 | Out-Printer
Remove-Item ru030d_26
Move-Item -Force ru030d.txt ru030d_26
Get-Content ru030d_26 | Out-Printer
Remove-Item ru030e_26
Move-Item -Force ru030e.txt ru030e_26
Get-Content ru030e_26 | Out-Printer
Remove-Item ru030f_26
Move-Item -Force ru030f.txt ru030f_26
#lp ru030f_26
Remove-Item r997_26
Move-Item -Force r997.txt r997_26
#lp r997_26
