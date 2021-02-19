#-------------------------------------------------------------------------------
# File 'convert_rat_to_ascii.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'convert_rat_to_ascii'
#-------------------------------------------------------------------------------

echo "CONVERT_RAT_TO_ASCII"
echo ""
echo "- W A R N I N G -"
echo ""
echo "THE PREVIOUS RAT-TAPE'S DISK FILE WILL NOW BE DELETED --"
echo ""
echo "HIT `"NEWLINE`" TO DELETE FILE AND CONTINUE CONVERSION ..."
echo ""
$garbage = Read-Host
echo ""

Remove-Item ohip_rat_ascii *> $null
echo ""
echo ""
# CONVERSION ERROR (unexpected, #15): Unknown command.
# dd if=filter_rat_tape of=ohip_rat_ascii conv=ascii
echo ""
echo "JOB COMPLETED ..."
