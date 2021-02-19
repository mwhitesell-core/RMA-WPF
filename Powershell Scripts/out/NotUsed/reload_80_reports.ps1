#-------------------------------------------------------------------------------
# File 'reload_80_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_80_reports'
#-------------------------------------------------------------------------------

echo "reload_80_reports"
echo ""
$garbage = Read-Host

echo ""
echo "RELOAD NOW COMMENCING ..."

Get-Date
echo ""

Set-Location $env:application_production\80

#cpio -icuvB -E < /dev/rmt/1 > reload_80_reports.ls

# CONVERSION ERROR (expected, #15): tape device is involved.
# o -icvB "$application_production/80/*.*" < /dev/rmt/1 > reload_80_reports.ls

# CONVERSION ERROR (expected, #17): tape device is involved.
# mt -f /dev/rmt/1 rewind

echo ""
Get-Date
echo "DONE!"
