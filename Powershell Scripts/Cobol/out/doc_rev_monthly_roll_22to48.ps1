#-------------------------------------------------------------------------------
# File 'doc_rev_monthly_roll_22to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'doc_rev_monthly_roll_22to48'
#-------------------------------------------------------------------------------

echo "MONTHLY ROLLOVER OF DOCTOR REVENUE MASTER"
echo ""
echo ""
echo "WARNING  DOCTOR REVENUE FILE WILL BE UPDATED BY THIS RUN --"
echo ""
echo "Make sure a backup_f001_f050 is done before pressing enter to continue"
echo ""
#echo  'HIT   "NEWLINE"   TO Continue'
$garbage = Read-Host
echo ""
echo ""
Get-Date

#$cmd/backup_f001_f050

echo ""
$cmd\doc_rev_monthly_roll_22
$cmd\doc_rev_monthly_roll_23
$cmd\doc_rev_monthly_roll_24
$cmd\doc_rev_monthly_roll_25
$cmd\doc_rev_monthly_roll_26
$cmd\doc_rev_monthly_roll_30
$cmd\doc_rev_monthly_roll_31
$cmd\doc_rev_monthly_roll_32
$cmd\doc_rev_monthly_roll_33
$cmd\doc_rev_monthly_roll_34
$cmd\doc_rev_monthly_roll_35
$cmd\doc_rev_monthly_roll_36
$cmd\doc_rev_monthly_roll_41
$cmd\doc_rev_monthly_roll_42
$cmd\doc_rev_monthly_roll_43
$cmd\doc_rev_monthly_roll_44
$cmd\doc_rev_monthly_roll_45
$cmd\doc_rev_monthly_roll_46
#$cmd/doc_rev_monthly_roll_48
$cmd\doc_rev_monthly_roll_98
#$cmd/doc_rev_monthly_roll_85
echo "done"
echo ""
Get-Date
