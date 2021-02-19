
#-------------------------------------------------------------------------------
# File 'backup_earnings_monthend_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'backup_earnings_monthend_disk'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# Save the current working directory
Push-Location -Path .

# BACKUP_EARNINGS_MONTHEND.CLI
# PURPOSE: BACKUP OF FILES RELEVANT EARNINGS FILE SO THAT:
#          A: THE PHYSICIAN STATEMENTS MUST BE RUN AGAIN ALL FILES
#             CAN BE RELOADED AND PROGRAM R124A/B RE-RUN.
#          B: THE EFT FILE SO THAT IF BANK TAPE IS REQUIRED AGAIN
#             FILE IS AVAILABLE
# 94/JUL/12 B.E.  - ORIGINAL
# 95/JUL/17 Y.B.  - ADD @MTD0 13 & 14
# 95/SEP/25 Y.B.  - ADD @MTD0 15
# 95/NOV/22 M.C.  - ADD F020 & F119 HISTORY FILES
# 96/FEB/19 M.C.  - ADD F020-DOCTOR-EXTRA FILE
# 96/JUL/31 Y.B.  - ADD R119 & R121 REPORT
# 98/JAN/21 K.M.  - PORTED to UNIX
# 98/Aug/20 B.E.  - removed dd= from CPIO to tape, changed backup to run
#                   to disk and tape
# 99/dec/20 B.E.  - added 'eft_constant' to backup and restore
# 00/nov/13 yas   - backup to disk only backup_earnings_mp does tape
# 00/nov/24 B.E. - added warning if backup already exists
# 04/jul/08 yas  - added backup f074 and f075 and f114
# 09/July   yas  - added backup f074_afp_group_sequence*
# 13/Aug/28 MC   - exclude f050*history  files
# 14/May    yas  - added backup r153*  and r124c*  r124*paycode*
# 14/May/28 MC1  - change 'eft_constant' to 'eft_constant*' so that eft_constant_debit will also include for backup
# 15/Aug/18 MC2  - include r125, r128, r153, r137, payeft, paycode1A_ceilings reports in the backup
# 15/Oct/21 MC3  - correct for 128
Push-Location
Set-Location $env:application_root

if (Test-Path $env:pb_data\backup_earnings_mthend${1}.tar)
{
  echo "WARNING - Backup already exists for the month specified"
  echo "Press Enter to continue and wipe out existing backup  OR "
  echo "Press CTRL-C to CANCEL"
  echo " "
  $garbage = Read-Host
  echo "Existing backup will be Overridden!"
}

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

Remove-Item $env:pb_data\backup_earnings_mthend_disk${1}.tar
echo ""
echo "Preparing list of files to be backed up ..."
echo ""
Get-Date

Get-ChildItem  production\u110_${1}.sf*, production\r111b_${1}.txt, production\u119_payeft.ps*, `
  production\r119_${1}.txt, production\r121_${1}.txt, production\r120_${1}.txt, production\r123a_${1}.txt, `
  production\r123b_${1}.txt, production\r123c_${1}.txt, production\r123ef, production\r124a_*${1}.sf*, `
  production\r124b_*${1}.txt, production\r124c_*${1}.txt, production\r125*_${1}.txt, production\r128*.txt, `
  production\r137*_${1}.txt, production\r153*_${1}.txt, production\r153ef, production\debugu114_${1}.txt, `
  production\debugu116cd1_${1}.txt, production\debugu116cd34_${1}.txt, production\dumpf119_${1}.txt, `
  production\dumpf119ytd_${1}.txt, production\payeft_${1}.txt, production\paycode1A_ceilings_${1}.txt, data\eft_constant* | Select-Object -ExpandProperty FullName > $env:pb_data\backup_earnings_mthend_disk${1}.ls

if($env:RMABILL_VERS -eq "MP") {
    Get-ChildItem data\f113_default_comp_BLANK_DOC.sql | Select-Object -ExpandProperty FullName >> $env:pb_data\backup_earnings_mthend_disk${1}.ls
}  
 
  $Utf8NoBomEncoding = New-Object System.Text.UTF8Encoding $False
  $ls = Get-Content $env:pb_data/backup_earnings_mthend_disk${1}.ls #| Set-Content -Encoding UTF8 -Path $env:pb_data/backup_earnings_daily$1.ls
  [System.IO.File]::WriteAllLines("$env:pb_data/backup_earnings_mthend_disk$1.ls",$ls, $Utf8NoBomEncoding)
  

Set-Location $env:pb_prod 
&"C:\Program Files\7-Zip\7z.exe" a -aoa -spf2 $env:pb_data/backup_earnings_mthend_disk${1}.tar @$env:pb_data/backup_earnings_mthend_disk${1}.ls
&"C:\Program Files\7-Zip\7z.exe" rn $env:pb_data/backup_earnings_mthend_disk${1}.tar -r RMA/alpha alpha

$out = $null
$rcmd = $env:QTP + "backup_earnings_daily ${1} backup_earnings_monthend_disk" 
Invoke-Expression $rcmd | Tee-Object -Variable out
$out | Add-Content $env:pb_data/backup_earnings_mthend_disk${1}.ls

echo ""
echo "performing backup to DISK ..."
echo ""
Get-Date

# CONVERSION ERROR (expected, #103): compressing to cpio.
# cat $pb_data/backup_earnings_mthend${1}.ls                              \    | cpio -ocuvB                                                       \    | compress > $pb_data/backup_earnings_mthend${1}.cpio.Z
# To restore from disk:
#
# "reload_earnings_monthend yymm"
#
# uncompress $pb_data/backup_earnings_mthendYYMM.cpio.Z 
# cd $application_root
# cpio -icuvB < /data/backup_earnings_mthendYYMM.cpio 

echo ""
Get-Date
echo ""
echo "DONE !"
Set-Location $env:application_root

# Go back to the original directory before script was launched.
Pop-Location
