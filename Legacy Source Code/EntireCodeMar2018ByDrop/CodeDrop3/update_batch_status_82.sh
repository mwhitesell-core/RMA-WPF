cd $application_production/82
rm status.ls
#batch << BATCH_EXIT
$cmd/status82 1>status.ls 2>&1
#BATCH_EXIT
