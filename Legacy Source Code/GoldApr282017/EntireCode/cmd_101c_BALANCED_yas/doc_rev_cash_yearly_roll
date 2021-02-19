rm roll.ls
#batch << BATCH_EXIT
qtp 1>roll.ls 2>&1 << QTP_EXIT
exe $obj/purge_f050_f051
QTP_EXIT

ls -l roll.ls 
lp roll.ls


echo "Done!" >> roll.ls


#BATCH_EXIT
