#-------------------------------------------------------------------------------
# File 'createf113_depmem_depmed.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'createf113_depmem_depmed'
#-------------------------------------------------------------------------------

#  createf113_depmem_depmed
#

echo "Setup of solo environment"
. $root\macros\setup_rmabill.com solo

echo ""
echo "Entering `'production`' directory"
Set-Location $application_production; Get-Location


qtp++ $obj\u921c  > createf113_depmem_depmed.log


echo "Setup of 101c environment"
. $root\macros\setup_rmabill.com 101c

echo ""
echo "Entering `'production`' directory"
Set-Location $application_production; Get-Location


qtp++ $obj\u921c  > createf113_depmem_depmed.log
