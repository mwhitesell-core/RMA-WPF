#-------------------------------------------------------------------------------
# File 'backup_daily.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_daily.com'
#-------------------------------------------------------------------------------

echo "backup_daily"
echo ""
## 2003/09/15   M.C.    - include f119, f190, f191, f924 in this backup
# 2004/jun/16 b.e. added MP and ICU data to backup 
# 04/jul/08 yas  - added backup f074 and f075 and f114 f113
# 07/nov/13 MC   - added backup f112 and f923, put files in sequence order
#                  and specify the full pathname for files that are shared
#                  by Cobol and PH
#                - add f110, f112, f113 & f191 for MP data, requested by Mary/Yas 
# 07/nov/14 MC   - add f011 in the backup
# 09/aug/10 MC   - add subdirectories disk1 to disk10  under 101c/production in the backup
# 09/oct/27 MC   - specific full pathname for f050/f050tp*history files because it has moved to /charly
# 11/apr/05 MC   - include Maria's stuff (r087* r085e* u085*) in production as suggested by Brad
# 11/Dec/08 MC   - comment out backup of mumc, stone, diskette & diskette1 since no longer needed
# 12/Apr/05 MC   - include subdirectories  n85  &   n85a under 101c/production in the backup 
# 13/Jul/30 MC   - replace n85 with oscar because Yasemin has renamed the directories     
# 14/Sep/09 MC1  - include second* and u020c_ohip_run_date* subfile for ohip run
echo ""
echo "BACKUP NOW COMMENCING ... parameter passed was: - $1 -"
echo ""

echo ""
Get-Date
echo ""

echo "Finding $pb_data files .."
Set-Location $env:application_root
Get-Location

echo "Selected linked f010* ..."
Get-ChildItem $Env:root\charly\rmabill\rmabill101c\data\f010_pat_mstr > data\backup_daily.ls
Get-ChildItem $Env:root\charly\rmabill\rmabill101c\data\f010_pat_mstr.idx >> data\backup_daily.ls

echo "Select remainder of files ..."

Get-ChildItem data\f001_batch_control_file, data\f001_batch_control_file.idx, data\f002_claim_shadow, `
  data\f002_claim_shadow.idx, data\f002_claims_extra, data\f002_claims_extra.idx, data\f002_claims_mstr, `
  data\f002_claims_mstr.idx, data\f011_pat_mstr_elig_history, data\f011_pat_mstr_elig_history.idx, `
  data\f020_doctor_extra*, data\f020_doctor_mstr, data\f020_doctor_mstr.idx, data\f021_avail_doctor_mstr*, data\f022*, `
  data\f023_alternative_doc_nbr*, data\f027_contacts_mstr, data\f027_contacts_mstr.idx, data\f028_audit_file*, `
  data\f028_contacts_info_mstr, data\f028_contacts_info_mstr.idx, data\f029*, data\f030_locations_mstr, `
  data\f030_locations_mstr.idx, data\f040_oma_fee_mstr, data\f040_oma_fee_mstr.idx, data\f050_doc_revenue_mstr, `
  data\f050_doc_revenue_mstr.idx, $Env:root\charly\rmabill\rmabill101c\data\f050_doc_revenue_mstr_history.dat, `
  $Env:root\charly\rmabill\rmabill101c\data\f050_doc_revenue_mstr_history.idx, data\f050tp_doc_revenue_mstr, `
  data\f050tp_doc_revenue_mstr.idx, $Env:root\charly\rmabill\rmabill101c\data\f050tp_doc_revenue_mstr_history.dat, `
  $Env:root\charly\rmabill\rmabill101c\data\f050tp_doc_revenue_mstr_history.idx, data\f051_doc_cash_mstr, `
  data\f051_doc_cash_mstr.idx, data\f051tp_doc_cash_mstr, data\f051tp_doc_cash_mstr.idx, data\f060_cheque_reg_mstr, `
  data\f060_cheque_reg_mstr.idx, data\f070_dept_mstr, data\f070_dept_mstr.idx, data\f071_client_rma_claim_nbr, `
  data\f071_client_rma_claim_nbr.idx, data\f072_client_mstr, data\f072_client_mstr.idx, data\f073_client_doc_mstr, `
  data\f073_client_doc_mstr.idx, data\f074*, data\f075*, data\f080_bank_mstr, data\f080_bank_mstr.idx, `
  data\f083_user_mstr*, data\f084_claims_inventory*, data\f085_rejected_claims, data\f085_rejected_claims.idx, `
  data\f086*, data\f087_submitted_rejected*, data\f088_rat_rejected_claims*, data\f090_constants_mstr, `
  data\f090_constants_mstr.idx, data\f091_diag_codes_mstr, data\f091_diag_codes_mstr.idx, data\f092*, data\f093*, `
  data\f094_msg_sub_mstr, data\f094_msg_sub_mstr.idx, data\f095*, data\f096_ohip_pay_code, `
  data\f096_ohip_pay_code.idx, data\f097*, data\f098_equiv_oma_code_mstr*, data\f099_group_claim_mstr*, `
  data\f112_pycdceilings*, data\f113_default_comp*, data\f114_special_payments.*, data\f123_company_mstr, `
  data\f123_company_mstr.idx, data\f190_comp_codes*, data\f191_earnings_period*, data\f923*, `
  data\f924_non_fee_for_service_locations*, data\adj_claim_file*, data\contract*, data\copy*, data\create*, `
  data\doc_totals*, data\resubmit.required, data\social*, production\ext*, production\f086*, production\moh_obec*, `
  production\r010*, production\r085*, production\r087*, production\u085*, production\second*, `
  production\u020c_ohip_run_date*, production\u010* >> data\backup_daily.ls

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

echo "Finding production diskette upload files ..."
Set-Location $env:application_root
Get-Location
Get-ChildItem -recurse production\disk1 | Select -ExpandProperty FullName > data\disk1dir.ls
Get-ChildItem -recurse production\disk2 | Select -ExpandProperty FullName > data\disk2dir.ls
Get-ChildItem -recurse production\disk3 | Select -ExpandProperty FullName > data\disk3dir.ls
Get-ChildItem -recurse production\disk4 | Select -ExpandProperty FullName > data\disk4dir.ls
Get-ChildItem -recurse production\disk5 | Select -ExpandProperty FullName > data\disk5dir.ls
Get-ChildItem -recurse production\disk6 | Select -ExpandProperty FullName > data\disk6dir.ls
Get-ChildItem -recurse production\disk7 | Select -ExpandProperty FullName > data\disk7dir.ls
Get-ChildItem -recurse production\disk8 | Select -ExpandProperty FullName > data\disk8dir.ls
Get-ChildItem -recurse production\disk9 | Select -ExpandProperty FullName > data\disk9dir.ls
Get-ChildItem -recurse production\disk10 | Select -ExpandProperty FullName > data\disk10dir.ls
#find production/diskette         -print > data/diskettedir.ls
#find production/diskette1        -print > data/diskette1dir.ls
#find production/f002_suspend*     -print > data/suspend.ls
Get-ChildItem -recurse production\kathy | Select -ExpandProperty FullName > data\kathydir.ls
#find production/mumc             -print > data/mumcdir.ls
#find production/stone            -print > data/stonedir.ls
Get-ChildItem -recurse production\web | Select -ExpandProperty FullName > data\webdir.ls
Get-ChildItem -recurse production\web1 | Select -ExpandProperty FullName > data\web1dir.ls
Get-ChildItem -recurse production\web2 | Select -ExpandProperty FullName > data\web2dir.ls
Get-ChildItem -recurse production\web3 | Select -ExpandProperty FullName > data\web3dir.ls
Get-ChildItem -recurse production\web4 | Select -ExpandProperty FullName > data\web4dir.ls
Get-ChildItem -recurse production\web5 | Select -ExpandProperty FullName > data\web5dir.ls
Get-ChildItem -recurse production\web6 | Select -ExpandProperty FullName > data\web6dir.ls
Get-ChildItem -recurse production\web7 | Select -ExpandProperty FullName > data\web7dir.ls
Get-ChildItem -recurse production\web8 | Select -ExpandProperty FullName > data\web8dir.ls
Get-ChildItem -recurse production\web9 | Select -ExpandProperty FullName > data\web9dir.ls
Get-ChildItem -recurse production\web10 | Select -ExpandProperty FullName > data\web10dir.ls
Get-ChildItem -recurse production\yasemin\yearend* | Select -ExpandProperty FullName > data\yasemin.ls

Get-ChildItem -recurse production\oscar* | Select -ExpandProperty FullName > data\oscar.ls

echo ""
Get-Date

echo "Finding MP PAYROLL data files .."
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillmp\data\f110_compensation* | Select -ExpandProperty FullName `
  > data\mp_data.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillmp\data\f112_pycdceilings* | Select -ExpandProperty FullName `
  >> data\mp_data.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillmp\data\f113_default_comp* | Select -ExpandProperty FullName `
  >> data\mp_data.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillmp\data\f191* | Select -ExpandProperty FullName >> data\mp_data.ls


# CONVERSION ERROR (expected, #195): tape device is involved.
# mt -f /dev/rmt/0 rewind

echo "Starting copy of file to tape ..."
Set-Location $env:application_root
Get-Location

Get-Content data\backup_daily.ls, data\disk1dir.ls, data\disk2dir.ls, data\disk3dir.ls, data\disk4dir.ls, `
  data\disk5dir.ls, data\disk6dir.ls, data\disk7dir.ls, data\disk8dir.ls, data\disk9dir.ls, data\disk10dir.ls, `
  data\kathydir.ls, data\mp_data.ls, data\rmadir.ls, data\webdir.ls, data\web1dir.ls, data\web2dir.ls, `
  data\web3dir.ls, data\web4dir.ls, data\web5dir.ls, data\web6dir.ls, data\web7dir.ls, data\web8dir.ls, `
  data\web9dir.ls, data\web10dir.ls, data\yasemin.ls, data\oscar.ls | Set-Content data\backup_daily_complete.ls
echo ""
Get-Date

# CONVERSION ERROR (expected, #232): tape device is involved.
# cat       data/backup_daily_complete.ls \    | cpio -ocuvB > /dev/rmt/0 

echo ""
Get-Date
echo ""
echo "Rewinding tape ..."

# CONVERSION ERROR (expected, #240): tape device is involved.
# mt -f /dev/rmt/0 rewind

if ("$1" -eq "")
{
    &$env:cmd\verify_daily
}


echo " "
Get-Date
echo "DONE!"


#  ***** IF NEW BACKUP ADDED UPDATE backup_daily_to_disk  ALSO
#  *****                            reload_daily
#  *****                            reload_daily_from_disk
