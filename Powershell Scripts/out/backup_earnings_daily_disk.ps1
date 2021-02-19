#-------------------------------------------------------------------------------
# File 'backup_earnings_daily_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'backup_earnings_daily_disk'
#-------------------------------------------------------------------------------

# EARNINGS_BACKUP.CLI
# parameters: $1 contains the EP being run

# 92/OCT/27 - ADDED BACKUP TO SPECIFIC EP FILE
# 93/MAR/27 - REMOVED MULTIPLE EP BACKUP OF F095 TEXT FILE
#           - ADDED BACKUP OF F119-DOCTOR-YTD
# 94/NOV/07 - ADDED BACKUP OF F050-DOC-REVENUE-MSTR
# 93/MAY/26 - MOVED BACKUP TO :BACKUP_EARN
# 95/SEP/25 - ADDED BACKUP OF F199-USER-DEFINED-FIELDS
# 95/NOV/22 - ADDED BACKUP OF F020 & F119 HISTORY FILES
# 96/FEB/19 - ADDED BACKUP OF F020-DOCTOR-EXTRA FILE
# 98/JAN/21 - PORTED TO UNIX
# 98/AUG/20 B.E. - changed CPIO options, now copies both to disk and tape
# 99/dec/20 B.E. - added 'eft_constant' to backup and restore
# 00/nov/13 yas  - backup to disk only backup_earnings_mp does tape
# 00/nov/24 B.E. - added warning if backup already exists
# 04/jul/08 yas  - added backup f074 and f075 and f114
# 09/June   yas  - added backup f074_afp_group_sequence*
# 14/May/28 MC1  - change 'eft_constant' to 'eft_constant*' so that eft_constant_debit will also include in the backup

param(
  [string] $1
)

# Save the current working directory
Push-Location -Path .

Set-Location $env:application_root

if ( $env:RMABILL_VERS -eq "101c"  -or $env:RMABILL_VERS -eq "101"  )
{
  $database = "101C"   
}                              # export clinic_nbr
elseif ( $env:RMABILL_VERS -eq "mp" )
{
   $database = "MP"
 }                               # export clinic_nbr
elseif ( $env:RMABILL_VERS -eq "solo" -or $env:RMABILL_VERS -eq "solotest" )
{
   $database = "SOLO"
} 



if (Test-Path $env:pb_data\backup_earnings_daily_disk$1.ls)
{
  echo "WARNING - Backup already exists for the month specified"
  echo "Press Enter to continue and wipe out existing backup  OR"
  echo "Press CTRL-C to CANCEL"
  echo " "
  $garbage = Read-Host
  echo "Existing backup will be Overridden!"
}

remove-item $env:pb_data/backup_earnings_daily_disk$1.*

Set-Location $env:pb_data
echo "Preparing list of files to be backed up ..."
Get-Date

Get-ChildItem $env:pb_data/eft_constant* | Select-Object -ExpandProperty FullName > $env:pb_data\backup_earnings_daily_disk${1}.ls

if($env:RMABILL_VERS -eq "MP") {
    Get-ChildItem $env:pb_data\f113_default_comp_BLANK_DOC.sql | Select-Object -ExpandProperty FullName >> $env:pb_data\backup_earnings_daily_disk${1}.ls
} 

  $Utf8NoBomEncoding = New-Object System.Text.UTF8Encoding $False
  $ls = Get-Content $env:pb_data/backup_earnings_daily_disk${1}.ls #| Set-Content -Encoding UTF8 -Path $env:pb_data/backup_earnings_daily$1.ls
  [System.IO.File]::WriteAllLines("$env:pb_data/backup_earnings_daily_disk$1.ls",$ls, $Utf8NoBomEncoding)
  
&"C:\Program Files\7-Zip\7z.exe" a -aoa $env:pb_data/backup_earnings_daily_disk${1}.tar @$env:pb_data/backup_earnings_daily_disk${1}.ls
#Get-ChildItem eft_constant*, f020_doctor_mstr*, f020_doc_mstr_history*, f020_doctor_extra*, f074_afp_group_sequence*, f075_afp_doc_mstr*, f090_constants_mstr*, f050_doc_revenue_mstr*, f095_text_lines*, f110_compensation*, f110_comp_history*, f112_pycdceilings*, f112_pycd_history*, f113_default_comp*, f113_def_comp_history*, f113_default_comp_upload_driver*, f114_special_payments*, f115*, f116*, f119_doctor_ytd*, f119_doc_ytd_history*, f198_user_defined_totals*, f199_user_defined_fields*, f190_comp_codes*, f191_earnings_period*  > backup_earnings_daily${1}.ls
#               2>/dev/null             
echo ""
echo "beginning backup to DISK ..."
Get-Date



$out = $null
$rcmd = $env:QTP + "backup_earnings_daily ${1} backup_earnings_daily_disk"
Invoke-Expression $rcmd | Tee-Object -Variable out
$out | Add-Content $env:pb_data/backup_earnings_daily_disk$1.ls

echo ""
Get-Date
echo ""
echo "DONE !"

# Go back to the original directory before script was launched.
Pop-Location
