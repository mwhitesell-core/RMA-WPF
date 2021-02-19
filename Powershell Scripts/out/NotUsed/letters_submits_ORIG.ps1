#-------------------------------------------------------------------------------
# File 'letters_submits_ORIG.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'letters_submits_ORIG'
#-------------------------------------------------------------------------------

Set-Location $pb_data
Remove-Item f085_backup_10*
Move-Item -Force f085_backup_09 f085_backup_10
Move-Item -Force f085_backup_09.idx f085_backup_10.idx
Move-Item -Force f085_backup_08 f085_backup_09
Move-Item -Force f085_backup_08.idx f085_backup_09.idx
Move-Item -Force f085_backup_07 f085_backup_08
Move-Item -Force f085_backup_07.idx f085_backup_08.idx
Move-Item -Force f085_backup_06 f085_backup_07
Move-Item -Force f085_backup_06.idx f085_backup_07.idx
Move-Item -Force f085_backup_05 f085_backup_06
Move-Item -Force f085_backup_05.idx f085_backup_06.idx
Move-Item -Force f085_backup_04 f085_backup_05
Move-Item -Force f085_backup_04.idx f085_backup_05.idx
Move-Item -Force f085_backup_03 f085_backup_04
Move-Item -Force f085_backup_03.idx f085_backup_04.idx
Move-Item -Force f085_backup_02 f085_backup_03
Move-Item -Force f085_backup_02.idx f085_backup_03.idx
Move-Item -Force f085_backup_01 f085_backup_02
Move-Item -Force f085_backup_01.idx f085_backup_02.idx
Copy-Item f085_rejected_claims f085_backup_01
Copy-Item f085_rejected_claims.idx f085_backup_01.idx

&$env:cmd\f086patid

Set-Location $env:application_production

Remove-Item r085.txt *> $null
Remove-Item r086.txt *> $null
Remove-Item r087.txt *> $null

echo "--- r085, r086 and r087 (QUIZ RUN) ---"
#quiz auto=$obj/r085.qzc
&$env:QUIZ r085a
&$env:QUIZ r085b
&$env:QUIZ r086
&$env:QUIZ r087

echo "--- u085 (QTP RUN) ---"
&$env:QTP u085

Get-Content r086.txt | Out-Printer
Get-Content r087.txt | Out-Printer
Get-Content r087.txt | Out-Printer

&$env:cmd\create_hist_rejects

if (Test-Path $pb_data\resubmit.required)
{

&$env:cmd\u022 0 0

}
