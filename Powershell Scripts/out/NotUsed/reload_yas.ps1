#-------------------------------------------------------------------------------
# File 'reload_yas.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_yas'
#-------------------------------------------------------------------------------

echo "modify macro reloadfiles in rmabill"
echo ""
Get-Date
echo ""
echo "hit NEW LINE to continue"
$garbage = Read-Host

echo ""
echo "reload  NOW COMMENCING ..."

Get-Date
echo ""

# IMPORTANT READ FOLLOWING FIRST
# depending on where you want to start 
# comment out  "cd /"   OR   "cd  $application_root"

# if you want to reload in cd / modify "reloadfiles" in there
Set-Location $Env:root\charly\rmabill\rmabill101c\data

# if you want to reload in $application_root modify "reloadfiles" in there
#cd  $application_root

echo "NOTE: the files following files will be loaded .."
Get-Content reloadfiles
echo "INTO THE FOLLOWING FOLDER"
Get-Location
echo ""
echo "hit new line ONLY IF OK"
$garbage = Read-Host

echo "reload starting ..."

# CONVERSION ERROR (expected, #34): tape device is involved.
# cpio -icvB -E reloadfiles < /dev/rmt/0

echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #40): tape device is involved.
# mt -f /dev/rmt/0 rewind
