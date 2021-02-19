cd $application_production/70
rm status.ls
#batch << BATCH_EXIT
$cmd/status70 1>status.ls 2>&1
#BATCH_EXIT
