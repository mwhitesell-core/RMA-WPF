#-------------------------------------------------------------------------------
# File 'nephrcodes.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'nephrcodes'
#-------------------------------------------------------------------------------

Remove-Item nephrcodes*.sf*
Remove-Item nephrcodes*.ps*

&$env:QTP nephrnodialysis2
&$env:QTP nephrcodes
