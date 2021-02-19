#-------------------------------------------------------------------------------
# File 'all_batches.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'all_batches'
#-------------------------------------------------------------------------------

echo "ALL BATCHES"
echo ""

echo "PRINT THE ALL BATCHES STATUS SUMMARY REPORT"
echo ""
echo "HIT  `"NEWLINE`"  TO CONTINUE ..."
#read garbage
echo ""
echo "PROGRAM `"R001B`" NOW LOADING ..."

Set-Location $env:application_production
$rcmd = $env:COBOL + "r001b"
Invoke-Expression $rcmd
echo ""
Get-ChildItem r001b
echo ""
echo "HIT  `"NEWLINE`"  TO QUEUE THE REPORT FOR PRINTING"
#read garbage
echo ""

#lp r001b
