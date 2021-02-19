#-------------------------------------------------------------------------------
# File 'backup_f071.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_f071'
#-------------------------------------------------------------------------------

echo ""
Get-Date
echo ""

Set-Location $pb_data
Get-ChildItem f071*, f072*, f073* > backup_f071.ls

# CONVERSION ERROR (expected, #10): tape device is involved.
# cat $pb_data/backup_f071.ls |cpio -ocuvB |dd of=/dev/rmt/1

echo ""
Get-Date
echo ""

# CONVERSION ERROR (expected, #16): tape device is involved.
# mt -f /dev/rmt/1 rewind
