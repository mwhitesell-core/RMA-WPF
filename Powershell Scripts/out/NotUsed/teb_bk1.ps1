#-------------------------------------------------------------------------------
# File 'teb_bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'teb_bk1'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# teb1
#
# *** IF YOU CHANGE THIS PLEASE CHANGE R124B_RMA_YEAREND.QZS ALSO ***
#
# MODIFICATION HISTORY
# 94/FEB/06  B.E.   ADDED BACKUP HISTORY OF R124A.SF
# 94/MAY/19  B.E.   ADDED BACKUP HISTORY OF U110.SF
# 94/JUL/12  B.E.   ADDED TAPE BACKUP FOR OFF LINE BACKUP
# 95/JUL/14  M.C.   ADD THE HOLDBACK PGM
# 95/JUL/26  Y.B.   ADD THE HOLDBK1 AND HOLDBK2 PGM
# 95/AUG/23  M.C.   CONVERT U115 INTO U115A AND U115B
# 95/SEP/28  M.C.   ADD THE REVHBK1 PGM
# 95/OCT/10  Y.B.   ADD THE MOHR PROGRAM
# 95/NOV/21  Y.B.   TAKE OUT REVHBK.QTS, HOLDBK1.QZS AND HOLDBK1.QZS
# 96/FEB/19  M.C.   ADD U115C AND U127 PGMS
# 96/FEB/19  Y.B.   ADD CFUND1 AND CFUND2 PGMS
# 96/APR/22  Y.B.   ADD REVCLA.QZS AND REVCLA.QTC FOR APRIL ONLY
# 96/APR/24  Y.B.   TAKE OUT REVCLA.QZS AND REVCLA.QTC
# 98/JAN/21  K.M.   PORTED TO UNIX
# 99/dec/16  B.E.   added test of $clinic_nbr to determine if certain pgms
#                   are to be run - clinic 81 doesn't run all the pgms
#                   that clinic 22 does.
# 01/oct/26  B.E.   added u934 and copy statements to load revenue from
#                   ICU payroll into 22 payroll for RMA doctors
# 04/mar/01  b.e.   - added u131a.qts
# 04/mar/25  b.e.   - moved u130.qts from d114.qks into this procedure
# 04/mar/25  b.e.   - added u131b.qts
# 04/jul/21  b.e.   - removed u934 and cp of subfile from rmabillicu as ICU
#                     payroll not being run



#echo "--- backup earnings system ---"
#$cmd/backup_earnings_daily $1


echo "Running CLINIC:  $env:clinic_nbr"


Set-Location $env:application_production
Remove-Item debug*sf*, holdback.txt *> $null
Remove-Item u119_payeft.ps* *> $null

echo "--- u105 ---"

&$env:QTP fix_seq_nbrs
&$env:QTP u105

# other clinics don't use f050 so doesn't need u110 upload
#-----------------------------------------------------------------------
if ($env:clinic_nbr -eq "22")
{

echo "--- u110 ---"
# new 2001/oct/26 B.E.
# doctors in other payrolls (currently clinic 85 - ICU payroll) have
# revenue transferred to this payroll - copy the subfile so that the
# U934 program can load this revenue into f110

#cp /alpha/rmabill/rmabillicu/production/u119_f110.sf  u119_f110_transferred.sf 
#cp /alpha/rmabill/rmabillicu/production/u119_f110.sfd u119_f110_transferred.sfd

&$env:QTP u110 "; upload other payroll revenueS" ";execute $obj/u934"

echo "--- u111a and r111b ---"
&$env:QUIZ u111a
&$env:QUIZ r111b
Remove-Item r111b_${1}.txt *> $null
Move-Item -Force r111b.txt r111b_${1}.txt

}
#-----------------------------------------------------------------------


echo "--- u113 ---"
&$env:QTP u113


# other clinics don't use f050 
#-----------------------------------------------------------------------
if ($env:clinic_nbr -eq "22")
{

echo "--- u111c ---"
&$env:QTP u111c

}
#-----------------------------------------------------------------------

# process AFP payments under '22' payroll
#-----------------------------------------------------------------------
if ($env:clinic_nbr -eq "22")
{

echo "--- u130 $Env:root\ u131a\b ---"
&$env:QTP u130
&$env:QTP u131a
&$env:QTP u131b

}
#-----------------------------------------------------------------------
echo "--- u112 and u114 ---"
&$env:QTP u112
&$env:QTP u114a
&$env:QTP u114b
