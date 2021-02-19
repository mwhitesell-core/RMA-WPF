
# macro: agep_part3 
# 2013/Sep/11 M.C. To delete the undefined doctor payment claim and reduce the pay amount in f001 file
#                  based on the subfile r030r_undefined_doc that is generated from r030r2.qzc if exists


date

cd $application_production

echo Current Directory:
pwd


echo 
echo  start of the run for AGEP payment PART 3                     
echo 

echo "Running delete undefined doc pay claim   "

qtp auto=$obj/u031.qtc

echo 
echo  end of the run for AGEP payment PART 3
echo 
date

