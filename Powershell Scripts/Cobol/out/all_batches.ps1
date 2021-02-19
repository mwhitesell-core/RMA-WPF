#-------------------------------------------------------------------------------
# File 'all_batches.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
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

Set-Location $application_production
cobrun++ $obj\r001b
echo ""
Get-ChildItem r001b
echo ""
echo "HIT  `"NEWLINE`"  TO QUEUE THE REPORT FOR PRINTING"
#read garbage
echo ""

#lp r001b
