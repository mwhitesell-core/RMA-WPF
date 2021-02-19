
#-------------------------------------------------------------------------------
# File 'teb2.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'teb2'
#-------------------------------------------------------------------------------

param(
  [string] $1,
  [string] $2
)

# teb2
# NOTE: clinic 22 - "normal" clinic 22 payroll
#       clinic 99 - "MP" / Manual Payments payroll
#       clinic 10 - "solo/solotest" payroll
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
# 07/aug/22 M.C. - add additional parameter for portal 'DOC' or 'DEP' when executing
#                  r124b_rma.qzc
# 07/sep/04 M.C. - add additional parameter for portal 'DOC' or 'DEP' when executing
#                  r124b_mp.qzc
# 08/jun/16 M.C. - include new program u122b.qtc
# 08/sep/04 b.e. - added if/then else checking for u115a_0 to check if solo 
#                  or 101c environment
# 08/sep/26 b.e. - change solo and solotest to be clinic 88
# 08/oct/17 b.e. - changed above solo and solotest definition so that now clinic 10 instead of 88
# 08/oct/21 b.e. - move u122b to run before u115/a/b/c series of programs
# 08/oct/28 yas. - missing ${%} for clinic 22 doc and dep statements (re added?)
# 08/Nov/25 yas  - missing $[%] for clinic mp doc and dep statemtns 
# 12/Feb/08 M.C. - added  to generate r124b_31.txt for MP only      
# 14/Apr/17 MC1  - add to run of r124a/b_paycode7.qzc & r124c.qzu - only run in 101c - not MP or solo
#                  no portal version but it does require 3 prompts to be input just like regular r124 run
# 14/Apr/22      - Brad/Yasemin requested to include portal version of r124b_paycode/qzc as well
# 14/May/06 MC2  - Paycode 7 JCC invoice only run in MP - not in 101c nor solo
# 14/May/13 MC3  - include the run of $cmd/r153   in MP - not in 101c nor solo
# 14/Jul/17 MC4  - include the run of r128a.qts & r128b.qzs  for inactive doctor report for 3 most recent months
# 14/Oct/14 Yas  - include the run of payeft.qzs for Helena                                                        
# 14/Oct/15 MC5  - include the run of paycode1A_ceilings.qzc for Helena                             
# 14/Nov/18 MC6  - run payeft.qzs & paycode1A_ceilings.qzc only for 101c (clinic = 22)
# 15/Apr/08 MC7  - suppress printing for department 80 for PORTAL/DOC/REGULAR
# 15/Apr/30 MC8  - include the run of r137.qzu which execute r137a/b.qzc  for Helena
# 15/Sep/22 MC9  - transfer the run of r128 to $cmd/teb3     for inactive doctor report for 3 most recent months
# 15/Oct/20 MC10 - include the run of r124a_xls.qzc & r124b_xls.qzc to create r124b_csv.txt  - for 3 environments
#                  the Excel YTD Earnings (r124a like) workbook as per Ross's spec
# 16/Jan/04 MC11 - rename r124b_csv.txt with its own environment as r124b_csv_environment.txt
#                  where environment is mp and solo, do not need to rename for 101c.
#                - transfer the execution of r124a/b_xls.qzc after u127.qtc because Brad complained that current month
#                  deposit not included in the file
# 16/Jun/16 MC12 - include the run of r127.qzc in MP payroll only
# 17/Jan/18 MC13 - include the run of u122_paycode7.qts for MP payroll only - to be run after u122.qts


echo "Payroll teb2 - starting -"(Get-Date).ToString('yyyy-MM-dd 0:h:mm:ss')

echo "--- u115a u115b u115c u116 u117 u118 u119 u119b u121 and u122 ---"

# If solo use C payroll
if ($env:clinic_nbr -eq "10")
{


$rcmd = $env:QTP + "u115a_0 C" 
invoke-expression $rcmd

$rcmd = $env:QTP + "u115a_1 C" 
invoke-expression $rcmd

} else {

if ($env:clinic_nbr -eq "99")
{
#  clinic 99 -ie payroll MP doesn't need u115a_0 to run
  echo "bypassing u115a_0 u115a_1"
} else {

$rcmd = $env:QTP + "u115a_0 A" 
invoke-expression $rcmd

$rcmd = $env:QTP + "u115a_1 A" 
invoke-expression $rcmd
}
}

# moved to run later so that run after u122b
#qtp << QTP_EXIT2
#cancel clear
#set default
#execute $obj/u115a
#cancel clear
#set default
#execute $obj/u115b
#cancel clear
#set default
#execute $obj/u115c
#QTP_EXIT2


# If solo use C payroll
if ($env:clinic_nbr -eq "10")
{


$rcmd = $env:QTP + "u122b C" 
invoke-expression $rcmd



} else {

if ($env:clinic_nbr -eq "99")
{
#  clinic 99 -ie payroll MP doesn't need u122b to run
  echo "bypassing u122b"
} else {


$rcmd = $env:QTP + "u122b A" 
invoke-expression $rcmd
}
}

#moved from above


$rcmd = $env:QTP + "u115a" 
invoke-expression $rcmd



$rcmd = $env:QTP + "u115b" 
invoke-expression $rcmd


$rcmd = $env:QTP + "u115c" 
invoke-expression $rcmd

$rcmd = $env:QTP + "u116" 
invoke-expression $rcmd


$rcmd = $env:QTP + "u117" 
invoke-expression $rcmd


$rcmd = $env:QTP + "u118" 
invoke-expression $rcmd


$rcmd = $env:QTP + "u119" 
invoke-expression $rcmd

$rcmd = $env:QTP + "u119b" 
invoke-expression $rcmd

$rcmd = $env:QTP + "u121" 
invoke-expression $rcmd
 
$rcmd = $env:QTP + "u122" 
invoke-expression $rcmd





# MC13
if ($env:clinic_nbr -eq "99")
{

Remove-Item u122*sf*, u119_chgeft.ps*  -EA SilentlyContinue

$rcmd = $env:QTP + "u122_paycode7" 
invoke-expression $rcmd

}
# MC13 - end

echo ""
echo "Looking for DUPLICATES in the f119 file and if found delete them"
Remove-Item f119_duplicates.sf*

$rcmd = $env:QTP + "utl0100" 
invoke-expression $rcmd




$rcmd = $env:QUIZ + "utl0101" 
invoke-expression $rcmd

echo "The following report should be EMPTY!"
Get-Content utl0101.txt 
echo ""
echo ""

echo "--- cobol program r123 ---"
$rcmd = $env:cmd + "\r123"
invoke-expression $rcmd

Remove-Item r123*_${1}.txt  -EA SilentlyContinue
Move-Item r123a.txt r123a_${1}.txt
Move-Item r123b.txt r123b_${1}.txt
Move-Item r123c.txt r123c_${1}.txt
echo "--- PH program r123d ---"

if (($env:clinic_nbr -eq "22") -or ($env:clinic_nbr -eq "10"))
{


$rcmd = $env:QUIZ + "r123d1" 
invoke-expression $rcmd

Move-Item r123d1.txt r123d1_${1}.txt
Get-Content r123d1_${1}.txt| Out-Printer

Get-Content r123ef.txt| Out-Printer
Get-Content r123ef.txt| Out-Printer

} else {
if ($env:clinic_nbr -eq "99")
{


$rcmd = $env:QUIZ + "r123d1a" 
invoke-expression $rcmd

Move-Item r123d1a.txt r123d1a_${1}.txt
Get-Content r123d1a_${1}.txt| Out-Printer

Get-Content r123ef.txt| Out-Printer
Get-Content r123ef.txt| Out-Printer

}
}

echo "--- generate_r120 ---"


$rcmd = $env:cmd + "\generate_r120 $1"
invoke-expression $rcmd

Remove-Item r123a.sf*
Remove-Item r124b.txt, r124b_csv.txt -EA SilentlyContinue
#

if ($env:clinic_nbr -eq "99")
{

echo "---   r124a_mp ---"

$rcmd = $env:QUIZ + "r124a_mp" 
invoke-expression $rcmd

} else {

echo "---   r124a ---"

$rcmd = $env:QUIZ + "r124a" 
invoke-expression $rcmd
}



if (($env:clinic_nbr -eq "22") -or ($env:clinic_nbr -eq "10"))
{


echo "---  and  r124b_rma PORTAL DOCTOR  VERSION ---"


###################################
# 1. r124b_rma PORTAL DOC REGULAR #
###################################

$rcmd = $env:QUIZ + "r124b_rma DISC_r124b_rma.ff PORTAL DOC REGULAR" 
invoke-expression $rcmd

#Core - Added to save file with ansi encoding
Get-Content r124b_rma.txt | Out-File -FilePath r124b.txt -Encoding ASCII

Remove-Item r124b_portal_doc_${1}_22.txt -EA SilentlyContinue
Move-Item r124b.txt r124b_portal_doc_${1}_22.txt

echo "---  and  r124b_rma  PORTAL DEPARTMENT  VERSION ---"

###################################
# 2. r124b_rma PORTAL DEP REGULAR #
###################################

$rcmd = $env:QUIZ + "r124b_rma DISC_r124b_rma.ff PORTAL DEP REGULAR" 
invoke-expression $rcmd

#Core - Added to save file with ansi encoding
Get-Content r124b_rma.txt | Out-File -FilePath r124b.txt -Encoding ASCII

Remove-Item r124b_portal_dep_${1}_22.txt -EA SilentlyContinue
Move-Item r124b.txt r124b_portal_dep_${1}_22.txt

echo "---  and  r124b_rma  PRINT VERSION ---"

###################################
# 3. r124b_rma PRINT DOC REGULAR  #
###################################

$rcmd = $env:QUIZ + "r124b_rma DISC_r124b_rma.ff PRINT DOC REGULAR" 
invoke-expression $rcmd

#Core - Added to save file with ansi encoding
Get-Content r124b_rma.txt | Out-File -FilePath r124b.txt -Encoding ASCII


} else {

if ($env:clinic_nbr -eq "99")
{

echo "---  and  r124b_mp -- PORTAL DOCTOR VERSION  ---"

##########################
# 1. r124b_mp PORTAL DOC #
##########################
$rcmd = $env:QUIZ + "r124b_mp DISC_r124b.ff PORTAL DOC" 
invoke-expression $rcmd

#Core - Added to save file with ansi encoding
Get-Content r124b.txt | Out-File -FilePath r124b_portal_doc_mp_${1}.txt -Encoding ASCII

echo "---  and  r124b_mp  -- PORTAL DEPARTMENT VERSION  ---"

##########################
# 2. r124b_mp PORTAL DEP #
##########################
$rcmd = $env:QUIZ + "r124b_mp DISC_r124b.ff PORTAL DEP" 
invoke-expression $rcmd

#Core - Added to save file with ansi encoding
Get-Content r124b.txt | Out-File -FilePath r124b_portal_dep_mp_${1}.txt -Encoding ASCII

echo "---  and  r124b_mp -- PRINT VERSION  ---"

##########################
# 3. r124b_mp PRINT DOC  #
##########################
$rcmd = $env:QUIZ + "r124b_mp DISC_r124b_print.ff PRINT DOC" 
invoke-expression $rcmd

#Core - Added to save file with ansi encoding
Get-Content r124b_print.txt | Out-File -FilePath r124b.txt -Encoding ASCII

echo "---  and  r124b_mp_31 -- PRINT VERSION  ---"

############################
# 4. r124b_mp_31 PRINT DOC #
############################
$rcmd = $env:QUIZ + "r124b_mp_31 DISC_r124b_mp_31.ff PRINT DOC" 
invoke-expression $rcmd

#Core - Added to save file with ansi encoding
Get-Content r124b_mp_31.txt | Out-File -FilePath r124b_mp_31.txt -Encoding ASCII
}
}

# KEEP BACKUP OF SUBFILE IN CASE STATEMENTS NEED TO BE RE-GENERATED


if (($env:clinic_nbr -eq "22") -or ($env:clinic_nbr -eq "10"))
{

Remove-Item r124a_${1}.sf  -EA SilentlyContinue
Move-Item r124a.sf r124a_${1}.sf
Remove-Item r124a_${1}.sfd  -EA SilentlyContinue
Move-Item r124a.sfd r124a_${1}.sfd
Remove-Item r124b_${1}.txt  -EA SilentlyContinue
Move-Item r124b.txt r124b_${1}.txt

} else {

if ($env:clinic_nbr -eq "99")
{

Remove-Item r124a_${1}.sf  -EA SilentlyContinue
Move-Item r124a.sf r124a_mp_${1}.sf
Remove-Item r124a_${1}.sfd  -EA SilentlyContinue
Move-Item r124a.sfd r124a_mp_${1}.sfd
Remove-Item r124b_${1}.txt  -EA SilentlyContinue
Move-Item r124b.txt r124b_mp_${1}.txt

}
}

echo "--- u126 and u127 ---"

$rcmd = $env:QTP + "u126"
invoke-expression $rcmd
$rcmd = $env:QTP + "u127"
invoke-expression $rcmd




echo "--- r125 debugu114 debugu116 dumpf119 dumpf119ytd check94 ---"
Remove-Item r125.txt  -EA SilentlyContinue



$rcmd = $env:QUIZ + "r125" 
invoke-expression $rcmd
$rcmd = $env:QUIZ + "debugu114" 
invoke-expression $rcmd
$rcmd = $env:QUIZ + "debugu116cd1" 
invoke-expression $rcmd
$rcmd = $env:QUIZ + "debugu116cd2" 
invoke-expression $rcmd
$rcmd = $env:QUIZ + "debugu116cd34" 
invoke-expression $rcmd
$rcmd = $env:QUIZ + "dumpf119" 
invoke-expression $rcmd
$rcmd = $env:QUIZ + "dumpf119ytd" 
invoke-expression $rcmd
$rcmd = $env:QUIZ + "check94" 
invoke-expression $rcmd

echo ""


Remove-Item debugu114_${1}.txt  -EA SilentlyContinue
Move-Item debugu114.txt debug114_${1}.txt
Remove-Item debugu116cd1_${1}.txt  -EA SilentlyContinue
Move-Item debugu116cd1.txt debug116cd1_${1}.txt
Remove-Item debugu116cd2_${1}.txt  -EA SilentlyContinue
Move-Item debugu116cd2.txt debug116cd2_${1}.txt
Remove-Item debugu116cd34_${1}.txt  -EA SilentlyContinue
Move-Item debugu116cd34.txt debug116cd34_${1}.txt
Remove-Item dumpf119_${1}.txt  -EA SilentlyContinue
Move-Item dumpf119.txt dumpf119_${1}.txt
Remove-Item dumpf119ytd_${1}.txt  -EA SilentlyContinue
Move-Item dumpf119ytd.txt dumpf119ytd_${1}.txt
Remove-Item u110_${1}.sf*  -EA SilentlyContinue
Move-Item u110.sf u110_${1}.sf
Move-Item u110.sfd u110_${1}.sfd

Get-Content r125.txt| Out-Printer

#------------------------------------------------
# MC9 - transfer the run of r128 to $cmd/teb3
# MC4 - inactive doctor report
##qtp auto=$obj/r128a.qtc
##quiz auto=$obj/r128b.qzc

##rm r128*_${1}.sf* 1>/dev/null 2>&1
##rm r128_${1}.txt  1>/dev/null 2>&1
##mv r128a.sf   r128a_${1}.sf
##mv r128a.sfd  r128a_${1}.sfd
##mv r128a_inactive.sf   r128a_inactive_${1}.sf
##mv r128a_inactive.sfd  r128a_inactive_${1}.sfd
##mv r128.txt r128_${1}.txt

##lp r128_${1}.txt

# MC4 - end
# MC9 - end
#------------------------------------------------

# MC1
# MC2
##if [ $env:clinic_nbr = "22" ]
if ($env:clinic_nbr -eq "99")
{

echo "--- r124a\b_paycode7 & r124c PRINT VERSION ---"


$rcmd = $env:QUIZ + "r124a_paycode7" 
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r124b_paycode7 DISC_r124b_paycode7_temp.ff PRINT DOC REGULAR" 
invoke-expression $rcmd

#Core - Added to save file with ansi encoding
Get-Content r124b_paycode7_temp.txt | Out-File -FilePath r124b_paycode7.txt -Encoding ASCII


$rcmd = $env:QUIZ + "r124c_1" 
invoke-expression $rcmd

$rcmd = $env:QUIZ + "r124c_2" 
invoke-expression $rcmd

$rcmd = $env:QUIZ + "r124c_3" 
invoke-expression $rcmd

$rcmd = $env:QUIZ + "r124c_4" 
invoke-expression $rcmd

#Core - Added to rename report according to quiz file

echo "--- MERGING r124c_1, r124c_2, r124c_3 and r124c_4 to r124c.txt---"

Get-Content r124c_1.txt > r124c.txt
"`f" | Add-Content r124c.txt
Get-Content r124c_2.txt >> r124c.txt
"`f" | Add-Content r124c.txt
Get-Content r124c_3.txt >> r124c.txt
"`f" | Add-Content r124c.txt
Get-Content r124c_4.txt >> r124c.txt

echo "--- MERGING r124.txt Complete"

Remove-Item r124b_paycode7_${1}.txt  -EA SilentlyContinue
Move-Item r124b_paycode7.txt r124b_paycode7_${1}.txt

Remove-Item r124c_${1}.txt  -EA SilentlyContinue
Move-Item r124c.txt r124c_${1}.txt

echo "--- r124b_paycode7 PORTAL VERSION ---"


$rcmd = $env:QUIZ + "r124b_paycode7 DISC_r124b_paycode7_temp.ff PORTAL DOC REGULAR" 
invoke-expression $rcmd

#Core - Added to save file with ansi encoding
Get-Content r124b_paycode7_temp.txt | Out-File -FilePath r124b_paycode7.txt -Encoding ASCII

Remove-Item r124b_paycode7_portal_${1}.txt  -EA SilentlyContinue
Move-Item r124b_paycode7.txt r124b_paycode7_portal_${1}.txt

Remove-Item r124a_paycode7_${1}.sf  -EA SilentlyContinue
Remove-Item r124a_paycode7_${1}.sfd  -EA SilentlyContinue
Move-Item r124a_paycode7.sf r124a_paycode7_${1}.sf
Move-Item r124a_paycode7.sfd r124a_paycode7_${1}.sfd

# MC3
echo "--- cobol program r153 ---"


$rcmd = $env:cmd + "\r153"
invoke-expression $rcmd

Remove-Item r153*_${1}.txt  -EA SilentlyContinue
Move-Item r153a.txt r153a_${1}.txt
Move-Item r153b.txt r153b_${1}.txt
Move-Item r153c.txt r153c_${1}.txt
# MC3 - end

}

# MC1 - end

# MC6
if ($env:clinic_nbr -eq "22")
{


$rcmd = $env:QUIZ + "payeft" 
invoke-expression $rcmd

Move-Item payeft.txt payeft_${1}.txt

# MC5

$rcmd = $env:QUIZ + "paycode1A_ceilings DISC_paycode1A_ceilings.ff" 
invoke-expression $rcmd

Move-Item paycode1A_ceilings.txt paycode1A_ceilings_${1}.txt
# MC5 - end

}

# MC6 - end

# MC8
#    When a doctor who is paying 'x' % RMA Change reaches the max of 60,000 then he needs to change
#    from RMA % percentage charge to a Flat rate change. Right now Helena watches dept 14 doctors
#    who YTD charges are approaching 60,000 to switch them over


$rcmd = $env:QUIZ + "r137a" 
invoke-expression $rcmd

$rcmd = $env:QUIZ + "r137b" 
invoke-expression $rcmd

Remove-Item r137a_${1}.txt  -EA SilentlyContinue
Move-Item r137a.txt r137a_${1}.txt
Remove-Item r137b${1}.txt  -EA SilentlyContinue
Move-Item r137b.txt r137b_${1}.txt

Get-Content r137?_${1}.txt| Out-Printer

# MC8 - end

# MC11

# MC10


$rcmd = $env:QUIZ + "r124a_xls" 
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r124b_xls" 
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r124b_xls.txt > r124b_csv.txt

Remove-Item r124a_xls_${1}.sf  -EA SilentlyContinue
Remove-Item r124a_xls_${1}.sfd  -EA SilentlyContinue
Move-Item r124a_xls.sf r124a_xls_${1}.sf
Move-Item r124a_xls.sfd r124a_xls_${1}.sfd

if ($env:clinic_nbr -eq "10")
{
Remove-Item r124b_csv_solo.txt  -EA SilentlyContinue
Move-Item r124b_csv.txt r124b_csv_solo.txt

} else {

if ($env:clinic_nbr -eq "99")
{
Remove-Item r124b_csv_mp.txt  -EA SilentlyContinue
Move-Item r124b_csv.txt r124b_csv_mp.txt

}
}

# MC11 - end

# MC12
if ($env:clinic_nbr -eq "99")
{

Remove-Item r127.txt  -EA SilentlyContinue


$rcmd = $env:QUIZ + "r127" 
invoke-expression $rcmd

Get-Content r127.txt| Out-Printer
}

# MC12 - end

echo "Payroll teb2 -   ending -"(Get-Date).ToString('yyyy-MM-dd 0:h:mm:ss')
