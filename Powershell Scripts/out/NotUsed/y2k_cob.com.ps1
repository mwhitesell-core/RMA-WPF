#-------------------------------------------------------------------------------
# File 'y2k_cob.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'y2k_cob.com'
#-------------------------------------------------------------------------------

# CONVERSION ERROR (unexpected, #1): Unknown command.
# for fname in `cat     y2k_cob.files`
{
# CONVERSION ERROR (unexpected, #3): Unknown command.
#   /macros/dy_time "Searching for date fields in .. $fname"
#  mv                $fname $fname.y2k
Get-Content $fname.y2k |  awk++ $env:cmd\y2k_c2.awk > $fname
}
