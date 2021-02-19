#-------------------------------------------------------------------------------
# File 'backup_web_to_disk_and_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_web_to_disk_and_tape'
#-------------------------------------------------------------------------------

echo "backup_web_to_disk_and_tape"
echo ""
## 2010/09/29   M.C.    - backup web1 to 10  

echo ""
Get-Date
echo ""

echo "Finding production web files ..."
Set-Location $env:application_root
Get-Location
Get-ChildItem -recurse production\web\* | Select -ExpandProperty FullName > data\backup_web.ls
Get-ChildItem -recurse production\web1\* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web2\* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web3\* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web4\* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web5\* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web6\* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web7\* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web8\* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web9\* | Select -ExpandProperty FullName >> data\backup_web.ls
Get-ChildItem -recurse production\web10\* | Select -ExpandProperty FullName >> data\backup_web.ls
echo ""
Get-Date


echo "Backup to disk commencing ..."

# CONVERSION ERROR (expected, #29): compressing to cpio.
# cat   data/backup_web.ls |cpio -ocuvB | compress -c  > /charly/backup_transfer_area/backup_101c_web.cpio


echo "Starting copy of file to tape ..."
Get-Location

echo ""
Get-Date
# CONVERSION ERROR (expected, #37): tape device is involved.
# cat   data/backup_web.ls | cpio -ocuvB > /dev/rmt/0 

echo ""
Get-Date
echo ""
echo "Rewinding tape ..."

# CONVERSION ERROR (expected, #44): tape device is involved.
# mt -f /dev/rmt/0 rewind



echo " "
Get-Date
echo "DONE!"
