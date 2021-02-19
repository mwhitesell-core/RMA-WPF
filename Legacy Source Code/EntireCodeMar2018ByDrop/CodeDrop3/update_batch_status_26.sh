cd $application_production/26
rm status.ls
#batch << BATCH_EXIT
$cmd/status26 1>status.ls 2>&1
#BATCH_EXIT
