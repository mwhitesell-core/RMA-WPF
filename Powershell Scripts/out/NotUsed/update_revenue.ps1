#-------------------------------------------------------------------------------
# File 'update_revenue.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'update_revenue'
#-------------------------------------------------------------------------------

# update_revenue
Set-Location $env:application_root

if (Test-Path backup_nightly.flg)
{
  Set-Location $env:application_production
    &$env:cmd\u010_daily 20010207
#else
# error don't update!
}
