#-------------------------------------------------------------------------------
# File 'backup_ohip_tape2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_ohip_tape2'
#-------------------------------------------------------------------------------

#  revised nov 6/96  add @mtd0:5 and after

echo "Run Backup_Ohip_tape2"
echo ""

echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""
Get-Date
echo ""

Set-Location $env:application_production
Get-ChildItem ru02*, u020_tapeout_file*, ohiptape, r001*, r014*, r801a.txt, r801b.txt, r801c.txt, r086.txt, r087.txt, `
  r088*.txt, r002*, r004_c*, r010*, ru701, u02*.sf*, u035*.sf* | Select-Object -ExpandProperty FullName > backup_ohip_tape2.ls
(Get-Content backup_ohip_tape2.ls | Select-Object -Skip 3) | Set-Content backup_ohip_tape2.ls

# CONVERSION ERROR (expected, #33): tape device is involved.
# cat backup_ohip_tape2.ls | cpio -ocuvB |dd of=/dev/rmt/0
&"C:\Program Files\7-Zip\7z.exe" a -aoa backup_ohip_tape2.tar backup_ohip_tape2.ls

echo ""
Get-Date
echo ""
echo "Backup done .. rewinding tape .."
echo ""

# CONVERSION ERROR (expected, #41): tape device is involved.
# mt -f /dev/rmt/0 rewind

#echo
#echo VERIFICATION NOW COMMENCING ... Be patient - this may take some time!
#echo
#echo Output is being sent to a file that will be paged out at end of verify ...
#echo
#date
#echo

#dd if=/dev/rmt/0 | cpio -itcvB  > backup_ohip_tape2.log

#date
#echo
#echo
#echo Comparing lines in .ls vs .log

#ls -l backup_ohip_tape2.ls backup_ohip_tape2.log

#cat backup_ohip_tape2.ls  | wc -l
#cat backup_ohip_tape2.log | wc -l

echo ""
echo ""
#echo Press Enter to page out verification log
#read garbage
#pg backup_ohip_tape2.log

echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #73): tape device is involved.
# mt -f /dev/rmt/0 rewind

#if you want to see the contents of the tape run the following - this won't reload
#dd if=/dev/rmt/0 | cpio -itcvB

#if you want to reload the selected files you have specified in reload file from 101c/production then 
# create a reload file in production with the names of the reports you want to reload then run the command below
#If you want to reload everything from the tape, then take out  -E reload.

#reload command below
#dd if=/dev/rmt/0 | cpio -icuvB -E reload
