#-------------------------------------------------------------------------------
# File 'utl0004.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'utl0004.com'
#-------------------------------------------------------------------------------

#file:  utl0004.com
# 12/Nov/13 M.C. - original

echo "Running `'utl0004.com - extraction of doctor $Env:root\ dept name\nbr for portal link`'"

echo " $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo "$SHELL"

echo ""
echo "Setting up Profile ..."
. $Env:root\macros\profile  >> $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production\utl0004.log

echo ""
echo "Setting up Environment ..."
rmabill $env:RMABILL_VERS >> $Env:root\alpha\rmabill\rmabill101c\production\utl0004.log
#. /macros/setup_rmabill.com 101c
echo ""

echo "Entering `'producton`' directory"
Set-Location $env:application_production ; Get-Location


echo ""
Remove-Item utl0004.txt
echo "recreating report utl0004.txt .."
&$env:QUIZ utl0004
echo ""
echo "Done!"

echo " $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
