## $cmd/claims_subfile_22to48

echo Start Time of $cmd/claims_subfile_22to48 is `date`

echo
date
$cmd/create_claims_subfile 22 20170421 201704
$cmd/create_claims_subfile 23 20170421 201704
$cmd/create_claims_subfile 24 20170421 201704
$cmd/create_claims_subfile 25 20170421 201704
$cmd/create_claims_subfile 26 20170421 201704
$cmd/create_claims_subfile 30 20170421 201704
$cmd/create_claims_subfile 31 20170421 201704
$cmd/create_claims_subfile 32 20170421 201704
$cmd/create_claims_subfile 33 20170421 201704
$cmd/create_claims_subfile 34 20170421 201704
$cmd/create_claims_subfile 35 20170421 201704
$cmd/create_claims_subfile 36 20170421 201704
$cmd/create_claims_subfile 41 20170421 201704
$cmd/create_claims_subfile 42 20170421 201704
$cmd/create_claims_subfile 43 20170421 201704
$cmd/create_claims_subfile 44 20170421 201704
$cmd/create_claims_subfile 45 20170421 201704
$cmd/create_claims_subfile 46 20170421 201704
$cmd/create_claims_subfile 98 20170421 201704

cd $pb_prod/22

cat $pb_prod/23/claims_subfile_23_201704.sf >> claims_subfile_22_201704.sf
cat $pb_prod/24/claims_subfile_24_201704.sf >> claims_subfile_22_201704.sf
cat $pb_prod/25/claims_subfile_25_201704.sf >> claims_subfile_22_201704.sf
cat $pb_prod/26/claims_subfile_26_201704.sf >> claims_subfile_22_201704.sf
cat $pb_prod/30/claims_subfile_30_201704.sf >> claims_subfile_22_201704.sf
cat $pb_prod/31/claims_subfile_31_201704.sf >> claims_subfile_22_201704.sf
cat $pb_prod/32/claims_subfile_32_201704.sf >> claims_subfile_22_201704.sf
cat $pb_prod/33/claims_subfile_33_201704.sf >> claims_subfile_22_201704.sf
cat $pb_prod/34/claims_subfile_34_201704.sf >> claims_subfile_22_201704.sf
cat $pb_prod/35/claims_subfile_35_201704.sf >> claims_subfile_22_201704.sf
cat $pb_prod/36/claims_subfile_36_201704.sf >> claims_subfile_22_201704.sf
cat $pb_prod/41/claims_subfile_41_201704.sf >> claims_subfile_22_201704.sf
cat $pb_prod/42/claims_subfile_42_201704.sf >> claims_subfile_22_201704.sf
cat $pb_prod/43/claims_subfile_43_201704.sf >> claims_subfile_22_201704.sf
cat $pb_prod/44/claims_subfile_44_201704.sf >> claims_subfile_22_201704.sf
cat $pb_prod/45/claims_subfile_45_201704.sf >> claims_subfile_22_201704.sf
cat $pb_prod/46/claims_subfile_46_201704.sf >> claims_subfile_22_201704.sf
cat $pb_prod/98/claims_subfile_98_201704.sf >> claims_subfile_22_201704.sf

echo
date

echo End    Time of $cmd/claims_subfile_22to48 is `date`

