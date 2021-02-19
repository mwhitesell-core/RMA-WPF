#  2015/Nov/30	M.C.	$cmd/r070_csv_second_monthend      

echo "Accounts Receivable  (r070_csv) in second monthend.."
echo
echo
echo

cd $application_root/production

$cmd/r070_csv.com  2          > r070_csv_second_monthend.log

echo
echo

