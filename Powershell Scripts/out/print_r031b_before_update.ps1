#-------------------------------------------------------------------------------
# File 'print_r031b_before_update.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'print_r031b_before_update'
#-------------------------------------------------------------------------------

# macro: print_r031b_before_update
# 2009/Apr/06 M.C. consolidate r031a_AGE3/AGEP/MOHR into r031a.dat, it will create r031b.txt
#                  compare this report with r031b_agep.txt.  Their amounts should match.
# 2013/May/16 MC1  change to exec r031_before_update.qzu for 2 passes
# 2013/Sep/11 MC2  change to exec r031_before_update.qzu for 3 passes

Get-Date

Set-Location $env:application_production

echo "Current Directory:"
Get-Location

Get-Content r031a_AGE3.dat, r031a_AGEP.dat, r031a_MOHR.dat | Set-Content r031a.dat

echo ""
echo "execute powerhouse program r031_before_update_1\2\3.qzc"
echo ""
$rcmd = $env:QUIZ+"r031_before_update_1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+"r031_before_update_2"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+"r031_before_update_3"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r031_before_update_1.txt > r031b.txt
Get-Content r031_before_update_2.txt >> r031b.txt
Get-Content r031_before_update_3.txt >> r031b.txt

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content r031b.txt | Out-Printer -Name $env:networkprinter
}

echo ""
echo ""
Get-Date
