#  PURGE f020_history file
#
#  2009/07/07	Change dates to 200101 to 200113 and EP 2001 to 2001
#  2010/07/06   Change dates to 200201 to 200213 and EP 2002 to 2002
#  2011/06/07   Change dates to 200301 to 200313 and EP 2003 to 2003
#  2014/Jun/11  yas change purge date to 2006 
#  2015/Jul/04  yas change purge date to 2007

cd /charly/purge/solo

rm $pb_prod/purgef020_solo.log 1>/dev/null  2>/dev/null

echo "Purge f020-history -  STARTING - `date`" > $pb_prod/purgef020_solo.log    

qtp auto=$obj/purge_unlof020_history.qtc << QTP_EXIT 1>>$pb_prod/purgef020_solo.log 2>&1
200801
200813
QTP_EXIT


cd $pb_data

mv f020_doc_mstr_history.dat  /charly/purge/solo/f020_doc_mstr_history.dat
mv f020_doc_mstr_history.idx  /charly/purge/solo/f020_doc_mstr_history.idx

echo "--- create files ---"
qutil << QUTIL_EXIT
create file f020-doc-mstr-history
QUTIL_EXIT

cd /charly/purge/solo

qtp auto=$obj/purge_relof020_history.qtc  1>>$pb_prod/purgef020_solo.log  2>&1


echo "Purge f020-history - ENDING - `date`" >> $pb_prod/purgef020_solo.log
