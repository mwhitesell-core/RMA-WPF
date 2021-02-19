#-------------------------------------------------------------------------------
# File 'generate_icu_payroll_nolonger_needed.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'generate_icu_payroll_nolonger_needed'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# file: generate_icu_payroll
# 01/feb/15 B.E. - original
# 01/apr/25 B.E. - new runs u933a_part2 
# 01/jun/06 B.E. - u119 changed to u119_icu
# 01/oct/26 M.C. - u933a_part2 changed to u933a_part2_icu
# 02/jan/26 B.E. - removed call to u933a_part2 after creating new macros
#                  daily_icu_payroll_update that performs that logic
# 2002/08/28 yas  - change percent to 1.40 as per Leena request
# 2003/04/23 B.E. - removed run of reports r934a/b as maryb no longer uses them
# 2003/09/23 B.E. - u933a_part2 no longer needs special icu version

clear
echo "Running  `'generate_icu_payroll`'"
echo ""
echo "Note:run_icu_reports must have already been run in normal Production Environment"

echo ""
# ensure running in correct environment
#if [ 1 = 2 ]
if (pwd -ne "\alpha\rmabill\rmabillicu\production")
{
  echo "`a`a`aERROR - you are in the wrong location to run this macro"
} else {

echo ""
echo ""
echo "Starting run ..... $(Get-Date -uformat `"%T`")"
echo ""

# remove 'appended to' subfile so that reruns start with empty file
Remove-Item f119.sf* *> $null

echo "--- fix_sequence_nbrs\u105\u105a --- zero mth values\106 delete deficit"

&$env:QTP fix_seq_nbrs
&$env:QTP u105
&$env:QTP u105a
&$env:QTP u106

echo "Running u112\u113 - update f112\f110"
echo ""
&$env:QTP u112
&$env:QTP u113 ";exec $obj/u933a_part2_icu.qtc"
&$env:QTP u933a_part2 0.0 1.40

##echo "Running quiz r934b ..."
##echo " "
##quiz auto=$obj/r934b.qzu
##lp -n 2 r934b.txt
##echo "Running quiz r934a ..."
##echo " "
##quiz auto=$obj/r934a.qzu
##lp -n 2 r934a.txt

echo "Running u933b - upate f110 ..."
echo " "
&$env:QTP u933b

echo "Running u933c - update f119 ..."
echo " "
&$env:QTP u933c

echo "Running u117\8\9"
echo ""
&$env:QTP u117
&$env:QTP u118_icu
&$env:QTP u119_icu
&$env:QTP u119b
&$env:QTP u121 "!ls -l *f119*"
&$env:QTP u122

echo "--- cobol program r123 ---"
&$env:cmd\r123
Remove-Item r123*_${1}.txt *> $null
Move-Item -Force r123a r123a_${1}.txt
Move-Item -Force r123b r123b_${1}.txt
Move-Item -Force r123c r123c_${1}.txt
echo "--- PH program r123d ---"
&$env:QUIZ r123d1
Move-Item -Force r123d.txt r123d_${1}.txt

echo "--- generate_r120 ---"
&$env:cmd\generate_r120 $1
echo "BYPASSING echo -- generate r120b --"
echo "BYPASSING quiz auto=$obj\r120b.qzc"

Remove-Item r123a.sf*
Remove-Item r124b.txt

echo "---   r124a_icu $Env:root\ r124b_icu  ---"
&$env:QUIZ r124a_icu
&$env:QUIZ r124b_icu


# KEEP BACKUP OF SUBFILE IN CASE STATEMENTS NEED TO BE RE-GENERATED

Remove-Item r124a_${1}.sf *> $null
Move-Item -Force r124a.sf r124a_85_${1}.sf
Remove-Item r124a_${1}.sfd *> $null
Move-Item -Force r124a.sfd r124a_85_${1}.sfd
Remove-Item r124b_${1}.txt *> $null
Move-Item -Force r124b.txt r124b_85_${1}.txt

echo "--- u126 and u127 ---"
&$env:QTP u126
&$env:QTP u127

echo "--- r125 debugu114 debugu116 dumpf119ytd check94 ---"
Remove-Item r125.txt *> $null
&$env:QUIZ r125 ";execute $obj/dumpf119"
&$env:QUIZ dumpf119ytd

Remove-Item dumpf119_${1}.txt *> $null
Move-Item -Force dumpf119.txt dumpf119_${1}.txt
Remove-Item dumpf119ytd_${1}.txt *> $null
Move-Item -Force dumpf119ytd.txt dumpf119ytd_${1}.txt

Remove-Item u110_${1}.sf* *> $null
Move-Item -Force u110.sf u110_${1}.sf
Move-Item -Force u110.sfd u110_${1}.sfd

Remove-Item f119_${1}.sf* *> $null
Move-Item -Force f119.sf f119_${1}.sf
Move-Item -Force f119.sfd f119_${1}.sfd

Get-Content r120.txt | Out-Printer
Get-Content r120b.txt | Out-Printer
#lp r125.txt
#lp r111b_${1}.txt
Get-Content r123d_${1}.txt | Out-Printer
Get-Content r123ef | Out-Printer
Get-Content r123ef | Out-Printer

echo ""
echo "If all reports balance then run the MONTH END TAPE backup ..."
echo ""
#$cmd/backup_earnings_monthend ${1}
#echo
#echo

echo "Finished Time $(Get-Date -uformat `"%T`")"
}
