#-------------------------------------------------------------------------------
# File 'backup_22_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_22_reports'
#-------------------------------------------------------------------------------

# CREATED NOV 6/96

Set-Location $env:application_production

Get-ChildItem r004, r005, r011, r012, r013, r051ca, r051cb, r123*, r111b*, r120*, r119*, r121*, r124*, r210, r211, `
  r070_22 > bk_22_reports.ls

# CONVERSION ERROR (expected, #22): tape device is involved.
# cat $application_production/bk_22_reports.ls |cpio -ocuvB |dd of=/dev/rmt/1

# CONVERSION ERROR (expected, #24): tape device is involved.
# mt -f /dev/rmt/1 rewind
