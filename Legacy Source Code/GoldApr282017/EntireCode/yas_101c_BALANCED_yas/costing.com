# costing.com
# 00/jul/14 B.E. added costing7.qtc and costing10.qzc
# 00/jul/31 B.E. added costing11.qzc
rm costing*sf*
qtp << qtp_EXIT
exe costing1.qtc
exe costing2.qtc
qtp_EXIT

qutil << qutil_EXIT
create file doc-totals-tmp 
create file tmp-counters
qutil_EXIT

qtp << qtp_EXIT
exe costing3.qtc
exe costing4.qtc
exe costing5.qtc
qtp_EXIT


