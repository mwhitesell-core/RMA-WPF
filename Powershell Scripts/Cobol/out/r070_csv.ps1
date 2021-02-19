#-------------------------------------------------------------------------------
# File 'r070_csv.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r070_csv.com'
#-------------------------------------------------------------------------------

echo "R070_CSV.COM"
echo ""

echo ""
echo "CREATE  Accounts Receivable in Excel Report  for monthend "
echo ""

echo ""
echo "PROGRAM `"r070_csv.qzc`" NOW LOADING ..."
echo ""

$pipedInput = @"
${1} 
"@

$pipedInput | quiz++ $obj\r070a_csv

quiz++ $obj\r070b_csv
quiz++ $obj\r070c_csv

echo ""
echo "COPY r070a_csv.sf & r070_csv.txt into ME "

echo ""

Copy-Item r070a_csv.sf r070a_csv_me${1}.sf
Copy-Item r070a_csv.sfd r070a_csv_me${1}.sfd
Copy-Item r070_csv.txt r070_csv_me${1}.txt
Copy-Item r070_all.txt r070_all_me${1}.txt
