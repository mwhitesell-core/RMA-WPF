#-------------------------------------------------------------------------------
# File 'utl0201_all.com.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'utl0201_all.com.bk1'
#-------------------------------------------------------------------------------

# utl0201_all.com

# NOTE: clinic 22 - "normal" clinic 22 payroll
#       clinic 99 - "MP" / Manual Payments payroll
#       clinic 10 - "solo/solotest" payroll
#
# 15/Mar/18 M.C. - original  
# 15/Mar/24 MC1  - include f191

echo "Running `'utl0201.com - extraction of doctor $Env:root\ audit files $Env:root\ f119 payments  `'"

echo " $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo "$SHELL"

echo ""
echo "Setting up Profile ..."
. $Env:root\macros\profile  >> $Env:root\alpha\rmabill\rmabill101c\production\utl0201_all.log

echo ""
echo "Setting up to MP Environment ..."
rmabill  mp >> $Env:root\alpha\rmabill\rmabill101c\production\utl0201_all.log
#. /macros/setup_rmabill.com mp   
echo ""

&$env:cmd\utl0201.com

echo ""
echo "Setting up to SOLO Environment ..."
rmabill  solo >> $Env:root\alpha\rmabill\rmabill101c\production\utl0201_all.log
#. /macros/setup_rmabill.com  solo    
echo ""

&$env:cmd\utl0201.com

echo ""
echo "Setting up to 101C Environment ..."
rmabill  101c >> $Env:root\alpha\rmabill\rmabill101c\production\utl0201_all.log
#. /macros/setup_rmabill.com  101c
echo ""

&$env:cmd\utl0201.com

# consolidate all 3 environments into 1 file
Set-Location $env:application_root\production

# utlf020_audit
Get-Content $Env:root\alpha\rmabill\rmabill101c\production\utlf020_audit.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utlf020_audit.ps, `
  $Env:root\alpha\rmabill\rmabillmp\production\utlf020_audit.ps | Set-Content utlf020_audit_all.ps

Copy-Item utlf020_audit.psd utlf020_audit_all.psd

# utlf028_audit

Get-Content $Env:root\alpha\rmabill\rmabill101c\production\utlf028_audit.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utlf028_audit.ps, `
  $Env:root\alpha\rmabill\rmabillmp\production\utlf028_audit.ps | Set-Content utlf028_audit_all.ps

Copy-Item utlf028_audit.psd utlf028_audit_all.psd

# utlf110_audit

Get-Content $Env:root\alpha\rmabill\rmabill101c\production\utlf110_audit.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utlf110_audit.ps, `
  $Env:root\alpha\rmabill\rmabillmp\production\utlf110_audit.ps | Set-Content utlf110_audit_all.ps

Copy-Item utlf110_audit.psd utlf110_audit_all.psd

# utlf112_audit

Get-Content $Env:root\alpha\rmabill\rmabill101c\production\utlf112_audit.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utlf112_audit.ps, `
  $Env:root\alpha\rmabill\rmabillmp\production\utlf112_audit.ps | Set-Content utlf112_audit_all.ps

Copy-Item utlf112_audit.psd utlf112_audit_all.psd

# utl0f020

Get-Content $Env:root\alpha\rmabill\rmabill101c\production\utl0f020.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utl0f020.ps, $Env:root\alpha\rmabill\rmabillmp\production\utl0f020.ps `
  | Set-Content utl0f020_all.ps

Copy-Item utl0f020.psd utl0f020_all.psd

# utl0201_f119

Get-Content $Env:root\alpha\rmabill\rmabill101c\production\utl0201_f119.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utl0201_f119.ps, `
  $Env:root\alpha\rmabill\rmabillmp\production\utl0201_f119.ps | Set-Content utl0201_f119_all.ps

Copy-Item utl0201_f119.psd utl0201_f119_all.psd

# utl0201_f119_audit

Get-Content $Env:root\alpha\rmabill\rmabill101c\production\utl0201_f119_audit.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utl0201_f119_audit.ps, `
  $Env:root\alpha\rmabill\rmabillmp\production\utl0201_f119_audit.ps | Set-Content utl0201_f119_audit_all.ps

Copy-Item utl0201_f119_audit.psd utl0201_f119_audit_all.psd

# utl0201_f119_history

Get-Content $Env:root\alpha\rmabill\rmabill101c\production\utl0201_f119_history.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utl0201_f119_history.ps, `
  $Env:root\alpha\rmabill\rmabillmp\production\utl0201_f119_history.ps | Set-Content utl0201_f119_history_all.ps

Copy-Item utl0201_f119_history.psd utl0201_f119_history_all.psd

# MC1
# utl0f191  

Get-Content $Env:root\alpha\rmabill\rmabill101c\production\utl0f191.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utl0f191.ps, $Env:root\alpha\rmabill\rmabillmp\production\utl0f191.ps `
  | Set-Content utl0f191_all.ps

Copy-Item utl0f191.psd utl0f191_all.psd

##################################

&$env:QTP utl0030

echo "Done!"
echo " $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
