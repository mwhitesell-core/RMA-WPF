#-------------------------------------------------------------------------------
# File 'rename_copy_r124_solo.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'rename_copy_r124_solo'
#-------------------------------------------------------------------------------
param(
  [string] $1
)

Move-Item r124b_portal_doc_${1}_22.txt r124b_portal_doc_solo_${1}.txt

Move-Item r124b_${1}.txt r124b_solo_${1}.txt

Copy-Item r124b_portal_doc_solo* \\$env:srvname\rma\alpha\rmabill\rmabill101c\production

Copy-Item r124* \\$env:srvname\rma\alpha\rmabill\rmabillsolo\data2\ma
