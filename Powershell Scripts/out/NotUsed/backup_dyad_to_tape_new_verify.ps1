#-------------------------------------------------------------------------------
# File 'backup_dyad_to_tape_new_verify.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_dyad_to_tape_new_verify'
#-------------------------------------------------------------------------------

# 2006/oct/11 b.e. removed data2/ma and icu from backups as per yas request
# 2007/nov/14 M.C. modify and correct accordingly based on Yasemin's agreement
#                  101c/data & mp/data are being backup once a week by $cmd/backupdata_101c_mp
# 2008/01/03  yas  comment out ma since we back it up monthly


echo "BACKUP_DYAD_TO_TAPE_VERIFY"
echo ""
echo ""
echo "VERIFY NOW COMMENCING ..."
echo ""
echo "Rewinding tape ..."
# CONVERSION ERROR (expected, #14): tape device is involved.
# mt -f /dev/rmt/1 rewind

Get-Date
echo "starting verify of tape ..."
# tar -tv1 >   $pb_data/backup_dyad_to_tape.log
# CONVERSION ERROR (expected, #19): tape device is involved.
# dd if=/dev/rmt/1 | uncompress -c | tar -tvf >  $pb_data/backup_dyad_to_tape.log

echo ""
echo "Done verifying ..."
Get-Date

echo "Comparing lines in .ls vs .log"
Get-ChildItem $pb_data\backup_dyad_to_tape.ls, $pb_data\backup_dyad_to_tape.log
echo ""
Get-Content $pb_data\backup_dyad_to_tape.ls | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content $pb_data\backup_dyad_to_tape.log | Measure-Object -Line | Select -ExpandProperty Lines

echo ""
#echo Press Enter to page out verification log
#read garbage
#pg data/backup_daily_complete.log

echo ""
Get-Date
echo ""

echo "Rewinding tape ..."
# CONVERSION ERROR (expected, #41): tape device is involved.
# mt -f /dev/rmt/1 rewind
echo ""

Get-Date
echo "DONE!"
