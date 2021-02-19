#-------------------------------------------------------------------------------
# File 'cleanup_rat_files_70.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'cleanup_rat_files_70'
#-------------------------------------------------------------------------------

echo ""
echo ""
echo ""
echo "*** HIT NEW LINE ***  ONLY ***"
echo ""
echo "AFTER APPLICATION OF RAT FOR CLINIC 71 to 75 IS FINISHED RUNNING"
echo ""
echo "BALANCED AND ALL THE EXTRA COPIES ARE PRINTED"
 $garbage = Read-Host
echo ""
Set-Location $env:application_production\70

Remove-Item u030*dat* *> $null
Remove-Item u030*sf* *> $null
Remove-Item ru030* *> $null
Remove-Item r030* *> $null
Remove-Item r997*.sf* *> $null
Remove-Item u997*.sf* *> $null

Set-Location $env:application_production\71

Remove-Item u030*dat* *> $null
Remove-Item u030*sf* *> $null
Remove-Item ru030* *> $null
Remove-Item r030* *> $null
Remove-Item r997*.sf* *> $null
Remove-Item u997*.sf* *> $null

Set-Location $env:application_production\72

Remove-Item u030*dat* *> $null
Remove-Item u030*sf* *> $null
Remove-Item ru030* *> $null
Remove-Item r030* *> $null
Remove-Item r997*.sf* *> $null
Remove-Item u997*.sf* *> $null

Set-Location $env:application_production\73

Remove-Item u030*dat* *> $null
Remove-Item u030*sf* *> $null
Remove-Item ru030* *> $null
Remove-Item r030* *> $null
Remove-Item r997*.sf* *> $null
Remove-Item u997*.sf* *> $null

Set-Location $env:application_production\74

Remove-Item u030*dat* *> $null
Remove-Item u030*sf* *> $null
Remove-Item ru030* *> $null
Remove-Item r030* *> $null
Remove-Item r997*.sf* *> $null
Remove-Item u997*.sf* *> $null

Set-Location $env:application_production\75

Remove-Item u030*dat* *> $null
Remove-Item u030*sf* *> $null
Remove-Item ru030* *> $null
Remove-Item r030* *> $null
Remove-Item r997*.sf* *> $null
Remove-Item u997*.sf* *> $null

Set-Location $env:application_production
