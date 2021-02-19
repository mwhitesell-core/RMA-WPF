cd $application_production/30
rm status.ls
#batch << BATCH_EXIT
$cmd/status30 1>status.ls 2>&1
#BATCH_EXIT
