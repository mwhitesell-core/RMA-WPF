#-------------------------------------------------------------------------------
# File 'backup_web.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_web'
#-------------------------------------------------------------------------------

echo "backup_web"
echo ""
## 2009/11/18   M.C.    - backup web1 to 10  

echo ""
Get-Date
echo ""

echo "Finding production web files ..."
Set-Location $env:application_root
Get-Location
Get-ChildItem -recurse production\web\w* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web1\w* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web2\w* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web3\w* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web4\w* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web5\w* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web6\w* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web7\w* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web8\w* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web9\w* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web10\w* | Select -ExpandProperty FullName >> data\backup_web.ls
echo ""
Get-Date


# CONVERSION ERROR (expected, #27): tape device is involved.
# mt -f /dev/rmt/1 rewind

echo "Starting copy of file to tape ..."
Set-Location $env:application_root
Get-Location

echo ""
Get-Date

# CONVERSION ERROR (expected, #36): tape device is involved.
# cat       data/backup_web.ls | cpio -ocuvB > /dev/rmt/1 

echo ""
Get-Date
echo ""
echo "Rewinding tape ..."

# CONVERSION ERROR (expected, #43): tape device is involved.
# mt -f /dev/rmt/1 rewind



echo " "
Get-Date
echo "DONE!"
