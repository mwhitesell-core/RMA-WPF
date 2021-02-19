echo  "R005_CSV.COM"
echo  

echo  
echo  'CREATE  r005_dtl.sf & r005_summ.sf for monthend '
echo 

echo 
echo  'PROGRAM "r005_csv.qtc" NOW LOADING ...'
echo 

qtp auto=$obj/r005_csv.qtc  << E_O_F
${1} 
E_O_F

echo  
echo  'COPY r005_dtl.sf & r005_summ.sf into ME '
echo

cp  r005_dtl.sf   r005_dtl_me${1}.sf
cp  r005_summ.sf  r005_summ_me${1}.sf



