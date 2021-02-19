#-------------------------------------------------------------------------------
# File 'backup_83_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_83_reports'
#-------------------------------------------------------------------------------

# CREATED AUG 13/97

Set-Location $env:application_production\83

Get-ChildItem r004, r005, r011, r012, r051ca, r051cb, r210, r211, r070_83 > bk_83_reports.ls

# CONVERSION ERROR (expected, #15): tape device is involved.
# cat $application_production/83/bk_83_reports.ls |cpio -ocuvB |dd of=/dev/rmt/1

# CONVERSION ERROR (expected, #17): tape device is involved.
# mt -f /dev/rmt/1 rewind
