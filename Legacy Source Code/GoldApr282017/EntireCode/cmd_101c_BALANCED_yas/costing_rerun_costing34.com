echo
date
echo

cd /charly/purge/costing

qtp << qtp_EXIT
exe $obj/costing3_not_yrend.qtc
exe $obj/costing4_not_yrend.qtc
qtp_EXIT

quiz << QUIZ_EXIT
execute $obj/costing10.qzc
QUIZ_EXIT

echo
date
echo

