#  Payroll Run 12  - onetime
#
cd $application_production
rm teb_12_onetime.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 12 onetime - starting - `date`" > teb_12_onetime.log

echo "--- teb2 onetime  ---" >> teb_12_onetime.log
$cmd/teb2_onetime 200912 200901 1>>teb_12_onetime.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_12_onetime.log
qtp auto=$obj/u090f.qtc 1>>teb_12_onetime.log 2>&1

echo "--- teb3 ---" >> teb_12_onetime.log
$cmd/teb3 200912 200901 1>>teb_12_onetime.log 2>&1

echo "Payroll Run 12 - ending - `date`" >> teb_12_onetime.log
#BATCH_EXIT
