# print_elig_letters 
# 2010/may/26 brad  - generated and prints patient letters except those that have been 'logically' deleted
# 2010/Jul/14 MC1   - update f010 for letter sent after printing letters to patient 
# 2011/Mar/08 MC2   - qutil tmp-counters file, run u085.qtc before r085e_?.qzc, add to run u085e.qtc afterward
#		      save the subfile u085e_savef010.sf by renaming to the run date
# 2011/Apr/04 MC3   - include the new program r085e_3.qzc 
#		      save the subfile r085e.sf instead of u085e_savef010.sf by copying with the run date
#		      also save r085e.txt by copying with the run date


echo Running"print_elig_letters" ...

cd $pb_data
rm ohip_run_dates_backup_10*
mv ohip_run_dates_backup_09.dat ohip_run_dates_backup_10.dat
mv ohip_run_dates_backup_09.idx ohip_run_dates_backup_10.idx
mv ohip_run_dates_backup_08.dat ohip_run_dates_backup_09.dat
mv ohip_run_dates_backup_08.idx ohip_run_dates_backup_09.idx
mv ohip_run_dates_backup_07.dat ohip_run_dates_backup_08.dat
mv ohip_run_dates_backup_07.idx ohip_run_dates_backup_08.idx
mv ohip_run_dates_backup_06.dat ohip_run_dates_backup_07.dat
mv ohip_run_dates_backup_06.idx ohip_run_dates_backup_07.idx
mv ohip_run_dates_backup_05.dat ohip_run_dates_backup_06.dat
mv ohip_run_dates_backup_05.idx ohip_run_dates_backup_06.idx
mv ohip_run_dates_backup_04.dat ohip_run_dates_backup_05.dat
mv ohip_run_dates_backup_04.idx ohip_run_dates_backup_05.idx
mv ohip_run_dates_backup_03.dat ohip_run_dates_backup_04.dat
mv ohip_run_dates_backup_03.idx ohip_run_dates_backup_04.idx
mv ohip_run_dates_backup_02.dat ohip_run_dates_backup_03.dat
mv ohip_run_dates_backup_02.idx ohip_run_dates_backup_03.idx
mv ohip_run_dates_backup_01.dat ohip_run_dates_backup_02.dat
mv ohip_run_dates_backup_01.idx ohip_run_dates_backup_02.idx
cp ohip_run_dates.dat     ohip_run_dates_backup_01.dat
cp ohip_run_dates.idx     ohip_run_dates_backup_01.idx

#########

# 2011/03/08 - MC2
rm tmp_counters.*

qutil << qutil_exit
create file tmp-counters
qutil_exit

# 2011/03/08 - end

cd $application_production

# 2011/03/08 - MC2
echo "Running u085 ...to update tmp-counters"
qtp << qtp_exit
exec $obj/u085.qtc
qtp_exit

# 2011/03/08 - end

################

rm   >/dev/null  2>/dev/null  r085e.txt

echo " Running r085e  ..."
quiz << quiz_exit
exec $obj/r085e_1.qzc
exec $obj/r085e_2.qzc
exec $obj/r085e_3.qzc
quiz_exit

# r085e.txt

timeStamp=20`date +%y_%m_%d.%H:%M` ;export timeStamp

cp r085e.txt r085e_$timeStamp.txt
cp r085e.sf  r085e_$timeStamp.sf 
cp r085e.sfd r085e_$timeStamp.sfd

################


# 2011/03/08 - MC2
echo 
echo "Running u085e ...to update patient mstr"
qtp << qtp_exit
exec $obj/u085e.qtc
qtp_exit


# 2011/03/08 - end

echo Done "print_elig_letters" 
