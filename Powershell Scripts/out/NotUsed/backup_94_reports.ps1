#-------------------------------------------------------------------------------
# File 'backup_94_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_94_reports'
#-------------------------------------------------------------------------------

# CREATED 2003/jun/16

Set-Location $env:application_production\94

Get-ChildItem r004, r005, r011, r012, r013, r051ca, r051cb, r070_94, r210, r211 > bk_94_reports.ls

# CONVERSION ERROR (expected, #16): tape device is involved.
# cat $application_production/94/bk_94_reports.ls |cpio -ocuvB |dd of=/dev/rmt/1

# CONVERSION ERROR (expected, #18): tape device is involved.
# mt -f /dev/rmt/1 rewind
