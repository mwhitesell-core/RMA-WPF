# macro: verify_doctor_premiums   
# 2013/Sep/11 M.C. consolidate r031a_AGE3/AGEP/MOHR/MOHD  into r031a.dat, determine if any UNDEFINED doctors 
# 2014/May/08 NC1  delete r031b*.txt before execution
date

cd $application_production

echo Current Directory:
pwd

#MC1
rm r031b.txt
rm r031b_undefined_doc.txt

cat r031a_AGE3.dat r031a_AGEP.dat r031a_MOHR.dat  r031a_MOHD?.dat  > r031a.dat

echo 
echo  execute powerhouse program r031_before_update_3.qzc  
echo 
quiz auto=$obj/r031_before_update_3.qzc

mv r031b.txt r031b_undefined_doc.txt
#lp r031b_undefined_doc.txt   
echo Do NOT continue if the below report is NOT EMPTY
pg r031b_undefined_doc.txt   

echo 
echo 
date

