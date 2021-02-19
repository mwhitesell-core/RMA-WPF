echo  "********************************************************************"

echo         THIS PROGRAM WILL DELETE THE CLINIC 30 MONTEND REPORTS
echo      MAKE SURE ALL THE REPORTS ARE PRINTED AND COPY MAG TAPE IS RUN
echo 
echo  "********************************************************************"
echo 
echo  "**** HIT NEW LINE TO CONTINUE ****"
read garbage

cd $application_production/30

rm   >/dev/null  2>/dev/null  r004
rm   >/dev/null  2>/dev/null  r011
rm   >/dev/null  2>/dev/null  r012
rm   >/dev/null  2>/dev/null  r013
rm   >/dev/null  2>/dev/null  r051ca
rm   >/dev/null  2>/dev/null  r051cb
rm   >/dev/null  2>/dev/null  r070
rm   >/dev/null  2>/dev/null  r070_30
rm   >/dev/null  2>/dev/null  r210
rm   >/dev/null  2>/dev/null  r211
rm   >/dev/null  2>/dev/null  f002_claims_history_tape_file
rm   >/dev/null  2>/dev/null  r004wf
rm   >/dev/null  2>/dev/null  r004_sort_work_mstr
rm   >/dev/null  2>/dev/null  r011_sort_work_mstr
rm   >/dev/null  2>/dev/null  r012_sort_work_mstr
rm   >/dev/null  2>/dev/null  r051wf
rm   >/dev/null  2>/dev/null  r051_sort_work_mstr
rm   >/dev/null  2>/dev/null  r070_srt_work_mstr_30
rm   >/dev/null  2>/dev/null  r070_work_mstr_30
rm   >/dev/null  2>/dev/null  filer001*
rm   >/dev/null  2>/dev/null  claims_subfile*
