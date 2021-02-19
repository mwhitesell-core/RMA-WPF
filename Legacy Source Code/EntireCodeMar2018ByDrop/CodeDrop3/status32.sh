cd $application_production/32
echo BEGIN NOW... `date`
qtp auto=$obj/u210.qtc << QTP_EXIT
32000000
32ZZZZZZ
QTP_EXIT
echo      ENDING.... `date`

echo BEGIN NOW... `date`
quiz auto=$obj/r211.qzc << QUIZ_EXIT
32000000
32ZZZZZZ
QUIZ_EXIT
echo      ENDING.... `date`

lp r211
#lp status.ls
