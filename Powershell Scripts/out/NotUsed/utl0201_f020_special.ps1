#-------------------------------------------------------------------------------
# File 'utl0201_f020_special.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'utl0201_f020_special'
#-------------------------------------------------------------------------------

# consolidate all 3 environments into 1 file
Set-Location $env:application_root\production


Get-Content $Env:root\alpha\rmabill\rmabill101c\production\utl0f020_special.ps, `
  $Env:root\alpha\rmabill\rmabillsolo\production\utl0f020_special.ps, `
  $Env:root\alpha\rmabill\rmabillmp\production\utl0f020_special.ps `
  | Set-Content $Env:root\foxtrot\bi\bi_utl0f020_all_special.ps

Copy-Item utl0f020.psd $Env:root\foxtrot\bi\bi_utl0f020_all_special.psd
