#-------------------------------------------------------------------------------
# File 'backup_f001_f050.bk2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_f001_f050.bk2'
#-------------------------------------------------------------------------------

echo "BACKUP_F001_F050"

echo "BACKUP OF:"
echo "----------!  F001   - BATCH CONTROL FILE"
echo "----------!  F050   - DOC REVENUE MSTR"
echo "----------!  F051   - DOC CASH    MSTR"
echo "----------!  F050TP - DOC REVENUE MSTR"
echo "----------!  F051TP - DOC CASH    MSTR"
echo ""

echo "HIT `"NEWLINE`" TO COMMENCE BACKUP ..."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""

echo ""
Get-Date
echo ""

Set-Location $pb_data
Get-ChildItem f001_batch_control_file*, f050_doc_revenue_mstr*, f051_doc_cash_mstr*, f050tp_doc_revenue_mstr*, `
  f051tp_doc_cash_mstr* > bk_f001_f050.ls

# CONVERSION ERROR (expected, #29): tape device is involved.
# cat $pb_data/bk_f001_f050.ls            \                | cpio -ocuvB           \                | dd of=/dev/rmt/1

echo ""
Get-Date
echo ""

# CONVERSION ERROR (expected, #37): tape device is involved.
# mt -f /dev/rmt/1 rewind

## to reload dir to data vi reload for the files you need to reload
### dd if=/dev/rmt/1 | cpio -icvB -E reload (use this command)
