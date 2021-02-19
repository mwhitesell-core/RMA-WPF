#-------------------------------------------------------------------------------
# File 'backup_82_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_82_reports'
#-------------------------------------------------------------------------------

# CREATED MAR 17/97

Set-Location $env:application_production\82

Get-ChildItem r004, r005, r011, r012, r013, r051ca, r051cb, r070_82, r210, r211 > bk_82_reports.ls

# CONVERSION ERROR (expected, #17): tape device is involved.
# cat $application_production/82/bk_82_reports.ls |cpio -ocuvB |dd of=/dev/rmt/1

# CONVERSION ERROR (expected, #19): tape device is involved.
# mt -f /dev/rmt/1 rewind
