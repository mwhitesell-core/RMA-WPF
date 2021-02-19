#-------------------------------------------------------------------------------
# File 'yearend_payroll_backups.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yearend_payroll_backups'
#-------------------------------------------------------------------------------

# 95/07/06 Y.B. ORIGINAL
# 95/07/17 Y.B. ADD F199
# 95/10/31 Y.B. CHANGED ORDER OF @MTD0:# SEE .BK FOR ORIGINAL ORDER
# 10/07/06 Y.B. added f115 f116 f113 defaul*                       
# 14/07/08 MC1  include the backup of f050tp* as well as Yasemin requested


Set-Location $env:pb_data
<#Get-ChildItem f110_compensation*, f112_pycdceilings*, f113_default_comp*, f113_default_comp_upload_driver*, f114*, `
  f115*, f116*, f119_doctor_ytd*, f190_comp_codes*, f191_earnings_period*, f198_user_defined_totals*, `
  f199_user_defined_fields*, f095_text_lines*, f020_doctor_mstr*, f090_constants_mstr*, f050_doc_revenue_mstr*, `
  f050tp_doc_revenue_mstr*, f074_afp_group_mstr*, f074_afp_group_sequence*, f075_afp_doc_mstr*, f110_comp_history*, `
  f112_pycd_history*, f113_def_comp_history*, f119_doc_ytd_history*, f020_doc_mstr_history*, f020_doctor_extra* `
  > backup_earnings_yearend.ls 2> $null#>

  $out = $null
  $rcmd = $env:QTP + "backup_earnings_daily 201706 yearend_payroll_backups"
  Invoke-Expression $rcmd | Tee-Object -Variable out
  $out | Set-Content $env:pb_data/yearend_payroll_backups.ls

# CONVERSION ERROR (expected, #37): tape device is involved.
# cat $pb_data/backup_earnings_yearend.ls | cpio -ocuvB > /dev/rmt/0
echo ""
Get-Date
echo "Rewinding tape .."
# CONVERSION ERROR (expected, #41): tape device is involved.
# mt -f /dev/rmt/0 rewind

echo ""
echo ""
echo "Starting VERIFY of the Tape ..."
echo ""

# CONVERSION ERROR (expected, #48): tape device is involved.
# cpio -itcvB < /dev/rmt/0 >  $pb_data/backup_earnings_yearend.log
# CONVERSION ERROR (expected, #49): tape device is involved.
# mt -f /dev/rmt/0 rewind
<#echo ""
Get-Date
echo ""
echo ""
echo "Comparing lines in .ls vs .log"
Get-ChildItem $pb_data\backup_earnings_yearend.ls, $pb_data\backup_earnings_yearend.log
echo ""
Get-Content $pb_data\backup_earnings_yearend.ls | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content $pb_data\backup_earnings_yearend.log | Measure-Object -Line | Select -ExpandProperty Lines

echo "The above total record counts SHOULD MATCH!!!"
echo ""

Get-Date#>
echo "DONE!"
