#  Payroll Run 18 
#
cd $application_production
rm teb_18.log 1>/dev/null 2>&1
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 18 - starting - `date`" > teb_18.log

echo "--- teb_yearend1 ---" >> teb_18.log
$cmd/teb1 201618 201601 1>>teb_18.log 2>&1

echo "--- teb_yearend2 ---" >> teb_18.log
$cmd/teb2 201618 201601 1>>teb_18.log 2>&1

echo "--- u090f (QTP RUN) ---" >> teb_18.log
qtp auto=$obj/u090f.qtc 1>>teb_18.log 2>&1

echo "--- teb3 ---" >> teb_18.log
$cmd/teb3 201618 201601 1>>teb_18.log 2>&1

echo "Payroll Run 18 - ending - `date`" >> teb_18.log
#BATCH_EXIT
