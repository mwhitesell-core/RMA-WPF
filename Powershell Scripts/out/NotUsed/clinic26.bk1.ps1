#-------------------------------------------------------------------------------
# File 'clinic26.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'clinic26.bk1'
#-------------------------------------------------------------------------------

Set-Location $Env:root\alpha\rmabill\rmabill101c\src\yas

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:QTP "Exec $obj/clinic26.qtc" 201508

echo "End Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
