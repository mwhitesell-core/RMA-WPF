## $cmd/run_monthends_60_82_83_86

echo Start Time of $cmd/run_monthends_60_82_83_86 is `date`

echo
echo        RUN MONTHEND REPORTS AND ACCOUNTS RECEIVABLE
echo    
echo        FOR clinics 61 - 70, 82, 83 and 86
echo
date

echo
$cmd/run_monthend_ar_82
$cmd/monthly_stage40_and_ar_tp
$cmd/run_monthend_ar_86
$cmd/run_monthend_ar_70
echo
echo NOW RUNNING portal reports r004 and r051
$cmd/r004_ph_portal_60_82_83_86
$cmd/r051_portal_60_70_82_86

date
echo
echo End   Time of $cmd/run_monthends_60_82_83_86 is `date`
