#-------------------------------------------------------------------------------
# File 'clinic26_k037.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'clinic26_k037'
#-------------------------------------------------------------------------------

Set-Location \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production

Remove-Item k037.txt *> $null

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

$rcmd = $env:QTP + "k037_code 201704"
Invoke-Expression $rcmd 

$rcmd = $env:QUIZ + "k037_code DISC_k037"
Invoke-Expression $rcmd

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content k037.txt | Out-Printer -Name $env:networkprinter
}

echo "End Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
