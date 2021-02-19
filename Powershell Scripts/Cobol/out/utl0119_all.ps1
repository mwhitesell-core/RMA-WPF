#-------------------------------------------------------------------------------
# File 'utl0119_all.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'utl0119_all.com'
#-------------------------------------------------------------------------------

# utl0119_all.com

# NOTE: clinic 22 - "normal" clinic 22 payroll
#       clinic 99 - "MP" / Manual Payments payroll
#       clinic 10 - "solo/solotest" payroll
#
# 14/Nov/25 M.C. - original  

echo "--- executing utl0119.qtc ---"

echo ""
echo "Return to MP   environment"
. $root\macros\setup_rmabill.com mp

$cmd\utl0119.com

echo ""
echo "Return to SOLO environment"
. $root\macros\setup_rmabill.com solo

$cmd\utl0119.com

echo ""
echo "Return to 101c environment"
. $root\macros\setup_rmabill.com 101c

$cmd\utl0119.com

# consolidate all 3 environments into 1 file
Set-Location $application_root\production

Get-Content $root\alpha\rmabill\rmabill101c\production\utl0f119_A.ps, $root\alpha\rmabill\rmabillsolo\production\utl0f119_A.ps, $root\alpha\rmabill\rmabillmp\production\utl0f119_A.ps  > utl0f119_all.ps

Copy-Item utl0f119_A.psd utl0f119_all.psd

Get-Content $root\alpha\rmabill\rmabill101c\production\utl0f020_B.ps, $root\alpha\rmabill\rmabillsolo\production\utl0f020_B.ps, $root\alpha\rmabill\rmabillmp\production\utl0f020_B.ps  > utl0f020_all.ps

Copy-Item utl0f020_B.psd utl0f020_all.psd

##################################
# below can be deleted after testing

Get-Content $root\alpha\rmabill\rmabill101c\production\utl0f020_A.ps, $root\alpha\rmabill\rmabillsolo\production\utl0f020_A.ps, $root\alpha\rmabill\rmabillmp\production\utl0f020_A.ps  > utl0f020_all_A.ps

Copy-Item utl0f020_A.psd utl0f020_all_A.psd

##################################

qtp++ $obj\utl0030

echo "Done!"
