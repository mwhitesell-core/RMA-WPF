#-------------------------------------------------------------------------------
# File 'r153.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r153'
#-------------------------------------------------------------------------------

$pipedInput = @"
LIVE RUN
001
017
046
017
059
Y
N
99
2017
02
28
Y
"@

$pipedInput | cobrun++ $obj\r153a  > r153a.log  2>&1
$pipedInput = @"
99
"@

$pipedInput | cobrun++ $obj\r153b  > r153b.log  2>&1
#R153_EXIT
echo ""
echo ""
echo "Ensure the below logs are zero length files!"
Get-Contents r153ef| Out-Printer
Get-Contents r153ef| Out-Printer

echo ""
Get-ChildItem r153?.log
