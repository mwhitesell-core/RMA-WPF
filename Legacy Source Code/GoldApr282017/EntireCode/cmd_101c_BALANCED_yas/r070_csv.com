echo  "R070_CSV.COM"
echo  

echo  
echo  'CREATE  Accounts Receivable in Excel Report  for monthend '
echo 

echo 
echo  'PROGRAM "r070_csv.qzc" NOW LOADING ...'
echo 

quiz auto=$obj/r070a_csv.qzc  << E_O_F
${1} 
E_O_F

quiz auto=$obj/r070b_csv.qzc  
quiz auto=$obj/r070c_csv.qzc  

echo  
echo  'COPY r070a_csv.sf & r070_csv.txt into ME '

echo

cp  r070a_csv.sf  r070a_csv_me${1}.sf
cp  r070a_csv.sfd r070a_csv_me${1}.sfd
cp  r070_csv.txt  r070_csv_me${1}.txt
cp  r070_all.txt  r070_all_me${1}.txt



