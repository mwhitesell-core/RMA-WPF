#-------------------------------------------------------------------------------
# File 'rename_copy_r124.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rename_copy_r124'
#-------------------------------------------------------------------------------

param(
  [string] $1,
  [string] $2
)

Move-Item -Force r124b_portal_doc_mp_${1}.txt r124b_portal_doc_mp_${1}_${2}.txt

Move-Item -Force r124b_portal_dep_mp_${1}.txt r124b_portal_dep_mp_${1}_${2}.txt

Copy-Item r124b_csv_mp.txt r124b_csv_mp_${1}_${2}.txt
Copy-Item r124b_mp_31.txt r124b_mp_31_${1}_${2}.txt

Copy-Item r124b_portal_doc* \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production
Copy-Item r124b_portal_dep* \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production
Copy-Item r124b_paycode7_portal* \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production

Copy-Item r124a* \\$Env:root\alpha\rmabill\rmabillmp\data2\ma
Copy-Item r124b* \\$Env:root\alpha\rmabill\rmabillmp\data2\ma
Copy-Item r124c* \\$Env:root\alpha\rmabill\rmabillmp\data2\ma
