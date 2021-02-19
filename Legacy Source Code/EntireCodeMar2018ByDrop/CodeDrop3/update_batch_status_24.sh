cd $application_production/24
rm status.ls
#batch << BATCH_EXIT
$cmd/status24 1>status.ls 2>&1
#BATCH_EXIT
