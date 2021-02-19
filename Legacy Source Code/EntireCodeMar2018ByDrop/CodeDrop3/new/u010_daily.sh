# U010_DAILY
echo "Running u010daily ... starting -  `date` "
echo "Running u010daily ... starting -  `date` " >> u010daily.log

cd $application_production

qtp   auto=$obj/u010daily.qtc   >> u010daily.log

echo "Running r010daily_1 ... starting -  `date` " >> r010daily.log

quiz  auto=$obj/r010daily_1.qzc >> r010daily.log

echo "Running r010daily_2 ... starting -  `date` " >> r010daily.log

quiz  auto=$obj/r010daily_2.qzc >> r010daily.log

mv r010daily.txt r010daily_${1}.txt

cat  extf001aa.sf >> extf001aa_cycle.sf
cat  extf001.sf   >> extf001_cycle.sf
cat  r010daily.sf >> r010daily_cycle.sf

echo "u010daily ...   ending -  `date` "
echo "u010daily ...   ending -  `date` " >> u010daily.log


