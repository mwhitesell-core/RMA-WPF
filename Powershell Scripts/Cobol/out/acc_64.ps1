#-------------------------------------------------------------------------------
# File 'acc_64.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'acc_64'
#-------------------------------------------------------------------------------

echo " --- r070a (COBOL) --- $(udate)"
$pipedInput = @"
64
Y
Y
"@

$pipedInput | cobrun++ $obj\r070a

echo " --- r070b (COBOL) --- $(udate)"
cobrun++ $obj\r070b

echo " --- r070c (COBOL) --- $(udate)"
$pipedInput = @"
N
"@

$pipedInput | cobrun++ $obj\r070c
