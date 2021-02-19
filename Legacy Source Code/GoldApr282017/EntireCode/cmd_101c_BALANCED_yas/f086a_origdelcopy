# f086a_origdelcopy
# 00/oct/16 B.E. - added code to keep 5 backups of files

rm >/dev/null 2>/dev/null f086a_orig_new_pat_ids_bkp_5.dat
mv f086a_orig_new_pat_ids_bkp_4.dat  f086a_orig_new_pat_ids_bkp_5.dat
mv f086a_orig_new_pat_ids_bkp_3.dat  f086a_orig_new_pat_ids_bkp_4.dat
mv f086a_orig_new_pat_ids_bkp_2.dat  f086a_orig_new_pat_ids_bkp_3.dat
mv f086a_orig_new_pat_ids_bkp.dat    f086a_orig_new_pat_ids_bkp_2.dat
cp f086a_orig_new_pat_ids.dat        f086a_orig_new_pat_ids_bkp.dat

rm f086a_orig_new_pat_ids.dat

qutil << EOJ_QUTIL
create file f086a-orig-new-pat-ids
EOJ_QUTIL

chmod +rw f086a_orig_new_pat_ids.dat

