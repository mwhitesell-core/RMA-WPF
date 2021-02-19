#  Payroll Run 19 
#
cd $application_production
rm teb_19 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 19 - starting - `date`" > teb_19

echo "--- teb_yearend1 ---" >> teb_19
$cmd/teb1 201619 201601 1>>teb_19 2>&1

echo "--- teb_yearend2 ---" >> teb_19
$cmd/teb2 201619 201601 1>>teb_19 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_19
qtp auto=$obj/u090f.qtc 1>>teb_19 2>&1

echo "--- teb3 ---" >> teb_19
$cmd/teb3 201619 201601 1>>teb_19 2>&1

echo "Payroll Run 19 - ending - `date`" >> teb_19
#BATCH_EXIT
