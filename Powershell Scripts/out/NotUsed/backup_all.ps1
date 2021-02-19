#-------------------------------------------------------------------------------
# File 'backup_all.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_all'
#-------------------------------------------------------------------------------

#  OCT/95 Y.B. ADD @MTD0:23 AND AFTER
echo "BACKUP_ALL"
echo ""

echo "BACKUP OF:"
echo "----------!  ALPHA_FILES"
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


Set-Location $pb_data

# CONVERSION ERROR (expected, #25): tape device is involved.
# /bin/ls f001_batch_control_file*   \        f020_doctor_mstr*          \        f050_doc_revenue_mstr*     \        f051_doc_cash_mstr*        \        f050tp_doc_revenue_mstr*   \        f051tp_doc_cash_mstr*      \        f002_claim_shadow*         \        f090_constants_mstr*       \        f030_locations_mstr*       \        f040_oma_fee_mstr*         \        f060_cheque_reg_mstr*      \        f070_dept_mstr*            \        f080_bank_mstr*            \        f091_diag_codes_mstr*      \        f092_b_y_oma_codes_mstr*   \        f094_msg_sub_mstr*         \        r120_class_totals*         \        f021_avail_doctor_mstr*    \        f096_ohip_pay_code*        \        f023_alternative_doc_nbr*  \        f002_suspend_address*      \        f002_suspend_dtl*          \        f002_suspend_hdr*          \        contract_dtl*              \        contract_mstr*             \        f071_client_rma_claim_nbr* \        f072_client_mstr*          \        f073_client_doc_mstr*      \        f098_equiv_oma_code_mstr*  \        f201_appti_recon_mstr*     \        f201_appto_recon_mstr*     \        part_adj_batch*            \        part_paid_dtl*             \        part_paid_hdr*             \        f085_rejected_claims*      \        f022_deleted_doc_mstr*     \        f086_pat_id* | \            cpio -ocuvB |dd of=/dev/rmt/1

Set-Location $Env:root\alpha\home
# CONVERSION ERROR (expected, #65): tape device is involved.
# find ./rma* -print |cpio -ocuvB |dd of=/dev/rmt/1

echo ""
Get-Date
echo ""

# CONVERSION ERROR (expected, #71): tape device is involved.
# mt -f /dev/rmt/1 rewind
