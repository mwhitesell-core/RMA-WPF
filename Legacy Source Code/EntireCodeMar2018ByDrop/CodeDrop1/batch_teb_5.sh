#  Payroll Run 5 
#
cd $application_production
rm teb_5*.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 5 - starting - `date`" > teb_5.log

echo "--- teb1 ---" >> teb_5.log
$cmd/teb1 201605 201601 1>>teb_5.log 2>&1

echo "--- teb2 ---" >> teb_5.log
$cmd/teb2 201605 201601 1>>teb_5.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_5.log
qtp auto=$obj/u090f.qtc 1>>teb_5.log 2>&1

echo "Payroll Run 5 - ending - `date`" >> teb_5.log

echo "Payroll Run 5b - starting - `date`" > teb_5b.log

echo "--- teb3 ---" >> teb_5b.log
$cmd/teb3 201605 201601 1>>teb_5b.log 2>&1

echo "Payroll Run 5b - ending - `date`" >> teb_5b.log
#BATCH_EXIT
