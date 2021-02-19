##  $cmd/batch_portal_reports
##  execute $cmd/portal_reports in batch

batch << BATCH_EXIT 
$cmd/portal_reports    > batch_portal_reports.log
BATCH_EXIT
