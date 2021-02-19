cd $application_production/23
rm status.ls
#batch << BATCH_EXIT
$cmd/status23 1>status.ls 2>&1
#BATCH_EXIT
