#-------------------------------------------------------------------------------
# File 'doc_rev_monthly_roll_22to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'doc_rev_monthly_roll_22to48'
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
&$env:cmd\doc_rev_monthly_roll_22
&$env:cmd\doc_rev_monthly_roll_23
&$env:cmd\doc_rev_monthly_roll_24
&$env:cmd\doc_rev_monthly_roll_25
&$env:cmd\doc_rev_monthly_roll_26
&$env:cmd\doc_rev_monthly_roll_30
&$env:cmd\doc_rev_monthly_roll_31
&$env:cmd\doc_rev_monthly_roll_32
&$env:cmd\doc_rev_monthly_roll_33
&$env:cmd\doc_rev_monthly_roll_34
&$env:cmd\doc_rev_monthly_roll_35
&$env:cmd\doc_rev_monthly_roll_36
&$env:cmd\doc_rev_monthly_roll_41
&$env:cmd\doc_rev_monthly_roll_42
&$env:cmd\doc_rev_monthly_roll_43
&$env:cmd\doc_rev_monthly_roll_44
&$env:cmd\doc_rev_monthly_roll_45
&$env:cmd\doc_rev_monthly_roll_46
#$cmd/doc_rev_monthly_roll_48
&$env:cmd\doc_rev_monthly_roll_98
#$cmd/doc_rev_monthly_roll_85
echo "done"
echo ""
Get-Date
