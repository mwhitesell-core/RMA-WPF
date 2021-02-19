#-------------------------------------------------------------------------------
# File 'palliative_moh.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'palliative_moh'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\89

Remove-Item palliative*.sf*
Remove-Item palliative*.ps*

&$env:QTP palliative > palliative_moh.log
&$env:QUIZ palliative_moh >> palliative_moh.log
&$env:QUIZ palliative_info >> palliative_moh.log
