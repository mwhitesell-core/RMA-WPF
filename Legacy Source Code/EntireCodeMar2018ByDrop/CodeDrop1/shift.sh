# file: ltd - upload SHIFT to f114 in payroll
# 2007/jan/09 b.e. added new param to u132 call
$cmd/u132 200 $1 SP
echo Running shift..
quiz auto=$pb_obj/maryshift
echo Done .. paging shift.txt report
pg shift.txt