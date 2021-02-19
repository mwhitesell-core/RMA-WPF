#-------------------------------------------------------------------------------
# File 'teb2yas.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'teb2yas'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# PAREN SET DEFAULT -- MOVE PAREN ABOVE DOWN 2 LINES!!
# PAREN EXE U125
echo "--- cobol program r123 ---"
&$env:cmd\r123
Remove-Item r123*_${1}.txt *> $null
Move-Item -Force r123a r123a_${1}.txt
Move-Item -Force r123b r123b_${1}.txt
Move-Item -Force r123c r123c_${1}.txt
echo "--- PH program r123d ---"

if ($env:clinic_nbr -eq "22")
{

&$env:QUIZ r123d1
Move-Item -Force r123d.txt r123d_${1}.txt
Get-Content r123d1_${1}.txt | Out-Printer

Get-Content r123ef | Out-Printer
Get-Content r123ef | Out-Printer

} else {
if ($env:clinic_nbr -eq "99")
{

&$env:QUIZ r123d1a
Move-Item -Force r123d1a.txt r123d1a_${1}.txt
Get-Content r123d1a_${1}.txt | Out-Printer

}
}

echo "--- generate_r120 ---"
&$env:cmd\generate_r120 $1

Remove-Item r123a.sf*
Remove-Item r124b.txt

if ($env:clinic_nbr -eq "99")
{

echo "---   r124a_mp ---"
&$env:QUIZ r124a_mp

} else {

echo "---   r124a ---"
&$env:QUIZ r124a

}



if ($env:clinic_nbr -eq "22")
{


echo "---  and  r124b_rma  PORTAL DOCTOR  VERSION ---"
&$env:QUIZ r124b_rma PORTAL DOC REGULAR ;YEAREND

Move-Item -Force r124b.txt r124b_portal_doc_22.txt

echo "---  and  r124b_rma  PORTAL DEPARTMENT  VERSION ---"
&$env:QUIZ r124b_rma PORTAL DEP REGULAR ;YEAREND

Move-Item -Force r124b.txt r124b_portal_dep_22.txt

echo "---  and  r124b_rma  PRINT VERSION ---"
&$env:QUIZ r124b_rma PRINT  REGULAR ;YEAREND

} else {

if ($env:clinic_nbr -eq "99")
{

echo "---  and  r124b_mp -- PORTAL DOCTOR VERSION  ---"
&$env:QUIZ r124b_mp PORTAL DOC

Move-Item -Force r124b.txt r124b_portal_doc_mp.txt

echo "---  and  r124b_mp  -- PORTAL DEPARTMENT VERSION  ---"
&$env:QUIZ r124b_mp PORTAL DEP

Move-Item -Force r124b.txt r124b_portal_dep_mp.txt

echo "---  and  r124b_mp -- PRINT VERSION  ---"
&$env:QUIZ r124b_mp PRINT



}
}

# KEEP BACKUP OF SUBFILE IN CASE STATEMENTS NEED TO BE RE-GENERATED

if ($env:clinic_nbr -eq "22")
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

echo "--- u126 and u127 ---"
&$env:QTP u126
&$env:QTP u127
