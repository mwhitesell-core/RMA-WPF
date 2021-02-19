#-------------------------------------------------------------------------------
# File 'earnings_revenue_solo.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'earnings_revenue_solo'
#-------------------------------------------------------------------------------

Remove-Item earningssolo*.sf*
Remove-Item earningssolo*.ps*

&$env:QTP earnings_solo
