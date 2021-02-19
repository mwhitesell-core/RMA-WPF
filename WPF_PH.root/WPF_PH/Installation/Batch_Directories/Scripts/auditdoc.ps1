#-------------------------------------------------------------------------------
# File 'auditdoc.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'auditdoc'
#-------------------------------------------------------------------------------
param(
  [string] $1,
  [string] $2
)

# program auditdoc.qzs
$rcmd = $env:QUIZ + "auditdoc1 ${1}, ${2}"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "auditdoc2 DISC_auditdoc"
Invoke-Expression $rcmd