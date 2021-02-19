cd $application_production/86
rm status.ls
#batch << BATCH_EXIT
$cmd/status86 1>status.ls 2>&1
#BATCH_EXIT
