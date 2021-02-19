#-------------------------------------------------------------------------------
# File 'delete_f001_invalid_clinic.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'delete_f001_invalid_clinic'
#-------------------------------------------------------------------------------


# 2014/Oct/20   MC delete_f001_invalid_clinic
#                  run this only if you receive invalid clinic in r001b / r001

Set-Location $env:application_root\production

&$env:QTP delete_f001
