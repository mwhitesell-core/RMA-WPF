#-------------------------------------------------------------------------------
# File 'utl0004.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'utl0004.com'
#-------------------------------------------------------------------------------

#file:  utl0004.com
# 12/Nov/13 M.C. - original

echo "Running `'utl0004.com - extraction of doctor $root\ dept name\nbr for portal link`'"

echo "$(udate)"
echo "$SHELL"

echo ""
echo "Setting up Profile ..."
. $root\macros\profile  >> $root\alpha\rmabill\rmabill101c\production\utl0004.log

echo ""
echo "Setting up Environment ..."
rmabill 101c  >> $root\alpha\rmabill\rmabill101c\production\utl0004.log
#. /macros/setup_rmabill.com 101c
echo ""

echo "Entering `'producton`' directory"
Set-Location $application_production; Get-Location


echo ""
Remove-Item utl0004.txt
echo "recreating report utl0004.txt .."
quiz++ $obj\utl0004
echo ""
echo "Done!"

echo "$(udate)"
