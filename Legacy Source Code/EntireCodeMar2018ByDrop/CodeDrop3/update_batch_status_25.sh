cd $application_production/25
rm status.ls
#batch << BATCH_EXIT
$cmd/status25 1>status.ls 2>&1
#BATCH_EXIT
