# $cmd/disk_create_claims  
# 00/oct/20 B.E. added backup - call to maintain_backup_copies_of_suspend_files

echo  Start Time of $cmd/disk_create_claims  is  `date` 
echo
echo "Running create_claims_from_new_susp ..."
echo
$cmd/maintain_backup_copies_of_suspend_files
echo
echo "Setting status of Header records to 'C'omplete if no errors"
qtp auto=$obj/u708.qtc

echo
echo "Transferring Suspend header/detail/desc records into Claims Master"
qtp auto=$obj/newu706a.qtc

#cobrun $obj/u706b

echo
echo "Printing report of errors in Suspended Detail file"
quiz auto=$obj/r709a.qzc


echo
echo "Printing report of errors in Suspended Header file"
quiz auto=$obj/r709b.qzc

lp r709b.txt 1>/dev/null 2>&1
lp r709a.txt 1>/dev/null 2>&1


echo  End   Time of $cmd/disk_create_claims  is  `date` 
echo
