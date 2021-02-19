#-------------------------------------------------------------------------------
# File 'run_monthends_31to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'run_monthends_31to48'
#-------------------------------------------------------------------------------

## $cmd/run_monthends_31to48

echo "Start Time of $cmd\run_monthends_31to48 is$(udate)"

echo ""
echo "RUN MONTHEND REPORTS AND ACCOUNTS RECEIVABLE"
echo ""
echo "FOR clinics 23-26,30,31,32,33,34,35,36,41,42,43,44,45,48"
echo ""
Get-Date
Remove-Item monthends.ls
echo ""
Set-Location $application_production\23
$cmd\run_monthend_ar_23  > monthend23.ls  2>&1
Set-Location $application_production\24
$cmd\run_monthend_ar_24  > monthend24.ls  2>&1
Set-Location $application_production\25
$cmd\run_monthend_ar_25  > monthend25.ls  2>&1
Set-Location $application_production\26
$cmd\run_monthend_ar_26  > monthend26.ls  2>&1
Set-Location $application_production\30
$cmd\run_monthend_ar_30  > monthend30.ls  2>&1
Set-Location $application_production\31
$cmd\run_monthend_ar_31  > monthend31.ls  2>&1
Set-Location $application_production\32
$cmd\run_monthend_ar_32  > monthend32.ls  2>&1
Set-Location $application_production\33
$cmd\run_monthend_ar_33  > monthend33.ls  2>&1
Set-Location $application_production\34
$cmd\run_monthend_ar_34  > monthend34.ls  2>&1
Set-Location $application_production\35
$cmd\run_monthend_ar_35  > monthend35.ls  2>&1
Set-Location $application_production\36
$cmd\run_monthend_ar_36  > monthend36.ls  2>&1
Set-Location $application_production\41
$cmd\run_monthend_ar_41  > monthend41.ls  2>&1
Set-Location $application_production\42
$cmd\run_monthend_ar_42  > monthend42.ls  2>&1
Set-Location $application_production\43
$cmd\run_monthend_ar_43  > monthend43.ls  2>&1
Set-Location $application_production\44
$cmd\run_monthend_ar_44  > monthend44.ls  2>&1
Set-Location $application_production\45
$cmd\run_monthend_ar_45  > monthend45.ls  2>&1
Set-Location $application_production\46
$cmd\run_monthend_ar_46  > monthend46.ls  2>&1
#cd $application_production/48
#$cmd/run_monthend_ar_48 1>monthend48.ls 2>&1
Set-Location $application_production\98
$cmd\run_monthend_ar_98  > monthend98.ls  2>&1
Set-Location $application_production
echo ""
echo "NOW RUNNING portal reports r004 and r051"
$cmd\r004_ph_portal_22to48
$cmd\r051_portal_22to48

$cmd\r134_r135_r136  > r134_r135_r136.log  2>&1

echo ""
echo "End   Time of $cmd\run_monthends_31to48 is$(udate)"
