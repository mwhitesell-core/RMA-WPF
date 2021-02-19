
#-------------------------------------------------------------------------------
# File 'teb1.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'teb1'
#-------------------------------------------------------------------------------

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
# 04/sep/15  b.e.   - made u130 run not only for regular payroll (clinic_nbr=22)
#                     but also for "MP" payroll (clinic_nbr=99)
# 07/may/16  b.e.   - added u110b_rma.qtc to u110.qtc process to pickup
#                     professional payments from revenue
# 08/may/26  b.e.   - u110 split into u110_1 and u110_2
# 08/oct/13  b.e.   - added clinic_nbr=88 for new solo payroll
# 08/oct/13  b.e.   - changed above for solo from clinic_nbr=88 to 10


#echo "--- backup earnings system ---"
#$cmd/backup_earnings_daily $1

param(
  [string] $1,
  [string] $2
)

echo "Payroll teb1 - starting -"(Get-Date).ToString('yyyy-MM-dd 0:h:mm:ss')

echo "Running CLINIC:  $env:clinic_nbr"


Set-Location $env:application_production
Remove-Item debug*sf*, holdback.txt -EA SilentlyContinue
Remove-Item u119_payeft.ps*  -EA SilentlyContinue

echo "--- u105 ---"
$rcmd = $env:QTP + "fix_seq_nbrs"
Invoke-Expression $rcmd

$rcmd = $env:QTP + "u105"
invoke-expression $rcmd



# some clinics don't use f050 so doesn't need u110 upload
#-----------------------------------------------------------------------
if (($env:clinic_nbr -eq "22") -or ($env:clinic_nbr -eq "10"))
{

echo "--- u110_1 and u110_2 ---"
# new 2001/oct/26 B.E.
# doctors in other payrolls (currently clinic 85 - ICU payroll) have
# revenue transferred to this payroll - copy the subfile so that the
# U934 program can load this revenue into f110

#cp /alpha/rmabill/rmabillicu/production/u119_f110.sf  u119_f110_transferred.sf 
#cp /alpha/rmabill/rmabillicu/production/u119_f110.sfd u119_f110_transferred.sfd

Remove-Item u110_audit*sf*, u110.sf*  -EA SilentlyContinue

#execute $obj/u110
$rcmd = $env:QTP + "u110_1"
invoke-expression $rcmd
$rcmd = $env:QTP + "u110_2"
invoke-expression $rcmd
$rcmd = $env:QTP + "u110b_rma"
invoke-expression $rcmd
# upload other payroll revenueS
#execute $obj/u934




echo "--- u111a and r111b ---"



$rcmd = $env:QUIZ + "u111a"
invoke-expression $rcmd

$rcmd = $env:QUIZ + "r111b"
invoke-expression $rcmd

Remove-Item r111b_${1}.txt  -EA SilentlyContinue
Move-Item r111b.txt r111b_${1}.txt

}
#-----------------------------------------------------------------------


echo "--- u113 ---"

$rcmd = $env:QTP + "u113"
invoke-expression $rcmd

# other clinics don't use f050 - just regular 101c and solo 
#-----------------------------------------------------------------------
if (($env:clinic_nbr -eq "22") -or ($env:clinic_nbr -eq "10"))
{

echo "--- u111c ---"

$rcmd = $env:QTP + "u111c"
invoke-expression $rcmd

}
#-----------------------------------------------------------------------

# process special payments under regular('22') and MP('99') payroll and SOLO('10')
#-----------------------------------------------------------------------
if (($env:clinic_nbr -eq "22") -or ($env:clinic_nbr -eq "99")-or ($env:clinic_nbr -eq "10"))
{

echo "--- u130  ---"

$rcmd = $env:QTP + "u130"
invoke-expression $rcmd
}

#-----------------------------------------------------------------------
# process AFP payments under '22' payroll
#-----------------------------------------------------------------------
if ($env:clinic_nbr -eq "22")
{

echo "---  u131a\b ---"



$rcmd = $env:QTP + "u131a"
invoke-expression $rcmd

}
#-----------------------------------------------------------------------
echo "--- u112 and u114 ---"


$rcmd = $env:QTP + "u112"
invoke-expression $rcmd

$rcmd = $env:QTP + "u114a"
invoke-expression $rcmd

$rcmd = $env:QTP + "u114b"
invoke-expression $rcmd

echo "Payroll teb1   - Ending -"(Get-Date).ToString('yyyy-MM-dd 0:h:mm:ss')
