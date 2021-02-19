#  PURGE f110_history file
#
#  2009/07/07   Change dates to 200101 to 200113 and EP 2001 to 2001
#  2010/07/06   Change dates to 200201 to 200213 and EP 2002 to 2002
#  2011/06/07   Change dates to 200301 to 200313 and EP 2003 to 2003
#  2013/Jan/10  MC1  - change to save original file from /charly/purge to /foxtrot/purge
#  2014/Jun/11  yas change purge date to 2006 
#  2015/Jul/04  yas change purge date to 2007  

#cd $pb_prod
cd /charly/purge/101c

rm $pb_prod/purgef110.log 1>/dev/null  2>/dev/null

echo "Purge f110-history -  STARTING - `date`" > $pb_prod/purgef110.log    

qtp auto=$obj/purge_unlof110_history.qtc << QTP_EXIT 1>>$pb_prod/purgef110.log 2>&1
200801
200813
QTP_EXIT


cd $pb_data

mv f110_comp_history.dat  /charly/purge/101c/f110_comp_history.dat
mv f110_comp_history.idx  /charly/purge/101c/f110_comp_history.idx

echo "--- create files ---"
qutil << QUTIL_EXIT
create file f110-compensation-history
QUTIL_EXIT

cd /charly/purge/101c

qtp auto=$obj/purge_relof110_history.qtc  1>>$pb_prod/purgef110.log  2>&1


echo "Purge f110-history - ENDING - `date`" >> $pb_prod/purgef110.log
