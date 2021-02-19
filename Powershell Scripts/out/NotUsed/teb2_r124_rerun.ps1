#-------------------------------------------------------------------------------
# File 'teb2_r124_rerun.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'teb2_r124_rerun'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# teb2_r124_rerun


echo "Payroll teb2_r124_rerun - starting - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Remove-Item r124b.txt, r124b_csv.txt *> $null
#

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
&$env:QUIZ r124b_mp "and select if       x-new-parm = `"DOC`"  &                 and doc-dept <>  80       " PORTAL DOC

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


&$env:QUIZ r124a_xls
&$env:QUIZ r124b_xls

Remove-Item r124a_xls_${1}.sf *> $null
Remove-Item r124a_xls_${1}.sfd *> $null
Move-Item -Force r124a_xls.sf r124a_xls_${1}.sf
Move-Item -Force r124a_xls.sfd r124a_xls_${1}.sfd

if ($env:clinic_nbr -eq "10")
{

Move-Item -Force r124b_csv.txt r124b_csv_solo.txt

} else {

if ($env:clinic_nbr -eq "99")
{

Move-Item -Force r124b_csv.txt r124b_csv_mp.txt

}
}

# MC11 - end


echo "Payroll teb2_r124_rerun -   ending - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
