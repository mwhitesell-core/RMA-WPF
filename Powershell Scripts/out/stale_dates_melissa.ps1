#-------------------------------------------------------------------------------
# File 'stale_dates_melissa.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'stale_dates_melissa'
#-------------------------------------------------------------------------------

Remove-Item r022f*.sf*

$rcmd = $env:QUIZ + "r022f_1"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r022f_2"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r022f_2.txt > r022f.txt

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content r022f.txt | Out-Printer -Name $env:networkprinter
}
