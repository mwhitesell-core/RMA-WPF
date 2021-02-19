#  PURGE f087 file
#  Deletes f087 if f002-claims master does not exist for the rejects 
#
#  2013/Jan/10  MC1  - change to save original file from /charly/purge to /foxtrot/purge
#  2014/Jul/06  yas  - change to save original file from /foxtrot/purge to /charly/purge

#cd $pb_prod

cd /charly/purge

rm $pb_prod/purgef087.log 1>/dev/null  2>/dev/null

echo "Purge f087 -  STARTING - `date`" > $pb_prod/purgef087.log    

qtp auto=$obj/purge_unlof087.qtc << QTP_EXIT 1>>$pb_prod/purgef087.log 2>&1
QTP_EXIT


cd $pb_data

mv  f087_submitted_rejected_claims_hdr.dat   /charly/purge/f087_submitted_rejected_claims_hdr.dat
mv  f087_submitted_rejected_claims_hdr.idx   /charly/purge/f087_submitted_rejected_claims_hdr.idx
mv  f087_submitted_rejected_claims_dtl.dat   /charly/purge/f087_submitted_rejected_claims_dtl.dat
mv  f087_submitted_rejected_claims_dtl.idx   /charly/purge/f087_submitted_rejected_claims_dtl.idx

echo "--- create files ---"
qutil << QUTIL_EXIT
create file f087-submitted-rejected-claims-hdr
create file f087-submitted-rejected-claims-dtl
QUTIL_EXIT

cd /charly/purge

qtp auto=$obj/purge_relof087.qtc  1>>$pb_prod/purgef087.log  2>&1


echo "Purge f087 - ENDING - `date`" 1>>$pb_prod/purgef087.log  2>&1
