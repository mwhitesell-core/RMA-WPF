#-------------------------------------------------------------------------------
# File 'clinic26_g040.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'clinic26_g040'
#-------------------------------------------------------------------------------

Set-Location $root\alpha\rmabill\rmabill101c\production

Remove-Item g040.txt  > $null

echo "Start Time is$(udate)"

$pipedInput = @"
exec $obj/g040_code.qtc
201702
exit
"@

$pipedInput | qtp++

quiz++ $obj\g040_code

Get-Contents g040.txt| Out-Printer

echo "End Time is$(udate)"
