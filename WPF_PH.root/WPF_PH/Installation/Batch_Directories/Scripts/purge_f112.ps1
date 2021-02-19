#-------------------------------------------------------------------------------
# File 'purge_f112.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'purge_f112'
#-------------------------------------------------------------------------------

param(
  [string] $1,
  [string] $2
)

#  PURGE f112_history file
#
#  2009/07/07   Change dates to 200101 to 200113 and EP 2001 to 2001
#  2010/07/06   Change dates to 200201 to 200213 and EP 2002 to 2002
#  2011/06/07   Change dates to 200301 to 200313 and EP 2003 to 2003
#  2013/Jan/10  MC1  - change to save original file from /charly/purge to /foxtrot/purge
#  2014/Jun/11  yas change purge date to 2006 
#  2015/Jul/04  yas change purge date to 2007       

#cd $env:pb_prod
Set-Location \\$Env:root\charly\purge\101c

Remove-Item $env:pb_prod\purgef112.log *> $null

$out = $null
$rcmd = $env:QTP + "backup_earnings_daily 1 f112_pycdceilings_history"
Invoke-Expression $rcmd | Tee-Object -Variable out
$out | Add-Content $env:pb_data/backup_earnings_daily$1.ls

echo "Purge f112-history -  STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > $env:pb_prod\purgef112.log

$rcmd = $env:QTP + "purge_unlof112_history $1 $2"
Invoke-Expression $rcmd *>>$env:pb_prod\purgef112.log


#Set-Location $env:pb_data

# Move-Item -Force f112_pycd_history.dat \\$Env:root\charly\purge\101c\f112_pycd_history.dat
# Move-Item -Force f112_pycd_history.idx \\$Env:root\charly\purge\101c\f112_pycd_history.idx

#echo "--- create files ---"
<#$pipedInput = @"
create file f112-pycdceilings-history
"@

$pipedInput | qutil++#>
#$rcmd = $env:TRUNCATE+ "f112_pycdceilings_history"
#Invoke-Expression $rcmd

#Set-Location \\$Env:root\charly\purge\101c

#$rcmd = $env:QTP + "purge_relof112_history"
#Invoke-Expression $rcmd *>>$env:pb_prod\purgef112.log


echo "Purge f112-history - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >>$env:pb_prod\purgef112.log
