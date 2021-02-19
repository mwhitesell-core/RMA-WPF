#-------------------------------------------------------------------------------
# File 'backup_85_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_85_reports'
#-------------------------------------------------------------------------------

# CREATED oct/22/01

Set-Location $env:application_production\85

Get-ChildItem r005, r011, r012, r013, r051ca, r051cb, r934*, mohbicu, r211 > bk_85_reports.ls

# CONVERSION ERROR (expected, #14): tape device is involved.
# cat $application_production/85/bk_85_reports.ls |cpio -ocuvB |dd of=/dev/rmt/1

# CONVERSION ERROR (expected, #16): tape device is involved.
# mt -f /dev/rmt/1 rewind
