#-------------------------------------------------------------------------------
# File 'reload_earnings_daily.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'reload_earnings_daily'
#-------------------------------------------------------------------------------

# reload_earnings_daily 
# parameters: $1 contains the EP being run

# 1999/sep/16 B.E. - original
# 2000/nov/13 B.E. - changed reload to NOT use the -E option and instead
#                    reload EVERYTHING on the backup file

param(
  [string] $1
)


Push-Location
echo "Reload from backup files on SQL Server ..."
Get-Date
echo "Reloading files ..."
Set-Location $env:pb_data
&"C:\Program Files\7-Zip\7z.exe" x -y $env:pb_data/backup_earnings_daily$1.tar
$rcmd = $env:QTP + "reload_earnings_daily $1 backup_earnings_daily"
Invoke-Expression $rcmd
Get-Date




echo "DONE !"
Pop-Location