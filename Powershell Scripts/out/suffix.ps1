#-------------------------------------------------------------------------------
# File 'suffix.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'suffix'
#-------------------------------------------------------------------------------

echo ""
echo "Report suspend_suffix"
echo ""
Remove-Item suspend_suffix.txt *> $null
$rcmd = $env:QUIZ + "suspend_suffix"
Invoke-Expression $rcmd

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content suspend_suffix.txt | Out-Printer -Name $env:networkprinter
}
