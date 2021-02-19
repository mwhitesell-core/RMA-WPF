#  PURGE f113_history file
#
#  2009/07/07   Change dates to 200101 to 200113 and EP 2001 to 2001
#  2010/07/06   Change dates to 200201 to 200213 and EP 2002 to 2002
#  2011/06/07   Change dates to 200301 to 200313 and EP 2003 to 2003
#  2014/Jun/11  yas change purge date to 2006 
#  2015/Jul/04  yas change purge date to 2007

cd /charly/purge/solo

rm $pb_prod/purgef113_solo.log 1>/dev/null  2>/dev/null

echo "Purge f113-history -  STARTING - `date`" > $pb_prod/purgef113_solo.log    

qtp auto=$obj/purge_unlof113_history.qtc << QTP_EXIT 1>>$pb_prod/purgef113_solo.log 2>&1
2008
2008
QTP_EXIT


cd $pb_data

mv  f113_def_comp_history.dat  /charly/purge/solo/f113_def_comp_history.dat
mv  f113_def_comp_history.idx  /charly/purge/solo/f113_def_comp_history.idx

echo "--- create files ---"
qutil << QUTIL_EXIT
create file f113-default-comp-history
QUTIL_EXIT

cd /charly/purge/solo

qtp auto=$obj/purge_relof113_history.qtc  1>>$pb_prod/purgef113_solo.log  2>&1


echo "Purge f113-history - ENDING - `date`" >> $pb_prod/purgef113_solo.log
