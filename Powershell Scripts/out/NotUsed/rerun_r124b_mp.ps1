#-------------------------------------------------------------------------------
# File 'rerun_r124b_mp.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rerun_r124b_mp'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# rerun_r124b_mp

Set-Location $env:application_production



echo "--- r124a\b_paycode7 & r124c PRINT VERSION ---"
&$env:QUIZ r124a_paycode7
&$env:QUIZ r124b_paycode7 PRINT DOC REGULAR

Remove-Item r124b_paycode7_${1}.txt *> $null
Move-Item -Force r124b_paycode7.txt r124b_paycode7_${1}.txt

echo "--- r124b_paycode7 PORTAL VERSION ---"
&$env:QUIZ r124b_paycode7 PORTAL DOC REGULAR

Remove-Item r124b_paycode7_portal_${1}.txt *> $null
Move-Item -Force r124b_paycode7.txt r124b_paycode7_portal_${1}.txt

Remove-Item r124a_paycode7_${1}.sf *> $null
Remove-Item r124a_paycode7_${1}.sfd *> $null
Move-Item -Force r124a_paycode7.sf r124a_paycode7_${1}.sf
Move-Item -Force r124a_paycode7.sfd r124a_paycode7_${1}.sfd

echo "PLEASE CHANGE THE EP NBR BACK..............."
echo ""
