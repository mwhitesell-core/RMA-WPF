#-------------------------------------------------------------------------------
# File 'backup_earnings_daily_tape_only.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_earnings_daily_tape_only'
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
# 2013/Aug/26 MC - exclude f050*history                   

echo "TAPE ONLY version of this macro - does not create disk.Z backup"


Set-Location $env:application_root

echo "Preparing list of files to be backed up ..."
Get-Date

Set-Location $pb_data

Get-ChildItem eft_constant, f020_doctor_mstr*, f020_doc_mstr_history*, f020_doctor_extra*, f074_afp_group_mstr*, `
  f074_afp_group_sequence*, f075_afp_doc_mstr*, f090_constants_mstr*, f050_doc_revenue_mstr, `
  f050_doc_revenue_mstr.idx, f095_text_lines*, f110_compensation*, f110_comp_history*, f112_pycdceilings*, `
  f112_pycd_history*, f113_default_comp*, f113_def_comp_history*, f113_default_comp_upload_driver*, `
  f114_special_payments*, f115*, f116*, f119_doctor_ytd*, f119_doc_ytd_history*, f198_user_defined_totals*, `
  f199_user_defined_fields*, f190_comp_codes*, f191_earnings_period* > backup_earnings_daily${1}.ls
#               2>/dev/null             

# CONVERSION ERROR (expected, #63): tape device is involved.
# cat $pb_data/backup_earnings_daily${1}.ls          \    | cpio -ocuvB > /dev/rmt/0

echo "Rewinding tape ..."

# CONVERSION ERROR (expected, #68): tape device is involved.
# mt -f /dev/rmt/0 rewind
