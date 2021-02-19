#-------------------------------------------------------------------------------
# File 'utl0005_csv.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'utl0005_csv.com'
#-------------------------------------------------------------------------------

echo "StartUTL0005_CSV.COM  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo ""

Set-Location $env:application_root\production

echo "Starting  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > utl0005_csv.log
echo ""
echo "CREATE  DOCTOR AUDIT MONTHLY CLAIMS " >> utl0005_csv.log
echo ""

echo ""
echo "PROGRAM `"utl0005_csv.qtc`" NOW LOADING ..." >> utl0005_csv.log
echo ""

&$env:QTP utl0005_csv ${1} >> utl0005_csv.log

&$env:QUIZ utl0005_csv >> utl0005_csv.log

echo "Ending $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> utl0005_csv.log

echo "Finish $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
