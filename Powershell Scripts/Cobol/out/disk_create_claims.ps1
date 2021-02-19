#-------------------------------------------------------------------------------
# File 'disk_create_claims.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'disk_create_claims'
#-------------------------------------------------------------------------------

# $cmd/disk_create_claims  
# 00/oct/20 B.E. added backup - call to maintain_backup_copies_of_suspend_files

echo "Start Time of $cmd\disk_create_claims  is$(udate)"
echo ""
echo "Running create_claims_from_new_susp ..."
echo ""
$cmd\maintain_backup_copies_of_suspend_files
echo ""
echo "Setting status of Header records to 'C'omplete if no errors"
qtp++ $obj\u708

echo ""
echo "Transferring Suspend header\detail\desc records into Claims Master"
qtp++ $obj\newu706a

#cobrun $obj/u706b

echo ""
echo "Printing report of errors in Suspended Detail file"
quiz++ $obj\r709a


echo ""
echo "Printing report of errors in Suspended Header file"
quiz++ $obj\r709b

Get-Contents r709b.txt| Out-Printer  > $null
Get-Contents r709a.txt| Out-Printer  > $null


echo "End   Time of $cmd\disk_create_claims  is$(udate)"
echo ""
