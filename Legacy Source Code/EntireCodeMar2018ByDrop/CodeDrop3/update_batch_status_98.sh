cd $application_production/98
rm status.ls
#batch << BATCH_EXIT
$cmd/status98 1>status.ls 2>&1
#BATCH_EXIT
