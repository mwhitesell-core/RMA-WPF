cd $application_production/43
echo BEGIN NOW... `date`
qtp auto=$obj/u210.qtc << QTP_EXIT
43000000
43ZZZZZZ
QTP_EXIT
echo      ENDING.... `date`

echo BEGIN NOW... `date`
quiz auto=$obj/r211.qzc << QUIZ_EXIT
43000000
43ZZZZZZ
QUIZ_EXIT
echo      ENDING.... `date`

lp r211
#lp status.ls
