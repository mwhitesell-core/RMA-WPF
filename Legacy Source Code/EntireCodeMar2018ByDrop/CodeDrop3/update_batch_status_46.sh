cd $application_production/46
rm status.ls
#batch << BATCH_EXIT
$cmd/status46 1>status.ls 2>&1
#BATCH_EXIT
