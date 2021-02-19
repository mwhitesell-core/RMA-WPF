#-------------------------------------------------------------------------------
# File 'teb_yearend1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'teb_yearend1'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# MODIFICATION HISTORY
# 94/FEB/06  B.E.   ADDED BACKUP HISTORY OF R124A.SF
# 94/MAY/19  B.E.   ADDED BACKUP HISTORY OF U110.SF
# 94/JUL/12  B.E.   ADDED TAPE BACKUP FOR OFF LINE BACKUP
# 95/JUL/14  M.C.   ADD THE HOLDBACK PGM
# 95/JUL/26  Y.B.   ADD THE HOLDBK1 AND HOLDBK2 PGM
# 95/AUG/23  M.C.   CONVERT U115 INTO U115A AND U115B
# 95/SEP/28  M.C.   ADD THE REVHBK1 PGM
# 95/SEP     Y.B.   CHANGE EXE R124B_RMA TO R124B_RMA_YEAREND
#                   (THIS IS RUN FOR YEAREND ONLY)
# 95/OCT/10  Y.B.   ADD THE MOHR PROGRAM
# 95/NOV/21  Y.B.   TAKE OUT REVHBK.QTS, HOLDBK1.QZS AND HOLDBK1.QZS
# 96/FEB/19  M.C.   ADD U115C AND U127 PGMS
# 96/FEB/19  Y.B.   ADD CFUND1 AND CFUND2 PGMS
# 96/APR/22  Y.B.   ADD REVCLA.QZS AND REVCLA.QTC FOR APRIL ONLY
# 96/APR/24  Y.B.   TAKE OUT REVCLA.QZS AND REVCLA.QTC



echo "--- backup earnings system ---"
echo "BACKUP COMMENTED OUT !!!"
#$cmd/backup_earnings_daily $1

# BROADCAST OPERATOR MESSAGE - BACKUP OF EARNINGS SYSTEM COMPLETED.. REMOVED TAPE!

Set-Location $env:application_production
Remove-Item debug*sf*, holdback.txt *> $null
Remove-Item u119_payeft.ps* *> $null

echo "--- u105 and u110 ---"
&$env:QTP fix_seq_nbrs
&$env:QTP u105
&$env:QTP u110

echo "--- u111a and r111b ---"
&$env:QUIZ u111a
&$env:QUIZ r111b

Remove-Item r111b_${1}.txt *> $null
Move-Item -Force r111b.txt r111b_${1}.txt

echo "--- u113  u111c  u112 and u114 ---"
&$env:QTP u113
&$env:QTP u111c
&$env:QTP u112
&$env:QTP u114
