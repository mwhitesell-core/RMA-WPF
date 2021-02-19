#-------------------------------------------------------------------------------
# File 'r070_csv.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r070_csv.com'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

echo "R070_CSV.COM"
echo ""

echo ""
echo "CREATE  Accounts Receivable in Excel Report  for monthend "
echo ""

echo ""
echo "PROGRAM `"r070_csv.qzc`" NOW LOADING ..."
echo ""

$rcmd = $env:QUIZ + "r070a_csv ${1}"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r070b_csv"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r070c_csv DISC_r070_all.rf"
Invoke-Expression $rcmd

echo ""
echo "COPY r070a_csv.sf & r070_csv.txt into ME "

echo ""

Copy-Item r070a_csv.sf r070a_csv_me${1}.sf
Copy-Item r070a_csv.sfd r070a_csv_me${1}.sfd
Copy-Item r070_csv.txt r070_csv_me${1}.txt
Copy-Item r070_all.txt r070_all_me${1}.txt
