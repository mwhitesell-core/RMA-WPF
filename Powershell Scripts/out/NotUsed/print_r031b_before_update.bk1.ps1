#-------------------------------------------------------------------------------
# File 'print_r031b_before_update.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'print_r031b_before_update.bk1'
#-------------------------------------------------------------------------------

# macro: print_r031b_before_update
# 2009/Apr/06 M.C. consolidate r031a_AGE3/AGEP/MOHR into r031a.dat, it will create r031b.txt
#                  compare this report with r031b_agep.txt.  Their amounts should match.
# 2013/May/16 MC1  change to exec r031_before_update.qzu for 2 passes
Get-Date

Set-Location $env:application_production

echo "Current Directory:"
Get-Location

Get-Content r031a_AGE3.dat, r031a_AGEP.dat, r031a_MOHR.dat | Set-Content r031a.dat

echo ""
echo "execute powerhouse program r031_before_update_1\2.qzc"
echo ""
&$env:QUIZ r031_before_update

Get-Content r031b.txt | Out-Printer

echo ""
echo ""
Get-Date
