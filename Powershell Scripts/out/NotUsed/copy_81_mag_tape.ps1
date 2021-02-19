#-------------------------------------------------------------------------------
# File 'copy_81_mag_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_81_mag_tape'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\81
echo "********************************************************************"
echo "Clinic 81 monthend reports"
echo ""
echo "Make sure you have printed all your extra copies of Reports"
echo ""
echo "r004 r011 r012 r013 r051ca r051cb r070"
echo "********************************************************************"

echo "PRESS  `"NEWLINE`"  CONTINUE OR CTRL-C"
echo "make sure there is a mag tape on drive"
$garbage = Read-Host

Get-Date

&$env:cmd\convert_for_fiche_rpt_cb r004
&$env:cmd\convert_for_fiche_rpt_cb r011
&$env:cmd\convert_for_fiche_rpt_cb r012
&$env:cmd\convert_for_fiche_rpt_cb r013
&$env:cmd\convert_for_fiche_rpt_cb r051ca
&$env:cmd\convert_for_fiche_rpt_cb r051cb
&$env:cmd\convert_for_fiche_rpt_cb r070

# CONVERSION ERROR (expected, #24): tape device is involved.
# cat r004 r011 r012 r013 r051ca r051cb r070 > /dev/rmt/1

echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #30): tape device is involved.
# mt -f /dev/rmt/1 rewind
