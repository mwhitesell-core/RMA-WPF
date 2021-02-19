#  Payroll Run 12 
#
cd $application_production
rm teb_12*.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 12 - starting - `date`" > teb_12.log

echo "--- teb1 ---" >> teb_12.log
$cmd/teb1 201612 201601 1>>teb_12.log 2>&1

echo "--- teb2 ---" >> teb_12.log
$cmd/teb2 201612 201601 1>>teb_12.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_12.log
qtp auto=$obj/u090f.qtc 1>>teb_12.log 2>&1

echo "Payroll Run 12 - ending - `date`" >> teb_12.log

echo "Payroll Run 12b - starting - `date`" > teb_12b.log

echo "--- teb3 ---" >> teb_12b.log
$cmd/teb3 201612 201601 1>>teb_12b.log 2>&1

echo "Payroll Run 12b - ending - `date`" >> teb_12b.log
#BATCH_EXIT
