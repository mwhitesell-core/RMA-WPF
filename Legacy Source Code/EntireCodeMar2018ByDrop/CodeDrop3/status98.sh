cd $application_production/98
echo BEGIN NOW... `date`
qtp auto=$obj/u210.qtc << QTP_EXIT
98000000
98ZZZZZZ
QTP_EXIT
echo      ENDING.... `date`

echo BEGIN NOW... `date`
quiz auto=$obj/r211.qzc << QUIZ_EXIT
98000000
98ZZZZZZ
QUIZ_EXIT
echo      ENDING.... `date`

lp r211
#lp status.ls
