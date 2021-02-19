#-------------------------------------------------------------------------------
# File 'backup_daily_to_disk_before_brad_2008_11.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_daily_to_disk_before_brad_2008_11'
#-------------------------------------------------------------------------------

# 98/Jul/01     B.E.    - original
# 98/Aug/01     Y.B.    - various additions
# 98/Sep/14     B.E.    - documentation addition only
# 07/nov/15     M.C.    - since backup_daily.com has modified to Yasemin's satisfaction,
#                         clone the same into here except backup to disk instead of tape

echo "backup_daily_to_disk"
echo ""

echo ""

echo "HIT   `"NEWLINE`"   TO COMMENCE BACKUP ..."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""

echo ""
Get-Date
echo ""


echo "Finding $pb_data files .."
Set-Location $env:application_root
Get-Location
echo "Find f010..."
Get-ChildItem $Env:root\charly\rmabill\rmabill101c\data\f010_pat_mstr > data\backup_daily_f010.ls
Get-ChildItem $Env:root\charly\rmabill\rmabill101c\data\f010_pat_mstr.idx >> data\backup_daily_f010.ls

echo "Find f002 .."
Get-ChildItem data\f002_claims_mstr, data\f002_claims_mstr.idx > data\backup_daily_f002.ls

echo "Select remainder of files ..."

Get-ChildItem data\f001_batch_control_file, data\f001_batch_control_file.idx, data\f002_claim_shadow, `
  data\f002_claim_shadow.idx, data\f002_claims_extra, data\f002_claims_extra.idx, data\f011_pat_mstr_elig_history, `
  data\f011_pat_mstr_elig_history.idx, data\f020_doctor_extra*, data\f020_doctor_mstr, data\f020_doctor_mstr.idx, `
  data\f021_avail_doctor_mstr*, data\f022*, data\f023_alternative_doc_nbr*, data\f027_contacts_mstr, `
  data\f027_contacts_mstr.idx, data\f028_audit_file*, data\f028_contacts_info_mstr, data\f028_contacts_info_mstr.idx, `
  data\f029*, data\f030_locations_mstr, data\f030_locations_mstr.idx, data\f040_oma_fee_mstr, `
  data\f040_oma_fee_mstr.idx, data\f050_doc_revenue_mstr, data\f050_doc_revenue_mstr.idx, `
  data\f050_doc_revenue_mstr_history, data\f050_doc_revenue_mstr_history.idx, data\f050tp_doc_revenue_mstr, `
  data\f050tp_doc_revenue_mstr.idx, data\f050tp_doc_revenue_mstr_history, data\f050tp_doc_revenue_mstr_history.idx, `
  data\f051_doc_cash_mstr, data\f051_doc_cash_mstr.idx, data\f051tp_doc_cash_mstr, data\f051tp_doc_cash_mstr.idx, `
  data\f060_cheque_reg_mstr, data\f060_cheque_reg_mstr.idx, data\f070_dept_mstr, data\f070_dept_mstr.idx, `
  data\f071_client_rma_claim_nbr, data\f071_client_rma_claim_nbr.idx, data\f072_client_mstr, `
  data\f072_client_mstr.idx, data\f073_client_doc_mstr, data\f073_client_doc_mstr.idx, data\f074*, data\f075*, `
  data\f080_bank_mstr, data\f080_bank_mstr.idx, data\f083_user_mstr*, data\f084_claims_inventory*, `
  data\f085_rejected_claims, data\f085_rejected_claims.idx, data\f086*, data\f087_submitted_rejected*, `
  data\f088_rat_rejected_claims*, data\f090_constants_mstr, data\f090_constants_mstr.idx, data\f091_diag_codes_mstr, `
  data\f091_diag_codes_mstr.idx, data\f092*, data\f093*, data\f094_msg_sub_mstr, data\f094_msg_sub_mstr.idx, `
  data\f095*, data\f096_ohip_pay_code, data\f096_ohip_pay_code.idx, data\f097*, data\f098_equiv_oma_code_mstr*, `
  data\f099_group_claim_mstr*, data\f112_pycdceilings*, data\f113_default_comp*, data\f114_special_payments.*, `
  data\f123_company_mstr, data\f123_company_mstr.idx, data\f190_comp_codes*, data\f191_earnings_period*, data\f923*, `
  data\f924_non_fee_for_service_locations*, data\adj_claim_file*, data\contract*, data\copy*, data\create*, `
  data\doc_totals*, data\resubmit.required, data\social*, production\ext*, production\f086*, production\moh_obec*, `
  production\r010*, production\u010* > data\backup_daily.ls

echo ""
echo ""
Get-Date

echo "Starting copy of file to disk ..."
Set-Location $env:application_root
Get-Location

#echo "all but f002/f010"
#cat data/backup_daily.ls                       \
#   | cpio -ocuvB >    /dyad/backup_transfer_area/backup_daily_to_disk.cpio

echo "f010"
# CONVERSION ERROR (expected, #149): piping to cpio.
# cat data/backup_daily_f010.ls                   \   | cpio -ocuvB >    /dyad/backup_transfer_area/backup_daily_to_disk_f010.cpio

#echo "f002"
#cat data/backup_daily_f002.ls                  \
#   | cpio -ocuvB >    /dyad/backup_transfer_area/backup_daily_to_disk_f002.cpio


echo " "
Get-Date
echo "DONE!"


echo ""
Get-Date
echo ""
