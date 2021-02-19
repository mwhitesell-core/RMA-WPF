#  Payroll Run 13 
#
cd $application_production
rm teb_13*.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 13 - starting - `date`" > teb_13.log

echo "--- teb_yearend1 ---" >> teb_13.log
$cmd/teb1 201613 201601 1>>teb_13.log 2>&1

echo "--- teb_yearend2 ---" >> teb_13.log
$cmd/teb2 201613 201601 1>>teb_13.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_13.log
qtp auto=$obj/u090f.qtc 1>>teb_13.log 2>&1

echo "Payroll Run 13 - ending - `date`" >> teb_13.log

echo "Payroll Run 13b - starting - `date`" > teb_13b.log

echo "--- teb3 ---" >> teb_13b.log
$cmd/teb3 201613 201601 1>>teb_13b.log 2>&1

echo "Payroll Run 13b - ending - `date`" >> teb_13b.log
#BATCH_EXIT
