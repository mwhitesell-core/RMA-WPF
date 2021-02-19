#-------------------------------------------------------------------------------
# File 'create_claims_subfile.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_claims_subfile'
#-------------------------------------------------------------------------------

param(
  [string] $1,
  [string] $2,
  [string] $3
)

Set-Location $env:application_production\${1}
echo ""
Get-Date
$rcmd = $env:QUIZ + "create_claims_suba ${1} ${2}"
Invoke-Expression $rcmd *> subfile.ls
$rcmd = $env:QUIZ + "create_claims_subb"
Invoke-Expression $rcmd *>> subfile.ls
$rcmd = $env:QUIZ + "create_claims_subc"
Invoke-Expression $rcmd *>> subfile.ls

Move-Item -Force claims_subfile.sf claims_subfile_${1}_${3}.sf
Move-Item -Force claims_subfile.sfd claims_subfile_${1}_${3}.sfd

echo ""
Get-Date
