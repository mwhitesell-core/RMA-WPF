# U022
# 99/dev/14 B.E. - added backup of u020a1_resubmits.sf
# 02/juan/07 B.E. - removed deletion of u022a subfile

cd $application_production
echo RESUBMITS IN PROGRESS `date` 

rm u022_tp.sf*
rm u022a?.sf*
rm u022e?.sf*
rm ru022a
rm ru022b
rm ru022
rm ru022mr

qtp auto=$obj/u022a1.qtc << QTP_EXIT1
${1}
${2}
QTP_EXIT1

quiz auto=$obj/r022.qzu << QUIZ_EXIT
QUIZ_EXIT

# save resubmit subfile for debugging purposes
cp u022a1.sf        u022a1_resubmits.sf
cp u022a1.sfd       u022a1_resubmits.sfd
cp u022a1_audit.sf  u022a1_audit_resubmits.sf
cp u022a1_audit.sfd u022a1_audit_resubmits.sfd

qtp auto=$obj/u022.qtu

mv ru022a.txt  ru022a
mv ru022b.txt  ru022b
mv ru022.txt   ru022
mv ru022mr.txt ru022mr_before

#lp ru022
#lp ru022b
#lp ru022_sd
#lp ru022b_sd

mv u020_tp.sf   u022_tp.sf
mv u020_tp.sfd  u022_tp.sfd

cd $pb_data
rm resubmit.required
cd $application_production

##  regenerate ru022mr for correct report
quiz << QUIZ_EXIT
exec $obj/r022a7
exec $obj/r022a8
exec $obj/r022a9
QUIZ_EXIT

mv ru022mr.txt ru022mr

echo ENDING RESUBMIT RUN `date` 
