#-------------------------------------------------------------------------------
# File 'purge_f011.bkp2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'purge_f011.bkp2'
#-------------------------------------------------------------------------------

#  PURGE f011 file
#  2013/Jan/07  MC1  - change to save original file from /charly/purge to /foxtrot/purge
#

#cd $pb_prod
Set-Location $Env:root\charly\purge

Remove-Item $pb_prod\purgef011.log *> $null

echo "Purge f011 -  STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > $pb_prod\purgef011.log

&$env:QTP purge_unlof011 >> $pb_prod\purgef011.log 2> $pb_prod\purgef011.log

Set-Location $pb_data


Move-Item -Force f011_pat_mstr_elig_history.idx $Env:root\foxtrot\purge\f011_pat_mstr_elig_history.idx
Move-Item -Force f011_pat_mstr_elig_history $Env:root\foxtrot\purge\f011_pat_mstr_elig_history


echo "--- create files ---"
$pipedInput = @"
create file f011-pat-mstr-elig-history
"@

$pipedInput | qutil++

Set-Location $Env:root\charly\purge

&$env:QTP purge_relof011 >> $pb_prod\purgef011.log 2> $pb_prod\purgef011.log


echo "Purge f011 - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> purgef011.log
