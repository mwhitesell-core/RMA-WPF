#-------------------------------------------------------------------------------
# File 'run_monthends_80_91to96.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthends_80_91to96'
#-------------------------------------------------------------------------------

## $cmd/run_monthends_80_91to96

echo "Start Time of $env:cmd\run_monthends_80_91to96 is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

echo ""
echo "RUN MONTHEND REPORTS AND ACCOUNTS RECEIVABLE"
echo ""
echo "FOR clinics 37, 78-80, 84, 87-89, 91-96"
echo ""
Get-Date
echo ""
&$env:cmd\run_monthend_ar_37
&$env:cmd\run_monthend_ar_68
&$env:cmd\run_monthend_ar_69
&$env:cmd\run_monthend_ar_78
&$env:cmd\run_monthend_ar_79
&$env:cmd\run_monthend_ar_80
&$env:cmd\run_monthend_ar_84
&$env:cmd\run_monthend_ar_87
&$env:cmd\run_monthend_ar_88
&$env:cmd\run_monthend_ar_89
&$env:cmd\run_monthend_ar_91
&$env:cmd\run_monthend_ar_92
&$env:cmd\run_monthend_ar_93
&$env:cmd\run_monthend_ar_94
&$env:cmd\run_monthend_ar_95
&$env:cmd\run_monthend_ar_96
echo ""
echo "NOW RUNNING portal reports r004 and r051"
&$env:cmd\r004_ph_portal_80_84_91to96
&$env:cmd\r051_portal_80_84_87_91to96

Get-Date
echo ""

echo "End   Time of $env:cmd\run_monthends_80_91to96 is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"