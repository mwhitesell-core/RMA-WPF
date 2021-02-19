#-------------------------------------------------------------------------------
# File 'filter_60_mth_mag_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'filter_60_mth_mag_tape'
#-------------------------------------------------------------------------------

Set-Location $applcation_upl
echo "********************************************************************"
echo ""
echo "MAKE SURE YOU HAVE QPRINTED ALL YOUR EXTRA COPIES OF"
echo "POWERHOUSE REPORTS BEFORE RUNNING THIS PROGRAM"
echo ""
echo "********************************************************************"

echo "PRESS  `"NEWLINE`"  CONTINUE OR CTRL-CA OR CTRL-CB TO CANCELL"
$garbage = Read-Host

&$env:cmd\filter_mag_tape r004tp
&$env:cmd\filter_mag_tape r005tp
&$env:cmd\filter_mag_tape r006tp
&$env:cmd\filter_mag_tape r011
&$env:cmd\filter_mag_tape r012tp
&$env:cmd\filter_mag_tape r013tp
&$env:cmd\filter_mag_tape r015tp
&$env:cmd\filter_mag_tape r051ca
&$env:cmd\filter_mag_tape r051cb

Get-Date
