#-------------------------------------------------------------------------------
# File 'utl0112_all.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'utl0112_all.com'
#-------------------------------------------------------------------------------

# utl0112_all.com

# NOTE: clinic 22 - "normal" clinic 22 payroll
#       clinic 99 - "MP" / Manual Payments payroll
#       clinic 10 - "solo/solotest" payroll
#
# 14/Nov/25 M.C. - original  

echo "--- executing utl0112.qtc ---"

echo ""
echo "Return to MP   environment"
. $Env:root\macros\setup_rmabill.com  mp

&$env:cmd\utl0112.com

echo ""
echo "Return to SOLO environment"
. $Env:root\macros\setup_rmabill.com  solo

&$env:cmd\utl0112.com

echo ""
echo "Return to 101c environment"
. $Env:root\macros\setup_rmabill.com  101c

&$env:cmd\utl0112.com

# consolidate all 3 environments into 1 file
Set-Location $env:application_root\production

Get-Content $Env:root\alpha\rmabill\rmabill101c\production\utl0f112.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utl0f112.ps, $Env:root\alpha\rmabill\rmabillmp\production\utl0f112.ps `
  | Set-Content utl0f112_all.ps

Copy-Item utl0f112.psd utl0f112_all.psd


echo "Done!"
