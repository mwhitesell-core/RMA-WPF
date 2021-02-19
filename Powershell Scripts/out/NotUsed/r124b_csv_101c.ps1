#-------------------------------------------------------------------------------
# File 'r124b_csv_101c.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r124b_csv_101c'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

Set-Location $env:application_root\production

&$env:QUIZ r124a_xls
&$env:QUIZ r124b_xls

Remove-Item r124a_xls_${1}.sf *> $null
Remove-Item r124a_xls_${1}.sfd *> $null
Move-Item -Force r124a_xls.sf r124a_xls_${1}.sf
Move-Item -Force r124a_xls.sfd r124a_xls_${1}.sfd
