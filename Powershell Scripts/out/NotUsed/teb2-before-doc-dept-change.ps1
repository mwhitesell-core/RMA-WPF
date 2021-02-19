#-------------------------------------------------------------------------------
# File 'teb2-before-doc-dept-change.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'teb2-before-doc-dept-change'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# teb2
# NOTE: clinic 22 - "normal" clinic 22 payroll
#       clinic 99 - "MP" / Manual Payments payroll
#       clinic 81 - used to be ICU payroll but moved to it's own macro
#
# 99/dec/16 B.E. - added test of $clinic_nbr to perform conditional processing
# 00/jan/24 B.E. - split u119 into u119/u119b
# 00/nov/17 B.E. - run special version of r124b.qzs depending upon clinic
#                  being processed. Note that clinic 99 used for MP payroll
# 01/jan/02 B.E. - run special version of r124a for clinic 99 (MP payroll)
# 02/dec/19 B.E. - removed references to clinic 81 
# 03/oct/27 b.e. - added call to utl0020 to create spreadsheet download files
# 03/nov/25 b.e. - made call utl0020 conditional for clinic 22
# 04/jan/23 b.e. - removed utl0020 and put into teb3
# 04/sep/01 b.e. - added new paramter "PORTAL" as 1st parameter for r124a_rma 
# 06/jan/17 b.e. - setup "PORTAL" parameter stuff for clinic 99(mp) same as 
#                  for clinic 22 in previous change
# 06/jun/22 b.e. - added utl0100.qtc and utl0101.qzc to look for duplicate
#                  entries in f119 - a bug that appears once a year around july

echo "--- u115a u115b u115c u116 u117 u118 u119 u119b u121 and u122 ---"
&$env:QTP u115a
&$env:QTP u115b
&$env:QTP u115c
&$env:QTP u116
&$env:QTP u117
&$env:QTP u118
&$env:QTP u119
&$env:QTP u119b
&$env:QTP u121
&$env:QTP u122

echo ""
echo "Looking for DUPLICATES in the f119 file and if found delete them"
Remove-Item f119_duplicates.sf*
&$env:QTP utl0100

&$env:QUIZ utl0101
echo "The following report should be EMPTY!"
Get-Content utl0101.txt
echo ""
echo ""

# PAREN SET DEFAULT -- MOVE PAREN ABOVE DOWN 2 LINES!!
# PAREN EXE U125
echo "--- cobol program r123 ---"
&$env:cmd\r123
Remove-Item r123*_${1}.txt *> $null
Move-Item -Force r123a r123a_${1}.txt
Move-Item -Force r123b r123b_${1}.txt
Move-Item -Force r123c r123c_${1}.txt
echo "--- PH program r123d ---"
&$env:QUIZ r123d1
&$env:QUIZ r123d1a
Move-Item -Force r123d.txt r123d_${1}.txt
Move-Item -Force r123d1a.txt r123d1a_${1}.txt
Get-Content r123ef | Out-Printer
Get-Content r123ef | Out-Printer

echo "--- generate_r120 ---"
&$env:cmd\generate_r120 $1

Remove-Item r123a.sf*
Remove-Item r124b.txt

if ($env:clinic_nbr -eq "99")
{

echo "---   r124a_mp ---"
&$env:QUIZ r124a_mp

} else {

echo "---   r124a ---"
&$env:QUIZ r124a

}



if ($env:clinic_nbr -eq "22")
{

echo "---  and  r124b_rma -- PORTAL VERSION  ---"
&$env:QUIZ r124b_rma PORTAL REGULAR ;YEAREND

Move-Item -Force r124b.txt r124b_portal_22.txt

echo "---  and  r124b_rma -- PRINT VERSION  ---"
&$env:QUIZ r124b_rma PRINT REGULAR ;YEAREND

} else {

if ($env:clinic_nbr -eq "99")
{

echo "---  and  r124b_rma -- PORTAL VERSION  ---"
&$env:QUIZ r124b_mp PORTAL

Move-Item -Force r124b.txt r124b_portal_mp.txt

echo "---  and  r124b_rma -- PRINT VERSION  ---"
&$env:QUIZ r124b_mp PRINT



}
}

# KEEP BACKUP OF SUBFILE IN CASE STATEMENTS NEED TO BE RE-GENERATED

if ($env:clinic_nbr -eq "22")
{

Remove-Item r124a_${1}.sf *> $null
Move-Item -Force r124a.sf r124a_${1}.sf
Remove-Item r124a_${1}.sfd *> $null
Move-Item -Force r124a.sfd r124a_${1}.sfd
Remove-Item r124b_${1}.txt *> $null
Move-Item -Force r124b.txt r124b_${1}.txt

} else {

if ($env:clinic_nbr -eq "99")
{

Remove-Item r124a_${1}.sf *> $null
Move-Item -Force r124a.sf r124a_mp_${1}.sf
Remove-Item r124a_${1}.sfd *> $null
Move-Item -Force r124a.sfd r124a_mp_${1}.sfd
Remove-Item r124b_${1}.txt *> $null
Move-Item -Force r124b.txt r124b_mp_${1}.txt

}
}

echo "--- u126 and u127 ---"
&$env:QTP u126
&$env:QTP u127

echo "--- r125 debugu114 debugu116 dumpf119 dumpf119ytd check94 ---"
Remove-Item r125.txt *> $null
&$env:QUIZ r125
&$env:QUIZ debugu114
&$env:QUIZ debugu116cd1
&$env:QUIZ debugu116cd2
&$env:QUIZ debugu116cd34
&$env:QUIZ dumpf119
&$env:QUIZ dumpf119ytd ";execute $obj/check94"

echo ""

#if [ $clinic_nbr = "22" ]
#then
#
#echo "--- utl0020 ---"
#$cmd/utl0020.com
#
#fi


Remove-Item debugu114_${1}.txt *> $null
Move-Item -Force debugu114.txt debug114_${1}.txt
Remove-Item debugu116cd1_${1}.txt *> $null
Move-Item -Force debugu116cd1.txt debug116cd1_${1}.txt
Remove-Item debugu116cd2_${1}.txt *> $null
Move-Item -Force debugu116cd2.txt debug116cd2_${1}.txt
Remove-Item debugu116cd34_${1}.txt *> $null
Move-Item -Force debugu116cd34.txt debug116cd34_${1}.txt
Remove-Item dumpf119_${1}.txt *> $null
Move-Item -Force dumpf119.txt dumpf119_${1}.txt
Remove-Item dumpf119ytd_${1}.txt *> $null
Move-Item -Force dumpf119ytd.txt dumpf119ytd_${1}.txt
Remove-Item u110_${1}.sf* *> $null
Move-Item -Force u110.sf u110_${1}.sf
Move-Item -Force u110.sfd u110_${1}.sfd

Get-Content r125.txt | Out-Printer
#lp r111b_${1}.txt
Get-Content r123d_${1}.txt | Out-Printer
Get-Content r123d1a_${1}.txt | Out-Printer
#lp check94.txt
#echo
#echo "Load Tape to create tape backup ..."
#echo 
#$cmd/backup_earnings_monthend ${1} 
#echo
#echo
