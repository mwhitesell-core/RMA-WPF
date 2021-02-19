cd $application_production/25
echo BEGIN NOW... `date`
qtp auto=$obj/u210.qtc << QTP_EXIT
25000000
25ZZZZZZ
QTP_EXIT
echo      ENDING.... `date`

echo BEGIN NOW... `date`
quiz auto=$obj/r211.qzc << QUIZ_EXIT
25000000
25ZZZZZZ
QUIZ_EXIT
echo      ENDING.... `date`

lp r211
#lp status.ls
