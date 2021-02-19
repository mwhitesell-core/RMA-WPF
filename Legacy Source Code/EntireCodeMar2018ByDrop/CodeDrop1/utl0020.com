# program: utl0020.com
# 2003/sep/28 B.E.  original
# 2011/apr/26 added pgm utl0020c_3.qts.txt 
# 2014/sep/20 added delete of dept 53 subfile
# 2015/apr/21 added delete of dept 80 subfile

clear
echo "utl0020 - Creating download file of doctor information used to create Revenue Workbooks of ME"
echo
#printf "Hit ENTER to continue ..."
#read  garbage

echo "program starting at: " $time 
echo
echo "Re-creating empty tmp download file ..." $time
qutil << qutil_EXIT
create file tmp-pc-download-file
qutil_EXIT
echo
echo

echo Delete any old files if found ..
rm utl0020_??.ps
rm utl0020_??.psd
rm utl0020_??.txt
echo


echo
echo "running utl0020a_1  /  _2.qtc  / _3.qtc  ... " $time
qtp auto=$obj/utl0020a_1.qtc
qtp auto=$obj/utl0020a_2.qtc
qtp auto=$obj/utl0020a_3.qtc

echo
echo "running utl0020b.qtc ... " $time
qtp auto=$obj/utl0020b.qtc

echo "running utl0020c.qzs ... " $time
#quiz auto=$obj/utl0020c.qzu
quiz  << quiz_EXIT
use $src/utl0020c nol
quiz_EXIT
mv utl0020c_1.qts.txt utl0020c_1.qts
mv utl0020c_2.qts.txt utl0020c_2.qts
mv utl0020c_3.qts.txt utl0020c_3.qts

qtp   << qtp_EXIT1
use      utl0020c_1 nol
exe $obj/utl0020c_1.qtc
qtp_EXIT1

qtp   << qtp_EXIT2
use      utl0020c_2 nol
exe $obj/utl0020c_2.qtc
qtp_EXIT2

qtp   << qtp_EXIT3
use      utl0020c_3 nol
exe $obj/utl0020c_3.qtc
qtp_EXIT3

echo 
echo "running utl0020d.qzc ... " $time
quiz auto=$obj/utl0020d.qzc
mv utl0020_00.txt utl0020_00.ps

$cmd/delete_empty_file.com utl0020_01.ps
$cmd/delete_empty_file.com utl0020_02.ps
$cmd/delete_empty_file.com utl0020_03.ps
$cmd/delete_empty_file.com utl0020_04.ps
$cmd/delete_empty_file.com utl0020_05.ps
$cmd/delete_empty_file.com utl0020_06.ps
$cmd/delete_empty_file.com utl0020_07.ps
$cmd/delete_empty_file.com utl0020_08.ps
$cmd/delete_empty_file.com utl0020_09.ps
$cmd/delete_empty_file.com utl0020_10.ps
$cmd/delete_empty_file.com utl0020_11.ps
$cmd/delete_empty_file.com utl0020_12.ps
$cmd/delete_empty_file.com utl0020_13.ps
$cmd/delete_empty_file.com utl0020_14.ps
$cmd/delete_empty_file.com utl0020_15.ps
$cmd/delete_empty_file.com utl0020_16.ps
$cmd/delete_empty_file.com utl0020_17.ps
$cmd/delete_empty_file.com utl0020_18.ps
$cmd/delete_empty_file.com utl0020_19.ps
$cmd/delete_empty_file.com utl0020_20.ps
$cmd/delete_empty_file.com utl0020_21.ps
$cmd/delete_empty_file.com utl0020_22.ps
$cmd/delete_empty_file.com utl0020_23.ps
$cmd/delete_empty_file.com utl0020_24.ps
$cmd/delete_empty_file.com utl0020_25.ps
$cmd/delete_empty_file.com utl0020_26.ps
$cmd/delete_empty_file.com utl0020_27.ps
$cmd/delete_empty_file.com utl0020_28.ps
$cmd/delete_empty_file.com utl0020_29.ps
$cmd/delete_empty_file.com utl0020_30.ps

$cmd/delete_empty_file.com utl0020_33.ps

$cmd/delete_empty_file.com utl0020_34.ps
$cmd/delete_empty_file.com utl0020_35.ps
$cmd/delete_empty_file.com utl0020_36.ps
$cmd/delete_empty_file.com utl0020_37.ps
$cmd/delete_empty_file.com utl0020_38.ps

$cmd/delete_empty_file.com utl0020_51.ps
$cmd/delete_empty_file.com utl0020_53.ps

$cmd/delete_empty_file.com utl0020_70.ps
$cmd/delete_empty_file.com utl0020_71.ps
$cmd/delete_empty_file.com utl0020_72.ps
$cmd/delete_empty_file.com utl0020_73.ps
$cmd/delete_empty_file.com utl0020_74.ps
$cmd/delete_empty_file.com utl0020_75.ps
$cmd/delete_empty_file.com utl0020_76.ps
$cmd/delete_empty_file.com utl0020_79.ps

$cmd/delete_empty_file.com utl0020_80.ps

echo 
echo "Done! " $time

