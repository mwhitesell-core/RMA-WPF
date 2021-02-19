#-------------------------------------------------------------------------------
# File 'utl0201_f020_all.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'utl0201_f020_all.com'
#-------------------------------------------------------------------------------

# utl0201_f020_all.com

# NOTE: clinic 22 - "normal" clinic 22 payroll
#       clinic 99 - "MP" / Manual Payments payroll
#       clinic 10 - "solo/solotest" payroll
#
# 15/Mar/18 M.C. - original  
# 15/Mar/24 MC1  - include f191
# 15/Oct/13 MC2  - transfer final output files in /foxtrot/bi instead of the current directory production;
#                  rename the files to start with bi_xxxxx.ps

echo "Running `'utl0201_f020_all.com - extraction of doctor `'"

echo " $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo "$SHELL"

echo ""
echo "Setting up Profile ..."
. $Env:root\macros\profile  >> $Env:root\alpha\rmabill\rmabill101c\production\utl0201_f020_all.log

echo ""
echo "Setting up to MP Environment ..."
rmabill  mp >> $Env:root\alpha\rmabill\rmabill101c\production\utl0201_f020_all.log
echo ""

&$env:cmd\utl0201_f020.com

echo ""
echo "Setting up to SOLO Environment ..."
rmabill  solo >> $Env:root\alpha\rmabill\rmabill101c\production\utl0201_f020_all.log
echo ""

&$env:cmd\utl0201_f020.com

echo ""
echo "Setting up to 101C Environment ..."
rmabill  101c >> $Env:root\alpha\rmabill\rmabill101c\production\utl0201_f020_all.log
echo ""

&$env:cmd\utl0201_f020.com

# consolidate all 3 environments into 1 file
Set-Location $env:application_root\production

# utl0f020

Get-Content $Env:root\alpha\rmabill\rmabill101c\production\utl0f020.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utl0f020.ps, $Env:root\alpha\rmabill\rmabillmp\production\utl0f020.ps `
  | Set-Content $Env:root\foxtrot\bi\bi_utl0f020_all.ps

Copy-Item utl0f020.psd $Env:root\foxtrot\bi\bi_utl0f020_all.psd


echo "Done!"
echo " $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
