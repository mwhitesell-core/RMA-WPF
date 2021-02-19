#-------------------------------------------------------------------------------
# File 'u141.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'u141.com'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

#file:  u141.com
# 2015/Nov/17   b.e. - original

clear
echo "Running `'processing of d004 Excel Transactions Upload `'"
echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl; Get-Location

$filename = "$1"
echo "Running r141.awk"
#file: u141_awk.com
Get-Content $1 | awk++ $cmd\u141.awk  > $pb_data\misc_payment_file.dat

Set-Location $production

echo ""
#echo Done!
