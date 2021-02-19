#  Payroll Run 10 
#
cd $application_production
rm teb_10*.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 10 - starting - `date`" > teb_10.log

echo "--- teb1 ---" >> teb_10.log
$cmd/teb1 201610 201601 1>>teb_10.log 2>&1

echo "--- teb2 ---" >> teb_10.log
$cmd/teb2 201610 201601 1>>teb_10.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_10.log
qtp auto=$obj/u090f.qtc 1>>teb_10.log 2>&1

echo "Payroll Run 10 - ending - `date`" >> teb_10.log

echo "Payroll Run 10b - starting - `date`" > teb_10b.log

echo "--- teb3 ---" >> teb_10b.log
$cmd/teb3 201610 201601 1>>teb_10b.log 2>&1

echo "Payroll Run 10b - ending - `date`" >> teb_10b.log
#BATCH_EXIT
