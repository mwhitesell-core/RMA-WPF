cobrun $obj/r153a 1>r153a.log 2>&1 << R153A_EXIT
LIVE RUN
001
017
108
017
118
Y
N
99
2017
04
28
Y
R153A_EXIT
cobrun $obj/r153b 1>r153b.log 2>&1 << R153B_EXIT
99
R153B_EXIT
#R153_EXIT
echo
echo
echo Ensure the below logs are zero length files!
lp r153ef
lp r153ef

echo
ls -l r153?.log
