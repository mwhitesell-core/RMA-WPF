#-------------------------------------------------------------------------------
# File 'print_r031b_before_update.bk2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'print_r031b_before_update.bk2'
#-------------------------------------------------------------------------------

# macro: print_r031b_before_update
# 2009/Apr/06 M.C. consolidate r031a_AGE3/AGEP/MOHR into r031a.dat, it will create r031b.txt
#                  compare this report with r031b_agep.txt.  Their amounts should match.

Get-Date

Set-Location $env:application_production

echo "Current Directory:"
Get-Location

Get-Content r031a_AGE3.dat, r031a_AGEP.dat, r031a_MOHR.dat | Set-Content r031a.dat

echo ""
echo "execute powerhouse program r031_before_update.qzc"
echo ""
&$env:QUIZ r031_before_update

Get-Content r031b.txt | Out-Printer

echo ""
echo ""
Get-Date
