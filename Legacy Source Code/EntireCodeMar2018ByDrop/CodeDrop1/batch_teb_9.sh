#  Payroll Run 9 
#
cd $application_production
rm teb_9*.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 9 - starting - `date`" > teb_9.log

echo "--- teb1 ---" >> teb_9.log
$cmd/teb1 201609 201601 1>>teb_9.log 2>&1

echo "--- teb2 ---" >> teb_9.log
$cmd/teb2 201609 201601 1>>teb_9.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_9.log
qtp auto=$obj/u090f.qtc 1>>teb_9.log 2>&1

echo "Payroll Run 9 - ending - `date`" >> teb_9.log

echo "Payroll Run 9b - starting - `date`" > teb_9b.log

echo "--- teb3 ---" >> teb_9b.log
$cmd/teb3 201609 201601 1>>teb_9b.log 2>&1

echo "Payroll Run 9b - ending - `date`" >> teb_9b.log
#BATCH_EXIT
