#-------------------------------------------------------------------------------
# File 'activate_6pm_backup.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'activate_6pm_backup'
#-------------------------------------------------------------------------------


Set-Location \\$Env:root\alpha\rmabill\rmabill101c\data
Remove-Item delay_6pm_backup.flg

echo "Activate 6pm backup -- $(Get-Date -uformat '%Y-%m-%d %H:%M:%S') " >> delay_6pm_backup.log

echo "delete flag file to activate  6pm backup ...."
Get-Date

Set-Location \\$Env:root\alpha\rmabill\rmabill101c\production
