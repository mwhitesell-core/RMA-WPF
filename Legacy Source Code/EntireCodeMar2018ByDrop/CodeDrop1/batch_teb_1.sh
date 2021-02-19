#  Payroll Run 1 
#
cd $application_production
rm teb_1*.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 1 - starting - `date`" > teb_1.log

echo "--- teb1 ---" >> teb_1.log
$cmd/teb1 201601 201601 1>>teb_1.log 2>&1

echo "--- teb2 ---" >> teb_1.log
$cmd/teb2 201601 201601 1>>teb_1.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_1.log
qtp auto=$obj/u090f.qtc 1>>teb_1.log 2>&1

echo "Payroll Run 1 - ending - `date`" >> teb_1.log

echo "Payroll Run 1b - starting - `date`" > teb_1b.log

echo "--- teb3 ---" >> teb_1b.log

$cmd/teb3 201601 201601 1>>teb_1b.log 2>&1

echo "Payroll Run 1b - ending - `date`" >> teb_1b.log

#BATCH_EXIT
