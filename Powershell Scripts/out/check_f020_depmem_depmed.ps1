#-------------------------------------------------------------------------------
# File 'check_f020_depmem_depmed.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'check_f020_depmem_depmed'
#-------------------------------------------------------------------------------

#  check_f020_depmem_depmed
#

echo "Setup of solo environment"
. $root\macros\setup_rmabill.com solo

echo ""
echo "Entering `'production`' directory"
Set-Location $application_production; Get-Location

Remove-Item u921a.sf*, r921b.txt  -EA SilentlyContinue


qtp++ $obj\u921a  > check_f020_depmem_depmed.log
quiz++ $obj\r921b  >> check_f020_depmem_depmed.log

Get-Content r921b.txt| Out-Printer

echo "Setup of 101c environment"
. $root\macros\setup_rmabill.com 101c

echo ""
echo "Entering `'production`' directory"
Set-Location $application_production; Get-Location


Remove-Item u921a.sf*, r921b.txt  -EA SilentlyContinue


qtp++ $obj\u921a  > check_f020_depmem_depmed.log
quiz++ $obj\r921b  >> check_f020_depmem_depmed.log

Get-Content r921b.txt| Out-Printer
