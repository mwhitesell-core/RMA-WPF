#-------------------------------------------------------------------------------
# File 'r136.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r136'
#-------------------------------------------------------------------------------

# 2015/Apr/22   MC              include the run of r136.qtc/qzc 

Set-Location $application_root\production

qtp++ $obj\r136

quiz++ $obj\r136
