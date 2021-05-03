#-------------------------------------------------------------------------------
# File 'status82.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'status82'
#-------------------------------------------------------------------------------

echo "BEGIN NOW...  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
$rcmd = $env:QTP + "u210 82000000 82ZZZZZZ"
Invoke-Expression $rcmd
echo "ENDING.... $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

echo "BEGIN NOW...  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
$rcmd = $env:QUIZ + "r211 82000000 82ZZZZZZ"
Invoke-Expression $rcmd
echo "ENDING.... $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content r211 | Out-Printer -Name $env:networkprinter
}
#lp status.ls
