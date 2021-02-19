cd $application_production/44
rm status.ls
#batch << BATCH_EXIT
$cmd/status44 1>status.ls 2>&1
#BATCH_EXIT
