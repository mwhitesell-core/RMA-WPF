echo  "CLAIMS_MSTR_VERIFY_OLD"
echo  

echo  A/R FILE PURGE STAGE # 3
echo 
#echo  HIT "NEWLINE" TO VERIFY 'OLD' CLAIMS MSTR
# read garbage
echo 
echo  PROGRAM "R071" NOW LOADING ...

### comment out the r071 if it is run after batch control purge
###    since it is run after batch control purge and cp r071_after
###    from batch adj purge to be r071_before_claims_purge 

cd /charly/purge

##  2012/01/23 - if claim purge at yearend time, the following section can be commented out
##------------------------

cobrun $obj/r001

##  create records in f002 shadow for the current cycle claims with agent 4 or 6
##  so that it should balance between rv071 & r071

qtp auto=$obj/u020_shdw.qtc > u020_shdw.log

##-----------------------

####cp r071_after r071_before_claims_purge 

cobrun $obj/r071 << COBOL_EXIT
20150630
Y
COBOL_EXIT


bcheck -n $pb_data/f002_claim_shadow > rv071_before

echo 
ls -laF r071
echo 
date 

mv r071 r071_before_claims_purge
lp      r071_before_claims_purge
lp rv071_before

