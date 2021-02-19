cd $application_production/89
rm status.ls
#batch << BATCH_EXIT
$cmd/status89 1>status.ls 2>&1
#BATCH_EXIT
