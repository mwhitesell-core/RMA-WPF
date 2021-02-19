#  Payroll Run 4 
#
cd $application_production
rm teb_4*.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 4 - starting - `date`" > teb_4.log

echo "--- teb1 ---" >> teb_4.log
$cmd/teb1 201604 201601 1>>teb_4.log 2>&1

echo "--- teb2 ---" >> teb_4.log
$cmd/teb2 201604 201601 1>>teb_4.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_4.log
qtp auto=$obj/u090f.qtc 1>>teb_4.log 2>&1

echo "Payroll Run 4 - ending - `date`" >> teb_4.log

echo "Payroll Run 4b - starting - `date`" > teb_4b.log

echo "--- teb3 ---" >> teb_4b.log
$cmd/teb3 201604 201601 1>>teb_4b.log 2>&1

echo "Payroll Run 4b - ending - `date`" >> teb_4b.log
#BATCH_EXIT
