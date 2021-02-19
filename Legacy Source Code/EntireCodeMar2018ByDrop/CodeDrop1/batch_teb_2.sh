#  Payroll Run 2 
#
cd $application_production
rm teb_2*.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 2 - starting - `date`" > teb_2.log

echo "--- teb1 ---" >> teb_2.log
$cmd/teb1 201602 201601 >>teb_2.log 2>&1

echo "--- teb2 ---" >> teb_2.log
$cmd/teb2 201602 201601 1>>teb_2.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_2.log
qtp auto=$obj/u090f.qtc 1>>teb_2.log 2>&1

echo "Payroll Run 2 - ending - `date`" >> teb_2.log

echo "Payroll Run 2b - starting - `date`" > teb_2b.log

echo "--- teb3 ---" >> teb_2b.log
$cmd/teb3 201602 201601 1>>teb_2b.log 2>&1

echo "Payroll Run 2b - ending - `date`" >> teb_2b.log
#BATCH_EXIT
