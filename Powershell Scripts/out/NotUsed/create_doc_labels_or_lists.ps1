#-------------------------------------------------------------------------------
# File 'create_doc_labels_or_lists.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_doc_labels_or_lists'
#-------------------------------------------------------------------------------

echo "CREATE_DOC_LABELS_OR_LISTS"
echo ""

echo "DOCTOR LABEL\LIST\DUMP PROGRAM"
echo ""
echo ""
echo "HIT `"^C`" OR `"NEWLINE`"  TO CONTINUE ..."
 $garbage = Read-Host
echo ""
echo "PROGRAMR020 NOW LOADING ..."

&$env:COBOL r020
echo ""

Get-ChildItem r020*
echo ""
echo "TO PRINT THE ABOVE CREATED OUTPUT  ENTER:"
echo ""
echo "PRINT_DOC_LABELS OR PRINT_DOC_LISTS"
echo ""
echo "DEPENDING UPON THE TYPE OF OUTPUT YOU GENERATED"
echo ""
echo ""
echo "FINISHED ..."
