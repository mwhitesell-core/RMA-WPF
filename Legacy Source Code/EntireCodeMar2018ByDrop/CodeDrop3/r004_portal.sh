rm r004*portal*  r004*sf*

quiz << R004_EXIT  > r004_portal.log
exec $obj/r004a
$1 
exec $obj/r004b
exec $obj/r004c
exec $obj/r004d
exec $obj/r004c_portal
exec $obj/r004c_portal_ss
R004_EXIT

mv r004c_portal.txt    r004c_portal_${2}.txt

# be 2013/apr/22
#mv r004c_portal_ss.txt r004c_portal_ss_${2}.csv
##awk -f $cmd/remove_rpt_heading.awk r004c_portal_ss.txt r004c_portal_ss_${2}.csv

mv r004c_portal_ss.txt r004c_portal_ss_${2}.csv
