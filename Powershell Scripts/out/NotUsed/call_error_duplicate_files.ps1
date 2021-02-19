#-------------------------------------------------------------------------------
# File 'call_error_duplicate_files.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'call_error_duplicate_files'
#-------------------------------------------------------------------------------

#  CALL_ERROR_DUPLICATE_FILES JAN FEB
echo ""
echo "*E* ERROR DUPLICATE SUBFILES ON SYSTEM:"
echo ""
echo "FOUND FILE: ${1}"
echo "AND       : ${2}"
echo ""
echo "DELETE THE FILE NOT WANTED"
echo ""
echo "HIT `"NEWLINE`" TO CONTINUE"
$garbage = Read-Host
