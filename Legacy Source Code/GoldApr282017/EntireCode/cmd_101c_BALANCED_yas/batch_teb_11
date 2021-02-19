#  Payroll Run 11 
#
cd $application_production
rm teb_11*.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 11 - starting - `date`" > teb_11.log

echo "--- teb1 ---" >> teb_11.log
$cmd/teb1 201611 201601 1>>teb_11.log 2>&1

echo "--- teb2 ---" >> teb_11.log
$cmd/teb2 201611 201601 1>>teb_11.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_11.log
qtp auto=$obj/u090f.qtc 1>>teb_11.log 2>&1

echo "Payroll Run 11 - ending - `date`" >> teb_11.log

echo "Payroll Run 11b - starting - `date`" > teb_11b.log

echo "--- teb3 ---" >> teb_11b.log
$cmd/teb3 201611 201601 1>>teb_11b.log 2>&1

echo "Payroll Run 11b - ending - `date`" >> teb_11b.log
#BATCH_EXIT
