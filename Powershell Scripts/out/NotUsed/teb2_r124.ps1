#-------------------------------------------------------------------------------
# File 'teb2_r124.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'teb2_r124'
#-------------------------------------------------------------------------------

param(
  [string] $1
)


if ($env:clinic_nbr -eq "99")
{

echo "---   r124a_mp ---"
&$env:QUIZ r124a_mp

} else {

echo "---   r124a ---"
&$env:QUIZ r124a
}



if (($env:clinic_nbr -eq "22") -or ($env:clinic_nbr -eq "10"))
{


echo "---  and  r124b_rma  PORTAL DOCTOR  VERSION ---"
&$env:QUIZ ";  MC7  execute $obj/r124b_rma"
&$env:QUIZ r124b_rma "and sel if doc-dept <> 80" PORTAL DOC REGULAR
Move-Item -Force r124b.txt r124b_portal_doc_${1}_22.txt

echo "---  and  r124b_rma  PORTAL DEPARTMENT  VERSION ---"
&$env:QUIZ r124b_rma PORTAL DEP REGULAR

Move-Item -Force r124b.txt r124b_portal_dep_${1}_22.txt

echo "---  and  r124b_rma  PRINT VERSION ---"
&$env:QUIZ r124b_rma PRINT DOC REGULAR
} else {

if ($env:clinic_nbr -eq "99")
{

echo "---  and  r124b_mp -- PORTAL DOCTOR VERSION  ---"
&$env:QUIZ "; MC7 execute $obj/r124b_mp"
&$env:QUIZ r124b_mp "and select if       x-new-parm = `"DOC`"  &                 and doc-dept <>  80" PORTAL DOC

Move-Item -Force r124b.txt r124b_portal_doc_mp_${1}.txt
echo "---  and  r124b_mp  -- PORTAL DEPARTMENT VERSION  ---"
&$env:QUIZ r124b_mp PORTAL DEP

Move-Item -Force r124b.txt r124b_portal_dep_mp_${1}.txt

echo "---  and  r124b_mp -- PRINT VERSION  ---"
&$env:QUIZ r124b_mp PRINT DOC

echo "---  and  r124b_mp_31 -- PRINT VERSION  ---"
&$env:QUIZ r124b_mp "and sel if x-new-parm = 'DOC' and doc-dept = 31" PRINT DOC



}
}

# KEEP BACKUP OF SUBFILE IN CASE STATEMENTS NEED TO BE RE-GENERATED

if (($env:clinic_nbr -eq "22") -or ($env:clinic_nbr -eq "10"))
{

Remove-Item r124a_${1}.sf *> $null
Move-Item -Force r124a.sf r124a_${1}.sf
Remove-Item r124a_${1}.sfd *> $null
Move-Item -Force r124a.sfd r124a_${1}.sfd
Remove-Item r124b_${1}.txt *> $null
Move-Item -Force r124b.txt r124b_${1}.txt

} else {

if ($env:clinic_nbr -eq "99")
{

Remove-Item r124a_${1}.sf *> $null
Move-Item -Force r124a.sf r124a_mp_${1}.sf
Remove-Item r124a_${1}.sfd *> $null
Move-Item -Force r124a.sfd r124a_mp_${1}.sfd
Remove-Item r124b_${1}.txt *> $null
Move-Item -Force r124b.txt r124b_mp_${1}.txt

}
}

if ($env:clinic_nbr -eq "99")
{

echo "--- r124a\b_paycode7 & r124c PRINT VERSION ---"
&$env:QUIZ r124a_paycode7
&$env:QUIZ r124b_paycode7 PRINT DOC REGULAR
&$env:QUIZ r124c

Remove-Item r124b_paycode7_${1}.txt *> $null
Move-Item -Force r124b_paycode7.txt r124b_paycode7_${1}.txt

Remove-Item r124c_${1}.txt *> $null
Move-Item -Force r124c.txt r124c_${1}.txt

echo "--- r124b_paycode7 PORTAL VERSION ---"
&$env:QUIZ r124b_paycode7 PORTAL DOC REGULAR

Remove-Item r124b_paycode7_portal_${1}.txt *> $null
Move-Item -Force r124b_paycode7.txt r124b_paycode7_portal_${1}.txt

Remove-Item r124a_paycode7_${1}.sf *> $null
Remove-Item r124a_paycode7_${1}.sfd *> $null
Move-Item -Force r124a_paycode7.sf r124a_paycode7_${1}.sf
Move-Item -Force r124a_paycode7.sfd r124a_paycode7_${1}.sfd
