#-------------------------------------------------------------------------------
# File 'print_doc_labels.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'print_doc_labels'
#-------------------------------------------------------------------------------

echo "PRINT_DOC_LABELS"
echo ""

echo "PRINT DOCTOR MAILING LABELS"
echo ""
echo "!! WARNING !!"
echo "THIS PROGRAM USESSETFORMS AND MUST BE RUN FROM THE BACKGROUND CONSOLE"
echo ""
echo "DO YOU WISH TO ABORT NOW???"
echo ""
echo "HIT `"^C^A`" OR `"NEWLINE`"  TO CONTINUE ..."
$garbage = Read-Host

Get-ChildItem -Force r020d

echo ""
echo ""
echo "LOAD DOCTOR MAILING LABELS ON THE LINEPRINTER"
echo ""
echo "HIT  `"NEWLINE`"  WHEN READY..."
$garbage = Read-Host


echo ""
echo ""

Get-Content r020d | Out-Printer

echo ""
echo ""
echo ""
echo "WHEN FINISHED PRINTING REMOVE MAILING LABELS FROM LINEPRINTER AND REPLACE WITH STANDARD PAPER"
echo ""
echo ""
echo ""

echo "HIT  `"NEWLINE`"  WHEN READY..."
$garbage = Read-Host

Get-Content blank_page_to_reset_lpt | Out-Printer

echo ""
echo "FINISHED ..."
