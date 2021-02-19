#-------------------------------------------------------------------------------
# File 'utl0200.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'utl0200.com'
#-------------------------------------------------------------------------------

#file:  utl0200.com
# 05/jul/20 b.e. - original
# 15/Oct/20 MC1  - move utl0200.ps and rename as bi_utl0200.ps to /foxtrot/bi as Brad agreed

echo "Running `'utl0200.com - extraction of doctor info for download to excel`'"

echo " $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo "$SHELL"

echo ""
echo "Setting up Profile ..."
. $Env:root\macros\profile  >> $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production\utl0200.log

echo ""
echo "Setting up Environment ..."
rmabill $env:RMABILL_VERS >> $Env:root\alpha\rmabill\rmabill101c\production\utl0200.log
echo ""

echo "Entering `'production`' directory"
Set-Location $env:application_production ; Get-Location


echo ""
Remove-Item utl0200.ps
Remove-Item utl0200.psd
echo "recreating file utl0200.ps ..."
&$env:QTP utl0200

# MC1 
Move-Item -Force utl0200.ps $Env:root\foxtrot\bi\bi_utl0200.ps
Move-Item -Force utl0200.psd $Env:root\foxtrot\bi\bi_utl0200.psd


echo ""
echo "Done!"
