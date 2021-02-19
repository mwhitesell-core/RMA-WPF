#-------------------------------------------------------------------------------
# File 'utl0201_all.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'utl0201_all.com'
#-------------------------------------------------------------------------------

# utl0201_all.com

# NOTE: clinic 22 - "normal" clinic 22 payroll
#       clinic 99 - "MP" / Manual Payments payroll
#       clinic 10 - "solo/solotest" payroll
#
# 15/Mar/18 M.C. - original  
# 15/Mar/24 MC1  - include f191
# 15/Oct/13 MC2  - transfer final output files in /foxtrot/bi instead of the current directory production;
#                  rename the files to start with bi_xxxxx.ps

echo "Running `'utl0201.com - extraction of doctor $Env:root\ audit files $Env:root\ f119 payments  `'"

echo " $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo "$SHELL"

echo ""
echo "Setting up Profile ..."
. $Env:root\macros\profile  >> $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production\utl0201_all.log

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
rmabill  $env:RMABILL_VERS >> $Env:root\alpha\rmabill\rmabill101c\production\utl0201_all.log
#. /macros/setup_rmabill.com  101c
echo ""

&$env:cmd\utl0201.com

# consolidate all 3 environments into 1 file
Set-Location $env:application_root\production

# utlf020_audit
Get-Content $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production\utlf020_audit.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utlf020_audit.ps, `
  $Env:root\alpha\rmabill\rmabillmp\production\utlf020_audit.ps `
  | Set-Content $Env:root\foxtrot\bi\bi_utlf020_audit_all.ps

# MC2
#cp utlf020_audit.psd utlf020_audit_all.psd
Copy-Item utlf020_audit.psd $Env:root\foxtrot\bi\bi_utlf020_audit_all.psd

# utlf028_audit

Get-Content $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production\utlf028_audit.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utlf028_audit.ps, `
  $Env:root\alpha\rmabill\rmabillmp\production\utlf028_audit.ps `
  | Set-Content $Env:root\foxtrot\bi\bi_utlf028_audit_all.ps

# MC2
#cp utlf028_audit.psd utlf028_audit_all.psd
Copy-Item utlf028_audit.psd $Env:root\foxtrot\bi\bi_utlf028_audit_all.psd

# utlf110_audit

Get-Content $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production\utlf110_audit.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utlf110_audit.ps, `
  $Env:root\alpha\rmabill\rmabillmp\production\utlf110_audit.ps `
  | Set-Content $Env:root\foxtrot\bi\bi_utlf110_audit_all.ps

# MC2
#cp utlf110_audit.psd utlf110_audit_all.psd
Copy-Item utlf110_audit.psd $Env:root\foxtrot\bi\bi_utlf110_audit_all.psd

# utlf112_audit

Get-Content $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production\utlf112_audit.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utlf112_audit.ps, `
  $Env:root\alpha\rmabill\rmabillmp\production\utlf112_audit.ps `
  | Set-Content $Env:root\foxtrot\bi\bi_utlf112_audit_all.ps

# MC2
#cp utlf112_audit.psd utlf112_audit_all.psd
Copy-Item utlf112_audit.psd $Env:root\foxtrot\bi\bi_utlf112_audit_all.psd

# utl0f020

Get-Content $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production\utl0f020.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utl0f020.ps, $Env:root\alpha\rmabill\rmabillmp\production\utl0f020.ps `
  | Set-Content $Env:root\foxtrot\bi\bi_utl0f020_all.ps

# MC2
#cp utl0f020.psd utl0f020_all.psd
Copy-Item utl0f020.psd $Env:root\foxtrot\bi\bi_utl0f020_all.psd

# utl0201_f119

Get-Content $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production\utl0201_f119.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utl0201_f119.ps, `
  $Env:root\alpha\rmabill\rmabillmp\production\utl0201_f119.ps | Set-Content $Env:root\foxtrot\bi\bi_utl0201_f119_all.ps

# MC2
#cp utl0201_f119.psd utl0201_f119_all.psd
Copy-Item utl0201_f119.psd $Env:root\foxtrot\bi\bi_utl0201_f119_all.psd

# utl0201_f119_audit

Get-Content $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production\utl0201_f119_audit.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utl0201_f119_audit.ps, `
  $Env:root\alpha\rmabill\rmabillmp\production\utl0201_f119_audit.ps `
  | Set-Content $Env:root\foxtrot\bi\bi_utl0201_f119_audit_all.ps

# MC2
#cp utl0201_f119_audit.psd utl0201_f119_audit_all.psd
Copy-Item utl0201_f119_audit.psd $Env:root\foxtrot\bi\bi_utl0201_f119_audit_all.psd

# utl0201_f119_history

Get-Content $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production\utl0201_f119_history.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utl0201_f119_history.ps, `
  $Env:root\alpha\rmabill\rmabillmp\production\utl0201_f119_history.ps `
  | Set-Content $Env:root\foxtrot\bi\bi_utl0201_f119_history_all.ps

# MC2
#cp utl0201_f119_history.psd utl0201_f119_history_all.psd
Copy-Item utl0201_f119_history.psd $Env:root\foxtrot\bi\bi_utl0201_f119_history_all.psd

# MC1
# utl0f191  

Get-Content $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production\utl0f191.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utl0f191.ps, $Env:root\alpha\rmabill\rmabillmp\production\utl0f191.ps `
  | Set-Content $Env:root\foxtrot\bi\bi_utl0f191_all.ps

# MC2
#cp utl0f191.psd utl0f191_all.psd
Copy-Item utl0f191.psd $Env:root\foxtrot\bi\bi_utl0f191_all.psd

##################################

&$env:QTP utl0030

# MC2
Copy-Item utl0f090_rec6.ps $Env:root\foxtrot\bi\bi_utl0f090_rec6.ps
Copy-Item utl0f090_rec6.psd $Env:root\foxtrot\bi\bi_utl0f090_rec6.psd
Copy-Item utl0f030.ps $Env:root\foxtrot\bi\bi_utl0f030.ps
Copy-Item utl0f030.psd $Env:root\foxtrot\bi\bi_utl0f030.psd
Copy-Item utl0f070.ps $Env:root\foxtrot\bi\bi_utl0f070.ps
Copy-Item utl0f070.psd $Env:root\foxtrot\bi\bi_utl0f070.psd
Copy-Item utl0f190.ps $Env:root\foxtrot\bi\bi_utl0f190.ps
Copy-Item utl0f190.psd $Env:root\foxtrot\bi\bi_utl0f190.psd
Copy-Item utl0f090_clinic.ps $Env:root\foxtrot\bi\bi_utl0f090_clinic.ps
Copy-Item utl0f090_clinic.psd $Env:root\foxtrot\bi\bi_utl0f090_clinic.psd
Copy-Item utl0f123.ps $Env:root\foxtrot\bi\bi_utl0f123.ps
Copy-Item utl0f123.psd $Env:root\foxtrot\bi\bi_utl0f123.psd

echo "Done!"
echo " $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
