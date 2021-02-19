date 
echo  "********************************************************************"
echo   TO CLEAN OFF U020_TAPEOUT_FILE AND U02+SF+ FILES AND REPORTS
echo   THIS WILL DELETE ALL THE REPORTS INCLUDING RU020MR AND RU022MR
echo   AND OHIP TAPE MAKE SURE ALL THE EXTRA COPPIES ARE PRINTED AND
echo                   COPY_MAG_TAPE IS CREATED
echo  "********************************************************************"

echo   'HIT "NEWLINE"  OHIP REPORTS AND TAPE'
 read garbage

cd $application_production

echo save last ohip run date
mv u020c_ohip_run_date.sf   second_last_ohip_rundate.sf
mv u020c_ohip_run_date.sfd  second_last_ohip_rundate.sfd

rm   >/dev/null  2>/dev/null  u020_tapeout_file*
rm   >/dev/null  2>/dev/null  u02*.sf*
rm   >/dev/null  2>/dev/null  r001b
rm   >/dev/null  2>/dev/null  r002aa
rm   >/dev/null  2>/dev/null  r002ab
rm   >/dev/null  2>/dev/null  r004_c
rm   >/dev/null  2>/dev/null  r014
rm   >/dev/null  2>/dev/null  ru022
rm   >/dev/null  2>/dev/null  ru022a*
rm   >/dev/null  2>/dev/null  ru022b*
rm   >/dev/null  2>/dev/null  ru022_sd
rm   >/dev/null  2>/dev/null  ru022a_sd
rm   >/dev/null  2>/dev/null  ru022b_sd
rm   >/dev/null  2>/dev/null  ru020a*
rm   >/dev/null  2>/dev/null  ru020b*
rm   >/dev/null  2>/dev/null  ru020c*
rm   >/dev/null  2>/dev/null  ru022c*
rm   >/dev/null  2>/dev/null  ru022c_sd
rm   >/dev/null  2>/dev/null  r010
rm   >/dev/null  2>/dev/null  ru020mr*
rm   >/dev/null  2>/dev/null  ru022mr*
##rm   >/dev/null  2>/dev/null  u020*.sf* - redundant - done from above
##rm   >/dev/null  2>/dev/null  u022*.sf* - redundant - done from above
rm   >/dev/null  2>/dev/null  sd_u022*.sf*
rm   >/dev/null  2>/dev/null  u035*
rm   >/dev/null  2>/dev/null  r085c.txt
