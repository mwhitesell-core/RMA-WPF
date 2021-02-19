#!/bin/ksh
## reload_sel_data_from_disk.com

echo "reload_sel_data_from_disk.com"

date

application_root=/alpha/rmabill/rmabill101c
cd $application_root


#echo  Restore 101c f002 data from disk
#rm data/f002_claims_mstr
#rm data/f002_claims_mstr.idx
#uncompress -c < /charly/backup_transfer_area/backup_101c_f002.cpio | cpio -icdvB
#date


#echo Restore 101c f010 data from disk
#uncompress -c < /charly/backup_transfer_area/backup_101c_f010.cpio | cpio -icdvB
#date


#echo  Restore 101c production from disk
#uncompress -c < /charly/backup_transfer_area/backup_101c_prod.cpio | cpio -icdvB
#echo  Restore 101c production from disk with content only
#uncompress -c < /charly/backup_transfer_area/backup_101c_prod.cpio | cpio -itcvB > backup_101c_prod_content.log
#echo  Restore 101c production from disk for selected files
#uncompress -c < /charly/backup_transfer_area/backup_101c_prod.cpio | cpio -icdvB -E reload_101c_prod > backup_101c_prod_select.log
#date

#echo  Restore 101c data  from disk
#uncompress -c < /charly/backup_transfer_area/backup_101c_data.cpio | cpio -icdvB
#echo  Restore 101c data from disk with content only
#uncompress -c < /charly/backup_transfer_area/backup_101c_data.cpio | cpio -itcvB > backup_101c_data_content.log
#echo  Restore 101c data from disk for selected files
#uncompress -c < /charly/backup_transfer_area/backup_101c_data.cpio | cpio -icdvB -E reload_101c_data > backup_101c_data_select.log
#date


#echo  Restore mp   data from disk
#uncompress -c < /charly/backup_transfer_area/backup_mp_data.cpio | cpio -icdvB
#echo  Restore mp   data from disk with content only
#uncompress -c < /charly/backup_transfer_area/backup_mp_data.cpio | cpio -itcvB > backup_mp_data_content.log
#echo  Restore mp   data from disk for selected files
#uncompress -c < /charly/backup_transfer_area/backup_mp_data.cpio | cpio -icdvB -E reload_mp_data > backup_mp_data_select.log
#date


#echo  Restore solo data from disk
#uncompress -c < /charly/backup_transfer_area/backup_solo_data.cpio | cpio -icdvB
#echo  Restore solo data from disk with content only
#uncompress -c < /charly/backup_transfer_area/backup_solo_data.cpio | cpio -itcvB > backup_solo_data_content.log
#echo  Restore solo data from disk for selected files
#uncompress -c < /charly/backup_transfer_area/backup_solo_data.cpio | cpio -icdvB -E reload_solo_data > backup_solo_data_select.log
#date


#echo  Restore 101  data from disk
#uncompress -c < /charly/backup_transfer_area/backup_101_data.cpio | cpio -icdvB
#echo  Restore 101  data from disk with content only
#uncompress -c < /charly/backup_transfer_area/backup_101_data.cpio | cpio -itcvB > backup_101_data_content.log
echo  Restore 101  data from disk for selected files
uncompress -c < /charly/backup_transfer_area/backup_101_data.cpio | cpio -icdvB -E reload_101_data > backup_101_data_select.log
date

echo "Restore is done"
date


