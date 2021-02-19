cd $application_production/93
rm status.ls
#batch << BATCH_EXIT
$cmd/status93 1>status.ls 2>&1
#BATCH_EXIT
