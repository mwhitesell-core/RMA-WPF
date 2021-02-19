cd $application_production/${1}
echo 
date 
quiz  << QUIZ_EXIT   1> subfile.ls 2>&1 
exe $obj/create_claims_suba
${1}
${2}
exe $obj/create_claims_subb
exe $obj/create_claims_subc
QUIZ_EXIT

mv claims_subfile.sf  claims_subfile_${1}_${3}.sf
mv claims_subfile.sfd claims_subfile_${1}_${3}.sfd

echo 
date 
