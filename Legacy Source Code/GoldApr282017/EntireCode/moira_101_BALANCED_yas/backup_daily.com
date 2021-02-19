echo  "backup_daily"
echo  
## 2003/09/15	M.C.	- include f119, f190, f191, f924 in this backup
# 2004/jun/16 b.e. added MP and ICU data to backup 
# 04/jul/08 yas  - added backup f074 and f075 and f114 f113
# 07/nov/13 MC   - added backup f112 and f923, put files in sequence order
#	           and specify the full pathname for files that are shared
#		   by Cobol and PH
#		 - add f110, f112, f113 & f191 for MP data, requested by Mary/Yas 
# 07/nov/14 MC   - add f011 in the backup
# 09/aug/10 MC   - add subdirectories disk1 to disk10  under 101c/production in the backup
echo 
echo  BACKUP NOW COMMENCING ... parameter passed was: - $1 -
echo 

echo  
date 
echo  

echo "Finding $pb_data files .."
cd  $application_root
pwd

echo Selected linked f010* ...
/bin/ls /charly/rmabill/rmabill101c/data/f010_pat_mstr     \
                                >  data/backup_daily.ls
/bin/ls /charly/rmabill/rmabill101c/data/f010_pat_mstr.idx \
                                >> data/backup_daily.ls

echo Select remainder of files ...

/bin/ls                                 \
data/f001_batch_control_file            \
data/f001_batch_control_file.idx        \
data/f002_claim_shadow                  \
data/f002_claim_shadow.idx              \
data/f002_claims_extra                  \
data/f002_claims_extra.idx              \
data/f002_claims_mstr                   \
data/f002_claims_mstr.idx               \
data/f011_pat_mstr_elig_history		\
data/f011_pat_mstr_elig_history.idx	\
data/f020_doctor_extra*                 \
data/f020_doctor_mstr                   \
data/f020_doctor_mstr.idx               \
data/f021_avail_doctor_mstr*            \
data/f022*                              \
data/f023_alternative_doc_nbr*          \
data/f027_contacts_mstr                 \
data/f027_contacts_mstr.idx             \
data/f028_audit_file*                   \
data/f028_contacts_info_mstr            \
data/f028_contacts_info_mstr.idx        \
data/f029*                              \
data/f030_locations_mstr                \
data/f030_locations_mstr.idx            \
data/f040_oma_fee_mstr                  \
data/f040_oma_fee_mstr.idx              \
data/f050_doc_revenue_mstr              \
data/f050_doc_revenue_mstr.idx          \
data/f050_doc_revenue_mstr_history.dat  \
data/f050_doc_revenue_mstr_history.idx  \
data/f050tp_doc_revenue_mstr            \
data/f050tp_doc_revenue_mstr.idx        \
data/f050tp_doc_revenue_mstr_history.dat \
data/f050tp_doc_revenue_mstr_history.idx \
data/f051_doc_cash_mstr                 \
data/f051_doc_cash_mstr.idx             \
data/f051tp_doc_cash_mstr               \
data/f051tp_doc_cash_mstr.idx           \
data/f060_cheque_reg_mstr               \
data/f060_cheque_reg_mstr.idx           \
data/f070_dept_mstr                     \
data/f070_dept_mstr.idx                 \
data/f071_client_rma_claim_nbr          \
data/f071_client_rma_claim_nbr.idx      \
data/f072_client_mstr                   \
data/f072_client_mstr.idx               \
data/f073_client_doc_mstr               \
data/f073_client_doc_mstr.idx           \
data/f074*                              \
data/f075*                              \
data/f080_bank_mstr                     \
data/f080_bank_mstr.idx                 \
data/f083_user_mstr*                    \
data/f084_claims_inventory*             \
data/f085_rejected_claims               \
data/f085_rejected_claims.idx           \
data/f086*                              \
data/f087_submitted_rejected*           \
data/f088_rat_rejected_claims*          \
data/f090_constants_mstr                \
data/f090_constants_mstr.idx            \
data/f091_diag_codes_mstr               \
data/f091_diag_codes_mstr.idx           \
data/f092*                              \
data/f093*                              \
data/f094_msg_sub_mstr                  \
data/f094_msg_sub_mstr.idx              \
data/f095*                              \
data/f096_ohip_pay_code                 \
data/f096_ohip_pay_code.idx             \
data/f097*                              \
data/f098_equiv_oma_code_mstr*          \
data/f099_group_claim_mstr*             \
data/f112_pycdceilings*                 \
data/f113_default_comp*                 \
data/f114_special_payments.*            \
data/f123_company_mstr                  \
data/f123_company_mstr.idx              \
data/f190_comp_codes*                   \
data/f191_earnings_period*              \
data/f923*                              \
data/f924_non_fee_for_service_locations*        \
data/adj_claim_file*                    \
data/contract*                          \
data/copy*                              \
data/create*                            \
data/doc_totals*                        \
data/resubmit.required                  \
data/social*                            \
production/ext*                         \
production/f086*                        \
production/moh_obec*                    \
production/r010*                        \
production/u010*                        >> data/backup_daily.ls

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
find production/disk1 	 	  -print > data/disk1dir.ls
find production/disk2 	 	  -print > data/disk2dir.ls
find production/disk3 	 	  -print > data/disk3dir.ls
find production/disk4 	 	  -print > data/disk4dir.ls
find production/disk5 	 	  -print > data/disk5dir.ls
find production/disk6 	 	  -print > data/disk6dir.ls
find production/disk7 	 	  -print > data/disk7dir.ls
find production/disk8 	 	  -print > data/disk8dir.ls
find production/disk9 	 	  -print > data/disk9dir.ls
find production/disk10	 	  -print > data/disk10dir.ls
find production/diskette	  -print > data/diskettedir.ls
find production/diskette1	  -print > data/diskette1dir.ls
find production/f002_suspend*     -print > data/suspend.ls
find production/kathy		  -print > data/kathydir.ls
find production/mumc 		  -print > data/mumcdir.ls
find production/stone 		  -print > data/stonedir.ls
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
find production/yasemin/yearend*  -print > data/yasemin.ls
echo 
date

echo "Finding MP data files .."
find /alpha/rmabill/rmabillmp/data/f110_compensation*   -print >   data/mp_data.ls
find /alpha/rmabill/rmabillmp/data/f112_pycdceilings*   -print >>  data/mp_data.ls
find /alpha/rmabill/rmabillmp/data/f113_default_comp*   -print >>  data/mp_data.ls
find /alpha/rmabill/rmabillmp/data/f191*                -print >>  data/mp_data.ls


mt -f /dev/rmt/1 rewind

echo "Starting copy of file to tape ..."
cd $application_root
pwd

cat data/backup_daily.ls       	        \
    data/disk1dir.ls 			\
    data/disk2dir.ls 			\
    data/disk3dir.ls 			\
    data/disk4dir.ls 			\
    data/disk5dir.ls 			\
    data/disk6dir.ls 			\
    data/disk7dir.ls 			\
    data/disk8dir.ls 			\
    data/disk9dir.ls 			\
    data/disk10dir.ls 			\
    data/diskettedir.ls			\
    data/diskette1dir.ls		\
    data/kathydir.ls                    \
    data/mp_data.ls               	\
    data/mumcdir.ls               	\
    data/rmadir.ls			\
    data/stonedir.ls               	\
    data/suspend.ls                     \
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
    data/yasemin.ls  			\
	> data/backup_daily_complete.ls
echo
date

cat       data/backup_daily_complete.ls \
    | cpio -ocuvB > /dev/rmt/1 

echo
date
echo
echo Rewinding tape ...

mt -f /dev/rmt/1 rewind

if [ "$1" = "" ]
then
  $cmd/verify_daily
fi


echo " "
date
echo "DONE!"


#  ***** IF NEW BACKUP ADDED UPDATE backup_daily_to_disk  ALSO
#  *****                            reload_daily
#  *****                            reload_daily_from_disk

