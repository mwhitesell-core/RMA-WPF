#  YEAREND PAYROLL PURGES 
#
# 00/jul/08 B.E. - disable running pgm in 'batch'
# 00/jul/10 B.E. - force log into be in $pb_prod
# 06/may/24 M.C. - As per Brad's request, include the new report r113
#		   to let user to verify the records in the new f113-default-comp
# 07/jul/09 M.C. - do not delete and recreate f020-doctor-extra via qutil
# 07/jul/12 M.C. - Yasemin requested not to delete F113-DEFAULT-COMP-UPLOAD-DRIVER
#		   when deleting f113-default-comp (they both share the same prefix)
# 15/Jul/08 MC1  - correct to delete files with specific names instead of wild card for f110/f112/f119 because
#		   do not want to delete audit files, save audit files as bkp  and recreate the new audit files
# 15/Jul/15 MC2  - Brad said do not need to save audit files for backup as he will take care of the file transfer 
#                  nightly from c:\macros\ftp_get_utl0201.bat   at 11:50 pm
# 15/Sep/22 MC3  - include the run of r112_csv.qzc
	
cd $pb_prod

rm $pb_prod/payrollpurge.log 1>/dev/null  2>/dev/null

echo "YEAREND PAYROLL PURGES - STARTING - `date`" > $pb_prod/payrollpurge.log

echo "--- yearend_1---"
qtp auto=$obj/yearend_1.qtc                    1>>$pb_prod/payrollpurge.log 2>&1

cd $pb_data

echo "--- delete files ---"
# MC1
#rm f110_compensation*
#rm f112_pycdceilings*
rm f110_compensation.*
rm f112_pycdceilings.*
rm f113_default_comp.*
#rm f119_doctor_ytd*
rm f119_doctor_ytd.*
rm f198_user_defined_totals*
##rm f020_doctor_extra*

echo "--- create files ---"
qutil << QUTIL_EXIT
create file f110-compensation
create file f112-pycdceilings
create file f113-default-comp
create file f119-doctor-ytd
create file f198-user-defined-totals
;##create file f020-doctor-extra
QUTIL_EXIT

cd $pb_prod

echo "--- yearend_2---"
qtp auto=$obj/yearend_2.qtc                    1>>$pb_prod/payrollpurge.log 2>&1


# MC3
quiz auto=$obj/r112_csv.qzc 			1>>$pb_prod/payrollpurge.log 2>&1

# 2006/Jul/11 - MC - add purge_f113.qtc  to delete comp-code LTD
qtp auto=$obj/purge_f113.qtc                   1>>$pb_prod/payrollpurge.log 2>&1


# 2006/may/24 - MC - add a new report r113
#                  - ask user to verify the content of the report
#                  - make neccessary correction if needed

quiz auto=$obj/r113.qzc				 1>>$pb_prod/payrollpurge.log 2>&1

lp r113.txt


# 2006/jun/13 - MC - Mary requests to blank out f112
# 2006/Jul/12 - MC - Mary changed her mind, roll over f112, not recreate empty file
#                    but zero out required and target revenue fields for the new year

##cd $pb_data

##echo "--- recreate f112 file ---"
##rm f112_pycdceilings*
##qutil << QUTIL_EXIT
##create file f112-pycdceilings
##QUTIL_EXIT


#MC1 - save audit files before recreate them
##mv f020_doctor_audit.dat    	     f020_doctor_audit.dat.bkp
##mv f110_compensation_audit.dat     f110_compensation_audit.dat.bkp
##mv f112_pycdceilings_audit.dat     f112_pycdceilings_audit.dat.bkp
##mv f119_doctor_ytd_audit.dat       f119_doctor_ytd_audit.dat.bkp

echo "--- create files ---"
qutil << QUTIL_EXIT
create file f020-doctor-audit
create file f028-audit-file
create file f110-compensation-audit
create file f112-pycdceilings-audit
create file f119-doctor-ytd-audit
QUTIL_EXIT

# MC1 - end

echo "YEAREND PAYROLL PURGES - ENDING - `date`" >> $pb_prod/payrollpurge.log
#
##BATCH_EXIT