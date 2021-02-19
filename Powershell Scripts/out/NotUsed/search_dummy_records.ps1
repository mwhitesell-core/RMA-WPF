#-------------------------------------------------------------------------------
# File 'search_dummy_records.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'search_dummy_records'
#-------------------------------------------------------------------------------

# search dummy records after  restore from cpio

&$env:QUIZ search_dummy_records > $pb_data\search_dummy_records.log
