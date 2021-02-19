#  2015/Jul/14  M.C.    $cmd/claims_subfile_monthend.com called from $cmd/claims_subfile_first_monthend,
#                       $cmd/claims_subfile_second_monthend or $cmd/claims_subfile_third_monthend
#                       pass monthend as the paramter

echo
echo `date`

qtp << QTP_EXIT
exec $obj/unlof002_me_claim.qtc
${1}
QTP_EXIT

echo
echo `date`

