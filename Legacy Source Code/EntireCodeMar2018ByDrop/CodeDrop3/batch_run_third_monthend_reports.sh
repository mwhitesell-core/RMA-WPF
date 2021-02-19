##  $cmd/batch_run_third_monthend_reports
##  execute $cmd/run_monthend_stage40, $cmd/run_monthends_31to48, $cmd/run_monthend_ar 
##  and $cmd/reports_third_monthend in batch

batch << BATCH_EXIT 
$cmd/run_monthend_stage40    > batch_run_monthend_stage40.log
$cmd/run_monthend_ar         > batch_run_monthend_ar.log
$cmd/run_monthends_31to48    > batch_run_monthends_31to48.log
$cmd/reports_third_monthend  > batch_reports_third_monthend.log          
BATCH_EXIT
