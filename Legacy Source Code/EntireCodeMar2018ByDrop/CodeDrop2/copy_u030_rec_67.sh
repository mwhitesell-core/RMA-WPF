# macro: copy_u030_rec_67
# 07/Feb/08 M.C. copy all u030-tape-67-file from each clinic directory into production
# 2009/Jul/09 Yas. - Added clinics 78 79 and 88
# 2013/May/16 MC1  - exec $obj/r031b_agep.qzu for 2 passes instead of $obj/r031b_agep.qzc

cd $application_production
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
22
quiz_exit

echo Current Directory:
pwd

echo 
echo   append 67  file from each clinic into production r031_agep subfile
echo 

cd $application_production/23
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
23
quiz_exit

cd $application_production/24
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
24
quiz_exit

cd $application_production/25
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
25
quiz_exit

cd $application_production/26
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
26
quiz_exit

cd $application_production/30
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
30
quiz_exit

cd $application_production/31
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
31
quiz_exit

cd $application_production/32
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
32
quiz_exit

cd $application_production/33
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
33
quiz_exit

cd $application_production/34
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
34
quiz_exit

cd $application_production/35
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
35
quiz_exit

cd $application_production/36
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
36
quiz_exit

cd $application_production/37
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
37
quiz_exit

cd $application_production/41
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
41
quiz_exit

cd $application_production/42
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
42
quiz_exit

cd $application_production/43
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
43
quiz_exit

cd $application_production/44
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
44
quiz_exit

cd $application_production/45
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
45
quiz_exit

cd $application_production/46
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
46
quiz_exit

cd $application_production/61
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
61
quiz_exit

cd $application_production/62
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
62
quiz_exit

cd $application_production/63
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
63
quiz_exit

cd $application_production/64
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
64
quiz_exit

cd $application_production/65
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
65
quiz_exit

cd $application_production/66
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
66
quiz_exit

cd $application_production/71
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
71
quiz_exit

cd $application_production/72
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
72
quiz_exit

cd $application_production/73
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
73
quiz_exit

cd $application_production/74
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
74
quiz_exit

cd $application_production/75
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
75
quiz_exit

cd $application_production/78
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
78
quiz_exit

cd $application_production/79
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
79
quiz_exit

cd $application_production/84
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
84
quiz_exit

cd $application_production/88
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
88
quiz_exit

cd $application_production/96
rm r031a_agep.sf* 2>/dev/null
quiz << quiz_exit
exec $obj/r031a_agep
96
quiz_exit


cd $application_production
quiz auto=$obj/r031b_agep.qzu

echo 
echo  end of the run 
echo 
date

