echo
echo  Report suspend_suffix
echo
rm suspend_suffix.txt 1>/dev/null 2>&1
quiz auto=$obj/suspend_suffix.qzc
lp suspend_suffix.txt
