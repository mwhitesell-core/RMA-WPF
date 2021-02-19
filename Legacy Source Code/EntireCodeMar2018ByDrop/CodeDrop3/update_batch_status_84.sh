cd $application_production/84
rm status.ls
#batch << BATCH_EXIT
$cmd/status84 1>status.ls 2>&1
#BATCH_EXIT
