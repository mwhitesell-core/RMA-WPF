#-------------------------------------------------------------------------------
# File 'create_doc_t4.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_doc_t4'
#-------------------------------------------------------------------------------

echo "CREATE_DOC_T4"
echo ""

echo "CREATE DOCTOR T4's AND PRINT T4 AUDIT REPORT"
echo ""
echo ""
echo "HIT `"^C`" or `"NEWLINE`"  TO CONTINUE ..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"R150A`" TO CREATE WORK FILE NOW LOADING ..."

&$env:COBOL r150a
Get-ChildItem -Force r150a

echo "HIT `"NEWLINE`" TO PRINT r150a ..."
 $garbage = Read-Host

echo ""

Get-Content r150a | Out-Printer

echo ""
echo "WORK FILE CREATED:"

Get-ChildItem -Force r150_work_mstr

echo ""
echo "HIT `"NEWLINE`" TO CONTINUE ..."
$garbage = Read-Host

echo ""
echo "PROGRAM `"R150B`" TO SORT WORK FILE NOW LOADING ..."

&$env:COBOL r150b
echo ""

echo ""
echo "SORTED WORK FILE CREATED:"

Get-ChildItem -Force r150_srt_work_mstr

echo ""
echo "HIT `"NEWLINE`" TO CONTINUE ..."
$garbage = Read-Host

echo ""
echo "PROGRAM r150c TO PRINT T4'S AND AUDIT REPORT NOW LOADING ..."

&$env:COBOL r150c

echo ""
echo "HIT `"NEWLINE`" TO PRINT r150cb..."
$garbage = Read-Host

Get-Content r150cb | Out-Printer

echo ""
echo "LOAD 'T4' FORMS ON THE PRINTER"
echo "ON THE BACKGROUND CONSOLE ENTER:"
echo "ENTERPRINT_DOC_T4"
echo ""
echo ""
echo ""
echo "FINISHED ....."
