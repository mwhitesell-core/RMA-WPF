echo
echo Create Doctor T4 Reports
echo

cd $application_production
rm 1>/dev/null 2>/dev/null r150*.sf*

qtp << qtp_exit
exec $obj/r150a_detail
201601
201606
201507
201513
qtp_exit

quiz <<  quiz_exit
use  $src/r150d_detail
quiz_exit


