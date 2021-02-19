cd $application_production/78
echo BEGIN NOW... `date`
qtp auto=$obj/u210.qtc << QTP_EXIT
78000000
78ZZZZZZ
QTP_EXIT
echo      ENDING.... `date`

echo BEGIN NOW... `date`
quiz auto=$obj/r211.qzc << QUIZ_EXIT
78000000
78ZZZZZZ
QUIZ_EXIT
echo      ENDING.... `date`

lp r211
#lp status.ls
