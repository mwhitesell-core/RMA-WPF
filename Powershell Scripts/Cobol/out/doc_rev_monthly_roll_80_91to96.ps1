#-------------------------------------------------------------------------------
# File 'doc_rev_monthly_roll_80_91to96.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'doc_rev_monthly_roll_80_91to96'
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
$cmd\doc_rev_monthly_roll_37
$cmd\doc_rev_monthly_roll_68
$cmd\doc_rev_monthly_roll_69
$cmd\doc_rev_monthly_roll_78
$cmd\doc_rev_monthly_roll_79
$cmd\doc_rev_monthly_roll_80
$cmd\doc_rev_monthly_roll_84
$cmd\doc_rev_monthly_roll_87
$cmd\doc_rev_monthly_roll_88
$cmd\doc_rev_monthly_roll_89
$cmd\doc_rev_monthly_roll_91
$cmd\doc_rev_monthly_roll_92
$cmd\doc_rev_monthly_roll_93
$cmd\doc_rev_monthly_roll_94
$cmd\doc_rev_monthly_roll_95
$cmd\doc_rev_monthly_roll_96
echo "done"
echo ""
Get-Date
