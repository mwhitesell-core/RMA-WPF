#-------------------------------------------------------------------------------
# File 'backup_60_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_60_reports'
#-------------------------------------------------------------------------------

# CREATED NOV 6/96

Set-Location $env:application_production\60

Get-ChildItem r004tp, r005tp, r006tp, r011, r012tp, r013tp, r015tp, r051ca, r051cb, r210, r211, r070tp_60 `
  > bk_60_reports.ls

# CONVERSION ERROR (expected, #18): tape device is involved.
# cat $application_production/60/bk_60_reports.ls |cpio -ocuvB |dd of=/dev/rmt/1

# CONVERSION ERROR (expected, #20): tape device is involved.
# mt -f /dev/rmt/1 rewind
