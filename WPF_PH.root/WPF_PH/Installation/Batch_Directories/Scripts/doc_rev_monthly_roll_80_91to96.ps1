#-------------------------------------------------------------------------------
# File 'doc_rev_monthly_roll_80_91to96.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'doc_rev_monthly_roll_80_91to96'
#-------------------------------------------------------------------------------

echo "MONTHLY ROLLOVER OF DOCTOR REVENUE MASTER"
echo ""
echo ""
echo "WARNING  DOCTOR REVENUE FILE WILL BE UPDATED BY THIS RUN --"
echo ""
echo "Make sure a backup_f001_f050 is done before pressing enter to continue"
echo ""
#echo  'HIT  "NEWLINE" TO Continue'
$garbage = Read-Host
echo ""
echo ""
Get-Date

#$cmd/backup_f001_f050

echo ""
&$env:cmd\doc_rev_monthly_roll_37
&$env:cmd\doc_rev_monthly_roll_68
&$env:cmd\doc_rev_monthly_roll_69
&$env:cmd\doc_rev_monthly_roll_78
&$env:cmd\doc_rev_monthly_roll_79
&$env:cmd\doc_rev_monthly_roll_80
&$env:cmd\doc_rev_monthly_roll_84
&$env:cmd\doc_rev_monthly_roll_87
&$env:cmd\doc_rev_monthly_roll_88
&$env:cmd\doc_rev_monthly_roll_89
&$env:cmd\doc_rev_monthly_roll_91
&$env:cmd\doc_rev_monthly_roll_92
&$env:cmd\doc_rev_monthly_roll_93
&$env:cmd\doc_rev_monthly_roll_94
&$env:cmd\doc_rev_monthly_roll_95
&$env:cmd\doc_rev_monthly_roll_96
echo "done"
echo ""
Get-Date
