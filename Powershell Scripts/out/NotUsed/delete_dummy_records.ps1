#-------------------------------------------------------------------------------
# File 'delete_dummy_records.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'delete_dummy_records'
#-------------------------------------------------------------------------------

# delete dummy records after  backup to cpio

&$env:QTP delete_dummy_records > $pb_data\delete_dummy_records.log
