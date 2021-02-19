#-------------------------------------------------------------------------------
# File 'dg2pc1_rma.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'dg2pc1_rma'
#-------------------------------------------------------------------------------

echo ""
Get-Date
echo ""

&$env:QTP dg2pc1a
&$env:QTP dg2pc1b

echo ""
Get-Date
echo ""
