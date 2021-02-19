#  Payroll Run 15 
#
cd $application_production
rm teb_15.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 15 - starting - `date`" > teb_15.log

echo "--- teb_yearend1 ---" >> teb_15.log
$cmd/teb1 201615 201601 1>>teb_15.log 2>&1

echo "--- teb_yearend2 ---" >> teb_15.log
$cmd/teb2 201615 201601 1>>teb_15.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_15.log
qtp auto=$obj/u090f.qtc 1>>teb_15.log 2>&1

echo "--- teb3 ---" >> teb_15.log
$cmd/teb3 201615 201601 1>>teb_15.log 2>&1

echo "Payroll Run 15 - ending - `date`" >> teb_15.log
#BATCH_EXIT
