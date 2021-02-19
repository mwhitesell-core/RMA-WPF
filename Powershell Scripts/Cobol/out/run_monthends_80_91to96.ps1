#-------------------------------------------------------------------------------
# File 'run_monthends_80_91to96.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'run_monthends_80_91to96'
#-------------------------------------------------------------------------------

## $cmd/run_monthends_80_91to96

echo "Start Time of $cmd\run_monthends_80_91to96 is$(udate)"

echo ""
echo "RUN MONTHEND REPORTS AND ACCOUNTS RECEIVABLE"
echo ""
echo "FOR clinics 37, 78-80, 84, 87-89, 91-96"
echo ""
Get-Date
echo ""
$cmd\run_monthend_ar_37
$cmd\run_monthend_ar_68
$cmd\run_monthend_ar_69
$cmd\run_monthend_ar_78
$cmd\run_monthend_ar_79
$cmd\run_monthend_ar_80
$cmd\run_monthend_ar_84
$cmd\run_monthend_ar_87
$cmd\run_monthend_ar_88
$cmd\run_monthend_ar_89
$cmd\run_monthend_ar_91
$cmd\run_monthend_ar_92
$cmd\run_monthend_ar_93
$cmd\run_monthend_ar_94
$cmd\run_monthend_ar_95
$cmd\run_monthend_ar_96
echo ""
echo "NOW RUNNING portal reports r004 and r051"
$cmd\r004_ph_portal_80_84_91to96
$cmd\r051_portal_80_84_87_91to96

Get-Date
echo ""

echo "End   Time of $cmd\run_monthends_80_91to96 is$(udate)"
