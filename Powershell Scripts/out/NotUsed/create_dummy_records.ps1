#-------------------------------------------------------------------------------
# File 'create_dummy_records.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_dummy_records'
#-------------------------------------------------------------------------------

# create dummy records before backup to cpio

&$env:QTP create_dummy_records > $pb_data\create_dummy_records.log
