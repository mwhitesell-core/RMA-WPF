#-------------------------------------------------------------------------------
# File 'print_r031b_mohd_before_update.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'print_r031b_mohd_before_update.bk1'
#-------------------------------------------------------------------------------

# macro: print_r031b_mohd_before_update
# 2013/May/15 M.C. consolidate r031a_MOHD1/2.dat into r031a.dat, it will create r031b_mohd.txt
#                  compare this report with r031b_agep.txt.  Their amounts should match.

Get-Date

Set-Location $env:application_production\22

echo "Current Directory:"
Get-Location

Get-Content ..\r031a_MOHD1.dat, ..\r031a_MOHD2.dat | Set-Content r031a.dat

echo ""
echo "execute powerhouse program r031_before_update_1\2.qzc"
echo ""
&$env:QUIZ r031_before_update

Move-Item -Force r031b.txt r031b_mohd.txt
Get-Content r031b_mohd.txt | Out-Printer


&$env:cmd\print_r031b_part2_before_update > print_r031b_part2_before_update.log

echo ""
echo ""
Get-Date
