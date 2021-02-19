
#-------------------------------------------------------------------------------
# File 'backup_earnings_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'backup_earnings_monthend'
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
# 04/jul/08 yas  - added backup f074 and f075 and f114
# 08/June   yas  - added backup f074_afp_group_sequence*
# 13/Aug/28 MC   - exclude f050*history  files  
# 14/May/28 MC1  - change 'eft_constant' to 'eft_constant*' so that eft_constant_debit will also include for backup
# 15/Aug/18 MC2  - include r125, r128, r153, r137, payeft, paycode1A_ceilings reports in the backup
# 15/Oct/21 MC3  - correct for r128

Set-Location $env:application_root

echo ""
echo "Preparing list of files to be backed up ..."
echo ""
Get-Date
Get-ChildItem production\u110_${1}.sf*, production\r111b_${1}.txt, production\u119_payeft.ps*, `
  production\r119_${1}.txt, production\r121_${1}.txt, production\r120_${1}.txt, production\r123a_${1}.txt, `
  production\r123b_${1}.txt, production\r123c_${1}.txt, production\r123ef, production\r124a*_${1}.sf*, `
  production\r124b*_${1}.txt, production\r124c*_${1}.txt, production\r125*_${1}.txt, production\r128*.txt, `
  production\r137*_${1}.txt, production\r153*_${1}.txt, production\r153ef, production\debug114_${1}.txt, `
  production\debug116cd1_${1}.txt, production\debug116cd2_${1}.txt, production\debug116cd34_${1}.txt, `
  production\debugu116cd*sf*, production\dumpf119_${1}.txt, production\dumpf119ytd_${1}.txt, `
  production\payeft_${1}.txt, production\paycode1A_ceilings_${1}.txt, data\eft_constant*  | Select-Object -ExpandProperty FullName > $env:pb_data\backup_earnings_mthend${1}.ls #data\eft_constant*, data\f020_doctor_mstr*, `
  #data\f020_doc_mstr_history*, data\f020_doctor_extra*, data\f050_doc_revenue_mstr, data\f050_doc_revenue_mstr.idx, `
  #data\f070_dept_mstr*, data\f074_afp_group_mstr*, data\f074_afp_group_sequence*, data\f075_afp_doc_mstr*, `
  #data\f080_bank_mstr*, data\f090_constants_mstr*, data\f095_text_lines*, data\f110_compensation*, `
  #data\f110_comp_history*, data\f112_pycdceilings*, data\f112_pycd_history*, data\f113_default_comp*, `
  #data\f113_def_comp_history*, data\f113_default_comp_upload_driver*, data\f114_special_payments*, data\f115*, `
  #data\f116*, data\f119_doctor_ytd*, data\f119_doc_ytd_history*, data\f190_comp_codes*, data\f191_earnings_period*, `
  #data\f198_user_defined_totals*, data\f199_user_defined_fields*
  $Utf8NoBomEncoding = New-Object System.Text.UTF8Encoding $False
  $ls = Get-Content $env:pb_data/backup_earnings_mthend${1}.ls #| Set-Content -Encoding UTF8 -Path $env:pb_data/backup_earnings_daily$1.ls
  [System.IO.File]::WriteAllLines("$env:pb_data/backup_earnings_mthend$1.ls",$ls, $Utf8NoBomEncoding)
  
echo ""
echo "performing backup to DISK ..."
echo ""
Get-Date

# CONVERSION ERROR (expected, #92): compressing to cpio.
# cat $pb_data/backup_earnings_mthend${1}.ls                              \    | cpio -ocuvB                                                       \    | compress > $pb_data/backup_earnings_mthend${1}.cpio.Z
&"C:\Program Files\7-Zip\7z.exe" a -aoa -spf2 $env:pb_data/backup_earnings_mthend${1}.tar @$env:pb_data/backup_earnings_mthend${1}.ls
&"C:\Program Files\7-Zip\7z.exe" rn $env:pb_data/backup_earnings_mthend${1}.tar -r RMA/alpha alpha
# To restore from disk:
# uncompress $pb_data/backup_earnings_mthendYYMM.cpio.Z 
# cd $application_root
# cpio -icuvB < data/backup_earnings_mthendYYMM.cpio 

echo ""
echo "performing additional backup to TAPE ..."
Get-Date

# CONVERSION ERROR (expected, #104): tape device is involved.
# cat $pb_data/backup_earnings_mthend${1}.ls   \    | cpio -ocuvB > /dev/rmt/0
echo ""
echo ""

echo "Rewinding tape ..."
# CONVERSION ERROR (expected, #110): tape device is involved.
# mt -f /dev/rmt/0 rewind

echo ""
echo "VERIFICATION NOW COMMENCING ... Be patient - this may take some time!"
echo ""
echo "Output is being sent to a file that will be paged out at end of verify ..."
echo ""
echo ""
# CONVERSION ERROR (expected, #118): tape device is involved.
# cpio -itcvB < /dev/rmt/0 > $pb_data/backup_earnings_mthend${1}.log
&"C:\Program Files\7-Zip\7z.exe" l $env:pb_data/backup_earnings_mthend${1}.tar > $env:pb_data\backup_earnings_mthend${1}.log
(Get-Content $env:pb_data\backup_earnings_mthend${1}.log | Select-Object -Skip 17) | Set-Content $env:pb_data/backup_earnings_mthend${1}.log
$test = Get-Content $env:pb_data/backup_earnings_mthend${1}.log
$test = $test[0..($test.count-3)]
$test | ForEach { $_.Remove(0,53) } | Set-Content $env:pb_data/backup_earnings_mthend${1}.log

$out = $null
$rcmd = $env:QTP + "backup_earnings_daily ${1} backup_earnings_monthend" 
Invoke-Expression $rcmd | Tee-Object -Variable out
$out | Add-Content  -Path "$env:pb_data/backup_earnings_mthend${1}.ls","$env:pb_data/backup_earnings_mthend${1}.log"

echo ""
echo ""
echo "Comparing lines in .ls vs .log"
Get-ChildItem $env:pb_data\backup_earnings_mthend${1}.ls, $env:pb_data/backup_earnings_mthend${1}.log

echo ""
Get-Content $env:pb_data\backup_earnings_mthend${1}.ls | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content $env:pb_data\backup_earnings_mthend${1}.log | Measure-Object -Line | Select -ExpandProperty Lines

echo "Rewinding tape ..."
# CONVERSION ERROR (expected, #129): tape device is involved.
# mt -f /dev/rmt/0 rewind

# Go back to the original directory before script was launched.
Pop-Location