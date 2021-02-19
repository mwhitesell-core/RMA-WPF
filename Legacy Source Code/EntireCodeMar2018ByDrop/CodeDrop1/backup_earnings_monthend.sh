# BACKUP_EARNINGS_MONTHEND.CLI
# PURPOSE: BACKUP OF FILES RELEVANT EARNINGS FILE SO THAT:
#          A: THE PHYSICIAN STATEMENTS MUST BE RUN AGAIN ALL FILES
#             CAN BE RELOADED AND PROGRAM R124A/B RE-RUN.
#          B: THE EFT FILE SO THAT IF BANK TAPE IS REQUIRED AGAIN
#             FILE IS AVAILABLE
# 94/JUL/12 B.E.  - ORIGINAL
# 95/JUL/17 Y.B.  - ADD @MTD0 13 & 14
# 95/SEP/25 Y.B.  - ADD @MTD0 15
# 95/NOV/22 M.C.  - ADD F020 & F119 HISTORY FILES
# 96/FEB/19 M.C.  - ADD F020-DOCTOR-EXTRA FILE
# 96/JUL/31 Y.B.  - ADD R119 & R121 REPORT
# 98/JAN/21 K.M.  - PORTED to UNIX
# 98/Aug/20 B.E.  - removed dd= from CPIO to tape, changed backup to run
#		    to disk and tape
# 99/dec/20 B.E.  - added 'eft_constant' to backup and restore
# 04/jul/08 yas  - added backup f074 and f075 and f114
# 08/June   yas  - added backup f074_afp_group_sequence*
# 13/Aug/28 MC   - exclude f050*history  files  
# 14/May/28 MC1  - change 'eft_constant' to 'eft_constant*' so that eft_constant_debit will also include for backup
# 15/Aug/18 MC2  - include r125, r128, r153, r137, payeft, paycode1A_ceilings reports in the backup
# 15/Oct/21 MC3  - correct for r128

cd $application_root

echo
echo "Preparing list of files to be backed up ..."
echo
date
/bin/ls production/u110_${1}.sf*			\
	production/r111b_${1}.txt			\
	production/u119_payeft.ps*			\
	production/r119_${1}.txt			\
	production/r121_${1}.txt			\
	production/r120_${1}.txt			\
	production/r123a_${1}.txt			\
	production/r123b_${1}.txt			\
	production/r123c_${1}.txt			\
	production/r123ef 				\
	production/r124a*_${1}.sf*			\
	production/r124b*_${1}.txt			\
	production/r124c*_${1}.txt			\
	production/r125*_${1}.txt			\
	production/r128*.txt                           \
	production/r137*_${1}.txt			\
	production/r153*_${1}.txt			\
	production/r153ef				\
	production/debug114_${1}.txt		\
	production/debug116cd1_${1}.txt		\
	production/debug116cd2_${1}.txt		\
	production/debug116cd34_${1}.txt	\
	production/debugu116cd*sf*		\
	production/dumpf119_${1}.txt		\
	production/dumpf119ytd_${1}.txt		\
	production/payeft_${1}.txt		\
	production/paycode1A_ceilings_${1}.txt	\
	data/eft_constant* 		\
 	data/f020_doctor_mstr*		\
        data/f020_doc_mstr_history*     \
        data/f020_doctor_extra*         \
        data/f050_doc_revenue_mstr      \
        data/f050_doc_revenue_mstr.idx  \
	data/f070_dept_mstr*		\
	data/f074_afp_group_mstr*       \
	data/f074_afp_group_sequence*   \
	data/f075_afp_doc_mstr*		\
	data/f080_bank_mstr*		\
	data/f090_constants_mstr*	\
	data/f095_text_lines*		\
	data/f110_compensation*		\
        data/f110_comp_history*         \
	data/f112_pycdceilings*		\
        data/f112_pycd_history*         \
	data/f113_default_comp*		\
        data/f113_def_comp_history*     \
        data/f113_default_comp_upload_driver* \
        data/f114_special_payments*     \
        data/f115*                      \
        data/f116*                      \
        data/f119_doctor_ytd*           \
        data/f119_doc_ytd_history*      \
	data/f190_comp_codes*		\
        data/f191_earnings_period*      \
	data/f198_user_defined_totals*	\
	data/f199_user_defined_fields*	\
   1>$pb_data/backup_earnings_mthend${1}.ls
echo
echo "performing backup to DISK ..."
echo
date

cat $pb_data/backup_earnings_mthend${1}.ls				\
    | cpio -ocuvB 							\
    | compress > $pb_data/backup_earnings_mthend${1}.cpio.Z
# To restore from disk:
# uncompress $pb_data/backup_earnings_mthendYYMM.cpio.Z 
# cd $application_root
# cpio -icuvB < data/backup_earnings_mthendYYMM.cpio 

echo
echo "performing additional backup to TAPE ..."
date

cat $pb_data/backup_earnings_mthend${1}.ls   \
    | cpio -ocuvB > /dev/rmt/0
echo
echo 

echo Rewinding tape ...
mt -f /dev/rmt/0 rewind

echo
echo VERIFICATION NOW COMMENCING ... Be patient - this may take some time!
echo
echo Output is being sent to a file that will be paged out at end of verify ...
echo
echo
cpio -itcvB < /dev/rmt/0 > $pb_data/backup_earnings_mthend${1}.log
echo
echo
echo Comparing lines in .ls vs .log
ls -l $pb_data/backup_earnings_mthend${1}.ls $pb_data/backup_earnings_mthend${1}.log

echo
cat $pb_data/backup_earnings_mthend${1}.ls  | wc -l
cat $pb_data/backup_earnings_mthend${1}.log | wc -l

echo Rewinding tape ...
mt -f /dev/rmt/0 rewind

