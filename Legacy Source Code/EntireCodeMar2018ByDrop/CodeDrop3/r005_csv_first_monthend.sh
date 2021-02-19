#  2015/Jun/22	M.C.	$cmd/r005_csv_first_monthend      

echo "Doctor Cash Analysis (r005_csv) in first monthend.."
echo
echo
echo

cd $application_root/production

$cmd/r005_csv.com  1          > r005_csv_first_monthend.log

echo
echo

