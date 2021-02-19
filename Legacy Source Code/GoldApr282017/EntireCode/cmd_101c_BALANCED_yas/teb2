# teb2
# NOTE: clinic 22 - "normal" clinic 22 payroll
#	clinic 99 - "MP" / Manual Payments payroll
#	clinic 10 - "solo/solotest" payroll
#	clinic 81 - used to be ICU payroll but moved to it's own macro
#
# 99/dec/16 B.E. - added test of $clinic_nbr to perform conditional processing
# 00/jan/24 B.E. - split u119 into u119/u119b
# 00/nov/17 B.E. - run special version of r124b.qzs depending upon clinic
#		   being processed. Note that clinic 99 used for MP payroll
# 01/jan/02 B.E. - run special version of r124a for clinic 99 (MP payroll)
# 02/dec/19 B.E. - removed references to clinic 81 
# 03/oct/27 b.e. - added call to utl0020 to create spreadsheet download files
# 03/nov/25 b.e. - made call utl0020 conditional for clinic 22
# 04/jan/23 b.e. - removed utl0020 and put into teb3
# 04/sep/01 b.e. - added new paramter "PORTAL" as 1st parameter for r124a_rma 
# 06/jan/17 b.e. - setup "PORTAL" parameter stuff for clinic 99(mp) same as 
#		   for clinic 22 in previous change
# 06/jun/22 b.e. - added utl0100.qtc and utl0101.qzc to look for duplicate
#		   entries in f119 - a bug that appears once a year around july
# 07/aug/22 M.C. - add additional parameter for portal 'DOC' or 'DEP' when executing
#		   r124b_rma.qzc
# 07/sep/04 M.C. - add additional parameter for portal 'DOC' or 'DEP' when executing
#		   r124b_mp.qzc
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
#		   no portal version but it does require 3 prompts to be input just like regular r124 run
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
#		   the Excel YTD Earnings (r124a like) workbook as per Ross's spec
# 16/Jan/04 MC11 - rename r124b_csv.txt with its own environment as r124b_csv_environment.txt
#		   where environment is mp and solo, do not need to rename for 101c.
#		 - transfer the execution of r124a/b_xls.qzc after u127.qtc because Brad complained that current month
#		   deposit not included in the file
# 16/Jun/16 MC12 - include the run of r127.qzc in MP payroll only
# 17/Jan/18 MC13 - include the run of u122_paycode7.qts for MP payroll only - to be run after u122.qts


echo "Payroll teb2 - starting - `date`"

echo "--- u115a u115b u115c u116 u117 u118 u119 u119b u121 and u122 ---"

# If solo use C payroll
if [ $clinic_nbr = "10" ]
then

qtp << QTP_EXIT1a
execute $obj/u115a_0
C
execute $obj/u115a_1
C
QTP_EXIT1a

else

if [ $clinic_nbr = "99" ]
then
#  clinic 99 -ie payroll MP doesn't need u115a_0 to run
  echo bypassing u115a_0 u115a_1
else

qtp << QTP_EXIT1a
execute $obj/u115a_0
A
execute $obj/u115a_1
A
QTP_EXIT1a
fi
fi

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
if [ $clinic_nbr = "10" ]
then
qtp << QTP_EXIT2a
execute $obj/u122b
C
QTP_EXIT2a

else

if  [ $clinic_nbr = "99" ]
then
#  clinic 99 -ie payroll MP doesn't need u122b to run
  echo bypassing u122b
else

qtp << QTP_EXIT2a
execute $obj/u122b
A
QTP_EXIT2a
fi
fi

#moved from above
qtp << QTP_EXIT2
cancel clear
set default
execute $obj/u115a
cancel clear
set default
execute $obj/u115b
cancel clear
set default
execute $obj/u115c
QTP_EXIT2

qtp << QTP_EXIT2c
cancel clear
set default
execute $obj/u116
cancel clear
set default
execute $obj/u117
cancel clear
set default
execute $obj/u118
cancel clear
set default
execute $obj/u119
cancel clear
set default
execute $obj/u119b
cancel clear
set default
execute $obj/u121
cancel clear
set default
execute $obj/u122
cancel clear
QTP_EXIT2c

# MC13
if [ $clinic_nbr = "99" ]
then

rm u122*sf* u119_chgeft.ps*  >/dev/null 2>&1 
qtp  auto=$obj/u122_paycode7.qtc

fi
# MC13 - end

echo
echo Looking for DUPLICATES in the f119 file and if found delete them
rm f119_duplicates.sf*
qtp << QTP_EXIT3
use $src/utl0100.qts
exit
QTP_EXIT3

quiz auto=$obj/utl0101.qzc
echo The following report should be EMPTY!
pg utl0101.txt
echo
echo

echo "--- cobol program r123 ---"
$cmd/r123
rm r123*_${1}.txt 1>/dev/null 2>&1 
mv r123a r123a_${1}.txt
mv r123b r123b_${1}.txt
mv r123c r123c_${1}.txt
echo "--- PH program r123d ---"

if [ $clinic_nbr = "22" -o $clinic_nbr = "10" ]
then

quiz auto=$obj/r123d1.qzc
mv r123d1.txt r123d1_${1}.txt
lp r123d1_${1}.txt

lp r123ef
lp r123ef

else
if [ $clinic_nbr = "99" ]
then

quiz auto=$obj/r123d1a.qzc
mv r123d1a.txt r123d1a_${1}.txt
lp r123d1a_${1}.txt

lp r123ef
lp r123ef

fi
fi

echo "--- generate_r120 ---"
$cmd/generate_r120 $1

rm r123a.sf*
rm r124b.txt  r124b_csv.txt
#

if [ $clinic_nbr = "99" ]
then

echo "---   r124a_mp ---"
quiz auto=$obj/r124a_mp.qzc

else

echo "---   r124a ---"
quiz auto=$obj/r124a.qzc

fi



if [ $clinic_nbr = "22" -o $clinic_nbr = "10" ]
then


echo "---  and  r124b_rma  PORTAL DOCTOR  VERSION ---"
quiz << QUIZ_EXIT
;  MC7  execute $obj/r124b_rma
execute $obj/r124b_rma nogo
and sel if doc-dept <> 80
go
PORTAL
DOC
REGULAR
QUIZ_EXIT

mv r124b.txt r124b_portal_doc_${1}_22.txt

echo "---  and  r124b_rma  PORTAL DEPARTMENT  VERSION ---"
quiz << QUIZ_EXIT
execute $obj/r124b_rma
PORTAL
DEP
REGULAR
QUIZ_EXIT

mv r124b.txt r124b_portal_dep_${1}_22.txt

echo "---  and  r124b_rma  PRINT VERSION ---"
quiz << QUIZ_EXIT
execute $obj/r124b_rma
PRINT 
DOC
REGULAR
QUIZ_EXIT

else

if [ $clinic_nbr = "99" ]
then

echo "---  and  r124b_mp -- PORTAL DOCTOR VERSION  ---"
quiz << QUIZ_EXIT
; MC7 execute $obj/r124b_mp
execute $obj/r124b_mp nogo
and select if       x-new-parm = "DOC"  &
                and doc-dept <>  80       
go
PORTAL
DOC
QUIZ_EXIT

mv r124b.txt r124b_portal_doc_mp_${1}.txt

echo "---  and  r124b_mp  -- PORTAL DEPARTMENT VERSION  ---"
quiz << QUIZ_EXIT
execute $obj/r124b_mp
PORTAL
DEP
QUIZ_EXIT

mv r124b.txt r124b_portal_dep_mp_${1}.txt

echo "---  and  r124b_mp -- PRINT VERSION  ---"
quiz << QUIZ_EXIT
execute $obj/r124b_mp
PRINT
DOC
QUIZ_EXIT

echo "---  and  r124b_mp_31 -- PRINT VERSION  ---"
quiz << QUIZ_EXIT
execute $obj/r124b_mp nogo 
and sel if x-new-parm = 'DOC' and doc-dept = 31
set rep dev disc name r124b_mp_31
set page width 202 length 0
set nohead
set noformfeed
go
PRINT
DOC
QUIZ_EXIT



fi
fi

# KEEP BACKUP OF SUBFILE IN CASE STATEMENTS NEED TO BE RE-GENERATED

if [ $clinic_nbr = "22" -o $clinic_nbr = "10" ]
then

rm r124a_${1}.sf 1>/dev/null 2>&1
mv r124a.sf r124a_${1}.sf
rm r124a_${1}.sfd 1>/dev/null 2>&1
mv r124a.sfd r124a_${1}.sfd
rm r124b_${1}.txt 1>/dev/null 2>&1
mv r124b.txt r124b_${1}.txt

else

if [ $clinic_nbr = "99" ]
then

rm r124a_${1}.sf 1>/dev/null 2>&1
mv r124a.sf r124a_mp_${1}.sf
rm r124a_${1}.sfd 1>/dev/null 2>&1
mv r124a.sfd r124a_mp_${1}.sfd
rm r124b_${1}.txt 1>/dev/null 2>&1
mv r124b.txt r124b_mp_${1}.txt

fi
fi

echo "--- u126 and u127 ---"
qtp << QTP_EXIT4
set default
execute $obj/u126
execute $obj/u127
QTP_EXIT4

echo "--- r125 debugu114 debugu116 dumpf119 dumpf119ytd check94 ---"
rm r125.txt 1>/dev/null 2>&1
quiz << QUIZ_EXIT
execute $obj/r125
execute $obj/debugu114
execute $obj/debugu116cd1
execute $obj/debugu116cd2
execute $obj/debugu116cd34
execute $obj/dumpf119
execute $obj/dumpf119ytd
;execute $obj/check94
QUIZ_EXIT

echo


rm debugu114_${1}.txt 1>/dev/null 2>&1
mv debugu114.txt debug114_${1}.txt
rm debugu116cd1_${1}.txt 1>/dev/null 2>&1
mv debugu116cd1.txt debug116cd1_${1}.txt
rm debugu116cd2_${1}.txt 1>/dev/null 2>&1
mv debugu116cd2.txt debug116cd2_${1}.txt
rm debugu116cd34_${1}.txt 1>/dev/null 2>&1
mv debugu116cd34.txt debug116cd34_${1}.txt
rm dumpf119_${1}.txt 1>/dev/null 2>&1
mv dumpf119.txt dumpf119_${1}.txt
rm dumpf119ytd_${1}.txt 1>/dev/null 2>&1
mv dumpf119ytd.txt dumpf119ytd_${1}.txt
rm u110_${1}.sf* 1>/dev/null 2>&1
mv u110.sf u110_${1}.sf
mv u110.sfd u110_${1}.sfd

lp r125.txt

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
##if [ $clinic_nbr = "22" ]
if [ $clinic_nbr = "99" ]
then

echo "--- r124a/b_paycode7 & r124c PRINT VERSION ---"
quiz << QUIZ_EXIT
execute $obj/r124a_paycode7
execute $obj/r124b_paycode7
PRINT 
DOC
REGULAR
use $obj/r124c.qzu
QUIZ_EXIT

rm r124b_paycode7_${1}.txt 1>/dev/null 2>&1
mv r124b_paycode7.txt r124b_paycode7_${1}.txt

rm r124c_${1}.txt 1>/dev/null 2>&1
mv r124c.txt r124c_${1}.txt

echo "--- r124b_paycode7 PORTAL VERSION ---"
quiz << QUIZ_EXIT
execute $obj/r124b_paycode7
PORTAL
DOC
REGULAR
QUIZ_EXIT

rm r124b_paycode7_portal_${1}.txt 1>/dev/null 2>&1
mv r124b_paycode7.txt r124b_paycode7_portal_${1}.txt

rm r124a_paycode7_${1}.sf  1>/dev/null 2>&1
rm r124a_paycode7_${1}.sfd 1>/dev/null 2>&1
mv r124a_paycode7.sf  r124a_paycode7_${1}.sf
mv r124a_paycode7.sfd r124a_paycode7_${1}.sfd

# MC3
echo "--- cobol program r153 ---"
$cmd/r153
rm r153*_${1}.txt 1>/dev/null 2>&1
mv r153a r153a_${1}.txt
mv r153b r153b_${1}.txt
mv r153c r153c_${1}.txt
# MC3 - end

fi

# MC1 - end

# MC6
if [ $clinic_nbr = "22" ]
then

quiz auto=$obj/payeft.qzc
mv payeft.txt payeft_${1}.txt

# MC5
quiz auto=$obj/paycode1A_ceilings.qzc
mv paycode1A_ceilings.txt  paycode1A_ceilings_${1}.txt
# MC5 - end

fi

# MC6 - end

# MC8
#    When a doctor who is paying 'x' % RMA Change reaches the max of 60,000 then he needs to change
#    from RMA % percentage charge to a Flat rate change. Right now Helena watches dept 14 doctors
#    who YTD charges are approaching 60,000 to switch them over

quiz auto=$obj/r137.qzu
mv r137a.txt   r137a_${1}.txt
mv r137b.txt   r137b_${1}.txt

lp r137?_${1}.txt

# MC8 - end

# MC11

# MC10

quiz auto=$obj/r124a_xls.qzc
quiz auto=$obj/r124b_xls.qzc

rm r124a_xls_${1}.sf  1>/dev/null 2>&1
rm r124a_xls_${1}.sfd 1>/dev/null 2>&1
mv r124a_xls.sf  r124a_xls_${1}.sf
mv r124a_xls.sfd r124a_xls_${1}.sfd

if [ $clinic_nbr = "10" ]
then

mv r124b_csv.txt r124b_csv_solo.txt

else

if [ $clinic_nbr = "99" ]
then

mv r124b_csv.txt r124b_csv_mp.txt

fi
fi

# MC11 - end

# MC12
if [ $clinic_nbr = "99" ]
then

rm  r127.txt 1>/dev/null 2>&1

quiz auto=$obj/r127.qzc

lp r127.txt
fi

# MC12 - end

echo "Payroll teb2 -   ending - `date`"

