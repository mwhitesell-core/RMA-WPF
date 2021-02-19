#-------------------------------------------------------------------------------
# File 'disk_create_claims.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'disk_create_claims'
#-------------------------------------------------------------------------------

# $cmd/disk_create_claims  
# 00/oct/20 B.E. added backup - call to maintain_backup_copies_of_suspend_files

echo "Start Time of $env:cmd\disk_create_claims  is  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo ""
echo "Running create_claims_from_new_susp ..."
echo ""
#CORE - Load suspend file into SQL server
if($args[0] -ne "false") {
    $rcmd = $env:QTP + "load_f002_suspend_files"
    Invoke-Expression $rcmd
}

&$env:cmd\maintain_backup_copies_of_suspend_files
echo ""
echo "Setting status of Header records to 'C'omplete if no errors"
$rcmd = $env:QTP + "u708"
Invoke-Expression $rcmd

echo ""
echo "Transferring Suspend header\detail\desc records into Claims Master"
$rcmd = $env:QTP + "newu706a"
Invoke-Expression $rcmd

#CORE - Delete suspend dat files and recreate them
Remove-Item f002_suspend_address.dat
Remove-Item f002_suspend_desc.dat
Remove-Item f002_suspend_dtl.dat
Remove-Item f002_suspend_hdr.dat

New-Item -Path . -Name "f002_suspend_address.dat" -ItemType "file"
New-Item -Path . -Name "f002_suspend_dtl.dat" -ItemType "file"
New-Item -Path . -Name "f002_suspend_hdr.dat" -ItemType "file"
New-Item -Path . -Name "f002_suspend_desc.dat" -ItemType "file"


#cobrun $obj/u706b

echo ""
echo "Printing report of errors in Suspended Detail file"
$rcmd = $env:QUIZ + "r709a"
Invoke-Expression $rcmd


echo ""
echo "Printing report of errors in Suspended Header file"
$rcmd = $env:QUIZ + "r709b"
Invoke-Expression $rcmd

Get-Content r709b.txt | Out-Printer *> $null
Get-Content r709a.txt | Out-Printer *> $null


echo "End   Time of $env:cmd\disk_create_claims  is  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo ""
