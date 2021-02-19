#-------------------------------------------------------------------------------
# File 'copy_fee_sched_ohip_to_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_fee_sched_ohip_to_disk'
#-------------------------------------------------------------------------------

echo "COPY_FEE_SCHED_OHIP_TO_DISK"
echo ""
echo ""
echo "PROGRAMMER'S NOTE: MACRO EXPECTS INPUT TAPE TO BE 'LABELLED'"
echo "IF IT'S NOT  THEN MODIFY @MTD0:1 TO REFERENCE FILE 0"
echo ""
echo ""
echo ""

echo "COPY OHIP SCHEDULE OF BENEDITS FILE FROM TAPE TO DISK"
echo ""

echo "HIT  `"NEWLINE`"  TO CONTINUE ..."
 $garbage = Read-Host

echo ""
echo ""

# CONVERSION ERROR (expected, #19): EBCDIC.
# rm  1>/dev/null 2>&1 tape_fee_schedule_ohip_ebcdic

echo ""
echo "TAPE FILE NOW BEING COPIED ..."
echo ""
# CONVERSION ERROR (expected, #24): tape device is involved.
# ls tape_fee_schedule_ohip_ebcdic |\        cpio -ocuvBL |compress |dd of=/dev/rmt/1
echo ""
echo ""
echo "FINISHED ..."
echo ""
echo ""
