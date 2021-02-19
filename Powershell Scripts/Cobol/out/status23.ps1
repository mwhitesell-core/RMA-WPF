#-------------------------------------------------------------------------------
# File 'status23.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'status23'
#-------------------------------------------------------------------------------

Set-Location $application_production\23
echo "BEGIN NOW...$(udate)"
$pipedInput = @"
23000000
23ZZZZZZ
"@

$pipedInput | qtp++ $obj\u210
echo "ENDING....$(udate)"

echo "BEGIN NOW...$(udate)"
$pipedInput = @"
23000000
23ZZZZZZ
"@

$pipedInput | quiz++ $obj\r211
echo "ENDING....$(udate)"

Get-Contents r211| Out-Printer
#lp status.ls
