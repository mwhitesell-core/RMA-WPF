#-------------------------------------------------------------------------------
# File 'backupdaily_2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backupdaily_2'
#-------------------------------------------------------------------------------

echo "BACKUPDAILY2"
echo ""

echo "BACKUP OF:"
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
echo "----------!  f002   - suspend hdr - from prod dir"
echo "----------!  f002   - suspend dtl - from prod dir"
echo "----------!  f002   - suspend address - from prod dir"
echo "----------!  f085   - rejected claims"
echo "----------!  f086   - patient-id.dat  - from prod dir"
echo "----------!  f086   - rma#'s patient-id.dat add 95$Env:root\02\02"
echo "----------!  f071   - client rma claim nbr"
echo "----------!  f072   - client master"
echo "----------!  f073   - client doctor master"
echo "----------!  f098   - equiv oma code master"
echo "----------!  f022   - deleted doc"
echo "----------!  u010   - u010-out-file"
echo "----------!  adj    - adj-claim-file"
echo "----------!  f020   - f020-doctor-extra"
echo "----------!  f099   - group_claim_mstr      echo"
echo ""

echo "HIT   `"NEWLINE`"   TO COMMENCE BACKUP ..."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""

echo ""
Get-Date
echo ""

# CONVERSION ERROR (expected, #46): tape device is involved.
# cat backupdaily_2.ls | cpio -ocuvB |dd of=/dev/rmt/1

Set-Location $Env:root\alpha\home
Get-ChildItem -recurse .\rma* | Select -ExpandProperty FullName > $pb_data\rmadir.ls
# CONVERSION ERROR (expected, #50): tape device is involved.
# cat $pb_data/rmadir.ls |cpio -ocuvB |dd of=/dev/rmt/1

echo ""
Get-Date
echo ""

# CONVERSION ERROR (expected, #56): tape device is involved.
# mt -f /dev/rmt/1 rewind


echo "Finding $pb_data files .."
Set-Location $env:application_root
Get-Location
Get-ChildItem data\f010_pat_mstr*, data\f001_batch_control_file*, data\f020_doctor_mstr*, data\f050_doc_revenue_mstr*, `
  data\f051_doc_cash_mstr*, data\f050tp_doc_revenue_mstr*, data\f051tp_doc_cash_mstr*, data\f002_claim_shadow*, `
  data\f090_constants_mstr*, data\f021_avail_doctor_mstr*, data\f096_ohip_pay_code*, data\f023_alternative_doc_nbr*, `
  data\f085_rejected_claims*, data\f071_client_rma_claim_nbr*, data\f072_client_mstr*, data\f073_client_doc_mstr*, `
  data\f098_equiv_oma_code_mstr*, data\f022_deleted_doc_mstr*, data\u010_out_file*, data\adj_claim_file*, `
  data\f020_doctor_extra*, data\f099_group_claim_mstr* > data\backupdaily_2.ls
echo ""
echo ""
Get-Date
echo "Finding $env:application_production files .."
Set-Location $env:application_root
Get-Location
# CONVERSION ERROR (unexpected, #90): \  not identifiers or numbers.
# /bin/ls production/f002_suspend_hdr*  \        production/f002_suspend_dtl*  \ 
# CONVERSION ERROR (unexpected, #92): Unknown command.
#         production/f002_suspend_address* \ 
# CONVERSION ERROR (unexpected, #93): Unknown command.
#         production/f086_pat_id*  > data/production.ls
echo ""
echo ""
Get-Date

echo "Finding rma logon directory files ..."
Set-Location $Env:root\
Get-Location
Get-ChildItem -recurse $Env:root\alpha\home\rma* | Select -ExpandProperty FullName > $pb_data\rmadir.ls
echo ""
echo ""
Get-Date



echo "Starting copy of file to tape ..."
Set-Location $env:application_root
Get-Location
# CONVERSION ERROR (unexpected, #111): Unsupported parameters: [other:\]
# cat data/backupdaily_2.ls               \    data/production.ls                  \ 
# CONVERSION ERROR (expected, #113): tape device is involved.
#     data/rmadir.ls                      \    | cpio -ocuvB > /dev/rmt/1 
### brad     | cpio -ocuvB |dd of=/dev/rmt/1
echo " "
Get-Date
echo "DONE!"


# CONVERSION ERROR (expected, #121): tape device is involved.
# mt -f /dev/rmt/1 rewind
