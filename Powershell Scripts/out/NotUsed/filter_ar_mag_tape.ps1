#-------------------------------------------------------------------------------
# File 'filter_ar_mag_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'filter_ar_mag_tape'
#-------------------------------------------------------------------------------

Set-Location $application_upl
echo "********************************************************************"
echo ""
echo "MAKE SURE YOU HAVE QPRINTED ALL YOUR EXTRA COPIES OF"
echo "R070 BEFORE RUNNING THIS PROGRAM"
echo ""
echo "********************************************************************"

echo "PRESS  `"NEWLINE`"  CONTINUE OR CTRL-CA OR CTRL-CB TO CANCELL"
$garbage = Read-Host

&$env:cmd\filter_mag_tape r070

Get-Date
