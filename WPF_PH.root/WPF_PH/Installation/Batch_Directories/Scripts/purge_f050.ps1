#-------------------------------------------------------------------------------
# File 'purge_f050.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'purge_f050'
#-------------------------------------------------------------------------------

param(
  [string] $1,
  [string] $2
)

#  PURGE f050_history file
#
#  2009/07/07   Change dates to 200101 to 200113 and EP 2001 to 2001
#  2010/07/06   Change dates to 200201 to 200213 and EP 2002 to 2002
#  2011/06/07   Change dates to 200301 to 200313 and EP 2003 to 2003
#  2009/oct/27  MC  history files have moved to /charly
#  2013/Jan/10  MC1  - change to save original file from /charly/purge to /foxtrot/purge
#  2013/July/07 yas  - change to save original file from /foxtrot/purge to /charly/purge
#  2014/Jun/11  yas change purge date to 2006 
#  2014/Jul/08  MC2 comment out the section below
#  2015/Jul/04  yas change purge date to 2007 

#cd $env:pb_prod
Set-Location \\$Env:root\charly\purge\101c

Remove-Item $env:pb_prod\purgef050.log *> $null

echo "Purge f050-history -  STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > $env:pb_prod\purgef050.log

$rcmd = $env:QTP + "purge_unlof050_history $1 $2 $1 $2"
Invoke-Expression $rcmd *>>$env:pb_prod\purgef050.log


Set-Location \\$Env:root\charly\rmabill\rmabill101c\data

# Move-Item -Force f050_doc_revenue_mstr_history.dat \\$Env:root\charly\purge\101c\f050_doc_revenue_mstr_history.dat
# Move-Item -Force f050_doc_revenue_mstr_history.idx \\$Env:root\charly\purge\101c\f050_doc_revenue_mstr_history.idx
# Move-Item -Force f050tp_doc_revenue_mstr_history.dat \\$Env:root\charly\purge\101c\f050tp_doc_revenue_mstr_history.dat
# Move-Item -Force f050tp_doc_revenue_mstr_history.idx \\$Env:root\charly\purge\101c\f050tp_doc_revenue_mstr_history.idx

# MC2 
# cd $env:pb_data

echo "--- create files ---"
<#$pipedInput = @"
create file f050-doc-revenue-mstr-history
create file f050tp-doc-revenue-mstr-history
"@

$pipedInput | qutil++#>
$rcmd = $env:TRUNCATE+ "f050_doc_revenue_mstr_history"
Invoke-Expression $rcmd
$rcmd = $env:TRUNCATE+ "f050tp_doc_revenue_mstr_history"
Invoke-Expression $rcmd


# MC2 - comment out - not needed
# 2009/10/28 - move the new empty files to /charly and create the link
##mv   f050*doc_revenue_mstr_history*  /charly/rmabill/rmabill101c/data
##ln -s /charly/rmabill/rmabill101c/data/f050_doc_revenue_mstr_history.dat    f050_doc_revenue_mstr_history.dat
##ln -s /charly/rmabill/rmabill101c/data/f050_doc_revenue_mstr_history.idx    f050_doc_revenue_mstr_history.idx
##ln -s /charly/rmabill/rmabill101c/data/f050tp_doc_revenue_mstr_history.dat  f050tp_doc_revenue_mstr_history.dat
##ln -s /charly/rmabill/rmabill101c/data/f050tp_doc_revenue_mstr_history.idx  f050tp_doc_revenue_mstr_history.idx

Set-Location \\$Env:root\charly\purge\101c

$rcmd = $env:QTP + "purge_relof050_history"
Invoke-Expression $rcmd *>>$env:pb_prod\purgef050.log


echo "Purge f050-history - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >>$env:pb_prod\purgef050.log
