#-------------------------------------------------------------------------------
# File 'mp_payments.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'mp_payments'
#-------------------------------------------------------------------------------


$rcmd = $env:QUIZ + "mp_payments DISC_mp_payments.ff"
invoke-expression $rcmd

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content mp_payments.txt | Out-Printer -Name $env:networkprinter
}
