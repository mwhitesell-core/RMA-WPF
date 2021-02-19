#-------------------------------------------------------------------------------
# File 'r123.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r123'
#-------------------------------------------------------------------------------

#cobrun $obj/r123 1>r123.log 2>&1 << R123_EXIT
$pipedInput = @"
LIVE RUN
001
017
072
017
074
Y
N
99
2017
03
15
Y
"@

$pipedInput | cobrun++ $obj\r123a  > r123a.log  2>&1
$pipedInput = @"
99
"@

$pipedInput | cobrun++ $obj\r123b  > r123b.log  2>&1
#R123_EXIT
echo ""
echo ""
echo "Ensure the below logs are zero length files!"
echo ""
Get-ChildItem r123?.log
