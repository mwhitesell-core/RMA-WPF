#-------------------------------------------------------------------------------
# File 'clinic26_k037.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'clinic26_k037'
#-------------------------------------------------------------------------------

Set-Location $root\alpha\rmabill\rmabill101c\production

Remove-Item k037.txt  > $null

echo "Start Time is$(udate)"

$pipedInput = @"
Exec $obj/k037_code.qtc
201702
exit
"@

$pipedInput | qtp++

quiz++ $obj\k037_code

Get-Contents k037.txt| Out-Printer

echo "End Time is$(udate)"
