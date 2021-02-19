##  $cmd/batch_run_second_monthend_reports
##  execute $cmd/run_monthends_60_82_83_86, $cmd/reports_second_monthend in batch

batch << BATCH_EXIT 
$cmd/run_monthends_60_82_83_86    > batch_run_monthends_60_82_83_86.log
$cmd/reports_second_monthend	  > batch_report_second_monthend.log
BATCH_EXIT
