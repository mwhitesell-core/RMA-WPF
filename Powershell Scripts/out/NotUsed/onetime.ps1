#-------------------------------------------------------------------------------
# File 'onetime.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'onetime'
#-------------------------------------------------------------------------------

# 99/dec/15 B.E. changed deleted to ignore errors, alignment changes
Set-Location $env:application_production\60
echo ""
Get-Date
echo ""
Get-Content r005btp.txt, r005ctp.txt, r005dtp.txt | Add-Content r005atp.txt
Get-Content r006btp.txt, r006ctp.txt, r006dtp.txt | Add-Content r006atp.txt
Move-Item -Force r005atp.txt r005tp
Move-Item -Force r006atp.txt r006tp
Get-Content r005tp | Out-Printer
Get-Content r006tp | Out-Printer
Get-Content utl0006.txt | Out-Printer
Get-Content utl0006a.txt | Out-Printer
echo ""
Get-Date
