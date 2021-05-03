#-------------------------------------------------------------------------------
# File 'solo_payments.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'solo_payments'
#-------------------------------------------------------------------------------

#quiz++ $obj\solo_payments
$rcmd = $env:QUIZ + "solo_payments"
Invoke-Expression $rcmd

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content solo_payments.txt | Out-Printer -Name $env:networkprinter
}
