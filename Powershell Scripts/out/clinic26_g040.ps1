#-------------------------------------------------------------------------------
# File 'clinic26_g040.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'clinic26_g040'
#-------------------------------------------------------------------------------

Set-Location \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production

Remove-Item g040.txt *> $null

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

$rcmd = $env:QTP + "g040_code 201704"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "g040_code DISC_g040"
Invoke-Expression $rcmd

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content g040.txt | Out-Printer -Name $env:networkprinter
}

echo "End Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
