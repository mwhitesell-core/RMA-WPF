cd $application_production/91
echo BEGIN NOW... `date`
qtp auto=$obj/u210.qtc << QTP_EXIT
91000000
91ZZZZZZ
QTP_EXIT
echo      ENDING.... `date`

echo BEGIN NOW... `date`
quiz auto=$obj/r211.qzc << QUIZ_EXIT
91000000
91ZZZZZZ
QUIZ_EXIT
echo      ENDING.... `date`

lp r211
#lp status.ls
