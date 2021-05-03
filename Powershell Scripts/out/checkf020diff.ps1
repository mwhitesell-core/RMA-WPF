#-------------------------------------------------------------------------------
# File 'checkf020diff.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'checkf020diff'
#-------------------------------------------------------------------------------

$rcmd = $env:QUIZ + "checkf020a"
Invoke-Expression $rcmd

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content checkf020a.txt | Out-Printer -Name $env:networkprinter
}
