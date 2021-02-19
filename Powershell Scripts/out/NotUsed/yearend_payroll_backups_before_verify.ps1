#-------------------------------------------------------------------------------
# File 'yearend_payroll_backups_before_verify.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yearend_payroll_backups_before_verify'
#-------------------------------------------------------------------------------

# 95/07/06 Y.B. ORIGINAL
# 95/07/17 Y.B. ADD F199
# 95/10/31 Y.B. CHANGED ORDER OF @MTD0:# SEE .BK FOR ORIGINAL ORDER

Set-Location $pb_data
Get-ChildItem f110_compensation*, f112_pycdceilings*, f113_default_comp*, f114*, f119_doctor_ytd*, f190_comp_codes*, `
  f191_earnings_period*, f198_user_defined_totals*, f199_user_defined_fields*, f095_text_lines*, f020_doctor_mstr*, `
  f090_constants_mstr*, f050_doc_revenue_mstr*, f110_comp_history*, f112_pycd_history*, f113_def_comp_history*, `
  f119_doc_ytd_history*, f020_doc_mstr_history*, f020_doctor_extra* > backup_earnings_yearend.ls 2> $null

# CONVERSION ERROR (expected, #28): tape device is involved.
# cat $pb_data/backup_earnings_yearend.ls |cpio -ocuvB > /dev/rmt/1

echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #34): tape device is involved.
# mt -f /dev/rmt/1 rewind
