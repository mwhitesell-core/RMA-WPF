echo  "reload_daily"

# 2009/aug/10 - include disk1 to disk10
# 2011/dec/08 - comment out mumc, stone, diskette & diskette1 since no longer needed
# 2012/Apr/05 - include n85 & n85a      
# 13/Jul/30 MC   - replace n85 with oscar because Yasemin has renamed the directories

echo  Reload from TAPE backup created by "backup_daily"
echo

echo "continue with RELOAD BACKUP_DAILY ? (y/n)"
read string

cd $application_root
pwd

if [ "$string" = "Y" -o "$string" = "y" ]
then
#   -----------------------------------------------------------
    echo "reload ** ALL ** files on tape ? (y/n)"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        echo
        date
        echo "Building a consolidated list of files to be restored ..."
        cp /dev/null                     data/reload_daily.ls
        cat data/backup_daily.ls     \
            data/disk1dir.ls          \
            data/disk2dir.ls          \
            data/disk3dir.ls          \
            data/disk4dir.ls          \
            data/disk5dir.ls          \
            data/disk6dir.ls          \
            data/disk7dir.ls          \
            data/disk8dir.ls          \
            data/disk9dir.ls          \
            data/disk10dir.ls         \
            data/kathydir.ls         \
            data/mp_data.ls	     \
            data/rmadir.ls           \
            data/suspend.ls          \
            data/webdir.ls           \
            data/web1dir.ls          \
            data/web2dir.ls          \
            data/web3dir.ls          \
            data/web4dir.ls          \
            data/web5dir.ls          \
            data/web6dir.ls          \
            data/web7dir.ls          \
            data/web8dir.ls          \
            data/web9dir.ls          \
            data/web10dir.ls         \
            data/yasemin.ls          \
            data/oscar.ls          > data/reload_daily.ls
        echo
        date
        echo "restoring ALL files UNCONDITIONALLY DELETING what is on disk now ..."
	echo
        cpio -icduvB -E data/reload_daily.ls < /dev/rmt/1
        echo
	date
        echo "restore DONE!"
        echo
    else

    echo
    echo "You haven't asked to restore ALL files from tape so"
    echo "you will now be prompted for each possible file that"
    echo "could be restored. Enter 'y' and 'Enter' to have the"
    echo "file added to the list of files to be restored. Either"
    echo "'n' and 'Enter' or just 'Enter' will NOT reload the file"
    echo "being prompted for."
    echo "As you respond a recover file LIST is being created. When"
    echo "all prompts are completed, the files requested will be"
    echo "reloaded in a single pass from the LIST."
    echo
    cp /dev/null data/reload.tmp  

#   -----------------------------------------------------------
    echo "reload F001 - BATCH CONTROL ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f001_batch_control_file.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F002 - CLAIM SHADOW? (y/n)"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f002_claim_shadow.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F002 - CLAIMS EXTRA ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f002_claims_extra.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F002 - claims? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f002_claims_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F010 - PATIENT ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f010_pat_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F011 - PATIENT ELIG HISTORY ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f011_pat_elig_history.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F020 - DOCTOR EXTRA (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f020_doctor_extra.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F020 - DOCTOR ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f020_doctor_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F021 - AVAILABLE DOCTOR ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f021_avail_doctor_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F022 - DELETED DOC MSTR ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f022_deleted_doc_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F023 - ALTERNATIVE DOC NUMBERS ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f023_alternative_doc_nbr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F027 - CONTACTS MSTR ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f027_contacts_mstr.ls  >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F028 - AUDIT FILE ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f028_audit_file.ls     >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F028 - CONTACTS INFO MSTR ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f028_contacts_info_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F029 - FOLLOWUP EVENTS ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f029_followup_events.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F030 - LOCATIONS MSTR ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f030_locations_mstr.ls >> data/reload.tmp 
    fi
#   -----------------------------------------------------------
    echo "reload F040 - OMA FEE MSTR ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f040_oma_fee_mstr.ls   >> data/reload.tmp 
    fi
#   -----------------------------------------------------------
    echo "reload F050 - DOCTOR REVENUE ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f050_doc_revenue_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F050 - DOCTOR REVENUE HISTORY? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f050history.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F050TP - TP DOCTOR REVENUE ? (y/n)"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f050tp_doc_revenue_mstr.ls >> data/reload.tmp
  fi
#   -----------------------------------------------------------
    echo "reload F050TP - TP DOCTOR REVENUE HISTORY? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f050tphistory.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F051 - DOCTOR CASH ? (y/n)"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f051_doc_cash_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F051TP - TP DOCTOR CASH ? (y/n)"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f051tp_doc_cash_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F060 - CHEQUE REGISTER  ? (y/n)"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f060_cheque_reg_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F070 - DEPT MSTR  ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f070_dept_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F071 - CLIENT/RMA CLAIMS NBR ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f071_client_rma_claim_nbr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F072 - CLIENT MSTR ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f072_client_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F073 - CLIENT DOC MSTR ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f073_client_doc_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F074 - AFP GROUP  MSTR ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f074.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F075 - AFP DOCTOR MSTR ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f075.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F080 - BANK MASTER     ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f080_bank_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F083 - USER MASTER     ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f083_user_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F084 - CLAIMS INVENTORY? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f084_claims_inventory.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F085 - REJECTED CLAIMS ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f085_rejected_claims.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F086 - PATIENT ID ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f086.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F087 - SUBMITTED REJECTED  ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f087submitted.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F088 DTL - RAT REJECTS  ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f088dtl.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F088 HDR - RAT REJECTS  ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f088hdr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F090 - CONSTANTS ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f090_constants_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F091 - DIAG CODES ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f091_diag_codes_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F092 - OHIP ERROR CAT MSTR  ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f092.ls  >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F093 - OHIP ERROR MSG MSTR  ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f093.ls  >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F094 - MSG SUB MSTR ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f094_msg_sub_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F095 - TEXT LINES ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f095_text_lines.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F096 - OHIP PAY CODE ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f096_ohip_pay_code.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F097 - SPEC CD MSTR  ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f097.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F098 - EQUIP OMA CODE ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f098_equiv_oma_code_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F099 - GROUP CLAIM ?  (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f099_group_claim_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F112 - PYCDCEILINGS  ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f112.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F113 - DEFAULT COMP ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f113.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F114 - SPECIAL PAYMENTS? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f114.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F123 - COMPANY MSTR   ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f123_compnay_mstr.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F190 - COMP CODES ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f190_comp_codes.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F191 - EARNINGS PERIOD ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f191_earnings_period.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F923 - DOC REVENUE TRANSLATION  ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f923.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload F924 -  NON FEE FOR SERVICE LOCATIONS ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/f924.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - ADJ CLAIM FILE ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/adj_claim_file.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - CONTRACT DTL/MSTR  ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/contract.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - DOCTOR TOTALS  ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/doc_totals.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - RESUBMIT.REQUIRED ?  (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/resubmit.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - SOCIAL CONTRACT FACTOR ?  (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/social.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - U010* R010* EXT* F086* MOH_OBEC ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/u010_r010_misc.ls >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - DISK1 ?  (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/disk1dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - DISK2  ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/disk2dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - DISK3  ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/disk3dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - DISK4    ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/disk4dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - DISK5    ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/disk5dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - DISK6     ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/disk6dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - DISK7     ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/disk7dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - DISK8     ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/disk8dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - DISK9    ?  (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/disk9dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - DISK10   ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/disk10dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
#    echo "reload - DISKETTTE ?      (y/[n])"
#    read string
#    if [ "$string" = "Y" -o "$string" = "y" ]
#    then
#        cat backups/diskettedir.ls  >> data/reload.tmp
#    fi
#   -----------------------------------------------------------
#    echo "reload - DISKETTE1 ?     (y/[n])"
#    read string
#    if [ "$string" = "Y" -o "$string" = "y" ]
#    then
#        cat backups/diskette1dir.ls   >> data/reload.tmp
#    fi
#   -----------------------------------------------------------
    echo "reload - MP DATA ?        (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/mp_data.ls  >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - KATHY ?          (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/kathydir.ls  >> data/reload.tmp
    fi
#   -----------------------------------------------------------
#    echo "reload - MUMC ?           (y/[n])"
#    read string
#    if [ "$string" = "Y" -o "$string" = "y" ]
#    then
#        cat backups/mumcdir.ls   >> data/reload.tmp
#    fi
#   -----------------------------------------------------------
    echo "reload - RMA HOME ?       (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/rmadir.ls  >> data/reload.tmp
    fi
#   -----------------------------------------------------------
#    echo "reload - STONE ?          (y/[n])"
#    read string
#    if [ "$string" = "Y" -o "$string" = "y" ]
#    then
#        cat backups/stonedir.ls  >> data/reload.tmp
#    fi
#   -----------------------------------------------------------
    echo "reload - F002 SUSPEND     (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/suspend.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - WEB ?   (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/webdir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - WEB1 ?  (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/web1dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - WEB2  ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/web2dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - WEB3  ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/web3dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - WEB4    ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/web4dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - WEB5    ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/web5dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - WEB6     ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/web6dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - WEB7     ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/web7dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - WEB8     ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/web8dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - WEB9    ?  (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/web9dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - WEB10   ? (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/web10dir.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - YASEMIN YEARNEND ?  (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/yasemin.ls   >> data/reload.tmp
    fi
#   -----------------------------------------------------------
    echo "reload - OSCAR(S)         ?  (y/[n])"
    read string
    if [ "$string" = "Y" -o "$string" = "y" ]
    then
        cat backups/oscar.ls     >> data/reload.tmp
    fi
#   -----------------------------------------------------------

    echo
    echo
    echo
    echo "Now restoring all FILES YOU SELECTED ..."
    pwd
    date
    cpio -icduvB -E data/reload.tmp < /dev/rmt/1
    echo
    date
    echo "restore DONE!"
    echo
    fi	# reload all files on tape
fi
echo
echo "rewinding tape ..."
mt -f /dev/rmt/1 rewind
echo
echo  FINISHED !
echo
