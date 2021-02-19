#-------------------------------------------------------------------------------
# File 'create_claims_from_new_susp_bk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_claims_from_new_susp_bk'
#-------------------------------------------------------------------------------

# create_claims_from_new_susp
# 00/oct/20 B.E. added backup - call to maintain_backup_copies_of_suspend_files
echo ""
Get-Date
echo ""
echo "Running create_claims_from_new_susp ..."
echo ""
&$env:cmd\maintain_backup_copies_of_suspend_files
echo ""
echo "Setting status of Header records to 'C'omplete if no errors"
&$env:QTP u708

echo ""
echo "Transferring Suspend header\detail\desc records into Claims Master"
&$env:QTP newu706a

#cobrun $obj/u706b

echo ""
echo "Printing report of errors in Suspended Detail file"
&$env:QUIZ r709a


echo ""
echo "Printing report of errors in Suspended Header file"
&$env:QUIZ r709b

Get-Content r709b.txt | Out-Printer *> $null
Get-Content r709a.txt | Out-Printer *> $null

echo ""
Get-Date
echo ""
