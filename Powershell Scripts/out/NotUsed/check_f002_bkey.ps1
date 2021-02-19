#-------------------------------------------------------------------------------
# File 'check_f002_bkey.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'check_f002_bkey'
#-------------------------------------------------------------------------------

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Set-Location $Env:root\alpha\rmabill\rmabill101c\src\fixup

&$env:QUIZ check_f002_bkey

echo "Ending Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
