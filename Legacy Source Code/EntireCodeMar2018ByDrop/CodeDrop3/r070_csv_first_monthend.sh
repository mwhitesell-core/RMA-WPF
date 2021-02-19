#  2015/Nov/30	M.C.	$cmd/r070_csv_first_monthend      

echo "Accounts Receivable  (r070_csv) in first monthend.."
echo
echo
echo

cd $application_root/production

$cmd/r070_csv.com  1          > r070_csv_first_monthend.log

echo
echo

