#-------------------------------------------------------------------------------
# File 'accounts_receivable.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'accounts_receivable'
#-------------------------------------------------------------------------------
param(
	[string]$1
)

## $cmd/accounts_receivable

echo " --- r070a (COBOL) ---  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
$rcmd = $env:COBOL + "r070a ${1} Y Y"
Invoke-Expression $rcmd

echo " --- r070b (COBOL) ---  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
$rcmd = $env:COBOL + "r070b"
Invoke-Expression $rcmd

echo " --- r070c (COBOL) ---  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
$rcmd = $env:COBOL +"r070c N"
Invoke-Expression $rcmd