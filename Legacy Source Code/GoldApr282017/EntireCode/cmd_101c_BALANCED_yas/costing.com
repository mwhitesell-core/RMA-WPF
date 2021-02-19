# costing.com
# 00/jul/14 B.E. added costing7.qtc and costing10.qzc
# 00/jul/31 B.E. added costing11.qzc
# 00/jul/26 b.e. - added recreation of tmp-counters-alpha
# 12/Jun/04 yas. - Run costing_f119hist.qts for Leena import into excel 
echo
date
echo

#####cd $application_production/yasemin

cd /charly/purge/costing

###rm costingf119.ps*
###qtp auto=$obj/costing_f119hist.qtc

rm costing*sf*
qtp << qtp_EXIT
exe $obj/costing1.qtc
exe $obj/costing2.qtc
qtp_EXIT

qutil << qutil_EXIT
create file doc-totals-tmp 
create file tmp-counters
create file tmp-counters-alpha
qutil_EXIT

qtp << qtp_EXIT
exe $obj/costing3.qtc
exe $obj/costing4.qtc
exe $obj/costing5.qtc
exe $obj/costing6.qtc
exe $obj/costing7.qtc
qtp_EXIT

quiz << QUIZ_EXIT
execute $obj/costing1.qzc
execute $obj/costing6a.qzc
execute $obj/costing10.qzc
execute $obj/costing11.qzc
QUIZ_EXIT

echo
date
echo
