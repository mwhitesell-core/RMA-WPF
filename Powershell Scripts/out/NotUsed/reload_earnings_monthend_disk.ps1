
#-------------------------------------------------------------------------------
# File 'reload_earnings_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_earnings_monthend'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# reload_earnings_monthend 
# parameters: $1 contains the EP being run

# 2000/jul/11 B.E. - original

Push-Location
echo ""
echo "Uncompress backup files on disk ..."
echo "Reload from backup files on SQL Server ..."
Get-Date
echo "Reloading files ..."
Set-Location \\$env:root
&"C:\Program Files\7-Zip\7z.exe" x -y $env:pb_data/backup_earnings_mthend_disk$1.tar
$rcmd = $env:QTP + "reload_earnings_daily $1 backup_earnings_monthend_disk"
Invoke-Expression $rcmd
Get-Date




echo "DONE !"
Pop-Location