#-------------------------------------------------------------------------------
# File 'purge_f113_mp.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'purge_f113_mp'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

#  PURGE f113_history file
#
#  2009/07/07   Change dates to 200101 to 200113 and EP 2001 to 2001
#  2010/07/06   Change dates to 200201 to 200213 and EP 2002 to 2002
#  2011/06/07   Change dates to 200301 to 200313 and EP 2003 to 2003
#  2014/Jun/11  yas change purge date to 2006 
#  2015/Jul/04  yas change purge date to 2007  

Set-Location \\$Env:root\charly\purge\mp

Remove-Item $env:pb_prod\purgef113_mp.log *> $null

$out = $null
$rcmd = $env:QTP + "backup_earnings_daily 1 f113_default_comp_history"
Invoke-Expression $rcmd | Tee-Object -Variable out
$out | Add-Content $env:pb_data/backup_earnings_daily$1.ls

echo "Purge f113-history -  STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > $env:pb_prod\purgef113_mp.log

$rcmd = $env:QTP + "purge_unlof113_history $1 $1"
Invoke-Expression $rcmd *>>$env:pb_prod\purgef113_mp.log


#Set-Location $env:pb_data

# Move-Item -Force f113_def_comp_history.dat \\$Env:root\charly\purge\mp\f113_def_comp_history.dat
# Move-Item -Force f113_def_comp_history.idx \\$Env:root\charly\purge\mp\f113_def_comp_history.idx

#echo "--- create files ---"
<#$pipedInput = @"
create file f113-default-comp-history
"@

$pipedInput | qutil++#>
#$rcmd = $env:TRUNCATE+ "f113_default_comp_history"
#Invoke-Expression $rcmd

#Set-Location \\$Env:root\charly\purge\mp

#$rcmd = $env:QTP + "purge_relof113_history"
#Invoke-Expression $rcmd *>>$env:pb_prod\purgef113_mp.log


echo "Purge f113-history - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >>$env:pb_prod\purgef113_mp.log
