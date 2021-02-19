#-------------------------------------------------------------------------------
# File 'u141.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u141.com'
#-------------------------------------------------------------------------------

#file:  u141.com
# 2015/Nov/17   b.e. - original
param(
	[string]$filename
)

echo "Running `'processing of d004 Excel Transactions Upload `'"
echo ""
echo "Entering `'upload`' directory"
Set-Location $env:application_upl ; Get-Location

$1 = "$env:application_upl/$filename"
echo "Running r141.awk"
#file: u141_awk.com
# CONVERSION ERROR (expected, #14): awk.
# awk -f $cmd/u141.awk < $1 > $pb_data/misc_payment_file.dat
&$env:cmd/u141.awk $1 $env:pb_data/misc_payment_file.dat

echo ""
#echo Done!
