#  Payroll Run 20 
#
cd $application_production
rm teb_20.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 20 - starting - `date`" > teb_20.log

echo "--- teb_yearend1 ---" >> teb_20.log
$cmd/teb1 201620 201601 1>>teb_20.log 2>&1

echo "--- teb_yearend2 ---" >> teb_20.log
$cmd/teb2 201620 201601 1>>teb_20.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_20.log
qtp auto=$obj/u090f.qtc 1>>teb_20.log 2>&1

echo "--- teb3 ---" >> teb_20.log
$cmd/teb3 201620 201601 1>>teb_20.log 2>&1


echo "Payroll Run 20 - ending - `date`" >> teb_20.log
#BATCH_EXIT
