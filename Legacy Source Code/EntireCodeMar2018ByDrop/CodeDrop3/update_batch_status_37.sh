cd $application_production/37
rm status.ls
#batch << BATCH_EXIT
$cmd/status37 1>status.ls 2>&1
#BATCH_EXIT
