#-------------------------------------------------------------------------------
# File 'recoverf001.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'recoverf001'
#-------------------------------------------------------------------------------

echo "Recover the batch control file"
echo ""
echo "No one must be accessing"
echo "the batch control and claims file"
echo "for the clinic being processed"
echo ""
echo ""
Get-Date
echo ""
echo "Hit NEWLINE to continue ..."
$garbage = Read-Host

&$env:COBOL u991


echo ""
Get-Date
echo ""
#lp u991
