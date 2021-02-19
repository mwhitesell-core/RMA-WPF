#  PURGE f088 file
#  Delete f088 records if f002-claims master does not exist for the rejects 
#
#  2013/Jan/10  MC1  - change to save original file from /charly/purge to /foxtrot/purge
#  2014/Jul/06  yas  - change to save original file from /foxtrot/purge to /charly/purge

#cd $pb_prod
cd /charly/purge

rm $pb_prod/purgef088.log 1>/dev/null  2>/dev/null

echo "Purge f088 -  STARTING - `date`" > $pb_prod/purgef088.log    

qtp auto=$obj/purge_unlof088.qtc << QTP_EXIT 1>>$pb_prod/purgef088.log 2>&1
QTP_EXIT

cd $pb_data

mv f088_rat_rejected_claims_hist_hdr.dat  /charly/purge/f088_rat_rejected_claims_hist_hdr.dat
mv f088_rat_rejected_claims_hist_hdr.idx  /charly/purge/f088_rat_rejected_claims_hist_hdr.idx
mv f088_rat_rejected_claims_hist_dtl.dat  /charly/purge/f088_rat_rejected_claims_hist_dtl.dat
mv f088_rat_rejected_claims_hist_dtl.idx  /charly/purge/f088_rat_rejected_claims_hist_dtl.idx


echo "--- create files ---"
qutil << QUTIL_EXIT
create file f088-rat-rejected-claims-hist-hdr
create file f088-rat-rejected-claims-hist-dtl
QUTIL_EXIT

cd /charly/purge

qtp auto=$obj/purge_relof088.qtc  1>>$pb_prod/purgef088.log  2>&1


echo "Purge f088 - ENDING - `date`" 1>>$pb_prod/purgef088.log  2>&1
