#-------------------------------------------------------------------------------
# File 'status22.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'status22'
#-------------------------------------------------------------------------------

echo "BEGIN NOW...$(udate)"
$pipedInput = @"
22000000
22ZZZZZZ
"@

$pipedInput | qtp++ $obj\u210
echo "ENDING....$(udate)"

echo "BEGIN NOW...$(udate)"
$pipedInput = @"
22000000
22ZZZZZZ
"@

$pipedInput | quiz++ $obj\r211
echo "ENDING....$(udate)"

Get-Contents r211.txt| Out-Printer
#lp status.ls
