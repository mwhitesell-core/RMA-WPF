echo  "DELETE_F001_CLAIMS_BATCHES"
echo

echo  'DELETE THE CLAIMS BATCHES FOR THE CLINIC'
echo
echo
echo  'N O T E : ! ! !  F001 MUST HAVE BEEN BACKED UP PRIOR TO THIS RUN ...'
echo
echo
echo  'HIT   "NEWLINE"   TO COMMENCE PROCEDURE ...'
read garbage
echo
echo  'STAGE  1  - RUN "ALL_BATCHES" FOR DUMP OF FILE BEFORE DELETION ...'

cd $pb_data

cp f001_batch_control_file        /foxtrot/purge/f001_batch_control_file_orig
cp f001_batch_control_file.idx    /foxtrot/purge/f001_batch_control_file_orig.idx

cd /charly/purge

cobrun $obj/r001b

rm   >/dev/null  2>/dev/null   r001b_before_r095
mv  r001b r001b_before_r095

echo
ls -laF r001b_before_r095
echo
echo  'HIT "NEWLINE" TO PRINT 'BEFORE' REPORT ...'
 read garbage

##lp r001b_before_r095

rm u095-retain-batch.sf*	> /dev/null 2>&1
rm u095-delete-batch.sf*	> /dev/null 2>&1
rm u095-purge-validate.sf*	> /dev/null 2>&1

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 22 --'
echo
echo  'HIT "NEWLINE" TO START DELETE PROGRAM...'
read garbage
echo
echo  'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
22000000
22ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
22
exit 
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_22
mv   r095.txt r095_22
#lp   r095_22

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 23 --'
echo

echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
23000000
23ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
23
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_23
mv   r095.txt r095_23
#lp   r095_23

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 24 --'
echo

echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
24000000
24ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
24
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_24
mv   r095.txt r095_24
#lp   r095_24

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 25 --'
echo

echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
25000000
25ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
25
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_25
mv   r095.txt r095_25
#lp   r095_25

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 26 --'
echo

echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
26000000
26ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
26
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_26
mv   r095.txt r095_26
#lp   r095_26


echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 30 --'
echo

echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
30000000
30ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
30
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_30
mv   r095.txt r095_30
#lp   r095_30


echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 31 --'
echo

echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
31000000
31ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
31
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_31
mv   r095.txt r095_31
#lp   r095_31

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 32 --'
echo

echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
32000000
32ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
32
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_32
mv   r095.txt r095_32
#lp   r095_32

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 33 --'
echo

echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
33000000
33ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
33
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_33
mv   r095.txt r095_33
#lp   r095_33

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 34 --'
echo

echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
34000000
34ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
34
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_34
mv   r095.txt r095_34
#lp   r095_34

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 35 --'
echo

echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
35000000
35ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
35
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_35
mv   r095.txt r095_35
#lp   r095_35

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 36 --'
echo

echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
36000000
36ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
36
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_36
mv   r095.txt r095_36
#lp   r095_36


echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 37 --'
echo

echo
echo  'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
37000000
37ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
37
exit
E_O_F


echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_37
mv   r095.txt r095_37
#lp   r095_37

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 41 --'
echo

echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
41000000
41ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
41
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_41
mv   r095.txt r095_41
#lp   r095_41

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 42 --'
echo

echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
42000000
42ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
42
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_42
mv   r095.txt r095_42
#lp   r095_42

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 43 --'
echo

echo
echo  'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
43000000
43ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
43
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_43
mv   r095.txt r095_43
#lp   r095_43

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 44 --'
echo

echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
44000000
44ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
44
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_44
mv   r095.txt r095_44
#lp   r095_44

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 45 --'
echo

echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
45000000
45ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
45
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_45
mv   r095.txt r095_45
#lp   r095_45

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 46 --'
echo

echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
46000000
46ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
46
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_46
mv   r095.txt r095_46
#lp   r095_46

echo
echo
echo  'STAGE 2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 60 --'
echo
echo  'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
60000000
66ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
60
exit 
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null  r095_60
mv   r095.txt r095_60
#lp   r095_60

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 68 --'
echo
echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
68000000
68ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
68
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_68
mv   r095.txt r095_68
#lp   r095_68

echo
echo

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 69 --'
echo
echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
69000000
69ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
69
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_69
mv   r095.txt r095_69
#lp   r095_69

echo
echo
echo  'STAGE 2 - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 70 --'
echo
echo  'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
70000000
75ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
70
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null  r095_70
mv   r095.txt r095_70
#lp   r095_70

echo
echo  'STAGE 2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 78 --'
echo

echo
echo  'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
78000000
78ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
78
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_78
mv   r095.txt r095_78
#lp   r095_78

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 79 --'
echo
echo
echo  'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
79000000
79ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
79
exit
E_O_F


echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_79
mv   r095.txt r095_79
#lp   r095_79

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 80 --'
echo

echo
echo  'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
80000000
80ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
80
exit 
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_80
mv   r095.txt r095_80
#lp   r095_80

echo
echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 82 --'
echo
echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
82000000
82ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
82
exit 
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_82
mv   r095.txt r095_82
#lp   r095_82

echo
echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 84 --'
echo
echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
84000000
84ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
84
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_84
mv   r095.txt r095_84
#lp   r095_84

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 86 --'
echo
echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
86000000
86ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
86
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_86
mv   r095.txt r095_86
#lp   r095_86

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 87 --'
echo
echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
87000000
87ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
87
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_87
mv   r095.txt r095_87
#lp   r095_87

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 88 --'
echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
88000000
88ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
88
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_88
mv   r095.txt r095_88
#lp   r095_88

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 89 --'
echo
echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
89000000
89ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
89
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_89
mv   r095.txt r095_89
#lp   r095_89

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 91 --'
echo
echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
91000000
91ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
91
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_91
mv   r095.txt r095_91
#lp   r095_91

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 92 --'
echo
echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
92000000
92ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
92
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_92
mv   r095.txt r095_92
#lp   r095_92

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 93 --'
echo
echo
echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
93000000
93ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
93
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_93
mv   r095.txt r095_93
#lp   r095_93

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 94 --'
echo

echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
94000000
94ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
94
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_94
mv   r095.txt r095_94
#lp   r095_94

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 95 --'
echo

echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
95000000
95ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
95
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_95
mv   r095.txt r095_95
#lp   r095_95

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 96 --'
echo

echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
96000000
96ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
96
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_96
mv   r095.txt r095_96
#lp   r095_96

echo
echo  'STAGE  2  - RUN "CLAIMS" BATCH DELETION PROGRAM FOR CLINIC -- 98 --'
echo

echo 'PROGRAM "U095" NOW LOADING ...'

qtp << E_O_F
exec $obj/u095.qtc
98000000
98ZZZ999
20160630
exit
E_O_F

quiz << E_O_F
exe $obj/r095a.qzc
exe $obj/r095b.qzc
exe $obj/r095c.qzc
98
exit
E_O_F

echo
ls -laF r095.txt
echo

rm   >/dev/null  2>/dev/null   r095_98
mv   r095.txt r095_98
#lp   r095_98

echo
echo  'STAGE   3   - RUN "ALL_BATCHES" FOR DUMP OF FILE AFTER DELETION ...'

cobrun $obj/r001b

rm   >/dev/null  2>/dev/null   r001b_after_r095
mv    r001b r001b_after_r095

echo
ls -laF r001b_after_r095
echo

##lp         r001b_after_r095
echo
echo  'FINISHED ...'
