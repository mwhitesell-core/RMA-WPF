#-------------------------------------------------------------------------------
# File 'reload_22_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_22_reports'
#-------------------------------------------------------------------------------

echo "reload_22_reports"
echo ""
$garbage = Read-Host

echo ""
echo "RELOAD NOW COMMENCING ..."

Get-Date
echo ""
Set-Location $env:application_production
Get-Location
echo ""
Get-Date

# line belows give listing of what's on tape
#cpio -itvcB < /dev/rmt/1    > $application_production/reload_22_reports.ls

# line belows actually reloads the files to disk
# CONVERSION ERROR (expected, #19): tape device is involved.
# cpio -icvB "$application_production/*.*" < /dev/rmt/1 > reload_22_reports.ls

echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #25): tape device is involved.
# mt -f /dev/rmt/1 rewind
