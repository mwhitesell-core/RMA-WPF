#-------------------------------------------------------------------------------
# File 'reload_101.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_101'
#-------------------------------------------------------------------------------

# 98/Jul/01     B.E.    - original
# 98/Aug/01     Y.B.    - various additions
# 98/Sep/14     B.E.    - added suspend.ls to consolidated list of files
#                         that could be reloaded for "all files" restore

echo "reload_daily_from_disk"

echo "Reload from DISK backup created bybackup_101"
echo ""

Set-Location $Env:root\alpha\rmabill\rmabill101
Get-Location

echo "continue with RELOAD 101 ? (y\[n])"
&$string = Read-Host

if ("$string" -eq "Y" -or "$string" -eq "y")
{
#   -----------------------------------------------------------
    echo "reload ** ALL ** files on DISK ? (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        echo ""
        Get-Date
        echo "Building a consolidated list of files that COULD BE reloaded ..."
        Copy-Item $null data\reload.tmp
        Get-Content data\backup_daily.ls, data\webdir.ls, data\web1dir.ls, data\diskettedir.ls, data\diskette1dir.ls, `
          data\stonedir.ls, data\suspend.ls | Set-Content data\reload.tmp
        echo ""
        Get-Date
        echo "Now restoring ALL files from DISK ..."
        Get-Location
        echo ""
#       cpio -icvB -E data/reload.tmp < backups/backup_daily_to_disk.cpio
# CONVERSION ERROR (unexpected, #42): Unknown command.
#         cpio -icuvB -E data/reload.tmp < backups/backup_daily_to_disk.cpio
        echo ""
        Get-Date
        echo "reload DONE!"
        echo ""
    } else {

    echo ""
    echo "You haven't asked to reload ALL files from DISK so"
    echo "you will now be prompted for each possible file that"
    echo "could be reloaded. Enter 'y' and 'Enter' to have the"
    echo "file added to the list of files to be reloaded. Either"
    echo "'n' and 'Enter' or just 'Enter' will NOT reload the file"
    echo "being prompted for."
    echo "As you respond a recover file LIST is being created. When"
    echo "all prompts are completed, the files requested will be"
    echo "reloaded in a single pass from the LIST."
    echo ""

    Copy-Item $null data\reload.tmp

#   -----------------------------------------------------------
    echo "reload f002-claims-mstr  ? (y\[n])"
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
    echo "reload f099 - group claims  (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\f099_group_claim_mstr.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload web1 -   (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web1.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload web2 -   (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web2.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload web3 -   (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web3.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload web4 -   (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web4.ls | Add-Content data\reload.tmp
    }
#   -----------------------------------------------------------
    echo "reload web5 -   (y\[n])"
    &$string = Read-Host
    if ("$ string" -eq "Y" -or "$string" -eq "y")
    {
        Get-Content backups\web5.ls | Add-Content data\reload.tmp
    }

    echo ""
    echo ""
    echo ""
    echo "Now restoring all FILES YOU SELECTED ..."
    echo ""
    Get-Date
# CONVERSION ERROR (unexpected, #301): Unknown command.
#     cpio -icuvB -E data/reload.tmp < backups/backup_daily_to_disk.cpio
    echo ""
    Get-Date
    echo "reload of selected files DONE!"
    echo ""
    }  # reload of all files from disk
}
echo ""
echo "FINISHED !"
echo ""
