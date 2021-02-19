#-------------------------------------------------------------------------------
# File 'backup_earnings_daily.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'backup_earnings_daily'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

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
# 00/dec/10 B.E. - added check that backup file doesn't exist before starting
#                - ensure that $1 parm passed
# 04/mar/05 b.e. - added backup of f114
# 04/jul/08 yas  - added backup f074 and f075
# 08/oct/25 b.e. - added  f113_default_comp_upload_driver
# 09/Jun    yas. - added  f074_afp_group_sequence*       
# 13/Aug/26 MC   - exclude f050*history                   
# 14/May/28 MC1  - change 'eft_constant' to 'eft_constant*' so that eft_constant_debit will also include for backu

if ("$1" -eq "")
{
  echo "`a"
  echo "`a"
  echo "`a"
  echo "ERROR - you must supply EP for backup (yyyymm) !"
} else {

Set-Location $application_root

# ensure that backup file doesn't already exist
if (Test-Path $pb_data\backup_earnings_daily${1}.cpio.Z)
{
  echo "`a"
  echo "`a"
  echo "`a"
  echo "ERROR - backup file:"
  echo " "
  echo "        $pb_data\backup_earnings_daily${1}.cpio.Z"
  echo " "
  echo "already exists !"
  echo " "
  echo "Delete it if you really want to continue with this backup!"
} else {

echo "Preparing list of files to be backed up ..."
Get-Date

Set-Location $pb_data

Get-ChildItem eft_constant*, f020_doctor_mstr*, f020_doc_mstr_history*, f020_doctor_extra*, f074_afp_group_mstr*, f074_afp_group_sequence*, f075_afp_doc_mstr*, f090_constants_mstr*, f050_doc_revenue_mstr, f050_doc_revenue_mstr.idx, f095_text_lines*, f110_compensation*, f110_comp_history*, f112_pycdceilings*, f112_pycd_history*, f113_default_comp*, f113_def_comp_history*, f113_default_comp_upload_driver*, f114_special_payments*, f115*, f116*, f119_doctor_ytd*, f119_doc_ytd_history*, f198_user_defined_totals*, f199_user_defined_fields*, f190_comp_codes*, f191_earnings_period*  > backup_earnings_daily${1}.ls
#               2>/dev/null             

echo ""
echo "begining backup to DISK ..."
Get-Date

# CONVERSION WARNING; compress+cpio is involved.
# cat              $pb_data/backup_earnings_daily${1}.ls              | cpio -ocuvB                                                   | compress > $pb_data/backup_earnings_daily${1}.cpio.Z

# To restore from disk: 
# Note: with the 'u' in the cpio command this UNCONDITIONALLY
#       reloads the files deleting existing files on disk!
# cd $pb_data
# uncompress    backup_earnings_dailyYYMM.cpio.Z 
# cpio -icuvB < backup_earnings_dailyYYMM.cpio
echo ""
Get-Date
echo ""

# CONVERSION WARNING; tape is involved.
# cat $pb_data/backup_earnings_daily${1}.ls              | cpio -ocuvB > /dev/rmt/0

echo "Rewinding tape ..."

# CONVERSION WARNING; tape is involved.
# mt -f /dev/rmt/0 rewind

echo ""
echo "VERIFICATION NOW COMMENCING ... Be patient - this may take some time!"
echo ""
echo "Output is being sent to a file that will be paged out at end of verify ..."
echo ""
echo ""
# CONVERSION WARNING; tape is involved.
# cpio -itcvB < /dev/rmt/0 > $pb_data/backup_earnings_daily${1}.log
echo ""
echo ""
echo "Comparing lines in .ls vs .log"
Get-ChildItem $pb_data\backup_earnings_daily${1}.ls, $pb_data\backup_earnings_daily${1}.log
echo ""
Get-Content ${param.outputValue} | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content ${param.outputValue} | Measure-Object -Line | Select -ExpandProperty Lines

echo "Rewinding tape ..."
# CONVERSION WARNING; tape is involved.
# mt -f /dev/rmt/0 rewind


}
}
