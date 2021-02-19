#cobrun $obj/r123 1>r123.log 2>&1 << R123_EXIT
cobrun $obj/r123a 1>r123a.log 2>&1 << R123A_EXIT
LIVE RUN
001
017
114
017
121
Y
N
22
2017
05
01
Y
R123A_EXIT
cobrun $obj/r123b 1>r123b.log 2>&1 << R123B_EXIT
22
R123B_EXIT
#R123_EXIT
echo
echo
echo Ensure the below logs are zero length files!
echo
ls -l r123?.log
