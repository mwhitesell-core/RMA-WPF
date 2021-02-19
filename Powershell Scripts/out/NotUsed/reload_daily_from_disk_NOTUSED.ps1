#-------------------------------------------------------------------------------
# File 'reload_daily_from_disk_NOTUSED.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_daily_from_disk_NOTUSED'
#-------------------------------------------------------------------------------

echo "reload_daily"

echo "Reload from TAPE backup created bybackup_daily"
echo ""

echo "continue with RELOAD BACKUP_DAILY ? (y\n)"
&$string = Read-Host

Set-Location $env:application_root
Get-Location

if ("$string" -eq "Y" -or "$string" -eq "y")
{
#   -----------------------------------------------------------
    echo "reload ** ALL ** files on tape ? (y\n)"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        echo ""
        Get-Date
        echo "Building a consolidated list of files to be restored ..."
        Copy-Item $null data\reload_daily.ls
        Get-Content data\backup_daily.ls, data\diskettedir.ls, data\diskette1dir.ls, data\kathydir.ls, `
          data\mp_data.ls, data\mumcdir.ls, data\rmadir.ls, data\stonedir.ls, data\suspend.ls, data\webdir.ls, `
          data\web1dir.ls, data\web2dir.ls, data\web3dir.ls, data\web4dir.ls, data\web5dir.ls, data\web6dir.ls, `
          data\web7dir.ls, data\web8dir.ls, data\web9dir.ls, data\web10dir.ls, data\yasemin.ls `
          | Set-Content data\reload_daily.ls
        echo ""
        Get-Date
        echo "restoring ALL files UNCONDITIONALLY DELETING what is on disk now ..."
        echo ""
# CONVERSION ERROR (unexpected, #48): Unknown command.
#         cpio -icuvB -E data/reload_daily.ls < backups/backup_daily_to_disk.cpio
        echo ""
        Get-Date
        echo "restore DONE!"
        echo ""
    } else {

    echo ""
    echo "You haven't asked to restore ALL files from tape so"
    echo "you will now be prompted for each possible file that"
    echo "could be restored. Enter 'y' and 'Enter' to have the"
    echo "file added to the list of files to be restored. Either"
    echo "'n' and 'Enter' or just 'Enter' will NOT reload the file"
    echo "being prompted for."
    echo "As you respond a recover file LIST is being created. When"
    echo "all prompts are completed, the files requested will be"
    echo "reloaded in a single pass from the LIST."
    echo ""
    Copy-Item $null data\reload.tmp

#   -----------------------------------------------------------
    echo "reload F001 - BATCH CONTROL ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f001_batch_control_file.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F002 - CLAIM SHADOW? (y\n)"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f002_claim_shadow.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F002 - CLAIMS EXTRA ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f002_claims_extra.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F002 - claims? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f002_claims_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F010 - PATIENT ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f010_pat_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F011 - PATIENT ELIG HISTORY ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f011_pat_elig_history.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F020 - DOCTOR EXTRA (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f020_doctor_extra.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F020 - DOCTOR ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f020_doctor_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F021 - AVAILABLE DOCTOR ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f021_avail_doctor_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F022 - DELETED DOC MSTR ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f022_deleted_doc_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F023 - ALTERNATIVE DOC NUMBERS ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f023_alternative_doc_nbr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F027 - CONTACTS MSTR ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f027_contacts_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F028 - AUDIT FILE ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f028_audit_file.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F028 - CONTACTS INFO MSTR ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f028_contacts_info_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F029 - FOLLOWUP EVENTS ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f029_followup_events.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F030 - LOCATIONS MSTR ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f030_locations_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F040 - OMA FEE MSTR ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f040_oma_fee_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F050 - DOCTOR REVENUE ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f050_doc_revenue_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F050 - DOCTOR REVENUE HISTORY? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f050history.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F050TP - TP DOCTOR REVENUE ? (y\n)"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f050tp_doc_revenue_mstr.ls | Add-Content data\reload.tmp
  }
#   -----------------------------------------------------------
    echo "reload F050TP - TP DOCTOR REVENUE HISTORY? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f050tphistory.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F051 - DOCTOR CASH ? (y\n)"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f051_doc_cash_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F051TP - TP DOCTOR CASH ? (y\n)"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f051tp_doc_cash_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F060 - CHEQUE REGISTER  ? (y\n)"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f060_cheque_reg_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F070 - DEPT MSTR  ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f070_dept_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F071 - CLIENT\RMA CLAIMS NBR ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f071_client_rma_claim_nbr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F072 - CLIENT MSTR ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f072_client_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F073 - CLIENT DOC MSTR ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f073_client_doc_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F074 - AFP GROUP  MSTR ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f074.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F075 - AFP DOCTOR MSTR ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f075.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F080 - BANK MASTER     ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f080_bank_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F083 - USER MASTER     ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f083_user_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F084 - CLAIMS INVENTORY? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f084_claims_inventory.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F085 - REJECTED CLAIMS ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f085_rejected_claims.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F086 - PATIENT ID ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f086.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F087 - SUBMITTED REJECTED  ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f087submitted.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F088 DTL - RAT REJECTS  ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f088dtl.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F088 HDR - RAT REJECTS  ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f088hdr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F090 - CONSTANTS ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f090_constants_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F091 - DIAG CODES ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f091_diag_codes_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F092 - OHIP ERROR CAT MSTR  ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f092.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F093 - OHIP ERROR MSG MSTR  ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f093.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F094 - MSG SUB MSTR ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f094_msg_sub_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F095 - TEXT LINES ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f095_text_lines.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F096 - OHIP PAY CODE ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f096_ohip_pay_code.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F097 - SPEC CD MSTR  ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f097.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F098 - EQUIP OMA CODE ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f098_equiv_oma_code_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F099 - GROUP CLAIM ?  (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f099_group_claim_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F112 - PYCDCEILINGS  ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f112.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F113 - DEFAULT COMP ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f113.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F114 - SPECIAL PAYMENTS? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f114.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F123 - COMPANY MSTR   ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f123_compnay_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F190 - COMP CODES ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f190_comp_codes.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F191 - EARNINGS PERIOD ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f191_earnings_period.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F923 - DOC REVENUE TRANSLATION  ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f923.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F924 -  NON FEE FOR SERVICE LOCATIONS ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f924.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - ADJ CLAIM FILE ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\adj_claim_file.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - CONTRACT DTL\MSTR  ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\contract.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - DOCTOR TOTALS  ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\doc_totals.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - RESUBMIT.REQUIRED ?  (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\resubmit.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - SOCIAL CONTRACT FACTOR ?  (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\social.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - U010* R010* EXT* F086* MOH_OBEC ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\u010_r010_misc.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - DISKETTTE ?      (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\diskettedir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - DISKETTE1 ?     (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\diskette1dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - MP DATA ?        (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\mp_data.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - KATHY ?          (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\kathydir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - MUMC ?           (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\mumcdir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - RMA HOME ?       (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\rmadir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - STONE ?          (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\stonedir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - F002 SUSPEND     (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\suspend.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - WEB ?   (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\webdir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - WEB1 ?  (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web1dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - WEB2  ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web2dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - WEB3  ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web3dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - WEB4    ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web4dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - WEB5    ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web5dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - WEB6     ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web6dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - WEB7     ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web7dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - WEB8     ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web8dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - WEB9    ?  (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web9dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - WEB10   ? (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web10dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - YASEMIN YEARNEND ?  (y\[n])"
    &$string = Read-Host
    if ("$string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\yasemin.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------

    echo ""
    echo ""
    echo ""
    echo "Now restoring all FILES YOU SELECTED ..."
    Get-Location
    Get-Date
# CONVERSION ERROR (unexpected, #650): Unknown command.
#     cpio -icuvB -E data/reload.tmp < backups/backup_daily_to_disk.cpio
    echo ""
    Get-Date
    echo "restore DONE!"
    echo ""
    }  # reload all files on from disk
}
echo ""
echo "FINISHED !"
echo ""
