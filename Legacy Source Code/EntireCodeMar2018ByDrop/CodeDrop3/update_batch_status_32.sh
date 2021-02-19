cd $application_production/32
rm status.ls
#batch << BATCH_EXIT
$cmd/status32 1>status.ls 2>&1
#BATCH_EXIT
