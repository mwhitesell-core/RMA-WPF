#-------------------------------------------------------------------------------
# File 'backup_f040_f090.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_f040_f090'
#-------------------------------------------------------------------------------

echo "BACKUP_f040_f090"

echo "HIT `"NEWLINE`" TO COMMENCE BACKUP ..."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""

echo ""
Get-Date
echo ""

Set-Location $pb_data
Get-ChildItem f040_oma_fee_mstr*, f090_constants_mstr* > bk_f040_f090.ls

# CONVERSION ERROR (expected, #18): tape device is involved.
# cat $pb_data/bk_f040_f090.ls            \                | cpio -ocuvB           \                | dd of=/dev/rmt/1

echo ""
Get-Date
echo ""

# CONVERSION ERROR (expected, #26): tape device is involved.
# mt -f /dev/rmt/1 rewind

## to reload dir to data vi reload for the files you need to reload
### dd if=/dev/rmt/1 | cpio -icvB -E reload (use this command)
