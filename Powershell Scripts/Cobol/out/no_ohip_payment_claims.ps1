#-------------------------------------------------------------------------------
# File 'no_ohip_payment_claims.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'no_ohip_payment_claims'
#-------------------------------------------------------------------------------

Remove-Item utl00013.txt  > $null
Remove-Item utl00013*.sf*  > $null
$pipedInput = @"
20000101
20170218
"@

$pipedInput | quiz++ $obj\utl00013

Get-Contents utl00013.txt| Out-Printer  > $null
