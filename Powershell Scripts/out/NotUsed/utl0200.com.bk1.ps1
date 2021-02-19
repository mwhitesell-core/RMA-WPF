#-------------------------------------------------------------------------------
# File 'utl0200.com.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'utl0200.com.bk1'
#-------------------------------------------------------------------------------

#file:  utl0200.com
# 05/jul/20 b.e. - original

echo "Running `'utl0200.com - extraction of doctor info for download to excel`'"

echo " $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo "$SHELL"

echo ""
echo "Setting up Profile ..."
. $Env:root\macros\profile  >> $Env:root\alpha\rmabill\rmabill101c\production\utl0200.log

echo ""
echo "Setting up Environment ..."
rmabill 101c >> $Env:root\alpha\rmabill\rmabill101c\production\utl0200.log
#. /macros/setup_rmabill.com 101c
echo ""

echo "Entering `'produciton`' directory"
Set-Location $env:application_production ; Get-Location


echo ""
Remove-Item utl0200.ps
Remove-Item utl0200.psd
echo "recreating file utl0200.ps ..."
&$env:QTP utl0200
echo ""
echo "Done!"
