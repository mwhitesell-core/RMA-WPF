#-------------------------------------------------------------------------------
# File 'y2k_ph.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'y2k_ph.com'
#-------------------------------------------------------------------------------

# CONVERSION ERROR (unexpected, #1): Unknown command.
# for fname in $1
{
# CONVERSION ERROR (unexpected, #3): Unknown command.
#   /macros/dy_time "Searching for date fields in .. $fname"
  Move-Item -Force $fname $fname.y2k
Get-Content $fname.y2k |  awk++ $env:cmd\y2k_p2.awk > $fname
}
