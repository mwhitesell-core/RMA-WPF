#-------------------------------------------------------------------------------
# File 'run_third_monthend_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_third_monthend_reports'
#-------------------------------------------------------------------------------

## $cmd/run_third_monthend_reports

echo "Start Time of $env:cmd\run_third_monthend_reports is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

echo ""
echo "RUN THIRD MONTHEND REPORTS AND ACCOUNTS RECEIVABLE"
echo ""
echo "FOR clinics 22-26, 30-36, 41-46, 98"
echo ""

Set-Location $env:application_production
&$env:cmd\run_monthend_reports  22 *> monthend.ls
Set-Location $env:application_production\23
&$env:cmd\run_monthend_reports  23 *> monthend23.ls
Set-Location $env:application_production\24
&$env:cmd\run_monthend_reports  24 *> monthend24.ls
Set-Location $env:application_production\25
&$env:cmd\run_monthend_reports  25 *> monthend25.ls
Set-Location $env:application_production\26
&$env:cmd\run_monthend_reports  26 *> monthend26.ls
Set-Location $env:application_production\30
&$env:cmd\run_monthend_reports  30 *> monthend30.ls
Set-Location $env:application_production\31
&$env:cmd\run_monthend_reports  31 *> monthend31.ls
Set-Location $env:application_production\32
&$env:cmd\run_monthend_reports  32 *> monthend32.ls
Set-Location $env:application_production\33
&$env:cmd\run_monthend_reports  33 *> monthend33.ls
Set-Location $env:application_production\34
&$env:cmd\run_monthend_reports  34 *> monthend34.ls
Set-Location $env:application_production\35
&$env:cmd\run_monthend_reports  35 *> monthend35.ls
Set-Location $env:application_production\36
&$env:cmd\run_monthend_reports  36 *> monthend36.ls
Set-Location $env:application_production\41
&$env:cmd\run_monthend_reports  41 *> monthend41.ls
Set-Location $env:application_production\42
&$env:cmd\run_monthend_reports  42 *> monthend42.ls
Set-Location $env:application_production\43
&$env:cmd\run_monthend_reports  43 *> monthend43.ls
Set-Location $env:application_production\44
&$env:cmd\run_monthend_reports  44 *> monthend44.ls
Set-Location $env:application_production\45
&$env:cmd\run_monthend_reports  45 *> monthend45.ls
Set-Location $env:application_production\46
&$env:cmd\run_monthend_reports  46 *> monthend46.ls
Set-Location $env:application_production\98
&$env:cmd\run_monthend_reports  98 *> monthend98.ls

Set-Location $env:application_production
echo " --- r011mohr (QUIZ) --- "
&$env:QUIZ r011mohr 22@ >> monthend.ls

echo ""
echo "NOW RUNNING portal reports r004 and r051"
echo ""

&$env:cmd\r004_ph_portal_22to48

&$env:cmd\r051_portal_22to48

&$env:cmd\r134_r135_r136 *> r134_r135_r136.log

echo ""
echo "End   Time of $env:cmd\run_third_monthend_reports is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
