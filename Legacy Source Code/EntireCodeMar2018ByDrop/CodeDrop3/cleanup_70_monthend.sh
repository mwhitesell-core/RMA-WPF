echo  "*** THIS PROGRAM WILL DELETE ALL OF THE SUBFILES  HISTORY FILE "
echo 
echo      SORT/WORK MSTRS AND ALL THE REPORTS FOR CLINICS 60 TO 65
echo 
echo  "**** HIT NEW LINE TO CONTINUE ****"
read garbage

cd $application_production/70

rm   >/dev/null  2>/dev/null  r004atp*.sf*
rm   >/dev/null  2>/dev/null  r007*
rm   >/dev/null  2>/dev/null  r070atp*.sf*
rm   >/dev/null  2>/dev/null  r070btp*.sf*
rm   >/dev/null  2>/dev/null  utl0006*.txt
rm   >/dev/null  2>/dev/null  utl0006a*.txt
rm   >/dev/null  2>/dev/null  utl0007*.txt
rm   >/dev/null  2>/dev/null  r004*.txt
rm   >/dev/null  2>/dev/null  r005*.txt
rm   >/dev/null  2>/dev/null  r006*.txt
rm   >/dev/null  2>/dev/null  r011*.txt
rm   >/dev/null  2>/dev/null  r012*.txt
rm   >/dev/null  2>/dev/null  r013*.txt
rm   >/dev/null  2>/dev/null  r015*.txt
rm   >/dev/null  2>/dev/null  r051*.txt
rm   >/dev/null  2>/dev/null  r070*.txt
rm   >/dev/null  2>/dev/null  r004tp_70
rm   >/dev/null  2>/dev/null  r005tp_70
rm   >/dev/null  2>/dev/null  r006tp_70
rm   >/dev/null  2>/dev/null  r011_70
rm   >/dev/null  2>/dev/null  r012tp_70
rm   >/dev/null  2>/dev/null  r013tp_70
rm   >/dev/null  2>/dev/null  r015tp_70
rm   >/dev/null  2>/dev/null  r051ca_70
rm   >/dev/null  2>/dev/null  r051cb_70
rm   >/dev/null  2>/dev/null  r070tp_70
rm   >/dev/null  2>/dev/null  r070_70
rm   >/dev/null  2>/dev/null  r210_70
rm   >/dev/null  2>/dev/null  f002_claims_history_tape_file
rm   >/dev/null  2>/dev/null  filer001*
rm   >/dev/null  2>/dev/null  claims_subfile*

cd $application_production/71
rm claims*sf*
cd $application_production/72
rm claims*sf*
cd $application_production/73
rm claims*sf*
cd $application_production/74
rm claims*sf*
cd $application_production/75
rm claims*sf*
