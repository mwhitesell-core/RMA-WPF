#-------------------------------------------------------------------------------
# File 'drsethi_rat.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'drsethi_rat'
#-------------------------------------------------------------------------------

Set-Location $Env:root\alpha\rmabill\rmabill101c\production

Copy-Item u030_tape_145_file.dat u030_tape_145_file_bkp1.dat
Get-Content u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:QTP drsethi_rat

&$env:QUIZ drsethi_rat


Remove-Item u030_tape_145_file.dat *> $null
Copy-Item u030_tape_145_file_bkp1.dat u030_tape_145_file.dat

echo "End Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
