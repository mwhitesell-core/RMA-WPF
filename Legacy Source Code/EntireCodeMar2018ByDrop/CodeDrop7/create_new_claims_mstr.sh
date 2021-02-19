echo  "CREATE_NEW_CLAIMS_MSTR"
#  modification history
#  2002/jul/06 B.E. - changed to put orig claim and processing of subifle
#		     on /dyad/purge disk
#  2002/nov/14 M.C. - include clinic 95 as well  
#  2003/Jun/16 yas  - include clinics 91,92,93,94 and 96
#  2005/jul/06 M.C. - changed to put orig claim and processing of subfile
#		      on /charly/purge disk
#  2006/Jun/29 yas  - include clinic 98                     
#  2011/Feb/16 yas  - comment out the printing of the reports
#  2011/Feb/17 MC1  - move the 3 files from /charly to /foxtrot instead as suggested by Brad
#  2011/Feb/22 MC2  - save f002_claims_extra & f085_rejected_claims as well in /foxtrot       
#  2011/Feb/22 yas  - include "claims_mstr_verify_new" in this macro  
#  2011/May/10 MC3  - copy f002_claims_extra & f085_rejected_claims instead of move
#		      unload & reload f002_claims_extra & f085_rejected_claims	
#  2011/Jun/06 MC4  - save f071 & f099 files as well in /foxtrot and  unload & reload f071 & f099 files  
#  2014/Oct/02 MC5  - generate r072_all.txt  for all clinics - run before each individual clinic  
#  2015/Jan/21 yas  - add new group H290 - clinic 30                                                                  
#  2015/Feb/11 MC6  - add f002-outstanding in /foxtrot/purge
#  2015/Jun/25 yas  - add clinic 26  
#  2015/Jun/29 MC7  - move f002-outstanding in  /foxtrot/purge with orig like other files, make correction
#		      on printing r072_all.txt, comment out 'rm *.dat' because create_links.com will 'rm *.dat'

echo
echo  A/R FILE PURGE STAGE # 1 

cd /charly/purge

$cmd/claims_mstr_verify_old    


echo
echo  A/R FILE PURGE STAGE # 2
#echo  NOTE -- THE PREVIOUS STAGE(S) MUST HAVE BEEN RUN !!!
echo
echo  CREATE NEW FILE AND MOVE 'BALANCE-OWING' CLAIMS FROM OLD TO NEW FILE
echo
echo  NOTE !!
echo  NO ONE MUST BE ACCESSING THE CLAIMS FILE !!!
echo
echo
echo  CREATING THE NEW CLAIMS MASTER FILE \"F002_CLAIMS_MSTR_NEW\" ...
echo

cd /charly/purge

echo  CREATING THE NEW CLAIM SHADOW  FILE \"F002_CLAIM_SHADOW_NEW\" ...
echo

echo
echo  PROGRAM \"u072\" NOW LOADING ...

echo Starting u072 Time is `date`

qtp << E_O_F
exec $obj/u072.qtc
20150630
exit
E_O_F

echo Ending u072 Time is `date`

#############################################################################

# MC5

echo Starting r072a/b/c_all    Time is `date`
quiz << E_O_F
exec $obj/r072a_all.qzc
exec $obj/r072b_all.qzc
exec $obj/r072c_all.qzc
exit
E_O_F

# MC7
##lp r072_all
#lp r072_all.txt

echo Ending r072a/b/c_all      Time is `date`

#############################################################################



echo Starting u072 split Files Time is `date`

qtp << E_O_F
exec $obj/u072_retain_1.qtc
exec $obj/u072_retain_2.qtc
exec $obj/u072_delete_1.qtc
exec $obj/u072_delete_2.qtc
exit
E_O_F

echo Ending u072 split Files Time is `date`


#############################################################################

# save the original subfiles
mv u072-retain-claim-hdr.sf     u072-retain-claim-hdr-orig.sf
mv u072-retain-claim-hdr.sfd    u072-retain-claim-hdr-orig.sfd
mv u072-delete-claim-hdr.sf     u072-delete-claim-hdr-orig.sf
mv u072-delete-claim-hdr.sfd    u072-delete-claim-hdr-orig.sfd

echo Starting r072_22 to r072_98 reports Time is `date`

cp u072-retain-claim-hdr-22.sf   u072-retain-claim-hdr.sf
cp u072-retain-claim-hdr-22.sfd  u072-retain-claim-hdr.sfd
cp u072-delete-claim-hdr-22.sf   u072-delete-claim-hdr.sf
cp u072-delete-claim-hdr-22.sfd  u072-delete-claim-hdr.sfd

quiz << E_O_F
exec $obj/r072a.qzc
22
exec $obj/r072b.qzc
22
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_22
rm r072?.txt
#lp r072_22

cp u072-retain-claim-hdr-23.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-23.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
23
exec $obj/r072b.qzc
23
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_23
rm r072?.txt
#lp r072_23

cp u072-retain-claim-hdr-24.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-24.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
24
exec $obj/r072b.qzc
24
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_24
rm r072?.txt
#lp r072_24

cp u072-retain-claim-hdr-25.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-25.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
25
exec $obj/r072b.qzc
25
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_25
rm r072?.txt
#lp r072_25

cp u072-retain-claim-hdr-26.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-26.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
26
exec $obj/r072b.qzc
26
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_26
rm r072?.txt
#lp r072_26


cp u072-retain-claim-hdr-30.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-30.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
30
exec $obj/r072b.qzc
30
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_30
rm r072?.txt
#lp r072_30

cp u072-retain-claim-hdr-31.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-31.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
31
exec $obj/r072b.qzc
31
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_31
rm r072?.txt
#lp r072_31

cp u072-retain-claim-hdr-32.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-32.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
32
exec $obj/r072b.qzc
32
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_32
rm r072?.txt
#lp r072_32

cp u072-retain-claim-hdr-33.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-33.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
33
exec $obj/r072b.qzc
33
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_33
rm r072?.txt
#lp r072_33

cp u072-retain-claim-hdr-34.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-34.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
34
exec $obj/r072b.qzc
34
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_34
rm r072?.txt
#lp r072_34

cp u072-retain-claim-hdr-35.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-35.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
35
exec $obj/r072b.qzc
35
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_35
rm r072?.txt
#lp r072_35

cp u072-retain-claim-hdr-36.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-36.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
36
exec $obj/r072b.qzc
36
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_36
rm r072?.txt
#lp r072_36

cp u072-retain-claim-hdr-37.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-37.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
37
exec $obj/r072b.qzc
37
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_37
rm r072?.txt
#lp r072_37

cp u072-retain-claim-hdr-41.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-41.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
41
exec $obj/r072b.qzc
41
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_41
rm r072?.txt
#lp r072_41

cp u072-retain-claim-hdr-42.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-42.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
42
exec $obj/r072b.qzc
42
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_42
rm r072?.txt
#lp r072_42

cp u072-retain-claim-hdr-43.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-43.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
43
exec $obj/r072b.qzc
43
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_43
rm r072?.txt
#lp r072_43

cp u072-retain-claim-hdr-44.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-44.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
44
exec $obj/r072b.qzc
44
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_44
rm r072?.txt
#lp r072_44

cp u072-retain-claim-hdr-45.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-45.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
45
exec $obj/r072b.qzc
45
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_45
rm r072?.txt
#lp r072_45

cp u072-retain-claim-hdr-46.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-46.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
46
exec $obj/r072b.qzc
46
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_46
rm r072?.txt
#lp r072_46

cp u072-retain-claim-hdr-61.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-61.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
61
exec $obj/r072b.qzc
61
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_61
rm r072?.txt
#lp r072_61

cp u072-retain-claim-hdr-62.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-62.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
62
exec $obj/r072b.qzc
62
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_62
rm r072?.txt
#lp r072_62

cp u072-retain-claim-hdr-63.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-63.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
63
exec $obj/r072b.qzc
63
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_63
rm r072?.txt
#lp r072_63

cp u072-retain-claim-hdr-64.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-64.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
64
exec $obj/r072b.qzc
64
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_64
rm r072?.txt
#lp r072_64

cp u072-retain-claim-hdr-65.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-65.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
65
exec $obj/r072b.qzc
65
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_65
rm r072?.txt
#lp r072_65

cp u072-retain-claim-hdr-66.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-66.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
66
exec $obj/r072b.qzc
66
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_66
rm r072?.txt
#lp r072_66

cp u072-retain-claim-hdr-68.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-68.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
68
exec $obj/r072b.qzc
68
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_68
rm r072?.txt
#lp r072_68


cp u072-retain-claim-hdr-69.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-69.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
69
exec $obj/r072b.qzc
69
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_69
rm r072?.txt
#lp r072_69

cp u072-retain-claim-hdr-71.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-71.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
71
exec $obj/r072b.qzc
71
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_71
rm r072?.txt
#lp r072_71

cp u072-retain-claim-hdr-72.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-72.sf   u072-delete-claim-hdr.sf


quiz << E_O_F
exec $obj/r072a.qzc
72
exec $obj/r072b.qzc
72
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_72
rm r072?.txt
#lp r072_72

cp u072-retain-claim-hdr-73.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-73.sf   u072-delete-claim-hdr.sf


quiz << E_O_F
exec $obj/r072a.qzc
73
exec $obj/r072b.qzc
73
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_73
rm r072?.txt
#lp r072_73

cp u072-retain-claim-hdr-74.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-74.sf   u072-delete-claim-hdr.sf


quiz << E_O_F
exec $obj/r072a.qzc
74
exec $obj/r072b.qzc
74
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_74
rm r072?.txt
#lp r072_74

cp u072-retain-claim-hdr-75.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-75.sf   u072-delete-claim-hdr.sf


quiz << E_O_F
exec $obj/r072a.qzc
75
exec $obj/r072b.qzc
75
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_75
rm r072?.txt
#lp r072_75

cp u072-retain-claim-hdr-78.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-78.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
78
exec $obj/r072b.qzc
78
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_78
rm r072?.txt
#lp r072_78

cp u072-retain-claim-hdr-79.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-79.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
79
exec $obj/r072b.qzc
79
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_79
rm r072?.txt
#lp r072_79

cp u072-retain-claim-hdr-80.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-80.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
80
exec $obj/r072b.qzc
80
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_80
rm r072?.txt
#lp r072_80

cp u072-retain-claim-hdr-82.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-82.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
82
exec $obj/r072b.qzc
82
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_82
rm r072?.txt
#lp r072_82

cp u072-retain-claim-hdr-84.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-84.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
84
exec $obj/r072b.qzc
84
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_84
rm r072?.txt
#lp r072_84

cp u072-retain-claim-hdr-86.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-86.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
86
exec $obj/r072b.qzc
86
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_86
rm r072?.txt
#lp r072_86

cp u072-retain-claim-hdr-87.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-87.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
87
exec $obj/r072b.qzc
87
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_87
rm r072?.txt
#lp r072_87

cp u072-retain-claim-hdr-88.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-88.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
88
exec $obj/r072b.qzc
88
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_88
rm r072?.txt
#lp r072_88

cp u072-retain-claim-hdr-89.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-89.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
89
exec $obj/r072b.qzc
89
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_89
rm r072?.txt
#lp r072_89

cp u072-retain-claim-hdr-91.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-91.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
91
exec $obj/r072b.qzc
91
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_91
rm r072?.txt
#lp r072_91

cp u072-retain-claim-hdr-92.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-92.sf   u072-delete-claim-hdr.sf


quiz << E_O_F
exec $obj/r072a.qzc
92
exec $obj/r072b.qzc
92
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_92
rm r072?.txt
#lp r072_92

cp u072-retain-claim-hdr-93.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-93.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
93
exec $obj/r072b.qzc
93
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_93
rm r072?.txt
#lp r072_93

cp u072-retain-claim-hdr-94.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-94.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
94
exec $obj/r072b.qzc
94
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_94
rm r072?.txt
#lp r072_94

cp u072-retain-claim-hdr-95.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-95.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
95
exec $obj/r072b.qzc
95
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_95
rm r072?.txt
#lp r072_95

cp u072-retain-claim-hdr-96.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-96.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
96
exec $obj/r072b.qzc
96
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_96
rm r072?.txt
#lp r072_96

cp u072-retain-claim-hdr-98.sf   u072-retain-claim-hdr.sf
cp u072-delete-claim-hdr-98.sf   u072-delete-claim-hdr.sf

quiz << E_O_F
exec $obj/r072a.qzc
98
exec $obj/r072b.qzc
98
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
E_O_F

cat r072a.txt r072b.txt r072c.txt > r072_98
rm r072?.txt
#lp r072_98

echo Ending r072_22 to r072_98 reports Time is `date`

#############################################################################

#  rename the original subfiles before recreating the new claims mstr  

mv u072-retain-claim-hdr-orig.sf     u072-retain-claim-hdr.sf
mv u072-retain-claim-hdr-orig.sfd    u072-retain-claim-hdr.sfd
mv u072-delete-claim-hdr-orig.sf     u072-delete-claim-hdr.sf
mv u072-delete-claim-hdr-orig.sfd    u072-delete-claim-hdr.sfd


cd $pb_data

mv f002_claims_mstr              /foxtrot/purge/f002_claims_mstr_orig
mv f002_claims_mstr.idx          /foxtrot/purge/f002_claims_mstr_orig.idx
mv f002_claim_shadow             /foxtrot/purge/f002_claim_shadow_orig
mv f002_claim_shadow.idx         /foxtrot/purge/f002_claim_shadow_orig.idx

# MC7
##rm f002_claims_mstr.dat
##rm f002_claim_shadow.dat


. ./createfiles.com

# MC6

#############################################################################

# MC7
##mv f002_outstanding.dat  	 /foxtrot/purge/f002_outstanding.dat
##mv f002_outstanding.idx        /foxtrot/purge/f002_outstanding.idx
mv f002_outstanding.dat  	 /foxtrot/purge/f002_outstanding_orig.dat
mv f002_outstanding.idx          /foxtrot/purge/f002_outstanding_orig.idx

qutil << qutil_exit
create file f002-outstanding
qutil_exit

#############################################################################

# 2011/feb/22  - save the following two files as well

cp f002_claims_extra 	      /foxtrot/purge/f002_claims_extra_orig
cp f002_claims_extra.idx      /foxtrot/purge/f002_claims_extra_orig.idx  
cp f085_rejected_claims       /foxtrot/purge/f085_rejected_claims_orig
cp f085_rejected_claims.idx   /foxtrot/purge/f085_rejected_claims_orig.idx
 
# 2011/Jun/06  - save the following two files as well

cp f071_client_rma_claim_nbr       /foxtrot/purge/f071_client_rma_claim_nbr_orig
cp f071_client_rma_claim_nbr.idx   /foxtrot/purge/f071_client_rma_claim_nbr_orig.idx
cp f099_group_claim_mstr.dat       /foxtrot/purge/f099_group_claim_mstr_orig.dat
cp f099_group_claim_mstr.idx       /foxtrot/purge/f099_group_claim_mstr_orig.idx

#############################################################################

echo Starting u072a Time is `date`

cd /charly/purge

qtp auto=$obj/u072a.qtc

echo Ending u072a Time is `date`

#ls -l  ru072
#lp ru072

#############################################################################
#following "claims_mstr_verify_new" is add Feb 22, 2011

echo Starting r073 Time is `date`

echo  "CLAIMS_MSTR_VERIFY_NEW"

cd  /charly/purge

cobrun $obj/r073 << COBOL_EXIT
20150630
Y
COBOL_EXIT

bcheck -n $pb_data/f002_claim_shadow > rv073_after

echo
ls -laF r073
echo
date

mv r073 r073_after_claims_purge
lp r073 r073_after_claims_purge
lp rv073_after

echo Ending r073 Time is `date`

## the followings are added by MC on 2011/May/10
#############################################################################
echo Starting time to unload f002extra and f085 files `date`

quiz auto=$obj/unlof002extra.qzc
quiz auto=$obj/unlof085.qzc

cd $pb_data

rm f002_claims_extra.idx
rm f002_claims_extra 

# MC7
##rm f002_claims_extra.dat
 
rm f085_rejected_claims.idx
rm f085_rejected_claims
# MC7
##rm f085_rejected_claims.dat

. ./createfiles.com

cd /charly/purge

qtp auto=$obj/relof002extra.qtc
qtp auto=$obj/relof085.qtc

echo Ending time to reload f002extra and f085 files `date`

## the followings are added by MC on 2011/Jun/06
#############################################################################
echo Starting time to unload f071 and f099 files `date`

quiz auto=$obj/unlof071.qzc 
quiz auto=$obj/unlof099.qzc

cd $pb_data

rm f071_client_rma_claim_nbr.idx
rm f071_client_rma_claim_nbr
# MC7 
##rm f071_client_rma_claim_nbr.dat

rm f099_group_claim_mstr.dat 
rm f099_group_claim_mstr.idx 

. ./createfiles.com

qutil << qutil_exit
create file f099-group-claim-mstr
qutil_exit

cd /charly/purge

qtp auto=$obj/relof071.qtc 
qtp auto=$obj/relof099.qtc

echo Ending time to reload f071 and  f099 files  `date`

