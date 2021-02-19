# process AGEP payments from u030-tape-8-file RA file
# 2006/nov/06 b.e. - added multi-clinic processing
# 2009/Mar/05 yas  - added clinics 37 and 84      
# 2009/Mar/26 yas  - added clinics 61-65 and 71-75
# 2009/Apr/09 M.C. - change to 'rm r031a.txt' instead of 'rm r031*'
# 2009/Jul/09 Yas. - Added clinics 78 79 and 88
# 2010/Feb/10 Yas. - Add clinc 66 same as 61-65 
# 2011/Jan/11 Yas. - Add clinc 23 same as 22    
# 2012/Jan/23 Yas. - Add clinc 24 same as 22    
# 2012/Jun/08 Yas. - Add clinc 25 same as 22    
# 2014/Oct/17 Yas. - Add clinc 30 same as 31               
# 2015/Mar/10 Yas. - Add clinc 26 same as 23

echo 
echo Processing clinic 22 ...
cd $pb_prod
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo 
echo 

echo Processing clinic 23 ...
cd $pb_prod/23
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

echo Processing clinic 24 ...
cd $pb_prod/24
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

echo Processing clinic 25 ...
cd $pb_prod/25
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

echo Processing clinic 26 ...
cd $pb_prod/26
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

echo Processing clinic 30 ...
cd $pb_prod/30
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

echo Processing clinic 31 ...
cd $pb_prod/31
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo 
echo 

echo Processing clinic 32 ...
cd $pb_prod/32
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo 
echo 

echo Processing clinic 33 ...
cd $pb_prod/33
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo 
echo 

echo Processing clinic 34 ...
cd $pb_prod/34
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo 
echo 

echo Processing clinic 35 ...
cd $pb_prod/35
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo 
echo 

echo Processing clinic 36 ...
cd $pb_prod/36
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo 
echo 

echo Processing clinic 37 ...
cd $pb_prod/37
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

echo Processing clinic 41 ...
cd $pb_prod/41
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo 
echo 

echo Processing clinic 42 ...
cd $pb_prod/42
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo 
echo 

echo Processing clinic 43 ...
cd $pb_prod/43
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo 
echo 

echo Processing clinic 44 ...
cd $pb_prod/44
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo 
echo 

echo Processing clinic 45 ...
cd $pb_prod/45
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo 
echo 

echo Processing clinic 46 ...
cd $pb_prod/46
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo 
echo 

echo Processing clinic 61 ...
cd $pb_prod/61
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

echo Processing clinic 62 ...
cd $pb_prod/62
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

echo Processing clinic 63 ...
cd $pb_prod/63
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

echo Processing clinic 64 ...
cd $pb_prod/64
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

#echo Processing clinic 65 ...
#cd $pb_prod/65
#rm r031a.txt
#quiz auto=$obj/r031a.qzc
#echo
#echo

echo Processing clinic 66 ...
cd $pb_prod/66
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

echo Processing clinic 71 ...
cd $pb_prod/71
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

echo Processing clinic 72 ...
cd $pb_prod/72
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

echo Processing clinic 73 ...
cd $pb_prod/73
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

echo Processing clinic 74 ...
cd $pb_prod/74
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

echo Processing clinic 75 ...
cd $pb_prod/75
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

echo Processing clinic 78 ...
cd $pb_prod/78
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

#echo Processing clinic 79 ...
#cd $pb_prod/79
#rm r031a.txt
#quiz auto=$obj/r031a.qzc
#echo
#echo

echo Processing clinic 84 ...
cd $pb_prod/84
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

echo Processing clinic 88 ...
cd $pb_prod/88
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

echo Processing clinic 96 ...
cd $pb_prod/96
rm r031a.txt
quiz auto=$obj/r031a.qzc
echo
echo

echo Done!
