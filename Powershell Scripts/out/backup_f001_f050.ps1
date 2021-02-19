#-------------------------------------------------------------------------------
# File 'backup_f001_f050.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_f001_f050'
#-------------------------------------------------------------------------------

# 09/oct/27 MC   - specific full pathname for f050/f050tp*history files because it has moved to /charly
# 15/Apr/20 MC1  - correct to backup files once
Push-Location
echo "backup_f001_f050"


echo "BACKUP OF:"
echo "----------!  F001   - BATCH CONTROL FILE"
echo "----------!  F050   - DOC REVENUE MSTR"
echo "----------!  F051   - DOC CASH    MSTR"
echo "----------!  F050TP - DOC REVENUE MSTR"
echo "----------!  F051TP - DOC CASH    MSTR"
echo ""

echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""
echo ""
Get-Date
echo ""

Set-Location $env:pb_data
Get-Location

<#Get-ChildItem f001_batch_control_file*, f050*_doc_revenue_mstr.*, `
  $Env:root\charly\rmabill\rmabill101c\data\f050_doc_revenue_mstr_history*, f051_doc_cash_mstr*, `
  f050*_doc_revenue_mstr, $Env:root\charly\rmabill\rmabill101c\data\f050tp_doc_revenue_mstr_history*, `
  f051tp_doc_cash_mstr* > backup_f001_f050.ls#>
  $out = $null
  $rcmd = $env:QTP + "backup_earnings_daily 2 backup_f001_f050"
  Invoke-Expression $rcmd | Tee-Object -Variable out
  $out | Add-Content $env:pb_data/backup_f001_f050.ls

#cat $pb_data/bk_f001_f050.ls           \
#               | cpio -ocuvB           \
#                | dd of=/dev/rmt/0
#cat $pb_data/bk_f001_f050.ls           \

# CONVERSION ERROR (expected, #38): tape device is involved.
# cat $pb_data/backup_f001_f050.ls        \                | cpio -ocuvB           \                > /dev/rmt/0 
echo ""
Get-Date
echo ""
echo "Rewinding the tape ..."
# CONVERSION ERROR (expected, #45): tape device is involved.
# mt -f /dev/rmt/0 rewind

Get-Date
echo ""
echo "VERIFICATION NOW COMMENCING ... Be patient - this may take some time!"
echo ""
echo "Output is being sent to a file that will be paged out at end of verify ..."
echo ""
echo ""

# CONVERSION ERROR (expected, #55): tape device is involved.
# cpio -itcvB < /dev/rmt/0 > backup_f001_f050.log 
# CONVERSION ERROR (expected, #56): tape device is involved.
# mt -f /dev/rmt/0 rewind

#CORE - Removed, SQL backup does not function in the same way
<#Get-Date
echo ""
echo ""
echo "Comparing lines in .ls vs .log"
Get-ChildItem backup_f001_f050.ls, backup_f001_f050.log
echo ""
Get-Content backup_f001_f050.ls | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content backup_f001_f050.log | Measure-Object -Line | Select -ExpandProperty Lines#>

#echo
#echo Press Enter to page out verification log
#read garbage
#pg $pb_data/backup_f001_f050.log

echo ""
Get-Date
echo "DONE!"
Pop-Location