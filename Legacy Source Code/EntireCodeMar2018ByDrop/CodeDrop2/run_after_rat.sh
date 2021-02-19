echo Start Time is `date`

cd /foxtrot/purge

echo Start Time is `date`                  > checkf002tech_servdate.log

qtp auto=$obj/checkf002tech_serv_date.qtc >> checkf002tech_servdate.log

quiz auto=$src/diffamt.qzs                >> checkf002tech_servdate.log

quiz auto=$src/diffdate.qzs               >> checkf002tech_servdate.log

echo End Time is `date`                   >> checkf002tech_servdate.log

mv diffamt.txt  diffamt.txt_`date '+20%y%m%d'`  2> /dev/null
mv diffdate.txt diffdate.txt_`date '+20%y%m%d'` 2> /dev/null
mv checkf002tech_servdate.log  checkf002tech_servdate.log_`date '+20%y%m%d'`

echo End Time is `date`

cd $application_production
