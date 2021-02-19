#-------------------------------------------------------------------------------
# File 'backup_daily_bkbrad.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_daily_bkbrad.com'
#-------------------------------------------------------------------------------

echo "BACKUP_DAILY"
echo ""
## 2003/09/15   M.C.    - include f119, f190, f191, f924 in this backup
# 2004/jun/16 b.e. added MP and ICU data to backup 
# 04/jul/08 yas  - added backup f074 and f075 and f114 f113
echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""

echo ""
Get-Date
echo ""

echo "Finding $pb_data files .."
Set-Location $env:application_root
Get-Location
Get-ChildItem data\f002_claims_mstr*, data\f010_pat_mstr*, data\f001_batch_control_file*, data\f020_doctor_mstr*, `
  data\f050_doc_revenue_mstr*, data\f051_doc_cash_mstr*, data\f050tp_doc_revenue_mstr*, data\f051tp_doc_cash_mstr*, `
  data\f002_claim_shadow*, data\f090_constants_mstr*, data\f021_avail_doctor_mstr*, data\f096_ohip_pay_code*, `
  data\f023_alternative_doc_nbr*, data\f085_rejected_claims*, data\f071_client_rma_claim_nbr*, data\f072_client_mstr*, `
  data\f073_client_doc_mstr*, data\f074*, data\f075*, data\f114*, data\f113*, data\f087_man_rejected_claims*, `
  data\f087_submitted_rejected*, data\f083_user_mstr*, data\f084_claims_inventory*, data\f088_rat_rejected_claims*, `
  data\f098_equiv_oma_code_mstr*, data\f022*, data\adj_claim_file*, data\f002_claims_extra*, data\f020_doctor_extra*, `
  data\resubmit.required, data\f099_group_claim_mstr*, data\f123*, data\f119_doctor_ytd*, data\f190_comp_codes*, `
  data\f191_earnings_period*, data\f924_non_fee_for_service_locations*, data\icu_app_file*, production\u010*, `
  production\ext*, production\*u993*, production\icuapp*, production\r010*, production\moh_obec*, production\f086* `
  > data\backup_daily.ls
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
Get-ChildItem -recurse production\diskette | Select -ExpandProperty FullName > data\diskettedir.ls
Get-ChildItem -recurse production\diskette1 | Select -ExpandProperty FullName > data\diskette1dir.ls
Get-ChildItem -recurse production\stone | Select -ExpandProperty FullName > data\stonedir.ls
Get-ChildItem -recurse production\mumc | Select -ExpandProperty FullName > data\mumcdir.ls
Get-ChildItem -recurse production\kathy | Select -ExpandProperty FullName > data\kathydir.ls
Get-ChildItem -recurse production\f002_suspend* | Select -ExpandProperty FullName > data\suspend.ls
Get-ChildItem -recurse production\f086* | Select -ExpandProperty FullName > data\prof086.ls
Get-ChildItem -recurse data\f086* | Select -ExpandProperty FullName > data\f086.ls
echo ""
Get-Date

#echo "Finding MP data files ..."
#find /alpha/rmabill/rmabillmp/data/*   -print > data/mp_data.ls

#echo "Finding ICU data files ..."
#find /alpha/rmabill/rmabillicu/data/*  -print > data/icu_data.ls


echo "Starting copy of file to tape ..."
Set-Location $env:application_root
Get-Location
Get-Content data\backup_daily.ls, data\rmadir.ls, data\webdir.ls, data\web1dir.ls, data\web2dir.ls, data\web3dir.ls, `
  data\web4dir.ls, data\web5dir.ls, data\web6dir.ls, data\web7dir.ls, data\web8dir.ls, data\web9dir.ls, `
  data\web10dir.ls, data\diskettedir.ls, data\diskette1dir.ls, data\stonedir.ls, data\mumcdir.ls, data\suspend.ls, `
  data\f086.ls                         #    data\mp_data.ls                    \
#    data/icu_data.ls                   \
# CONVERSION ERROR (expected, #131): tape device is involved.
#     | cpio -ocuvB > /dev/rmt/1 
### brad     | cpio -ocuvB |dd of=/dev/rmt/1
echo " "
Get-Date
echo "DONE!"


#  ***** IF NEW BACKUP ADDED UPDATE backup_daily_to_disk  ALSO
#  *****                            reload_daily
#  *****                            reload_daily_from_disk

echo ""
Get-Date
echo ""

# CONVERSION ERROR (expected, #146): tape device is involved.
# mt -f /dev/rmt/1 rewind
