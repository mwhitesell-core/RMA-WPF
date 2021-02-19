#-------------------------------------------------------------------------------
# File 'doc_rev_monthly_roll_60_82_83_86.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'doc_rev_monthly_roll_60_82_83_86'
#-------------------------------------------------------------------------------

echo "MONTHLY ROLLOVER OF DOCTOR REVENUE MASTER"
echo ""
echo ""
echo "WARNING  DOCTOR REVENUE FILE WILL BE UPDATED BY THIS RUN --"
echo ""
echo "Make sure a backup_f001_f050 is done before pressing enter to continue"
echo ""
#echo  'HIT  "NEWLINE  TO Continue'"
$garbage = Read-Host
echo ""
echo ""
Get-Date

#$cmd/backup_f001_f050

echo ""
&$env:cmd\doc_rev_monthly_roll_82
&$env:cmd\doc_rev_monthly_roll_86
&$env:cmd\doc_rev_monthly_roll_60
&$env:cmd\doc_rev_monthly_roll_70
echo "done"
echo ""
Get-Date
