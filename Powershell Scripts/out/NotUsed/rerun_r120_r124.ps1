#-------------------------------------------------------------------------------
# File 'rerun_r120_r124.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rerun_r120_r124'
#-------------------------------------------------------------------------------

param(
  [string] $1
)



echo "--- generate_r120 ---"
&$env:cmd\generate_r120 $1


echo "---   r124a ---"
&$env:QUIZ r124a



echo "---  and  r124b_rma  PORTAL DOCTOR  VERSION ---"
&$env:QUIZ r124b_rma PORTAL DOC REGULAR

Move-Item -Force r124b.txt r124b_portal_doc_${1}_22.txt

echo "---  and  r124b_rma  PORTAL DEPARTMENT  VERSION ---"
&$env:QUIZ r124b_rma PORTAL DEP REGULAR

Move-Item -Force r124b.txt r124b_portal_dep_${1}_22.txt

echo "---  and  r124b_rma  PRINT VERSION ---"
&$env:QUIZ r124b_rma PRINT DOC REGULAR


Remove-Item r124a_${1}.sf *> $null
Move-Item -Force r124a.sf r124a_${1}.sf
Remove-Item r124a_${1}.sfd *> $null
Move-Item -Force r124a.sfd r124a_${1}.sfd
Remove-Item r124b_${1}.txt *> $null
Move-Item -Force r124b.txt r124b_${1}.txt



&$env:QUIZ payeft
Move-Item -Force payeft.txt payeft_${1}.txt

&$env:QUIZ paycode1A_ceilings
Move-Item -Force paycode1A_ceilings.txt paycode1A_ceilings_${1}.txt
