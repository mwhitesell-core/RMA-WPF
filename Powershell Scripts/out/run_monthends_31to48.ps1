#-------------------------------------------------------------------------------
# File 'run_monthends_31to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthends_31to48'
#-------------------------------------------------------------------------------

## $cmd/run_monthends_31to48

echo "Start Time of $env:cmd\run_monthends_31to48 is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

echo ""
echo "RUN MONTHEND REPORTS AND ACCOUNTS RECEIVABLE"
echo ""
echo "FOR clinics 23-26,30,31,32,33,34,35,36,41,42,43,44,45,48"
echo ""
Get-Date
Remove-Item monthends.ls
echo ""
Set-Location $env:application_production\23
&$env:cmd\run_monthend_ar_23 *> monthend23.ls
Set-Location $env:application_production\24
&$env:cmd\run_monthend_ar_24 *> monthend24.ls
Set-Location $env:application_production\25
&$env:cmd\run_monthend_ar_25 *> monthend25.ls
Set-Location $env:application_production\26
&$env:cmd\run_monthend_ar_26 *> monthend26.ls
Set-Location $env:application_production\30
&$env:cmd\run_monthend_ar_30 *> monthend30.ls
Set-Location $env:application_production\31
&$env:cmd\run_monthend_ar_31 *> monthend31.ls
Set-Location $env:application_production\32
&$env:cmd\run_monthend_ar_32 *> monthend32.ls
Set-Location $env:application_production\33
&$env:cmd\run_monthend_ar_33 *> monthend33.ls
Set-Location $env:application_production\34
&$env:cmd\run_monthend_ar_34 *> monthend34.ls
Set-Location $env:application_production\35
&$env:cmd\run_monthend_ar_35 *> monthend35.ls
Set-Location $env:application_production\36
&$env:cmd\run_monthend_ar_36 *> monthend36.ls
Set-Location $env:application_production\41
&$env:cmd\run_monthend_ar_41 *> monthend41.ls
Set-Location $env:application_production\42
&$env:cmd\run_monthend_ar_42 *> monthend42.ls
Set-Location $env:application_production\43
&$env:cmd\run_monthend_ar_43 *> monthend43.ls
Set-Location $env:application_production\44
&$env:cmd\run_monthend_ar_44 *> monthend44.ls
Set-Location $env:application_production\45
&$env:cmd\run_monthend_ar_45 *> monthend45.ls
Set-Location $env:application_production\46
&$env:cmd\run_monthend_ar_46 *> monthend46.ls
#cd $application_production/48
#$cmd/run_monthend_ar_48 1>monthend48.ls 2>&1
Set-Location $env:application_production\98
&$env:cmd\run_monthend_ar_98 *> monthend98.ls
Set-Location $env:application_production
echo ""
echo "NOW RUNNING portal reports r004 and r051"
&$env:cmd\r004_ph_portal_22to48
&$env:cmd\r051_portal_22to48

&$env:cmd\r134_r135_r136 *> r134_r135_r136.log

echo ""
echo "End   Time of $env:cmd\run_monthends_31to48 is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
