#-------------------------------------------------------------------------------
# File 'print_rat_68.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'print_rat_68'
#-------------------------------------------------------------------------------

echo ""
Set-Location $env:application_production\68
#lp u030_68.ls
Remove-Item ru030a_68
Move-Item -Force ru030a.txt ru030a_68
Get-Content ru030a_68 | Out-Printer
Remove-Item ru030b_68
Move-Item -Force ru030b.txt ru030b_68
Get-Content ru030b_68 | Out-Printer
Remove-Item ru030c_68
Move-Item -Force ru030c.txt ru030c_68
Get-Content ru030c_68 | Out-Printer
Remove-Item ru030d_68
Move-Item -Force ru030d.txt ru030d_68
Get-Content ru030d_68 | Out-Printer
Remove-Item ru030e_68
Move-Item -Force ru030e.txt ru030e_68
Get-Content ru030e_68 | Out-Printer
Remove-Item ru030f_68
Move-Item -Force ru030f.txt ru030f_68
#lp ru030f_68
Remove-Item r997_68
Move-Item -Force r997.txt r997_68
#lp r997_68
##lp r997_68
echo ""
Get-Date
echo ""
