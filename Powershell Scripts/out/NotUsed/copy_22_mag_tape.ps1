#-------------------------------------------------------------------------------
# File 'copy_22_mag_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_22_mag_tape'
#-------------------------------------------------------------------------------

Set-Location $env:application_production
echo "********************************************************************"
echo "Clinic 22 monthend reports"
echo ""
echo "Make sure you have printed all your extra copies of Reports"
echo ""
echo "r004 r005 r011 r012 r013 r051ca r051cb r123b r123c r123ef"
echo "r111b r120 r119 r070"
echo "********************************************************************"

echo "PRESS  `"NEWLINE`"  CONTINUE OR CTRL-C"
echo "make sure there is a mag tape on drive"
$garbage = Read-Host

Get-Date

&$env:cmd\convert_for_fiche_rpt_cb r004
&$env:cmd\convert_for_fiche_rpt_cb r005
&$env:cmd\convert_for_fiche_rpt_cb r011
&$env:cmd\convert_for_fiche_rpt_cb r012
&$env:cmd\convert_for_fiche_rpt_cb r013
&$env:cmd\convert_for_fiche_rpt_cb r051ca
&$env:cmd\convert_for_fiche_rpt_cb r051cb
&$env:cmd\convert_for_fiche_rpt_cb r123b
&$env:cmd\convert_for_fiche_rpt_cb r123c
&$env:cmd\convert_for_fiche_rpt_cb r123ef
&$env:cmd\convert_for_fiche_rpt_ph r111b
&$env:cmd\convert_for_fiche_rpt_ph r120
&$env:cmd\convert_for_fiche_rpt_ph r119
&$env:cmd\convert_for_fiche_rpt_cb r070

# CONVERSION ERROR (expected, #32): tape device is involved.
# cat r004 r005 r011 r012 r013 r051ca r051cb r123b r123c r123ef \r111b r120 r119 r070 > /dev/rmt/1

echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #39): tape device is involved.
# mt -f /dev/rmt/1 rewind