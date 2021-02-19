#-------------------------------------------------------------------------------
# File 'reload_nightly_NOTUSED.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_nightly_NOTUSED'
#-------------------------------------------------------------------------------

echo "reload_nightly"

echo "Reload from TAPE backup created bybackup_nightly"
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
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        echo ""
        Get-Date
        echo "Building a consolidated list of files to be restored ..."
        Copy-Item $null data\reload_nightly.ls
        Get-Content data\backup_nightly.ls, data\rmadir.ls, data\webdir.ls, data\web1dir.ls, data\web2dir.ls, `
          data\web3dir.ls, data\web4dir.ls, data\web5dir.ls, data\web6dir.ls, data\web7dir.ls, data\web8dir.ls, `
          data\web9dir.ls, data\web10dir.ls, data\diskettedir.ls, data\diskette1dir.ls, data\stonedir.ls, `
          data\mumc.ls, data\suspend.ls, data\f086.ls | Set-Content data\reload_nightly.ls
        echo ""
        Get-Date
        echo "restoring ALL files UNCONDITIONALLY DELETING what is on disk now ..."
        echo ""
# CONVERSION ERROR (expected, #46): tape device is involved.
#         cpio -icuvB -E data/reload_nightly.ls < /dev/rmt/1
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
    echo "reload f002 - claims? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f002_claims_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F010 - PATIENT ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f010_pat_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F001 - BATCH CONTROL ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f001_batch_control_file.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F020 - DOCTOR ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f020_doctor_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F050 - DOCTOR REVENUE ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f050_doc_revenue_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F050 - DOCTOR REVENUE history? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f050history.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F051 - DOCTOR CASH ? (y\n)"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f051_doc_cash_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F050TP - TP DOCTOR REVENUE ? (y\n)"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f050tp_doc_revenue_mstr.ls | Add-Content data\reload.tmp
  }
#   -----------------------------------------------------------
    echo "reload F050tp - DOCTOR REVENUE history? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f050tphistory.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F051TP - TP DOCTOR CASH ? (y\n)"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f051tp_doc_cash_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F002 - CLAIM SHADOW? (y\n)"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f002_claim_shadow.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F090 - CONSTANTS ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f090_constants_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F021 - AVAILABLE DOCTOR ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f021_avail_doctor_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F096 - OHIP PAY CODE ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f096_ohip_pay_code.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F023 - ALTERNATIVE DOC NUMBERS ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f023_alternative_doc_nbr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F002 - SUSPEND HDR ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f002_suspend_hdr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F002 - SUSPEND DTL ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f002_suspend_dtl.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F002 - SUSPEND ADDRESS ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f002_suspend_address.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload f083 - USER MASTER     ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f083_user_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload f084 - CLAIMS INVENTORY? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f084_claims_inventory.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F085 - REJECTED CLAIMS ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f085_rejected_claims.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F086 - PATIENT ID ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f086_pat_id.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload f087 - man rejected claims ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f087.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F088 dtl - rat rejects  ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f088dtl.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F088 hdr - rat rejects  ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f088hdr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F071 - CLIENT\RMA CLAIMS NBR ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f071_client_rma_claim_nbr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F072 - CLIENT MSTR ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f072_client_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F073 - CLIENT DOC MSTR ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f073_client_doc_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F098 - EQUIP OMA CODE ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f098_equiv_oma_code_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F022 - DELETED DOC MSTR ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f022_deleted_doc_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - U010 OUT FILE ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\u010_out_file.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload - ADJ CLAIM FILE ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\adj_claim_file.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F002 - CLAIMS EXTRA ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f002_claims_extra.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload F020 - DOCTOR EXTRA (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f020_doctor_extra.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload resubmit.required (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\resubmit.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload f099 - group claim (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f099_group_claim_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "web                      (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\webdir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "web1                      (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web1dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "web2                      (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web2dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "web3                     (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web3dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "web4                      (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web4dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "web5                      (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web5dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "web6                      (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web6dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "web7                      (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web7dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "web8                      (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web8dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "web9                      (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web9dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "web10                     (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web10dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "diskette                  (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\diskettedir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "diskette1                 (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\diskette1dir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "stone                     (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\stonedir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "mumc                      (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\mumcdir.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "suspend.ls                (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\suspend.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "f086.ls                   (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f086.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------

    echo ""
    echo ""
    echo ""
    echo "Now restoring all FILES YOU SELECTED ..."
    Get-Location
    Get-Date
# CONVERSION ERROR (expected, #445): tape device is involved.
#     cpio -icuvB -E data/reload.tmp < /dev/rmt/1
    echo ""
    Get-Date
    echo "restore DONE!"
    echo ""
    }  # reload all files on tape
}
echo ""
echo "rewinding tape ..."
# CONVERSION ERROR (expected, #454): tape device is involved.
# mt -f /dev/rmt/1 rewind
echo ""
echo "FINISHED !"
echo ""
