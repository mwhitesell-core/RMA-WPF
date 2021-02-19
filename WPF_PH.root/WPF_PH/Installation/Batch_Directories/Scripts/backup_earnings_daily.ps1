#-------------------------------------------------------------------------------
# File 'backup_earnings_daily.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'backup_earnings_daily'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# Save the current working directory
Push-Location -Path .

if ("$1" -eq "")
{
  echo "`a"
  echo "`a"
  echo "`a"
  echo "ERROR - you must supply EP for backup (yyyymm) !"
} else {



if (Test-Path $env:pb_data/backup_earnings_daily$1.ls)
{
  echo "`a"
  echo "`a"
  echo "`a"
  echo "ERROR - backup file:"
  echo " "
  echo "        ../data/backup_earnings_daily${1}.ls"
  echo " "
  echo "already exists !" 
  echo " "
  echo "Delete it if you really want to continue with this backup!" 
}

else
{
  Get-ChildItem $env:pb_data/eft_constant* | Select-Object -ExpandProperty FullName > $env:pb_data/backup_earnings_daily$1.ls
  $Utf8NoBomEncoding = New-Object System.Text.UTF8Encoding $False
  $ls = Get-Content $env:pb_data/backup_earnings_daily${1}.ls #| Set-Content -Encoding UTF8 -Path $env:pb_data/backup_earnings_daily$1.ls
  [System.IO.File]::WriteAllLines("$env:pb_data/backup_earnings_daily$1.ls",$ls, $Utf8NoBomEncoding)
  
  &"C:\Program Files\7-Zip\7z.exe" a -aoa $env:pb_data/backup_earnings_daily$1.tar @$env:pb_data/backup_earnings_daily$1.ls

  echo "begining backup to SQL Server ..."
  Get-Date
  $out = $null
  $rcmd = $env:QTP + "backup_earnings_daily ${1} backup_earnings_daily"
  Invoke-Expression $rcmd | Tee-Object -Variable out
  $out | Add-Content $env:pb_data/backup_earnings_daily$1.ls

  echo "Back up Complete ..."

}
}

# Go back to the original directory before script was launched.
Pop-Location

