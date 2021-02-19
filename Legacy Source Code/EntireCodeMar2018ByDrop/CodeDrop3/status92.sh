cd $application_production/92
echo BEGIN NOW... `date`
qtp auto=$obj/u210.qtc << QTP_EXIT
92000000
92ZZZZZZ
QTP_EXIT
echo      ENDING.... `date`

echo BEGIN NOW... `date`
quiz auto=$obj/r211.qzc << QUIZ_EXIT
92000000
92ZZZZZZ
QUIZ_EXIT
echo      ENDING.... `date`

lp r211
#lp status.ls
