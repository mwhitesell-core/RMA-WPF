cd $application_production/91
rm status.ls
#batch << BATCH_EXIT
$cmd/status91 1>status.ls 2>&1
#BATCH_EXIT
