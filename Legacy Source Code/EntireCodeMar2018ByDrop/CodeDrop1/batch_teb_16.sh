#  Payroll Run 16 
#
cd $application_production
rm teb_16.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 16 - starting - `date`" > teb_16.log

echo "--- teb_yearend1 ---" >> teb_16.log
$cmd/teb1 201616 201601 1>>teb_16.log 2>&1

echo "--- teb_yearend2 ---" >> teb_16.log
$cmd/teb2 201616 201601 1>>teb_16.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_16.log
qtp auto=$obj/u090f.qtc 1>>teb_16.log 2>&1

echo "--- teb3 ---" >> teb_16.log
$cmd/teb3 201616 201601 1>>teb_16.log 2>&1

echo "Payroll Run 16 - ending - `date`" >> teb_16.log
#BATCH_EXIT
