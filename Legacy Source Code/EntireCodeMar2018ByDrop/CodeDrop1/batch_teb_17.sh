#  Payroll Run 17 
#
cd $application_production
rm teb_17.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 17 - starting - `date`" > teb_17.log

echo "--- teb_yearend1 ---" >> teb_17.log
$cmd/teb1 201617 201601 1>>teb_17.log 2>&1

echo "--- teb_yearend2 ---" >> teb_17.log
$cmd/teb2 201617 201601 1>>teb_17.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_17.log
qtp auto=$obj/u090f.qtc 1>>teb_17.log 2>&1

echo "--- teb3 ---" >> teb_17.log
$cmd/teb3 201617 201601 1>>teb_17.log 2>&1

echo "Payroll Run 17 - ending - `date`" >> teb_17.log
#BATCH_EXIT
