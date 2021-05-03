#-------------------------------------------------------------------------------
# File 'check_suspend_dtl.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'check_suspend_dtl'
#-------------------------------------------------------------------------------

Remove-Item check_susp_dtl.txt *> $null


$rcmd= $env:QUIZ + "check_susp_dtl"
Invoke-Expression $rcmd

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content check_susp_dtl.txt | Out-Printer -Name $env:networkprinter
}
