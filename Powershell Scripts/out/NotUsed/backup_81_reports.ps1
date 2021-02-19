#-------------------------------------------------------------------------------
# File 'backup_81_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_81_reports'
#-------------------------------------------------------------------------------

# CREATED NOV 6/96

Set-Location $env:application_production\81

Get-ChildItem r004, r005, r011, r012, r013, r051ca, r051cb, r070_81, r934*, mohbicu, r210, r211 > bk_81_reports.ls

# CONVERSION ERROR (expected, #18): tape device is involved.
# cat $application_production/81/bk_81_reports.ls |cpio -ocuvB |dd of=/dev/rmt/1

#cd $application_production/yasemin
#/bin/ls r934a.txt \
#        r934b.txt   > $application_production/81/bk_81b_reports.ls
#
#cat $application_production/bk_81b_reports.ls |cpio -ocuvB |dd of=/dev/rmt/1

# CONVERSION ERROR (expected, #26): tape device is involved.
# mt -f /dev/rmt/1 rewind
