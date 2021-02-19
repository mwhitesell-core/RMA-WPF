#-------------------------------------------------------------------------------
# File 'backup_eft.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'backup_eft'
#-------------------------------------------------------------------------------

# Save the current working directory
Push-Location -Path .

# CREATED oct/98 

Set-Location $env:application_production
Get-Location

echo ""
echo "performing EFT backup to TAPE ..."
echo ""
Get-Location
echo ""
#echo "Press Enter to begin backup:"
#$garbage = Read-Host

echo "Backup started ..."

Get-ChildItem eft* | Select-Object Name > backup_eft.ls
&"C:\Program Files\7-Zip\7z.exe" a -aoa backup_eft.tar eft*


# CONVERSION ERROR (expected, #17): tape device is involved.
# cat $application_production/backup_eft.ls |cpio -ocuvB > /dev/rmt/0 

echo "Backup Done - rewinding tape ..."
# CONVERSION ERROR (expected, #20): tape device is involved.
# mt -f /dev/rmt/0 rewind

echo ""
echo "VERIFICATION NOW COMMENCING ... Be patient - this may take some time!"
echo ""
echo "Output is being sent to a file that will be paged out at end of verify ..."
echo ""
# CONVERSION ERROR (expected, #27): tape device is involved.
# cpio -itcvB < /dev/rmt/0 >   backup_eft.log
&"C:\Program Files\7-Zip\7z.exe" l backup_eft.tar > backup_eft.log
(Get-Content backup_eft.log | Select-Object -Skip 17) | Set-Content backup_eft.log
$test = Get-Content backup_eft.log
$test = $test[0..($test.count-3)]
$test | ForEach { $_.Remove(0,53) } | Set-Content backup_eft.log
echo ""
Get-ChildItem backup_eft.ls, backup_eft.log
echo ""
echo "Comparing lines in .log vs .ls"
Get-Content backup_eft.log | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content backup_eft.ls | Select-Object -Skip 3 | Measure-Object -Line | Select -ExpandProperty Lines

echo ""
#echo "Press Enter to page out verification log"
#$garbage = Read-Host

Get-Content backup_eft.log

echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #45): tape device is involved.
# mt -f /dev/rmt/0 rewind

# Go back to the original directory before script was launched.
Pop-Location

