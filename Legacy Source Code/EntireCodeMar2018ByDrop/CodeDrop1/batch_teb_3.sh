#  Payroll Run 3 
#
cd $application_production
rm teb_3*.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 3 - starting - `date`" > teb_3.log

echo "--- teb1 ---" >> teb_3.log
$cmd/teb1 201603 201601 1>>teb_3.log 2>&1

echo "--- teb2 ---" >> teb_3.log
$cmd/teb2 201603 201601 1>>teb_3.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_3.log
qtp auto=$obj/u090f.qtc 1>>teb_3.log 2>&1

echo "Payroll Run 3 - ending - `date`" >> teb_3.log

echo "Payroll Run 3b - starting - `date`" > teb_3b.log

echo "--- teb3 ---" >> teb_3b.log
$cmd/teb3 201603 201601 1>>teb_3b.log 2>&1

echo "Payroll Run 3b - ending - `date`" >> teb_3b.log
#BATCH_EXIT
