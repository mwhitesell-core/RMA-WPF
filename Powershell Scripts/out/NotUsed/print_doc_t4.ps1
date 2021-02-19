#-------------------------------------------------------------------------------
# File 'print_doc_t4.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'print_doc_t4'
#-------------------------------------------------------------------------------

echo "PRINT_DOC_T4"
echo ""
echo ""
echo ""
echo ""
echo "PRINT DOCTOR T4'S"
echo ""
echo "NOTE:  THIS MACRO USES 'SETFORMS' AND MUST BE RUN FROM THE BACKGROUND CONSOLE"
echo ""
echo ""

Set-Location $env:application_production

Get-ChildItem -Force r150ca

echo ""
echo ""
echo "LOAD T4 FORMS ON THE PRINTER ... HIT `"NEW-LINE`" WHEN READY ..."
$garbage = Read-Host

echo ""

Get-Content r150ca | Out-Printer

echo ""
echo ""
echo "FINISHED ....."
