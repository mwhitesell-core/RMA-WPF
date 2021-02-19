
#-------------------------------------------------------------------------------
# File 'backup_earnings_solo.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'backup_earnings_solo'
#-------------------------------------------------------------------------------

# Save the current working directory
Push-Location -Path .

# EARNINGS_BACKUP.CLI
# parameters: $1 contains 'nv' if no verify is to be performed

# 2000/11/13  yas backup disk files *Z daily and monthend onto tape 
# 2008/06/18  brad 'nv' option

echo "backup_earnings_Solo"
echo ""
echo ""

if (("$1" -ne "") -and ("$1" -ne "nv"))
{
        echo ""
        echo "**ERROR**"
        echo "You must run the backup with either no parameter or theNo Verify  parameter"
        echo ""
        echo ""
        echo "Valid format:   backup_earning_solo [nv]"
        exit
}

Set-Location $env:pb_data
#Added to account for cpio overwrite
Remove-Item backup_earnings_solo.tar
Get-Date
echo ""
echo "This macro will perform a TAPE backup ..."
echo ""
Get-Location
echo "Press Enter to begin backup:"
$garbage = Read-Host

echo "Backup started ..."
Get-ChildItem *.tar | Select-Object Name > backup_earnings_solo.ls
&"C:\Program Files\7-Zip\7z.exe" a -aoa backup_earnings_solo.tar *.tar
echo ""
Get-Date
echo ""
echo "Performing TAPE backup ..."
echo "doing cpio ....................."
# CONVERSION ERROR (expected, #38): tape device is involved.
# cat backup_earnings_solo.ls  |cpio -ocuvB > /dev/rmt/0
# IF NEEDED  - to dump contents of the tape do the following:
#cpio -itcvB  <  /dev/rmt/0
# to reload:
# vi reload_backup_earnings_solo.reload in data folder and enter names of file to be reloaded - then run below command
#cpio -iucvB -E  reload_backup_earnings_solo.reload  <  /dev/rmt/0
echo ""
Get-Date

echo ""
# CONVERSION ERROR (expected, #48): tape device is involved.
# echo mt -f /dev/rmt/0 rewind
echo ""
Get-Date

if ("$1" -ne "nv")
{
echo ""
echo "VERIFICATION NOW COMMENCING ... Be patient - this may take some time!"
echo ""
echo "Output is being sent to a file that will be paged out at end of verify ..."
echo ""
# CONVERSION ERROR (expected, #59): tape device is involved.
# cpio -itcvB < /dev/rmt/0 >   backup_earnings_solo.log
&"C:\Program Files\7-Zip\7z.exe" l backup_earnings_solo.tar > backup_earnings_solo.log
(Get-Content backup_earnings_solo.log | Select-Object -Skip 17) | Set-Content backup_earnings_solo.log
$test = Get-Content backup_earnings_solo.log
$test = $test[0..($test.count-3)]
$test | ForEach { $_.Remove(0,53) } | Set-Content backup_earnings_solo.log
echo ""

Get-ChildItem backup_earnings_solo.ls, backup_earnings_solo.log
echo ""
echo "Comparing lines in .ls vs .log"
Get-Content backup_earnings_solo.ls | Select-Object -Skip 3 | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content backup_earnings_solo.log | Measure-Object -Line | Select -ExpandProperty Lines

echo ""
# CONVERSION ERROR (expected, #69): tape device is involved.
# mt -f /dev/rmt/0 rewind
echo ""

echo "Press Enter to page out verification log"
$garbage = Read-Host

Get-Content backup_earnings_solo.log

echo ""
Get-Date

} else {
        echo "NO VERIFICATION of tape was performed!"
}
echo ""
echo "DONE!"

# Go back to the original directory before script was launched.
Pop-Location
