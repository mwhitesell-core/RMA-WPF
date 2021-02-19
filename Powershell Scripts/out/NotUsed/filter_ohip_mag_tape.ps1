#-------------------------------------------------------------------------------
# File 'filter_ohip_mag_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'filter_ohip_mag_tape'
#-------------------------------------------------------------------------------

Set-Location $env:application_production
echo "********************************************************************"
echo ""
echo "MAKE SURE YOU HAVE PRINTED ALL YOUR EXTRA COPIES OF"
echo "POWERHOUSE REPORTS BEFORE RUNNING THIS PROGRAM"
echo ""
echo "********************************************************************"

echo "PRESS   `"NEWLINE`"  CONTINUE OR CTRL-C TO CANCEL"
 $garbage = Read-Host

&$env:cmd\filter_mag_tape ru020a
&$env:cmd\filter_mag_tape ru020b
&$env:cmd\filter_mag_tape ru020c
&$env:cmd\filter_mag_tape ru022a
&$env:cmd\filter_mag_tape ru022b

Get-Date
