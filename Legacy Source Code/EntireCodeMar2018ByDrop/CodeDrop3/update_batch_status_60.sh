cd $application_production/60
rm status.ls
#batch << BATCH_EXIT
$cmd/status60 1>status.ls 2>&1
#BATCH_EXIT
