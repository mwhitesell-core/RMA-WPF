# file: gsttax - upload gsttax to f113 in payroll
# 2007/jan/09 b.e. added new param to u132 call
$cmd/u132 100 $1 DC
echo Running webhst ...
quiz auto=$pb_obj/webhst.qzc
echo Done .. paging webhst.txt report
pg webhst.txt
