#-------------------------------------------------------------------------------
# File 'r011_csv.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r011_csv'
#-------------------------------------------------------------------------------

# r011_csv
#
# MODIFICATION HISTORY
#
# 15/Jun/23  MC    - original
#                  - run r011_csv.qzu to generate r011_csv.txt  - Doctor Revenue Analysis by clinic

Set-Location $env:application_production

echo "--- Doctor Revenue Analysis-- r011_csv"

$rcmd = $env:QUIZ + "r011a_csv"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r011b_csv"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r011c_csv DISC_r011c_csv.rf"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r011c_csv.txt > r011_csv.txt

$rcmd = $env:QUIZ + "r011d_csv"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r011d_csv.txt > r011_all.txt

echo "Done"
