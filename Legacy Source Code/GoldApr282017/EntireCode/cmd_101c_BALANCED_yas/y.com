
echo removing duplicates from u140_d1 subfile
qtp auto=$obj/u140_d1_remove_dups.qtc
mv u140_d1.sf  u140_d1_with_dups.sf
mv u140_d1.sfd u140_d1_with_dups.sfd
 
mv u140_d2.sf  u140_d1.sf
mv u140_d2.sfd u140_d1.sfd

echo ensure that all docs in u140_d1 are also in f075
echo running u140_f.qtc
qtp auto=$obj/u140_f.qtc

echo run reports
# run reports
$cmd/r140_reports

echo Entering \'upload\' directory
cd $application_upl;pwd

ls -l r140_a1f.txt r140_a2g.txt r140_a2s.txt r140_a3c.txt r140_a4t.txt r140_a.txt r140_a.txt r140_b.txt
echo
echo
echo Confirm the above reports are correct and then complete this process
echo by running "u140_stage4"
echo
echo Done!
