#  Payroll Run 8 
#
cd $application_production
rm teb_8*.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 8 - starting - `date`" > teb_8.log

echo "--- teb1 ---" >> teb_8.log
$cmd/teb1 201608 201601 1>>teb_8.log 2>&1

echo "--- teb2 ---" >> teb_8.log
$cmd/teb2 201608 201601 1>>teb_8.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_8.log
qtp auto=$obj/u090f.qtc 1>>teb_8.log 2>&1

echo "Payroll Run 8 - ending - `date`" >> teb_8.log

echo "Payroll Run 8b - starting - `date`" > teb_8b.log

echo "--- teb3 ---" >> teb_8b.log
$cmd/teb3 201608 201601 1>>teb_8b.log 2>&1

echo "Payroll Run 8b - ending - `date`" >> teb_8b.log
#BATCH_EXIT
