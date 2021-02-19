#-------------------------------------------------------------------------------
# File 'clinic26.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'clinic26'
#-------------------------------------------------------------------------------

## $cmd/clinic26

Set-Location $root\alpha\rmabill\rmabill101c\src\yas

echo "Start Time of $cmd\clinic26 is$(udate)"

$pipedInput = @"
Exec $obj/clinic26.qtc
201702
exit
"@

$pipedInput | qtp++


echo "End Time of $cmd\clinic26 is$(udate)"
