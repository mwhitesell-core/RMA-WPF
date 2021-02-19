#-------------------------------------------------------------------------------
# File 'reload_60_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_60_reports'
#-------------------------------------------------------------------------------

echo "reload_60_reports"
echo ""
$garbage = Read-Host

echo ""
echo "RELOAD NOW COMMENCING ..."

Get-Date
echo ""
Set-Location $env:application_production\60

#cpio -icuvB -E < /dev/rmt/1 > reload_60_reports.ls

# CONVERSION ERROR (expected, #14): tape device is involved.
# o -icvB "$application_production/60/*.*" < /dev/rmt/1 > reload_60_reports.ls

# CONVERSION ERROR (expected, #16): tape device is involved.
# mt -f /dev/rmt/1 rewind

echo ""
Get-Date
echo "DONE!"
