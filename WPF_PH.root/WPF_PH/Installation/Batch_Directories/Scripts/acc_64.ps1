#-------------------------------------------------------------------------------
# File 'acc_64.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'acc_64'
#-------------------------------------------------------------------------------

echo " --- r070a (COBOL) ---  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
&$env:COBOL r070a 64 Y Y

echo " --- r070b (COBOL) ---  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
&$env:COBOL r070b

echo " --- r070c (COBOL) ---  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
&$env:COBOL r070c N