echo BEGIN NOW... `date`
qtp auto=$obj/u210.qtc << QTP_EXIT
22000000
22ZZZZZZ
QTP_EXIT
echo      ENDING.... `date`

echo BEGIN NOW... `date`
quiz auto=$obj/r211.qzc << QUIZ_EXIT
22000000
22ZZZZZZ
QUIZ_EXIT
echo      ENDING.... `date`

lp r211.txt
#lp status.ls
