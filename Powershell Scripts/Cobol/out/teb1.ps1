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

echo "Payroll teb1 - starting -$(udate)"

echo "Running CLINIC:  $clinic_nbr"


Set-Location $application_production
Remove-Item debug*sf*, holdback.txt  > $null
Remove-Item u119_payeft.ps*  > $null

echo "--- u105 ---"

$pipedInput = @"
use $src/fix_seq_nbrs nolist
cancel clear
set default
execute $obj/u105
"@

$pipedInput | qtp++

# some clinics don't use f050 so doesn't need u110 upload
#-----------------------------------------------------------------------
if (($clinic_nbr -eq "22") -or ($clinic_nbr -eq "10"))
{

echo "--- u110_1 and u110_2 ---"
# new 2001/oct/26 B.E.
# doctors in other payrolls (currently clinic 85 - ICU payroll) have
# revenue transferred to this payroll - copy the subfile so that the
# U934 program can load this revenue into f110

#cp /alpha/rmabill/rmabillicu/production/u119_f110.sf  u119_f110_transferred.sf 
#cp /alpha/rmabill/rmabillicu/production/u119_f110.sfd u119_f110_transferred.sfd

Remove-Item u110_audit*sf*, u110.sf*  > $null

$pipedInput = @"
cancel clear
;execute $obj/u110
execute $obj/u110_1
execute $obj/u110_2
execute $obj/u110b_rma
; upload other payroll revenueS
;execute $obj/u934
"@

$pipedInput | qtp++

echo "--- u111a and r111b ---"
$pipedInput = @"
execute $obj/u111a
execute $obj/r111b
"@

$pipedInput | quiz++
Remove-Item r111b_${1}.txt  > $null
Move-Item r111b.txt r111b_${1}.txt

}
#-----------------------------------------------------------------------


echo "--- u113 ---"
$pipedInput = @"
set default
execute $obj/u113
"@

$pipedInput | qtp++


# other clinics don't use f050 - just regular 101c and solo 
#-----------------------------------------------------------------------
if (($clinic_nbr -eq "22") -or ($clinic_nbr -eq "10"))
{

echo "--- u111c ---"
$pipedInput = @"
cancel clear
set default
execute $obj/u111c
"@

$pipedInput | qtp++

}
#-----------------------------------------------------------------------

# process special payments under regular('22') and MP('99') payroll and SOLO('10')
#-----------------------------------------------------------------------
if (($clinic_nbr -eq "22") -or ($clinic_nbr -eq "99")-or ($clinic_nbr -eq "10"))
{

echo "--- u130  ---"
$pipedInput = @"
cancel clear
set default
execute $obj/u130
"@

$pipedInput | qtp++

}

#-----------------------------------------------------------------------
# process AFP payments under '22' payroll
#-----------------------------------------------------------------------
if ($clinic_nbr -eq "22")
{

echo "---  u131a\b ---"
$pipedInput = @"
cancel clear
set default
execute $obj/u131a
;execute $obj/u131b
"@

$pipedInput | qtp++

}
#-----------------------------------------------------------------------
echo "--- u112 and u114 ---"
$pipedInput = @"
cancel clear
set default
execute $obj/u112
cancel clear
set default
execute $obj/u114a
set default
execute $obj/u114b
"@

$pipedInput | qtp++


echo "Payroll teb1   - Ending -$(udate)"
