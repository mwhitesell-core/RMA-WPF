cd $application_production/79
rm status.ls
#batch << BATCH_EXIT
$cmd/status79 1>status.ls 2>&1
#BATCH_EXIT
