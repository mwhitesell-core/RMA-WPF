#-------------------------------------------------------------------------------
# File 'solo_earnings.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'solo_earnings'
#-------------------------------------------------------------------------------

Remove-Item earningssolo*.sf*
Remove-Item earningssolo*.ps*

&$env:QTP solo_earnings
