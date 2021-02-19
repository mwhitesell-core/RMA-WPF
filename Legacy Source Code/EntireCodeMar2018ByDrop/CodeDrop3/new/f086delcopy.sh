# f086delcopy
# 00/oct/16 B.E. - added code to keep 5 backups of files
# 04/jan/05 b.e. - perform only if in 'live' application

# NOTE: LIVE version is   '101c'


if [ "$RMABILL_VERSION" = "101c" ]
then

rm >/dev/null 2>/dev/null f086_pat_id_bkp_5.dat
mv f086_pat_id_bkp_4.dat  f086_pat_id_bkp_5.dat
mv f086_pat_id_bkp_3.dat  f086_pat_id_bkp_4.dat
mv f086_pat_id_bkp_2.dat  f086_pat_id_bkp_3.dat
mv f086_pat_id_bkp.dat    f086_pat_id_bkp_2.dat
cp f086_pat_id.dat        f086_pat_id_bkp.dat

rm >/dev/null 2>/dev/null f086_pat_id_bkp_5.d001
mv f086_pat_id_bkp_4.d001 f086_pat_id_bkp_5.d001
mv f086_pat_id_bkp_3.d001 f086_pat_id_bkp_4.d001
mv f086_pat_id_bkp_2.d001 f086_pat_id_bkp_3.d001
mv f086_pat_id_bkp.d001   f086_pat_id_bkp_2.d001
cp f086_pat_id.d001       f086_pat_id_bkp.d001

rm >/dev/null 2>/dev/null f086_pat_id_bkp_5.d003
mv f086_pat_id_bkp_4.d003 f086_pat_id_bkp_5.d003
mv f086_pat_id_bkp_3.d003 f086_pat_id_bkp_4.d003
mv f086_pat_id_bkp_2.d003 f086_pat_id_bkp_3.d003
mv f086_pat_id_bkp.d003   f086_pat_id_bkp_2.d003
cp f086_pat_id.d003       f086_pat_id_bkp.d003

rm f086_pat_id.dat
rm f086_pat_id.d001
rm f086_pat_id.d003

cobrun $obj/createpatid
cp f086_pat_id.dat f086_pat_id.d003
cp f086_pat_id.dat f086_pat_id.d001

chmod +rw f086_pat_id.dat
chmod +rw f086_pat_id.d001
chmod +rw f086_pat_id.d003
else
  echo "NOT running in Live - f086_delcopy bypassed ..."

fi
