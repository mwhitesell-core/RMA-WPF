##  $cmd/batch_run_first_monthend_reports
##  execute $cmd/run_monthends_80_91to96, $cmd/reports_first_monthend in batch

batch << BATCH_EXIT 
$cmd/run_monthends_80_91to96    > batch_run_monthends_80_91to96.log
$cmd/reports_first_monthend     > batch_reports_first_monthend.log
BATCH_EXIT



