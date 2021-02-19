# 
# 98/jun/29 B.E.	added delete of u010_out_file after processing
# 2001/oct/17 M.C.  	convert r010 from cobol to powerhouse  
#

echo "R010 BEGINNING" `date`

echo "Running r010cycle ..." 
cd $application_production

mv r010daily_cycle.sf r010cycle.sf
cp r010daily.sfd      r010cycle.sfd
mv extf001aa_cycle.sf extf001aacycle.sf
cp extf001aa.sfd      extf001aacycle.sfd
mv extf001_cycle.sf   extf001cycle.sf
cp extf001.sfd        extf001cycle.sfd

quiz auto=$obj/r010cycle.qzu  >> r010cycle.log

#lp r010cycle.txt

echo "R010 ENDING" `date`
