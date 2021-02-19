# teb3
#
# MODIFICATION HISTORY
# 04/jan/23  b.e.   -new 
# 15/Mar/24  MC1    - include the run of utl0201_f119.qtc and utl0201.qzu for 3 enviroments
#                     note that this program must be run after u090f.qts (after increasing current-ep-nbr + 1)
# 15/Jun/11  yas    - utl0201_a.txt =  "Highest MTD Payment Amount by Dept"  and 
#                     utl0201_b.txt =  "Highest different MTD in Payment Amount from LAST MONTH  by Dept"         
#                     $cmd/utl0020.com  is for the revenue reports
# 15/Aug/12  MC2    - include the run of r138_csv.qzc, r139_csv.qtc/qzc for 101c only
#		    - r138_csv.txt = Defict report for Ross
#		    - r139_csv.txt = INCEXP minus TOTDED not equal PAYEFT for pay code 2
# 15/Sep/22  MC3    - transfer the run of r128 here from $cmd/teb2
#		    - r128.txt = Inactive Doctor with no activity for last 3 ep nbr and has outstanding claim
#				 for dept 14 or 15 with pay code 2, this report is printed for Helena,
#		    - r128_csv.txt = Inactive Doctor with no activity for last 3 ep nbr and has outstanding claim,
#		      this should be run for 101c only as solo and mp has no claims
# 16/Mar/30  MC4   - include the run of r138_csv.qtc as part of r138_csv.txt

    
echo "Payroll teb3 - starting - `date`"

echo "Running CLINIC: " $clinic_nbr

#------------------------------------------------------------------
#MC1

# NOTE: clinic 22 - "normal" clinic 22 payroll
#	clinic 99 - "MP" / Manual Payments payroll
#	clinic 10 - "solo/solotest" payroll
#

echo "--- executing utl0201_f119.qtc  ---"

cd $application_root/production

rm utl0201_f119.ps* utl0201*.txt utl0201.sf*  1>/dev/null 2>&1

# If 101c, pass 101C 
if [ $clinic_nbr = "22" ]
then

   qtp << QTP_EXIT1a
   execute $obj/utl0201_f119
   101C
   QTP_EXIT1a

else

   # If MP, pass MP   
   if [ $clinic_nbr = "99" ]
   then 

      qtp << QTP_EXIT1b
      execute $obj/utl0201_f119
      MP   
      QTP_EXIT1b

   else

      # If solo, pass SOLO 
      if [ $clinic_nbr = "10" ]
      then

         qtp << QTP_EXIT1c
         execute $obj/utl0201_f119
         SOLO
         QTP_EXIT1c

      fi
   fi
fi

quiz auto=$obj/utl0201.qzu

lp utl0201_a.txt utl0201_b.txt
lp utl0201_a.txt utl0201_b.txt

#------------------------------------------------------------------
if [ $clinic_nbr = "22" ]
then

   cd $application_production

   #MC3 - Inactive Doctors for last 3 ep nbr and have outstanding claims

   rm r128*.sf*  r128.txt r128_csv.txt  1>/dev/null 2>&1

   rm $pb_data/tmp_counters_alpha*

   qutil  << eof_qutil
   create file tmp-counters-alpha
   eof_qutil

   qtp auto=$obj/r128a.qtc
   quiz auto=$obj/r128b.qzc 
   quiz auto=$obj/r128b_csv.qzc 

   lp r128.txt

   #MC2
   #MC4
   #rm r138_csv.txt r139*.sf* r139_csv.txt 1>/dev/null 2>&1
   rm r138*.sf* r138_csv.txt r139*.sf* r139_csv.txt 1>/dev/null 2>&1

   #####  Deficit Report
   #MC4
   qtp  auto=$obj/r138_csv.qtc 
   quiz auto=$obj/r138_csv.qzc 

   #####  INCEXP minus TOTDED not equal to PAYEFT for pay code 2
   qtp  auto=$obj/r139_csv.qtc  
   quiz auto=$obj/r139_csv.qzc 

   ##### Revenue Reports

   echo "--- utl0020 ---"
   $cmd/utl0020.com

   # MC3 - end

fi
echo "Done!"

echo "Payroll teb3 -   ending - `date`"
