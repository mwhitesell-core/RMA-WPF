#-------------------------------------------------------------------------------
# File 'r011_csv.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r011_csv'
#-------------------------------------------------------------------------------

# r011_csv
#
# MODIFICATION HISTORY
#
# 15/Jun/23  MC    - original
#                  - run r011_csv.qzu to generate r011_csv.txt  - Doctor Revenue Analysis by clinic

Set-Location $application_production

echo "--- Doctor Revenue Analysis-- r011_csv"

quiz++ $obj\r011_csv

echo "Done"
