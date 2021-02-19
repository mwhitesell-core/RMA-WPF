#-------------------------------------------------------------------------------
# File 'run_ohip_stale_claims.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_ohip_stale_claims'
#-------------------------------------------------------------------------------

#Macro: run_ohip_stale_claims

echo "Running run_ohip_stale_claims IN PROGRESS  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')  ..."

Set-Location $env:application_production

Remove-Item u020_tapeout_file*, u020*sf* 2> $null

#######################################

Remove-Item u022_tp.sf*
Remove-Item u022a?.sf*
Remove-Item u022e?.sf*
Remove-Item ru022a
Remove-Item ru022b
Remove-Item ru022
Remove-Item ru022mr
Remove-Item u022a1*stale*.sf*

&$env:QTP u022a1_stale

&$env:QUIZ r022

&$env:QTP u022

Move-Item -Force ru022a.txt ru022a_stale
Move-Item -Force ru022b.txt ru022b_stale
Move-Item -Force ru022.txt ru022_stale
Move-Item -Force ru022mr.txt ru022mr_stale_before

Move-Item -Force u020_tp.sf u022_tp_stale.sf
Move-Item -Force u020_tp.sfd u022_tp_stale.sfd


##  regenerate ru022mr for correct report
&$env:QUIZ r022a7
&$env:QUIZ r022a8
&$env:QUIZ r022a9

Move-Item -Force ru022mr.txt ru022mr_stale

##############################################

Get-Content u022_tp_stale.sf | Set-Content u020_tapeout_file | Set-Content $null

##$cmd/ohip_convert_copy_to_tape              

echo ""
Get-Date
echo ""
