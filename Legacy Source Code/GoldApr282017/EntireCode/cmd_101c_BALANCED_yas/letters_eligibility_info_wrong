# letters_eligbility_info_wrong
# 00/sep/22 B.E. - allow only 5 doctors to appear on letters. Renamed
#		   r085c.qzs to r085e.qzs and added u085c/d.qts
# 02/nov/18 B.E. - added delete of r085e.txt before running
# 04/feb/24 M.C. - transfer the calls of $cmd/f086patid and $cmd/f086a_origpatid
#		   to $cmd/process_elig_corrected_patients
# 10/may/26 brad1 - comment out r085e.qzc and move that pgm into new macro print_elig_letters
# 10/jul/14 MC1   - comment out u085.qtc  and move that pgm into new macro print_elig_letters 

# Note: This macro called by letters_resubmit 

echo Running"letters_eligbility_info_wrong" ...

cd $pb_data
rm f085_backup_10*
mv f085_backup_09     f085_backup_10
mv f085_backup_09.idx f085_backup_10.idx
mv f085_backup_08     f085_backup_09
mv f085_backup_08.idx f085_backup_09.idx
mv f085_backup_07     f085_backup_08
mv f085_backup_07.idx f085_backup_08.idx
mv f085_backup_06     f085_backup_07
mv f085_backup_06.idx f085_backup_07.idx
mv f085_backup_05     f085_backup_06
mv f085_backup_05.idx f085_backup_06.idx
mv f085_backup_04     f085_backup_05
mv f085_backup_04.idx f085_backup_05.idx
mv f085_backup_03     f085_backup_04
mv f085_backup_03.idx f085_backup_04.idx
mv f085_backup_02     f085_backup_03
mv f085_backup_02.idx f085_backup_03.idx
mv f085_backup_01     f085_backup_02
mv f085_backup_01.idx f085_backup_02.idx
cp f085_rejected_claims     f085_backup_01
cp f085_rejected_claims.idx f085_backup_01.idx

##  $cmd/f086patid  - transfer to $cmd/process_elig_corrected_patients
##  $cmd/f086a_origpatid - transfer to $cmd/process_elig_corrected_patients

cd $application_production

rm   >/dev/null  2>/dev/null  r085?.txt
rm   >/dev/null  2>/dev/null  r086.txt
rm   >/dev/null  2>/dev/null  r087.txt

echo " Running r085a / u085b /r085c / r086 / r087  ..."
#quiz auto=$obj/r085.qzc - replaced by r085a/r085b

quiz auto=$obj/r085a.qzc
#quiz auto=$obj/r085b.qzc - replaced by u085b/r085c
qtp  auto=$obj/u085b.qtc
#quiz auto=$obj/r085c.qzc 00/sep/22 B.E.
qtp  auto=$obj/u085c.qtc
qtp  auto=$obj/u085d.qtc
# brad1 quiz auto=$obj/r085e.qzc

quiz auto=$obj/r086.qzc
quiz auto=$obj/r087.qzc

#MC1 - comment out update to f010
##echo "Running u085 ..." 
##qtp  auto=$obj/u085.qtc

lp r086.txt
lp r087.txt
lp r087.txt

echo Done "letters_eligbility_info_wrong"
