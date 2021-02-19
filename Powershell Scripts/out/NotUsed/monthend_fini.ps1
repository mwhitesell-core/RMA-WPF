#-------------------------------------------------------------------------------
# File 'monthend_fini.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'monthend_fini'
#-------------------------------------------------------------------------------

echo "MONTHEND_FINI"
echo ""
echo ""
echo "B A C K U P   F O R   M O N T H E N D   F I N I !!!!!!"
echo ""

#c c $cmd/backup_f001_f050

echo ""
echo ""
echo "**** NOTE ****TAPE HAS BEEN AUTOMATICALLY REWOUND, BUT DO NOT REMOVE IT."
echo "CHEQUE REGISTER WILL BE COPIED ONTO SAME TAPE."
echo ""
echo ""
echo "BACKUP OF:"
echo "----------!  F060 - CHEQUE REGISTER MSTR"
echo ""
echo ""
echo "HIT `"NEWLINE`" TO COMMENCE BACKUP ..."
$garbage = Read-Host
echo ""
echo "BACKUP NOW COMMENCING ..."


echo ""
Get-Date
echo ""

# CONVERSION ERROR (expected, #29): tape device is involved.
# cat $pb_data/f060_cheque_reg_mstr* |cpio -ocuvB |dd of=/dev/rmt/1

echo ""
Get-Date
echo ""

# CONVERSION ERROR (expected, #35): tape device is involved.
# mt -f /dev/rmt/1 rewind

echo ""
echo ""
echo "MONTHEND-FINI BACKUPS COMPLETED ..."
