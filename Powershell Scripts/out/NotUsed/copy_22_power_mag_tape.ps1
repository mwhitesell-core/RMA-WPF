#-------------------------------------------------------------------------------
# File 'copy_22_power_mag_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_22_power_mag_tape'
#-------------------------------------------------------------------------------

Set-Location $env:application_production
echo "********************************************************************"
echo ""
echo "Make sure you have printed all your extra copies of"
echo "POWERHOUSE REPORTS BEFORE RUNNING THIS PROGRAM"
echo ""
echo "********************************************************************"

echo "PRESS  `"NEWLINE`"  CONTINUE OR CTRL-C"
echo "make sure there is a mag tape on drive"
$garbage = Read-Host

Get-Date

&$env:cmd\convert_for_fiche_rpt_ph r111b
&$env:cmd\convert_for_fiche_rpt_ph r120
&$env:cmd\convert_for_fiche_rpt_ph r119

# CONVERSION ERROR (expected, #19): tape device is involved.
# cat r111b r120 r119 > /dev/rmt/1

echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #25): tape device is involved.
# mt -f /dev/rmt/1 rewind
