#-------------------------------------------------------------------------------
# File 'convert_fee_ohip_to_ascii.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'convert_fee_ohip_to_ascii'
#-------------------------------------------------------------------------------

echo "CONVERT_FEE_OHIP_TO_ASCII"
echo ""
echo ""
echo "OHIP FEE SCHEDULE TAPE CONVERSION"
echo "HIT `"NEWLINE`" TO DELETE FILE AND COMMENCE CONVERSION ..."
echo ""
echo "^C TO ABORT !!!"
echo ""
 $garbage = Read-Host
echo ""

Remove-Item fee_schedule_ohip_ascii
echo ""
echo ""

# CONVERSION ERROR (unexpected, #16): Unknown command.
# dd if=filter_fee_tape_ohip of=fee_schedule_ohip_ascii conv=ascii

echo ""
echo "FINISHED ..."
echo ""
echo ""
