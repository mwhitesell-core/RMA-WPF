## $cmd/run_monthend_ar

echo Start Time of $cmd/run_monthend_ar is `date`

rm ar.ls  1>/dev/null  2>/dev/null
$cmd/accounts_receivable  22  1>ar.ls 2>&1

echo End   Time of $cmd/run_monthend_ar is `date`

