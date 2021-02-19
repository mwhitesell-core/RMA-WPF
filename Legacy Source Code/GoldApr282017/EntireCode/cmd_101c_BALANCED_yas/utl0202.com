# program: utl0202.com
# 2016/nov/23 B.E.  original
clear
echo "utl0202.com - verify all doctors with payments have all required bank info"
echo

echo
echo "running utl0202.qzc " $time
rm             utl0202.txt 1>/dev/null 2>&1
quiz auto=$obj/utl0202.qzc    

echo
echo


if [  -s utl0202.txt ]
then
	ls -l utl0202.txt
	echo 
	echo
	echo
	echo !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
	echo THERE ARE ERRORS - Give report to Accounting!
	echo !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
	echo
	echo
	lp utl0202.txt
fi
echo "Done! " $time

