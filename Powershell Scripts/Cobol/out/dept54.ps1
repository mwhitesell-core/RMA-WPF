#-------------------------------------------------------------------------------
# File 'dept54.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'dept54'
#-------------------------------------------------------------------------------

Set-Location $root\alpha\rmabill\rmabill101c\src\yas

echo "Start Time of $cmd\dept54 is$(udate)"

$pipedInput = @"
Exec $obj/dept54_billings.qtc
201702
exit
"@

$pipedInput | qtp++

echo "End Time of $cmd\dept54 is$(udate)"
