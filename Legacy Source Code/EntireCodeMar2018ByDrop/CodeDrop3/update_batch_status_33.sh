cd $application_production/33
rm status.ls
#batch << BATCH_EXIT
$cmd/status33 1>status.ls 2>&1
#BATCH_EXIT
