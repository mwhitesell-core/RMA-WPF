cd $pb_data
echo Rolling over the adj_claim_file backup files ...
#rm >/dev/null 2>/dev/null adj_claim_file_bkp.dat
#cp adj_claim_file.dat adj_claim_file_bkp.dat
rm                        adj_claim_file_bk9.dat
mv adj_claim_file_bk8.dat adj_claim_file_bk9.dat
mv adj_claim_file_bk7.dat adj_claim_file_bk8.dat
mv adj_claim_file_bk6.dat adj_claim_file_bk7.dat
mv adj_claim_file_bk5.dat adj_claim_file_bk6.dat
mv adj_claim_file_bk4.dat adj_claim_file_bk5.dat
mv adj_claim_file_bk3.dat adj_claim_file_bk4.dat
mv adj_claim_file_bk2.dat adj_claim_file_bk3.dat
mv adj_claim_file_bk1.dat adj_claim_file_bk2.dat
cp adj_claim_file.dat     adj_claim_file_bk1.dat

cd $application_production
echo
echo "CREATE AUTOMATIC ADJUSTMENT CLAIMS (U802.QTC)"
echo
qtp auto=$obj/u802.qtc 

echo
echo "CREATE THE ADJUSTED CLMDTL RECORDS (U030C)"
echo

cobrun $obj/u030c

echo
echo "CREATE THE AUTOMATIC ADJUSTMENT CLAIMS REPORT (R801A,B,C)"
echo

rm >/dev/null 2>/dev/null r801*.txt

quiz << QUIZ_EXIT
exec $obj/r801a.qzc 
exec $obj/r801b.qzc 
exec $obj/r801c.qzc 
QUIZ_EXIT

ls -l r801*

lp r801a.txt >/dev/null 2>/dev/null 
lp r801b.txt >/dev/null 2>/dev/null 
#lp r801c.txt >/dev/null 2>/dev/null 

echo
echo "DELETE AND RECREATE THE ADJ_CLAIM_FILE"
echo

qutil << QUTIL_EXIT
create file adj-claim-file
QUTIL_EXIT
