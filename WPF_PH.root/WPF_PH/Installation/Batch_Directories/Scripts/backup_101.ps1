#-------------------------------------------------------------------------------
# File 'backup_101.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_101'
#-------------------------------------------------------------------------------

# 99/Mar/16     B.E.    - original

echo "backup_101"
echo ""

echo "BACKUP OF:"
echo "----------!  101 data files"
echo ""

Set-Location $Env:root\alpha\rmabill\rmabill101
Get-Location

echo ""
echo "HIT   `"NEWLINE`"   TO COMMENCE BACKUP ..."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""
Get-Date
echo ""
echo "Finding   101   files .."

Get-ChildItem data\f002_claims_mstr*, data\f010_pat_mstr*, data\f001_batch_control_file*, data\f020_doctor_mstr*, `
  data\f050_doc_revenue_mstr*, data\f051_doc_cash_mstr*, data\f050tp_doc_revenue_mstr*, data\f051tp_doc_cash_mstr*, `
  data\f002_claim_shadow*, data\f090_constants_mstr*, data\f021_avail_doctor_mstr*, data\f096_ohip_pay_code*, `
  data\f023_alternative_doc_nbr*, data\f085_rejected_claims*, data\f071_client_rma_claim_nbr*, data\f072_client_mstr*, `
  data\f073_client_doc_mstr*, data\f098_equiv_oma_code_mstr*, data\f022_deleted_doc_mstr*, data\u010_out_file*, `
  data\adj_claim_file*, data\f020_doctor_extra*, data\f099_group_claim_mstr* > data\backup_daily.ls
echo ""
echo ""
Get-Date
echo "Finding production diskette upload files ..."

Get-ChildItem -recurse production\web | Select -ExpandProperty FullName > data\webdir.ls
Get-ChildItem -recurse production\web1 | Select -ExpandProperty FullName > data\web1dir.ls
Get-ChildItem -recurse production\diskette | Select -ExpandProperty FullName > data\diskettedir.ls
Get-ChildItem -recurse production\diskette1 | Select -ExpandProperty FullName > data\diskette1dir.ls
Get-ChildItem -recurse production\stone | Select -ExpandProperty FullName > data\stonedir.ls
Get-ChildItem -recurse production\f002_suspend* | Select -ExpandProperty FullName > data\suspend.ls
Get-ChildItem -recurse production\f086_pat_id* | Select -ExpandProperty FullName > data\f086.ls
echo ""
echo ""
Get-Date

echo "Starting copy of files to DISK ..."
Get-Location
# CONVERSION ERROR (expected, #66): piping to cpio.
# cat data/backup_daily.ls                \    data/webdir.ls                      \    data/web1dir.ls                     \    data/diskettedir.ls                 \    data/diskette1dir.ls                \    data/stonedir.ls                    \    data/suspend.ls                     \    data/f086.ls                \    | cpio -ocuvB > backups/backup_daily_to_disk.cpio
echo " "
Get-Date
echo "DONE!"
