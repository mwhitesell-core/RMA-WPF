#-------------------------------------------------------------------------------
# File 'recoverf002.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'recoverf002'
#-------------------------------------------------------------------------------

echo "Recover the claims master file"
echo "No one must be accessing the batch control and claims files"
echo "For the clinic being processed"
echo ""
Get-Date
echo ""
&$env:COBOL r992
echo ""
Get-Date
echo ""
Get-Content r992 | Out-Printer

echo ""
echo ""



