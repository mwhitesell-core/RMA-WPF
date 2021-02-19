#-------------------------------------------------------------------------------
# File 'cleanup_rat_files_60.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'cleanup_rat_files_60'
#-------------------------------------------------------------------------------

echo ""
echo ""
echo ""
echo "*** HIT NEW LINE ***  ONLY ***"
echo ""
echo "AFTER APPLICATION OF RAT FOR CLINIC 60 TO 65 IS FINISHED RUNNING"
echo ""
echo "BALANCED AND ALL THE EXTRA COPIES ARE PRINTED"
 $garbage = Read-Host
echo ""
Set-Location $env:application_production\60


Remove-Item u030*dat* *> $null
Remove-Item u030*sf* *> $null
Remove-Item ru030* *> $null
Remove-Item r030* *> $null
Remove-Item r997*.sf* *> $null
Remove-Item u997*.sf* *> $null

Set-Location $env:application_production\61

Remove-Item u030*dat* *> $null
Remove-Item u030*sf* *> $null
Remove-Item ru030* *> $null
Remove-Item r030* *> $null
Remove-Item r997*.sf* *> $null
Remove-Item u997*.sf* *> $null

Set-Location $env:application_production\62

Remove-Item u030*dat* *> $null
Remove-Item u030*sf* *> $null
Remove-Item ru030* *> $null
Remove-Item r030* *> $null
Remove-Item r997*.sf* *> $null
Remove-Item u997*.sf* *> $null

Set-Location $env:application_production\63

Remove-Item u030*dat* *> $null
Remove-Item u030*sf* *> $null
Remove-Item ru030* *> $null
Remove-Item r030* *> $null
Remove-Item r997*.sf* *> $null
Remove-Item u997*.sf* *> $null

Set-Location $env:application_production\64

Remove-Item u030*dat* *> $null
Remove-Item u030*sf* *> $null
Remove-Item ru030* *> $null
Remove-Item r030* *> $null
Remove-Item r997*.sf* *> $null
Remove-Item u997*.sf* *> $null

Set-Location $env:application_production\65

Remove-Item u030*dat* *> $null
Remove-Item u030*sf* *> $null
Remove-Item ru030* *> $null
Remove-Item r030* *> $null
Remove-Item r997*.sf* *> $null
Remove-Item u997*.sf* *> $null

Set-Location $env:application_production\66

Remove-Item u030*dat* *> $null
Remove-Item u030*sf* *> $null
Remove-Item ru030* *> $null
Remove-Item r030* *> $null
Remove-Item r997*.sf* *> $null
Remove-Item u997*.sf* *> $null

Set-Location $env:application_production
