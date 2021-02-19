echo  "BACKUP_DAILY"
echo  
## 2003/09/15	M.C.	- include f119, f190, f191, f924 in this backup
# 2004/jun/16 b.e. added MP and ICU data to backup 
# 04/jul/08 yas  - added backup f074 and f075 and f114 f113
echo 
echo  BACKUP NOW COMMENCING ...
echo 

echo  
date 
echo  

echo "Finding $pb_data files .."
cd  $application_root
pwd
/bin/ls data/f002_claims_mstr*	\
data/f010_pat_mstr*		\
data/f001_batch_control_file*	\
data/f020_doctor_mstr* \
data/f050_doc_revenue_mstr* \
data/f051_doc_cash_mstr* \
data/f050tp_doc_revenue_mstr* \
data/f051tp_doc_cash_mstr* \
data/f002_claim_shadow* \
data/f090_constants_mstr* \
data/f021_avail_doctor_mstr* \
data/f096_ohip_pay_code* \
data/f023_alternative_doc_nbr* \
data/f085_rejected_claims* \
data/f071_client_rma_claim_nbr*	\
data/f072_client_mstr*	\
data/f073_client_doc_mstr* \
data/f074*                 \
data/f075*                 \
data/f114*                 \
data/f113*                 \
data/f087_man_rejected_claims* \
data/f087_submitted_rejected*  \
data/f083_user_mstr* \
data/f084_claims_inventory* \
data/f088_rat_rejected_claims* \
data/f098_equiv_oma_code_mstr* \
data/f022*                  \
data/adj_claim_file* \
data/f002_claims_extra* \
data/f020_doctor_extra* \
data/resubmit.required \
data/f099_group_claim_mstr* \
data/f123* \
data/f119_doctor_ytd*	\
data/f190_comp_codes*	\
data/f191_earnings_period*	\
data/f924_non_fee_for_service_locations*	\
data/icu_app_file*     \
production/u010*             \
production/ext*              \
production/*u993*            \
production/icuapp*           \
production/r010*             \
production/moh_obec*         \
production/f086*                 > data/backup_daily.ls
echo 
echo 
date

echo "Finding rma logon directory files ..."
cd /
pwd
find /alpha/home/rma*  	  -print > $pb_data/rmadir.ls
echo 
echo
date

echo "Finding production diskette upload files ..."
cd $application_root
pwd
find production/web   		  -print > data/webdir.ls
find production/web1 	 	  -print > data/web1dir.ls
find production/web2 	 	  -print > data/web2dir.ls
find production/web3 	 	  -print > data/web3dir.ls
find production/web4 	 	  -print > data/web4dir.ls
find production/web5 	 	  -print > data/web5dir.ls
find production/web6 	 	  -print > data/web6dir.ls
find production/web7 	 	  -print > data/web7dir.ls
find production/web8 	 	  -print > data/web8dir.ls
find production/web9 	 	  -print > data/web9dir.ls
find production/web10	 	  -print > data/web10dir.ls
find production/diskette	  -print > data/diskettedir.ls
find production/diskette1	  -print > data/diskette1dir.ls
find production/stone 		  -print > data/stonedir.ls
find production/mumc 		  -print > data/mumcdir.ls
find production/kathy		  -print > data/kathydir.ls
find production/f002_suspend*     -print > data/suspend.ls
find production/f086*             -print > data/prof086.ls
find data/f086*                   -print > data/f086.ls
echo 
date

#echo "Finding MP data files ..."
#find /alpha/rmabill/rmabillmp/data/*	-print > data/mp_data.ls

#echo "Finding ICU data files ..."
#find /alpha/rmabill/rmabillicu/data/*	-print > data/icu_data.ls


echo "Starting copy of file to tape ..."
cd $application_root
pwd
cat data/backup_daily.ls       	        \
    data/rmadir.ls			\
    data/webdir.ls                 	\
    data/web1dir.ls 			\
    data/web2dir.ls 			\
    data/web3dir.ls 			\
    data/web4dir.ls 			\
    data/web5dir.ls 			\
    data/web6dir.ls 			\
    data/web7dir.ls 			\
    data/web8dir.ls 			\
    data/web9dir.ls 			\
    data/web10dir.ls 			\
    data/diskettedir.ls			\
    data/diskette1dir.ls		\
    data/stonedir.ls               	\
    data/mumcdir.ls               	\
    data/suspend.ls                     \
    data/f086.ls                        \
#    data/mp_data.ls			\
#    data/icu_data.ls			\
    | cpio -ocuvB > /dev/rmt/1 
### brad     | cpio -ocuvB |dd of=/dev/rmt/1
echo " "
date
echo "DONE!"


#  ***** IF NEW BACKUP ADDED UPDATE backup_daily_to_disk  ALSO
#  *****                            reload_daily
#  *****                            reload_daily_from_disk

echo  
date 
echo  

mt -f /dev/rmt/1 rewind
