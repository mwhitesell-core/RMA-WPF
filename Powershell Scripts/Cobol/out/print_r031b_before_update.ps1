#-------------------------------------------------------------------------------
# File 'print_r031b_before_update.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'print_r031b_before_update'
#-------------------------------------------------------------------------------

# macro: print_r031b_before_update
# 2009/Apr/06 M.C. consolidate r031a_AGE3/AGEP/MOHR into r031a.dat, it will create r031b.txt
#                  compare this report with r031b_agep.txt.  Their amounts should match.
# 2013/May/16 MC1  change to exec r031_before_update.qzu for 2 passes
# 2013/Sep/11 MC2  change to exec r031_before_update.qzu for 3 passes

Get-Date

Set-Location $application_production

echo "Current Directory:"
Get-Location

Get-Content r031a_AGE3.dat, r031a_AGEP.dat, r031a_MOHR.dat  > r031a.dat

echo ""
echo "execute powerhouse program r031_before_update_1\2\3.qzc"
echo ""
quiz++ $obj\r031_before_update

Get-Contents r031b.txt| Out-Printer

echo ""
echo ""
Get-Date
