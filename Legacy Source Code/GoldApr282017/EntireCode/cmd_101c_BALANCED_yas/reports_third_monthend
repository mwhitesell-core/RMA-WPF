#  2015/Jul/15	M.C.	$cmd/reports_third_monthend      
#			include all macros that should be run in the third monthend
#			macros have automatically passed the monthend 3 in the executing programs
#  2015/Dec/01  MC1     include $cmd/r070_csv_third_monthend

echo
echo "start - reports in third monthend..`date`"
echo

cd $application_root/production

# MC1
$cmd/r070_csv_third_monthend
$cmd/r070_csv_all_monthend

$cmd/r005_csv_third_monthend
$cmd/r005_csv_all_monthend
$cmd/claims_subfile_third_monthend

echo
echo "finish - reports in third monthend..`date`"
echo

