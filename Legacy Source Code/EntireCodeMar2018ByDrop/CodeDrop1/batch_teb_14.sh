#  Payroll Run 14 
#
cd $application_production
rm teb_14.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 14 - starting - `date`" > teb_14.log

echo "--- teb_yearend1 ---" >> teb_14.log
$cmd/teb1 201614 201601 1>>teb_14.log 2>&1

echo "--- teb_yearend2 ---" >> teb_14.log
$cmd/teb2 201614 201601 1>>teb_14.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_14.log
qtp auto=$obj/u090f.qtc 1>>teb_14.log 2>&1

echo "--- teb3 ---" >> teb_14.log
$cmd/teb3 201614 201601 1>>teb_14.log 2>&1

echo "Payroll Run 14 - ending - `date`" >> teb_14.log
#BATCH_EXIT
