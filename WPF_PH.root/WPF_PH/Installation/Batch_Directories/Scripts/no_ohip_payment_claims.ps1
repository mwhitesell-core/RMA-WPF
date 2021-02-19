#-------------------------------------------------------------------------------
# File 'no_ohip_payment_claims.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'no_ohip_payment_claims'
#-------------------------------------------------------------------------------

Remove-Item utl00013.txt *> $null
Remove-Item utl00013*.sf* *> $null
$rcmd = $env:QUIZ +"utl00013A 20000101 20170318"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ +"utl00013B DISC_utl00013"
Invoke-Expression $rcmd

Get-Content utl00013.txt | Out-Printer *> $null
