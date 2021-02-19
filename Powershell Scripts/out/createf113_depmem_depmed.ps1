#-------------------------------------------------------------------------------
# File 'createf113_depmem_depmed.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'createf113_depmem_depmed'
#-------------------------------------------------------------------------------

#  createf113_depmem_depmed
#

echo "Setup of solo environment"
. $Env:root\macros\setup_rmabill.com  solo

echo ""
echo "Entering `'production`' directory"
Set-Location $env:application_production ; Get-Location


&$env:QTP u921c > createf113_depmem_depmed.log


echo "Setup of 101c environment"
. $Env:root\macros\setup_rmabill.com  101c

echo ""
echo "Entering `'production`' directory"
Set-Location $env:application_production ; Get-Location


&$env:QTP u921c > createf113_depmem_depmed.log
