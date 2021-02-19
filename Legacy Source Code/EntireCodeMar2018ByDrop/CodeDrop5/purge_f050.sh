#  PURGE f050_history file
#
#  2009/07/07   Change dates to 200101 to 200113 and EP 2001 to 2001
#  2010/07/06   Change dates to 200201 to 200213 and EP 2002 to 2002
#  2011/06/07   Change dates to 200301 to 200313 and EP 2003 to 2003
#  2009/oct/27	MC  history files have moved to /charly
#  2013/Jan/10  MC1  - change to save original file from /charly/purge to /foxtrot/purge
#  2013/July/07 yas  - change to save original file from /foxtrot/purge to /charly/purge
#  2014/Jun/11  yas change purge date to 2006 
#  2014/Jul/08  MC2 comment out the section below
#  2015/Jul/04  yas change purge date to 2007 

#cd $pb_prod
cd /charly/purge/101c

rm $pb_prod/purgef050.log 1>/dev/null  2>/dev/null

echo "Purge f050-history -  STARTING - `date`" > $pb_prod/purgef050.log    

qtp auto=$obj/purge_unlof050_history.qtc << QTP_EXIT 1>>$pb_prod/purgef050.log 2>&1
2008
2008
2008
2008
QTP_EXIT


cd /charly/rmabill/rmabill101c/data

mv  f050_doc_revenue_mstr_history.dat     /charly/purge/101c/f050_doc_revenue_mstr_history.dat
mv  f050_doc_revenue_mstr_history.idx     /charly/purge/101c/f050_doc_revenue_mstr_history.idx
mv  f050tp_doc_revenue_mstr_history.dat   /charly/purge/101c/f050tp_doc_revenue_mstr_history.dat
mv  f050tp_doc_revenue_mstr_history.idx   /charly/purge/101c/f050tp_doc_revenue_mstr_history.idx

# MC2 
# cd $pb_data

echo "--- create files ---"
qutil << QUTIL_EXIT
create file f050-doc-revenue-mstr-history
create file f050tp-doc-revenue-mstr-history
QUTIL_EXIT


# MC2 - comment out - not needed
# 2009/10/28 - move the new empty files to /charly and create the link
##mv   f050*doc_revenue_mstr_history*  /charly/rmabill/rmabill101c/data
##ln -s /charly/rmabill/rmabill101c/data/f050_doc_revenue_mstr_history.dat    f050_doc_revenue_mstr_history.dat
##ln -s /charly/rmabill/rmabill101c/data/f050_doc_revenue_mstr_history.idx    f050_doc_revenue_mstr_history.idx
##ln -s /charly/rmabill/rmabill101c/data/f050tp_doc_revenue_mstr_history.dat  f050tp_doc_revenue_mstr_history.dat
##ln -s /charly/rmabill/rmabill101c/data/f050tp_doc_revenue_mstr_history.idx  f050tp_doc_revenue_mstr_history.idx

cd /charly/purge/101c

qtp auto=$obj/purge_relof050_history.qtc  1>>$pb_prod/purgef050.log  2>&1


echo "Purge f050-history - ENDING - `date`" >> $pb_prod/purgef050.log