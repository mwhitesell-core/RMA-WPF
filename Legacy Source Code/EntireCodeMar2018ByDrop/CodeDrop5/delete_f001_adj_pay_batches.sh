#!/bin/ksh
#  2001/jul/09 B.E. added renames to backup subfiles for each clinic
#  2003/Jul/16 yas. added clinics 91,92,93,94 and 96
#  2012/Jul/05 MC   copy f002-claims-mstr   to /foxtrot/purge
#  2015/Feb/17 Yas  add new group H290 clinic 30             
#  2015/Jun/10 Yas  add new clinic 26                        

echo  "DELETE_F001_ADJ_PAY_BATCHES"
echo

echo  'DELETE THE ADJUSTMENT AND PAYMENT BATCHES FOR THE CLINIC'
echo
echo 'N O T E : ! ! !  F001 AND F002 MUST HAVE BE BACKED UP before THIS RUN ...'
echo
echo
echo 'STAGE 1A - RUN VERIFY OF CLAIMS  FOR A REPORT OF FILE BEFORE DELETION ..'

cd $pb_data

cp f002_claims_mstr       /foxtrot/purge/f002_claims_mstr_orig
cp f002_claims_mstr.idx   /foxtrot/purge/f002_claims_mstr_orig.idx

cd /charly/purge

cobrun $obj/r071  2>&1 << R071_EXIT
20160630
Y
R071_EXIT

rm  >/dev/null  2>/dev/null  r071_before
mv                      r071 r071_before

echo
ls -laF r071_before
echo

date

#lp r071_before

echo
echo 'STAGE 1B - RUN "ALL_BATCHES" ON ALL CLINICS BEFORE DELETION ...'

cobrun $obj/r001b

rm >/dev/null  2>/dev/null   r001b_before_r093
mv                     r001b r001b_before_r093

echo
ls -laF r001b_before_r093
echo



##lp     r001b_before_r093

rm u093-retain-batch.sf*	> /dev/null 2>&1
rm u093-delete-batch.sf*	> /dev/null 2>&1
rm u093-purge-validate.sf*	> /dev/null 2>&1
rm u093*.txt			> /dev/null 2>&1

echo
echo  'STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 22 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...


echo  " --- u093   (QTP) --- "
qtp << E_O_F
exec $obj/u093.qtc
22000000
22ZZZ999
20160630
exit
E_O_F

quiz << E_O_F 
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
22
exec $obj/r093d.qzc
22
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-22.sf
mv u093-delete-batch.sfd u093-delete-batch-22.sfd
mv u093-retain-batch.sf  u093-retain-batch-22.sf
mv u093-retain-batch.sfd u093-retain-batch-22.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_22
cat    r093a.txt r093b.txt > r093_22
#lp                           r093_22

echo
echo  'STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 23 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
23000000
23ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
23
exec $obj/r093d.qzc
23
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-23.sf
mv u093-delete-batch.sfd u093-delete-batch-23.sfd
mv u093-retain-batch.sf  u093-retain-batch-23.sf
mv u093-retain-batch.sfd u093-retain-batch-23.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date

rm >/dev/null  2>/dev/null   r093_23
cat    r093a.txt r093b.txt > r093_23
#lp                           r093_23

echo
echo  'STAGE 2   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 24 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
24000000
24ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
24
exec $obj/r093d.qzc
24
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-24.sf
mv u093-delete-batch.sfd u093-delete-batch-24.sfd
mv u093-retain-batch.sf  u093-retain-batch-24.sf
mv u093-retain-batch.sfd u093-retain-batch-24.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date

rm >/dev/null  2>/dev/null   r093_24
cat    r093a.txt r093b.txt > r093_24
#lp                           r093_24


echo
echo  'STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 25 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
25000000
25ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
25
exec $obj/r093d.qzc
25
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-25.sf
mv u093-delete-batch.sfd u093-delete-batch-25.sfd
mv u093-retain-batch.sf  u093-retain-batch-25.sf
mv u093-retain-batch.sfd u093-retain-batch-25.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date

rm >/dev/null  2>/dev/null   r093_25
cat    r093a.txt r093b.txt > r093_25
#lp                           r093_25


echo
echo  'STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 26 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
26000000
26ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
26
exec $obj/r093d.qzc
26
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-26.sf
mv u093-delete-batch.sfd u093-delete-batch-26.sfd
mv u093-retain-batch.sf  u093-retain-batch-26.sf
mv u093-retain-batch.sfd u093-retain-batch-26.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date

rm >/dev/null  2>/dev/null   r093_26
cat    r093a.txt r093b.txt > r093_26
#lp                           r093_26


echo
echo  'STAGE  2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 30 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
30000000
30ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
30
exec $obj/r093d.qzc
30
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-30.sf
mv u093-delete-batch.sfd u093-delete-batch-30.sfd
mv u093-retain-batch.sf  u093-retain-batch-30.sf
mv u093-retain-batch.sfd u093-retain-batch-30.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date

rm >/dev/null  2>/dev/null   r093_30
cat    r093a.txt r093b.txt > r093_30
#lp                           r093_30

echo
echo  'STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 31 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
31000000
31ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
31
exec $obj/r093d.qzc
31
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-31.sf
mv u093-delete-batch.sfd u093-delete-batch-31.sfd
mv u093-retain-batch.sf  u093-retain-batch-31.sf
mv u093-retain-batch.sfd u093-retain-batch-31.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_31
cat    r093a.txt r093b.txt > r093_31
#lp                           r093_31

echo
echo  'STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 32 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
32000000
32ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
32
exec $obj/r093d.qzc
32
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-32.sf
mv u093-delete-batch.sfd u093-delete-batch-32.sfd
mv u093-retain-batch.sf  u093-retain-batch-32.sf
mv u093-retain-batch.sfd u093-retain-batch-32.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_32
cat    r093a.txt r093b.txt > r093_32
#lp                           r093_32

echo
echo  'STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 33 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
33000000
33ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
33
exec $obj/r093d.qzc
33
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-33.sf
mv u093-delete-batch.sfd u093-delete-batch-33.sfd
mv u093-retain-batch.sf  u093-retain-batch-33.sf
mv u093-retain-batch.sfd u093-retain-batch-33.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_33
cat    r093a.txt r093b.txt > r093_33
#lp                           r093_33

echo
echo  'STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 34 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
34000000
34ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
34
exec $obj/r093d.qzc
34
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-34.sf
mv u093-delete-batch.sfd u093-delete-batch-34.sfd
mv u093-retain-batch.sf  u093-retain-batch-34.sf
mv u093-retain-batch.sfd u093-retain-batch-34.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_34
cat    r093a.txt r093b.txt > r093_34
#lp                           r093_34

echo
echo  'STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 35 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
35000000
35ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
35
exec $obj/r093d.qzc
35
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-35.sf
mv u093-delete-batch.sfd u093-delete-batch-35.sfd
mv u093-retain-batch.sf  u093-retain-batch-35.sf
mv u093-retain-batch.sfd u093-retain-batch-35.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_35
cat    r093a.txt r093b.txt > r093_35
#lp                           r093_35


echo
echo  'STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 36 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
36000000
36ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
36
exec $obj/r093d.qzc
36
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-36.sf
mv u093-delete-batch.sfd u093-delete-batch-36.sfd
mv u093-retain-batch.sf  u093-retain-batch-36.sf
mv u093-retain-batch.sfd u093-retain-batch-36.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_36
cat    r093a.txt r093b.txt > r093_36
#lp                           r093_36


echo
echo  'STAGE  2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 37 --'
echo

echo
echo  'PROGRAM "U093" NOW LOADING ...'

qtp << E_O_F
exec $obj/u093.qtc
37000000
37ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
37
exec $obj/r093d.qzc
37
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-37.sf
mv u093-delete-batch.sfd u093-delete-batch-37.sfd
mv u093-retain-batch.sf  u093-retain-batch-37.sf
mv u093-retain-batch.sfd u093-retain-batch-37.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_37
cat    r093a.txt r093b.txt > r093_37
#lp                           r093_37

echo
echo  'STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 41 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
41000000
41ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
41
exec $obj/r093d.qzc
41
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-41.sf
mv u093-delete-batch.sfd u093-delete-batch-41.sfd
mv u093-retain-batch.sf  u093-retain-batch-41.sf
mv u093-retain-batch.sfd u093-retain-batch-41.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_41
cat    r093a.txt r093b.txt > r093_41
#lp                           r093_41


echo
echo  'STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 42 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
42000000
42ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
42
exec $obj/r093d.qzc
42
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-42.sf
mv u093-delete-batch.sfd u093-delete-batch-42.sfd
mv u093-retain-batch.sf  u093-retain-batch-42.sf
mv u093-retain-batch.sfd u093-retain-batch-42.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_42
cat    r093a.txt r093b.txt > r093_42
#lp                           r093_42

echo
echo  'STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 43 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
43000000
43ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
43
exec $obj/r093d.qzc
43
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-43.sf
mv u093-delete-batch.sfd u093-delete-batch-43.sfd
mv u093-retain-batch.sf  u093-retain-batch-43.sf
mv u093-retain-batch.sfd u093-retain-batch-43.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_43
cat    r093a.txt r093b.txt > r093_43
#lp                           r093_43


echo
echo  'STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 44 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
44000000
44ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
44
exec $obj/r093d.qzc
44
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-44.sf
mv u093-delete-batch.sfd u093-delete-batch-44.sfd
mv u093-retain-batch.sf  u093-retain-batch-44.sf
mv u093-retain-batch.sfd u093-retain-batch-44.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_44
cat    r093a.txt r093b.txt > r093_44
#lp                           r093_44


echo
echo  'STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 45 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
45000000
45ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
45
exec $obj/r093d.qzc
45
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-45.sf
mv u093-delete-batch.sfd u093-delete-batch-45.sfd
mv u093-retain-batch.sf  u093-retain-batch-45.sf
mv u093-retain-batch.sfd u093-retain-batch-45.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_45
cat    r093a.txt r093b.txt > r093_45
#lp                           r093_45


echo
echo  'STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 46 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
46000000
46ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
46
exec $obj/r093d.qzc
46
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-46.sf
mv u093-delete-batch.sfd u093-delete-batch-46.sfd
mv u093-retain-batch.sf  u093-retain-batch-46.sf
mv u093-retain-batch.sfd u093-retain-batch-46.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_46
cat    r093a.txt r093b.txt > r093_46
#lp                           r093_46

 
echo
echo
echo  'STAGE  2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 60 --'
echo

echo
echo  'PROGRAM "U093" NOW LOADING ...'

qtp << E_O_F
exec $obj/u093.qtc
60000000
66ZZZ999
20160630
exit
E_O_F

quiz << E_O_F 
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
60
exec $obj/r093d.qzc
60
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-60.sf
mv u093-delete-batch.sfd u093-delete-batch-60.sfd
mv u093-retain-batch.sf  u093-retain-batch-60.sf
mv u093-retain-batch.sfd u093-retain-batch-60.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo
date
echo


rm >/dev/null  2>/dev/null   r093_60
cat    r093a.txt r093b.txt > r093_60
#lp                           r093_60

echo
echo
echo  'STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 68 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
68000000
68ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
68
exec $obj/r093d.qzc
68
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-68.sf
mv u093-delete-batch.sfd u093-delete-batch-68.sfd
mv u093-retain-batch.sf  u093-retain-batch-68.sf
mv u093-retain-batch.sfd u093-retain-batch-68.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_68
cat    r093a.txt r093b.txt > r093_68
#lp                           r093_68

echo
echo


echo  'STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 69 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
69000000
69ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
69
exec $obj/r093d.qzc
69
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-69.sf
mv u093-delete-batch.sfd u093-delete-batch-69.sfd
mv u093-retain-batch.sf  u093-retain-batch-69.sf
mv u093-retain-batch.sfd u093-retain-batch-69.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_69
cat    r093a.txt r093b.txt > r093_69
#lp                           r093_69

echo
echo
echo  'STAGE   2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 70 --'
echo

echo
echo  'PROGRAM "U093" NOW LOADING ...'

qtp << E_O_F
exec $obj/u093.qtc
70000000
75ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
70
exec $obj/r093d.qzc
70
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-70.sf
mv u093-delete-batch.sfd u093-delete-batch-70.sfd
mv u093-retain-batch.sf  u093-retain-batch-70.sf
mv u093-retain-batch.sfd u093-retain-batch-70.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo
date
echo


rm >/dev/null  2>/dev/null   r093_70
cat    r093a.txt r093b.txt > r093_70
#lp                           r093_70


echo
echo  'STAGE  2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 78 --'
echo

echo
echo  'PROGRAM "U093" NOW LOADING ...'

qtp << E_O_F
exec $obj/u093.qtc
78000000
78ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
78
exec $obj/r093d.qzc
78
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-78.sf
mv u093-delete-batch.sfd u093-delete-batch-78.sfd
mv u093-retain-batch.sf  u093-retain-batch-78.sf
mv u093-retain-batch.sfd u093-retain-batch-78.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_78
cat    r093a.txt r093b.txt > r093_78
#lp                           r093_78




echo
echo  'STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 79 --'
echo

echo
echo  'PROGRAM "U093" NOW LOADING ...'

qtp << E_O_F
exec $obj/u093.qtc
79000000
79ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
79
exec $obj/r093d.qzc
79
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-79.sf
mv u093-delete-batch.sfd u093-delete-batch-79.sfd
mv u093-retain-batch.sf  u093-retain-batch-79.sf
mv u093-retain-batch.sfd u093-retain-batch-79.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_79
cat    r093a.txt r093b.txt > r093_79
#lp                           r093_79

echo
echo  'STAGE  2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 80 --'
echo

echo
echo  'PROGRAM "U093" NOW LOADING ...'

qtp << E_O_F
exec $obj/u093.qtc
80000000
80ZZZ999
20160630
exit
E_O_F

quiz << E_O_F 
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
80
exec $obj/r093d.qzc
80
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-80.sf
mv u093-delete-batch.sfd u093-delete-batch-80.sfd
mv u093-retain-batch.sf  u093-retain-batch-80.sf
mv u093-retain-batch.sfd u093-retain-batch-80.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_80
cat    r093a.txt r093b.txt > r093_80
#lp                           r093_80


echo
echo
echo 'STAGE  2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 82 --'
echo

echo
echo  'PROGRAM "U093" NOW LOADING ...'

qtp << E_O_F
exec $obj/u093.qtc
82000000
82ZZZ999
20160630
exit
E_O_F

quiz << E_O_F 
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
82
exec $obj/r093d.qzc
82
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-82.sf
mv u093-delete-batch.sfd u093-delete-batch-82.sfd
mv u093-retain-batch.sf  u093-retain-batch-82.sf
mv u093-retain-batch.sfd u093-retain-batch-82.sfd


echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_82
cat    r093a.txt r093b.txt > r093_82
#lp                           r093_82

echo

echo
echo
echo 'STAGE   2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 84 --'
echo

echo
echo  'PROGRAM "U093" NOW LOADING ...'

qtp << E_O_F
exec $obj/u093.qtc
84000000
84ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
84
exec $obj/r093d.qzc
84
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-84.sf
mv u093-delete-batch.sfd u093-delete-batch-84.sfd
mv u093-retain-batch.sf  u093-retain-batch-84.sf
mv u093-retain-batch.sfd u093-retain-batch-84.sfd


echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_84
cat    r093a.txt r093b.txt > r093_84
#lp                           r093_84


echo
echo  'STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 86 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
86000000
86ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
86
exec $obj/r093d.qzc
86
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-86.sf
mv u093-delete-batch.sfd u093-delete-batch-86.sfd
mv u093-retain-batch.sf  u093-retain-batch-86.sf
mv u093-retain-batch.sfd u093-retain-batch-86.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_86
cat    r093a.txt r093b.txt > r093_86
#lp                           r093_86

echo
echo  'STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC --87 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
87000000
87ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
87
exec $obj/r093d.qzc
87
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-87.sf
mv u093-delete-batch.sfd u093-delete-batch-87.sfd
mv u093-retain-batch.sf  u093-retain-batch-87.sf
mv u093-retain-batch.sfd u093-retain-batch-87.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_87

ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_87
cat    r093a.txt r093b.txt > r093_87
#lp                           r093_87

echo
echo  'STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC --88 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
88000000
88ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
88
exec $obj/r093d.qzc
88
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-88.sf
mv u093-delete-batch.sfd u093-delete-batch-88.sfd
mv u093-retain-batch.sf  u093-retain-batch-88.sf
mv u093-retain-batch.sfd u093-retain-batch-88.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_88

ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_88
cat    r093a.txt r093b.txt > r093_88
#lp                           r093_88

echo
echo  'STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC --89 --'
echo

echo
echo  PROGRAM "U093" NOW LOADING ...

qtp << E_O_F
exec $obj/u093.qtc
89000000
89ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
89
exec $obj/r093d.qzc
89
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-89.sf
mv u093-delete-batch.sfd u093-delete-batch-89.sfd
mv u093-retain-batch.sf  u093-retain-batch-89.sf
mv u093-retain-batch.sfd u093-retain-batch-89.sfd

echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_89

ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_89
cat    r093a.txt r093b.txt > r093_89
#lp                           r093_89

echo
echo 'STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 91 --'
echo

echo
echo  'PROGRAM "U093" NOW LOADING ...'

qtp << E_O_F
exec $obj/u093.qtc
91000000
91ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
91
exec $obj/r093d.qzc
91
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-91.sf
mv u093-delete-batch.sfd u093-delete-batch-91.sfd
mv u093-retain-batch.sf  u093-retain-batch-91.sf
mv u093-retain-batch.sfd u093-retain-batch-91.sfd


echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_91
cat    r093a.txt r093b.txt > r093_91
#lp                           r093_91



echo
echo 'STAGE  2   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 92 --'
echo

echo
echo  'PROGRAM "U093" NOW LOADING ...'

qtp << E_O_F
exec $obj/u093.qtc
92000000
92ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
92
exec $obj/r093d.qzc
92
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-92.sf
mv u093-delete-batch.sfd u093-delete-batch-92.sfd
mv u093-retain-batch.sf  u093-retain-batch-92.sf
mv u093-retain-batch.sfd u093-retain-batch-92.sfd


echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_92
cat    r093a.txt r093b.txt > r093_92
#lp                           r093_92



echo
echo 'STAGE  2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 93 --'
echo

echo
echo  'PROGRAM "U093" NOW LOADING ...'

qtp << E_O_F
exec $obj/u093.qtc
93000000
93ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
93
exec $obj/r093d.qzc
93
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-93.sf
mv u093-delete-batch.sfd u093-delete-batch-93.sfd
mv u093-retain-batch.sf  u093-retain-batch-93.sf
mv u093-retain-batch.sfd u093-retain-batch-93.sfd


echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_93
cat    r093a.txt r093b.txt > r093_93
#lp                           r093_93


echo
echo 'STAGE  2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 94 --'
echo

echo
echo  'PROGRAM "U093" NOW LOADING ...'

qtp << E_O_F
exec $obj/u093.qtc
94000000
94ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
94
exec $obj/r093d.qzc
94
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-94.sf
mv u093-delete-batch.sfd u093-delete-batch-94.sfd
mv u093-retain-batch.sf  u093-retain-batch-94.sf
mv u093-retain-batch.sfd u093-retain-batch-94.sfd


echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_94
cat    r093a.txt r093b.txt > r093_94
#lp                           r093_94


echo
echo 'STAGE   2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 95 --'
echo

echo
echo  'PROGRAM "U093" NOW LOADING ...'

qtp << E_O_F
exec $obj/u093.qtc
95000000
95ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
95
exec $obj/r093d.qzc
95
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-95.sf
mv u093-delete-batch.sfd u093-delete-batch-95.sfd
mv u093-retain-batch.sf  u093-retain-batch-95.sf
mv u093-retain-batch.sfd u093-retain-batch-95.sfd


echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_95
cat    r093a.txt r093b.txt > r093_95
#lp                           r093_95


echo
echo 'STAGE  2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 96 --'
echo

echo
echo  'PROGRAM "U093" NOW LOADING ...'

qtp << E_O_F
exec $obj/u093.qtc
96000000
96ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
96
exec $obj/r093d.qzc
96
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-96.sf
mv u093-delete-batch.sfd u093-delete-batch-96.sfd
mv u093-retain-batch.sf  u093-retain-batch-96.sf
mv u093-retain-batch.sfd u093-retain-batch-96.sfd


echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_96
cat    r093a.txt r093b.txt > r093_96
#lp                           r093_96


echo
echo 'STAGE   2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 98 --'
echo

echo
echo  'PROGRAM "U093" NOW LOADING ...'

qtp << E_O_F
exec $obj/u093.qtc
98000000
98ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
98
exec $obj/r093d.qzc
98
exit
E_O_F
mv u093-delete-batch.sf  u093-delete-batch-98.sf
mv u093-delete-batch.sfd u093-delete-batch-98.sfd
mv u093-retain-batch.sf  u093-retain-batch-98.sf
mv u093-retain-batch.sfd u093-retain-batch-98.sfd


echo
ls -laF r093a.txt
ls -laF r093b.txt
echo

date


rm >/dev/null  2>/dev/null   r093_98
cat    r093a.txt r093b.txt > r093_98
#lp                           r093_98



echo
echo  'STAGE  3A - RUN VERIFY OF CLAIMS FOR A REPORT OF FILE AFTER DELETION .'

cobrun $obj/r071  2>&1 << R071_EXIT
20160630
Y
R071_EXIT

rm >/dev/null  2>/dev/null   r071_after
mv                      r071 r071_after

echo
ls -laF r071_after
echo
#lp      r071_after

echo
date
echo
echo  'STAGE   3B    - RUN "ALL_BATCHES" FOR REPORT OF FILE AFTER REPORT ...'

cobrun $obj/r001b

rm >/dev/null  2>/dev/null   r001b_after_r093
mv                     r001b r001b_after_r093

echo
ls -laF r001b_after_r093
echo
##lp      r001b_after_r093


echo
echo  'FINISHED ...'
