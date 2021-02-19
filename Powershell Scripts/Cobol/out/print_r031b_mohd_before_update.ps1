#-------------------------------------------------------------------------------
# File 'print_r031b_mohd_before_update.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'print_r031b_mohd_before_update'
#-------------------------------------------------------------------------------

# macro: print_r031b_mohd_before_update
# 2013/May/15 M.C. consolidate r031a_MOHD1/2.dat into r031a.dat, it will create r031b_mohd.txt
#                  compare this report with r031b_agep.txt.  Their amounts should match.
# 2013/Sep/11 MC1  change to exec r031_before_update.qzu for 3 passes
Get-Date

Set-Location $application_production\22

echo "Current Directory:"
Get-Location

Get-Content ..\r031a_MOHD1.dat, ..\r031a_MOHD2.dat  > r031a.dat

echo ""
echo "execute powerhouse program r031_before_update_1\2\3.qzc"
echo ""
quiz++ $obj\r031_before_update

Move-Item r031b.txt r031b_mohd.txt
Get-Contents r031b_mohd.txt| Out-Printer


$cmd\print_r031b_part2_before_update  > print_r031b_part2_before_update.log

echo ""
echo ""
Get-Date
