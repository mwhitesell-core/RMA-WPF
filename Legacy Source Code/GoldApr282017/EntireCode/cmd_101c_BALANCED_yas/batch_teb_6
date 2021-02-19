#  Payroll Run 6 
#
cd $application_production
rm teb_6*.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 6 - starting - `date`" > teb_6.log

echo "--- teb1 ---" >> teb_6.log
$cmd/teb1 201606 201601 1>>teb_6.log 2>&1

echo "--- teb2 ---" >> teb_6.log
$cmd/teb2 201606 201601 1>>teb_6.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_6.log
qtp auto=$obj/u090f.qtc 1>>teb_6.log 2>&1

echo "Payroll Run 6 - ending - `date`" >> teb_6.log

echo "Payroll Run 6b - starting - `date`" > teb_6b.log

echo "--- teb3 ---" >> teb_6b.log
$cmd/teb3 201606 201601 1>>teb_6b.log 2>&1

echo "Payroll Run 6b - ending - `date`" >> teb_6b.log
#BATCH_EXIT
