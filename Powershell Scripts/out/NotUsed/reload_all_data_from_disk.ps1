#-------------------------------------------------------------------------------
# File 'reload_all_data_from_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_all_data_from_disk'
#-------------------------------------------------------------------------------

## reload_all_data_from_disk

echo "reload_all_data_from_disk"

Get-Date

$application_root = "$Env:root\alpha\rmabill\rmabill101c"
Set-Location $env:application_root

# CONVERSION ERROR (unexpected, #10): Unknown command.
# $application_root/cmd/reload_all_data_from_disk.com > /backups/reload_all_data_from_disk_`date '+%Y_%m_%d.%H:%M'`.log
