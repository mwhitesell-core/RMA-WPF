#  Payroll Run 7 
#
cd $application_production
rm teb_7*.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 7 - starting - `date`" > teb_7.log

echo "--- teb1 ---" >> teb_7.log
$cmd/teb1 201607 201601 1>>teb_7.log 2>&1

echo "--- teb2 ---" >> teb_7.log
$cmd/teb2 201607 201601 1>>teb_7.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_7.log
qtp auto=$obj/u090f.qtc 1>>teb_7.log 2>&1

echo "Payroll Run 7 - ending - `date`" >> teb_7.log

echo "Payroll Run 7b - starting - `date`" > teb_7b.log

echo "--- teb3 ---" >> teb_7b.log
$cmd/teb3 201607 201601 1>>teb_7b.log 2>&1

echo "Payroll Run 7b - ending - `date`" >> teb_7b.log
#BATCH_EXIT