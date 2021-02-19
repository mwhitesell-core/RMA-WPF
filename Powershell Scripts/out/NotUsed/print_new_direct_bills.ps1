#-------------------------------------------------------------------------------
# File 'print_new_direct_bills.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'print_new_direct_bills'
#-------------------------------------------------------------------------------

clear
echo ""
echo "PRINT THE NEW DIRECT BILL INVOICES"
echo ""
echo "THIS PROGRAM USESSETFORMS AND  MUST BE RUN FROM THE BACKGROUND CONSOLE"
echo ""
echo "ENTER  `"^C^A`" TO ABORT OR `"NEWLINE`" TO CONTINUE"
 $garbage = Read-Host

echo ""
echo "LOAD THE NEW DIRECT BILL INVOICE FORMS FOR CLINICS 22 AND 60 ON THE LINEPRINTER"
echo ""

echo "HIT   `"NEWLINE`"   WHEN READY ..."
 $garbage = Read-Host

Get-Content ru035 | Out-Printer

echo ""
echo ""

Get-Content ru035ca | Out-Printer
echo ""
echo ""
echo ""
echo "REMOVE INVOICES FROM LINEPRINTER WHEN FINISHED AND REPLACE WITH STANDARD PAPER"
echo "HIT  `"NEWLINE`"  WHEN READY ..."
$garbage = Read-Host

Get-Content blank_page_to_reset_lpt | Out-Printer

echo ""
echo "FINISHED .."

echo ""
echo ""
