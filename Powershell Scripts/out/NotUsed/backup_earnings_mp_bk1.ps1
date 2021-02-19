#-------------------------------------------------------------------------------
# File 'backup_earnings_mp_bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_earnings_mp_bk1'
#-------------------------------------------------------------------------------

# EARNINGS_BACKUP.CLI
# parameters: $1 contains the EP being run

# 2000/11/13  yas backup disk files *Z daily and monthend onto tape 

Set-Location $pb_data
Get-Date
echo ""
echo "performing additional backup to TAPE ..."
echo ""
Get-Location
echo "Press Enter to begin backup:"
$garbage = Read-Host

echo "Backup started ..."
Get-ChildItem *.Z > backup_earnings_mp.ls
echo ""
Get-Date
# CONVERSION ERROR (expected, #19): tape device is involved.
# cat backup_earnings_mp.ls  |cpio -ocuvB > /dev/rmt/0
echo ""
Get-Date
echo ""

# CONVERSION ERROR (expected, #24): tape device is involved.
# mt -f /dev/rmt/0 rewind
echo ""
echo "VERIFICATION NOW COMMENCING ... Be patient - this may take some time!"
echo ""
echo "Output is being sent to a file that will be paged out at end of verify ..."
echo ""
# CONVERSION ERROR (expected, #30): tape device is involved.
# cpio -itcvB < /dev/rmt/0 >   backup_earnings_mp.log
echo ""

Get-ChildItem backup_earnings_mp.ls, backup_earnings_mp.log
echo ""
echo "Comparing lines in .ls vs .log"
Get-Content backup_earnings_mp.ls | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content backup_earnings_mp.log | Measure-Object -Line | Select -ExpandProperty Lines

echo ""
echo "Press Enter to page out verification log"
$garbage = Read-Host

Get-Content backup_earnings_mp.log

echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #49): tape device is involved.
# mt -f /dev/rmt/0 rewind
