#-------------------------------------------------------------------------------
# File 'backup_rat.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_rat'
#-------------------------------------------------------------------------------

echo "BACKUP_RAT"

echo "BACKUP OF:"
echo "----------!  OHIP_RAT_ASCII  - RAT FILE IN 'ASCII'  FORMAT"
echo "----------!  OHIP_RAT_EBCDIC - RAT FILE IN 'EBCDIC' FORMAT"
echo ""
echo ""

echo "HIT  `"NEWLINE`"  TO COMMENCE BACKUPS ..."
$garbage = Read-Host

echo ""
echo "BACKUPS NOW COMMENCING ..."

Set-Location $pb_data

echo ""
Get-Date
echo ""

#/bin/ls  ohip_rat_ascii rat_tape_ebcdic > backup_rat.ls
Get-ChildItem ohip_rat_ascii* > backup_rat.ls

# CONVERSION ERROR (expected, #24): tape device is involved.
# cat $pb_data/backup_rat.ls      \                | cpio -ocuvB                   \                > /dev/rmt/1
#980814 mc      | dd of=/dev/rmt/1
echo ""
Get-Date

echo ""

# CONVERSION ERROR (expected, #33): tape device is involved.
# mt -f /dev/rmt/1 rewind
