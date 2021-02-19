cd $application_production/94
rm status.ls
#batch << BATCH_EXIT
$cmd/status94 1>status.ls 2>&1
#BATCH_EXIT
