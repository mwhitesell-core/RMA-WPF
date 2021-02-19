#-------------------------------------------------------------------------------
# File 'reload_f002.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_f002'
#-------------------------------------------------------------------------------

## reload_all_data_from_disk

echo "reload_all_data_from_disk"

Get-Date

$application_root = "$Env:root\alpha\rmabill\rmabill101c"
Set-Location $env:application_root

## 2009/may/20 - f002 files takes (91% - 58%) = 33% in dyad
## MUST delete the files before reload; otherwise receive error 'No space Left'

# CONVERSION ERROR (expected, #14): compressing to cpio.
# uncompress -c < /charly/backup_transfer_area/backup_101c_f002.cpio | cpio -icdvB
Get-Date

echo "restore is done"
Get-Date
