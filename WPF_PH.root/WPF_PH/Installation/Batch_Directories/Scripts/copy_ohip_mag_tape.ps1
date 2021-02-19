#-------------------------------------------------------------------------------
# File 'copy_ohip_mag_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_ohip_mag_tape'
#-------------------------------------------------------------------------------

Set-Location $env:application_production
echo "********************************************************************"
echo "COPY MAG TAPE FOR OHIP REPORTS"
echo ""
echo "Make sure you have printed all your extra copies of REPORTS"
echo ""
echo "r001 r001b r002aa r002ab r004_c r010 r014 r014sm"
echo "ru020a ru020b ru020c ru022a ru022b"
echo "********************************************************************"

echo "PRESS  `"NEWLINE`"  CONTINUE OR CTRL-C"
echo "make sure there is a mag tape on drive"
$garbage = Read-Host

Get-Date

&$env:cmd\convert_for_fiche_rpt_cb r001
&$env:cmd\convert_for_fiche_rpt_cb r001b
&$env:cmd\convert_for_fiche_rpt_cb r002aa
&$env:cmd\convert_for_fiche_rpt_cb r002ab
&$env:cmd\convert_for_fiche_rpt_cb r004_c
&$env:cmd\convert_for_fiche_rpt_cb r010
&$env:cmd\convert_for_fiche_rpt_cb r014
&$env:cmd\convert_for_fiche_rpt_cb r014sm
&$env:cmd\convert_for_fiche_rpt_ph ru020a
&$env:cmd\convert_for_fiche_rpt_ph ru020b
&$env:cmd\convert_for_fiche_rpt_ph ru020c
&$env:cmd\convert_for_fiche_rpt_ph ru022a
&$env:cmd\convert_for_fiche_rpt_ph ru022b

# CONVERSION ERROR (expected, #31): tape device is involved.
# cat r001 r001b r002aa r002ab r004_c r010 r014 r014sm \ru020a ru020b ru020c ru022a ru022b > /dev/rmt/1

echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #38): tape device is involved.
# mt -f /dev/rmt/1 rewind
