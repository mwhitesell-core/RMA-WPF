#-------------------------------------------------------------------------------
# File 'utl0119_all.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'utl0119_all.com'
#-------------------------------------------------------------------------------

# utl0119_all.com

# NOTE: clinic 22 - "normal" clinic 22 payroll
#       clinic 99 - "MP" / Manual Payments payroll
#       clinic 10 - "solo/solotest" payroll
#
# 14/Nov/25 M.C. - original  

#CORE - TESTING ENVIRONMENT CHANGES
$vers = $env:RMABILL_VERS
echo "--- executing utl0119.qtc ---"

echo ""
echo "Return to MP   environment"
#. $Env:root\macros\setup_rmabill.com  mp
rmabill mp

&$env:cmd\utl0119.com

echo ""
echo "Return to SOLO environment"
#. $Env:root\macros\setup_rmabill.com  solo

rmabill solo


&$env:cmd\utl0119.com

echo ""
echo "Return to 101c environment"
#. $Env:root\macros\setup_rmabill.com  101c
if($vers -eq "101c") {
	rmabill 101c
}
else {
	echo "WARNING: TEST ENVIRONMENT DETECTED"
	rmabill $vers
}

&$env:cmd\utl0119.com

# consolidate all 3 environments into 1 file
Set-Location $env:application_root\production

Get-Content \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production\utl0f119_A.ps, `
  \\$Env:root\alpha\rmabill\rmabillsolo\production\utl0f119_A.ps, `
  \\$Env:root\alpha\rmabill\rmabillmp\production\utl0f119_A.ps | Set-Content utl0f119_all.ps

Copy-Item utl0f119_A.psd utl0f119_all.psd

Get-Content \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production\utl0f020_B.ps, `
  \\$Env:root\alpha\rmabill\rmabillsolo\production\utl0f020_B.ps, `
  \\$Env:root\alpha\rmabill\rmabillmp\production\utl0f020_B.ps | Set-Content utl0f020_all.ps

Copy-Item utl0f020_B.psd utl0f020_all.psd

##################################
# below can be deleted after testing

Get-Content \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production\utl0f020_A.ps, `
  \\$Env:root\alpha\rmabill\rmabillsolo\production\utl0f020_A.ps, `
  \\$Env:root\alpha\rmabill\rmabillmp\production\utl0f020_A.ps | Set-Content utl0f020_all_A.ps

Copy-Item utl0f020_A.psd utl0f020_all_A.psd

##################################

$rcmd = $env:QTP + "utl0030"
Invoke-Expression $rcmd

echo "Done!"
