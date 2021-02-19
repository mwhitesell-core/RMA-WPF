echo  "CLAIMS_MSTR_VERIFY_NEW"
echo  

echo  A/R FILE PURGE STAGE # 4                
echo  NOTE -- STAGE #2 MUST HAVE COMPLETED NEW THIS RUN !!!
echo 
#echo  HIT "NEWLINE" TO VERIFY 'NEW' CLAIMS MSTR
#read garbage
echo 
echo  PROGRAM "R073" NOW LOADING ...

cd  /charly/purge

cobrun $obj/r073  << COBOL_EXIT
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
