#-------------------------------------------------------------------------------
# File 'r140_verify.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'r140_verify'
#-------------------------------------------------------------------------------

# r140_verify

echo "Running r140_verify"
echo ""
echo "if an error report is generated it will be paged out at end of run"
echo "if no records are selected then everything balances"
echo ""
echo ""

&$env:cmd\r140_verify.com > r140_verify.log
Get-Content r140w.txt

echo ""
echo "Done!"
