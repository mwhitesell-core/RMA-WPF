#-------------------------------------------------------------------------------
# File 'dr_roy.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'dr_roy'
#-------------------------------------------------------------------------------

Remove-Item afppeds.sf*
Remove-Item pfppeds1.sf*
Remove-Item afppeds2.sf*

&$env:QTP afp_peds_oma_drroy
