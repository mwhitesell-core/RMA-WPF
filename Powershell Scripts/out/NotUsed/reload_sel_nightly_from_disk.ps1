#-------------------------------------------------------------------------------
# File 'reload_sel_nightly_from_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_sel_nightly_from_disk'
#-------------------------------------------------------------------------------

echo "reload_sel_nightly_from_disk"

echo ""
Get-Date

$application_root = "$Env:root\alpha\rmabill\rmabill101c"
Set-Location $env:application_root

# CONVERSION ERROR (unexpected, #9): Unknown command.
# $application_root/cmd/reload_sel_nightly_from_disk.com > /backups/reload_sel_nightly_from_disk_`date '+%Y_%m_%d.%H:%M'`.log
