#-------------------------------------------------------------------------------
# File 'backup_subfile.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'backup_subfile'
#-------------------------------------------------------------------------------

echo "backup_subfile"
echo ""
echo "Hit NEWLINE to continue ..."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""
Set-Location $pb_data2
Get-Location
#ma/claims_sub*.sf* > ma/backup_subfile.ls (changed on jan1898)
# changed below line as 'ma' directory was setup as a link and so actual
# linked directory had to be specified - be 2006/jun/15
#/bin/ls ma/claims_subfile*.* > ma/backup_subfile.ls

# 2007/sep20 b.e. on Dyad's backup machine - dir location changed
#
#/bin/ls /charly/rmabill/rmabill101c/data2/ma/claims_subfile*.* \
#      > /charly/rmabill/rmabill101c/data2/ma/backup_subfile.ls

# 2009/sep/21 M.C  since this macro is used for 3 different environments 101, mp & solo,
#                  the below is only work for 101c but not mp & solo, comment out and change accordingly
##/bin/ls /beta/rmabill/rmabill101c/data2/ma/claims_subfile*.* \
##      > /beta/rmabill/rmabill101c/data2/ma/backup_subfile.ls

Get-ChildItem ma\claims_subfile*.*  > ma\backup_subfile.ls

##-------------------------------------------------------


echo ""
Get-Date
Get-Location

# CONVERSION WARNING; tape is involved.
# cat     ma/backup_subfile.ls |cpio -ocuvB > /dev/rmt/0
echo ""
Get-Date
echo "Rewinding tape ..."

# 2009/aug/20 - MC - & may cause error below:
#   /dev/rmt/0: Device busy
#   /dev/rmt/0: Open intent conflicts with existing opens of the device.
#mt -f /dev/rmt/0 rewind &

# CONVERSION WARNING; tape is involved.
# mt -f /dev/rmt/0 rewind 
## -------------------------------------

echo ""
echo "VERIFICATION NOW COMMENCING ... Be patient - this may take some time!"
echo ""
echo "Output is being sent to a file that will be paged out at end of verify ..."
echo ""
echo ""
# CONVERSION WARNING; tape is involved.
# cpio -itcvB < /dev/rmt/0 > ma/verify_subfile.log
echo ""
echo ""
echo "Comparing lines in .ls vs .log"
Get-ChildItem ma\backup_subfile.ls, ma\verify_subfile.log
echo ""
Get-Content ${param.outputValue} | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content ${param.outputValue} | Measure-Object -Line | Select -ExpandProperty Lines

echo ""
#echo Press Enter to page out verification log
#read garbage
#pg ma/verify_subfile.log

echo ""
Get-Date
echo "DONE!"

# CONVERSION WARNING; tape is involved.
# mt -f /dev/rmt/0 rewind
