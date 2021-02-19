#-------------------------------------------------------------------------------
# File 'backup_ohip_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_ohip_tape'
#-------------------------------------------------------------------------------

echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""


echo ""
Get-Date
echo ""

Set-Location $pb_data
Get-ChildItem f001_batch_control_file*, f002_claims_mstr*, f002_claim_shadow*, f050_doc_revenue_mstr*, `
  f050tp_doc_revenue_mstr*, f051_doc_cash_mstr*, f051tp_doc_cash_mstr*, f090_constants_mstr* > backup_ohip_tape.ls

# CONVERSION ERROR (expected, #21): tape device is involved.
# cat backup_ohip_tape.ls | cpio -ocuvB |dd of=/dev/rmt/1

echo ""
Get-Date
echo ""

# CONVERSION ERROR (expected, #27): tape device is involved.
# mt -f /dev/rmt/1 rewind
