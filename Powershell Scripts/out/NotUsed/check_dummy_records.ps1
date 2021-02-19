#-------------------------------------------------------------------------------
# File 'check_dummy_records.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'check_dummy_records'
#-------------------------------------------------------------------------------

# check dummy records after  restore from cpio

&$env:QUIZ check_dummy_records > $pb_data\check_dummy_records.log
