# costing_noweb.com
# 00/jul/14 B.E. added costing7.qtc and costing10.qzc
# 00/jul/31 B.E. added costing11.qzc
# 02/sep/06 yas  this is run instead of costing.com to print out physicians 
#                costing amounts only in manual billing if physician bills
#                web and manual               
# 15/Jul/22 MC1  do not need to run costing11.qzc because it is run is $cmd/costing.com

#####cd $application_production/yasemin/noweb

cd /charly/purge/costing/noweb

rm costing*sf*
qtp << qtp_EXIT
exe $obj/costing1_noweb.qtc
exe $obj/costing2_noweb.qtc
qtp_EXIT

qutil << qutil_EXIT
create file doc-totals-tmp 
create file tmp-counters
create file tmp-counters-alpha
qutil_EXIT

qtp << qtp_EXIT
exe $obj/costing3.qtc
exe $obj/costing4.qtc
exe $obj/costing5_noweb.qtc
exe $obj/costing6_noweb.qtc
exe $obj/costing7.qtc
qtp_EXIT

quiz << QUIZ_EXIT
execute $obj/costing1.qzc
execute $obj/costing6a.qzc
execute $obj/costing10.qzc nogo
select if x-billing-source <> 'W' and x-billing-source <> 'D'
go
; MC1 - execute $obj/costing11.qzc
QUIZ_EXIT
