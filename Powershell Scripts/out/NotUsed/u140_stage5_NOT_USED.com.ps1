#-------------------------------------------------------------------------------
# File 'u140_stage5_NOT_USED.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u140_stage5_NOT_USED.com'
#-------------------------------------------------------------------------------

# 08/jun/15 b.e. - original

echo "Setup of 101c environment"
. $Env:root\macros\setup_rmabill.com  101c

echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

echo "running u122.qts ..."
&$env:QTP u122

echo "Setup of MP environment"
. $Env:root\macros\setup_rmabill.com  mp

echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

echo "running u122.qts ..."
&$env:QTP u122

echo ""
echo "Return to 101c"
. $Env:root\macros\setup_rmabill.com  101c

echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location


echo "Done!"
