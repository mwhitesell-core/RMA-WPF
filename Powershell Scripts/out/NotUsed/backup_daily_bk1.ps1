#-------------------------------------------------------------------------------
# File 'backup_daily_bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_daily_bk1'
#-------------------------------------------------------------------------------

echo "BACKUP_DAILY"
echo ""

echo "BACKUP OF:"
echo "----------!  f002   - claims mstr"
echo "----------!  f010   - patient mstr"
echo "----------!  f001   - batch control file"
echo "----------!  f020   - doctor mstr"
echo "----------!  f050   - doc revenue mstr"
echo "----------!  f051   - doc cash    mstr"
echo "----------!  f050tp - doc revenue mstr"
echo "----------!  f051tp - doc cash    mstr"
echo "----------!  f002   - claim shadow"
echo "----------!  f090   - constants master"
echo "----------!  f021   - available doctor master"
echo "----------!  f096   - ohip pay code master"
echo "----------!  f023   - alternative doc nbr"
echo "----------!  f002   - suspend hdr"
echo "----------!  f002   - suspend dtl"
echo "----------!  f002   - suspend address"
echo "----------!  f085   - rejected claims"
echo "----------!  f086   - patient-id.dat"
echo "----------!  f086   - rma#'s patient-id.dat 95$Env:root\02\02"
echo "----------!  f071   - client rma claim nbr"
echo "----------!  f072   - client master"
echo "----------!  f073   - client doctor master"
echo "----------!  f098   - equiv oma code master"
echo "----------!  f022   - deleted doc"
echo "----------!  u010   - u010-out-file"
echo "----------!  adj    - adj-calim-file"
echo "----------!  f002   - f002-claims-extra"
echo "----------!  f020   - f020-doctor-extra"
echo "----------!  f099   - group_claim_mstr"
echo ""

echo "HIT   `"NEWLINE`"   TO COMMENCE BACKUP ..."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""

echo ""
Get-Date
echo ""

Set-Location $env:application_root
Get-Location
echo " "
echo " "
echo "Finding $pb_data files .."
Get-ChildItem $pb_data\f002_claims_mstr*, $pb_data\f010_pat_mstr*, $pb_data\f001_batch_control_file, `
  $pb_data\f020_doctor_mstr*, $pb_data\f050_doc_revenue_mstr*, $pb_data\f051_doc_cash_mstr*, `
  $pb_data\f050tp_doc_revenue_mstr*, $pb_data\f051tp_doc_cash_mstr*, $pb_data\f002_claim_shadow*, `
  $pb_data\f090_constants_mstr*, $pb_data\f021_avail_doctor_mstr*, $pb_data\f096_ohip_pay_code*, `
  $pb_data\f023_alternative_doc_nbr*, $pb_data\f002_suspend_hdr*, $pb_data\f002_suspend_dtl*, `
  $pb_data\f002_suspend_address*, $pb_data\f085_rejected_claims*, $pb_data\f086_pat_id*, `
  $pb_data\f073_client_doc_mstr*, $pb_data\f098_equiv_oma_code_mstr*, $pb_data\f022_deleted_doc_mstr*, `
  $pb_data\u010_out_file*, $pb_data\adj_claim_file*, $pb_data\f002_claims_extra*, $pb_data\f020_doctor_extra*, `
  $pb_data\f099_group_claim_mstr* > $pb_data\backup_daily.ls

echo " "
echo " "
Get-Date
echo "Finding rma logon directory files ..."
Get-ChildItem -recurse alpha\home\rma* | Select -ExpandProperty FullName > $pb_data\rmadir.ls
echo " "
echo " "
Get-Date
echo "Finding production diskette upload files ..."
Get-ChildItem -recurse $pb_prod\web | Select -ExpandProperty FullName > $pb_data\webdir.ls
Get-ChildItem -recurse $pb_prod\web1 | Select -ExpandProperty FullName > $pb_data\web1dir.ls
Get-ChildItem -recurse $pb_prod\diskette | Select -ExpandProperty FullName > $pb_data\diskettedir.ls
Get-ChildItem -recurse $pb_prod\diskette1 | Select -ExpandProperty FullName > $pb_data\diskette1dir.ls
Get-ChildItem -recurse $pb_prod\stone | Select -ExpandProperty FullName > $pb_data\stonedir.ls

echo " "
echo " "
Get-Date
echo "Starting copy of file to tape ..."
# CONVERSION ERROR (expected, #98): tape device is involved.
# cat $pb_data/backup_daily.ls            \    $pb_data/rmadir.ls                  \    $pb_data/webdir.ls                  \    $pb_data/web1dir.ls                 \    $pb_data/diskettedir.ls             \    $pb_data/diskette1dir.ls            \    $pb_data/stonedir.ls                \    | cpio -ocuvB > /dev/rmt/1
### brad     | cpio -ocuvB |dd of=/dev/rmt/1
echo " "
Get-Date
echo "DONE!"


#  ***** IF NEW BACKUP ADDED UPDATE BACKUPDAILY_2 ALSO

echo ""
Get-Date
echo ""

# CONVERSION ERROR (expected, #118): tape device is involved.
# mt -f /dev/rmt/1 rewind
