#-------------------------------------------------------------------------------
# File 'delay_6pm_backup.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'delay_6pm_backup'
#-------------------------------------------------------------------------------


#Set-Location \\$Env:root\alpha\rmabill\rmabill101c\data
#CORE - TESTING
Set-Location \\$Env:root\alpha\rmabill\rmabill$env:RMABILL_VERS\data
New-Item -ItemType "file" delay_6pm_backup.flg

echo "delaying 6pm backup -- $(Get-Date -uformat '%Y-%m-%d %H:%M:%S') " >> delay_6pm_backup.log

echo "Create flag file to delay 6pm backup ...."
Get-Date

#Set-Location \\$Env:root\alpha\rmabill\rmabill101c\production
#CORE - TESTING
Set-Location \\$Env:root\alpha\rmabill\rmabill$env:RMABILL_VERS\production
