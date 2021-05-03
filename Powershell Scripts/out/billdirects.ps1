#-------------------------------------------------------------------------------
# File 'billdirects.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'billdirects'
#-------------------------------------------------------------------------------

&$env:QUIZ billdirects
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content billdirects.txt | Out-Printer -Name $env:networkprinter
}
