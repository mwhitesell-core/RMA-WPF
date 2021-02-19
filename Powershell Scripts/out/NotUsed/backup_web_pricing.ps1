#-------------------------------------------------------------------------------
# File 'backup_web_pricing.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_web_pricing'
#-------------------------------------------------------------------------------

# 2013/Apr/11 - created by Moira Chan 

echo "backup_web_pricing"
echo ""

echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""

Set-Location $env:application_root\production
Get-Location
Get-ChildItem web*\w*.hdr, web*\w*.des, web*\w*.dtl, web*\w*.pr, web*\pr*, web*\canbedel\* > backup_web_pricing.ls

echo ""
Get-Date
# CONVERSION ERROR (expected, #19): tape device is involved.
# cat backup_web_pricing.ls   | cpio -ocuvB > /dev/rmt/1
echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #24): tape device is involved.
# mt -f /dev/rmt/1 rewind

# line belows give listing of what's on tape
#    cpio -itvcB < /dev/rmt/1    > reload_web_pricing.ls
#
# lines  below actually reloads all files to web directories
#    cd $application_root/production
#    cpio -icuvB < /dev/rmt/1
#
# lines below actually reloads the selected files to web directories 
# provided that you add the files in reload_sel_web.ls in   $application_root/production
#    cd $application_root/production
#    cpio -icuvB  -E  reload_sel_web.ls  < /dev/rmt/1
