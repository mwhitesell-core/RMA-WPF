#-------------------------------------------------------------------------------
# File 'run_monthends_60_82_83_86.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthends_60_82_83_86.bk1'
#-------------------------------------------------------------------------------

echo ""
echo "RUN MONTHEND REPORTS AND ACCOUNTS RECEIVABLE"
echo ""
echo "FOR clinics 61 - 70, 82, 83 and 86"
echo ""
Get-Date
Remove-Item monthends.ls
echo ""
&$env:cmd\run_monthend_ar_82
&$env:cmd\monthly_stage40_and_ar_tp
&$env:cmd\run_monthend_ar_86
&$env:cmd\run_monthend_ar_70
echo ""
echo "NOW RUNNING portal reports r004 and r051"
&$env:cmd\r004_ph_portal_60_82_83_86
&$env:cmd\r051_portal_60_70_82_86

Get-Date
echo ""
