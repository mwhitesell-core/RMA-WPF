#-------------------------------------------------------------------------------
# File 'copy_60_mag_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_60_mag_tape'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\60
echo "********************************************************************"
echo "Clinic 60 Monthend Reports"
echo ""
echo "Make sure you have printed all your extra copies of Reports"
echo ""
echo "r004tp r005tp r006tp r011 r012tp r013tp r015tp r051ca r051cb r070"
echo "********************************************************************"

echo "PRESS  `"NEWLINE`"  CONTINUE OR CTRL-C"
echo "make sure there is a mag tape on drive"
$garbage = Read-Host

Get-Date

&$env:cmd\convert_for_fiche_rpt_ph r004tp
&$env:cmd\convert_for_fiche_rpt_ph r005tp
&$env:cmd\convert_for_fiche_rpt_ph r006tp
&$env:cmd\convert_for_fiche_rpt_ph r011
&$env:cmd\convert_for_fiche_rpt_ph r012tp
&$env:cmd\convert_for_fiche_rpt_ph r013tp
&$env:cmd\convert_for_fiche_rpt_ph r015tp
&$env:cmd\convert_for_fiche_rpt_ph r051ca
&$env:cmd\convert_for_fiche_rpt_ph r051cb
&$env:cmd\convert_for_fiche_rpt_ph r070

# CONVERSION ERROR (expected, #27): tape device is involved.
# cat r004tp r005tp r006tp r011 r012tp r013tp r015tp r051ca r051cb r070 > /dev/rmt/1

echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #33): tape device is involved.
# mt -f /dev/rmt/1 rewind
