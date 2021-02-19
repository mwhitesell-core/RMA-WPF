#-------------------------------------------------------------------------------
# File 'rerun_r124_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rerun_r124_reports'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

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

echo "---  and  r124b_rma -- PORTAL VERSION  ---"
&$env:QUIZ r124b_rma PORTAL REGULAR ;YEAREND

Move-Item -Force r124b.txt r124b_portal_22.txt

echo "---  and  r124b_rma -- PRINT VERSION  ---"
&$env:QUIZ r124b_rma PRINT REGULAR ;YEAREND

} else {

if ($env:clinic_nbr -eq "99")
{

echo "---  and  r124b_rma -- PORTAL VERSION  ---"
&$env:QUIZ r124b_mp PORTAL

Move-Item -Force r124b.txt r124b_portal_mp.txt

echo "---  and  r124b_rma -- PRINT VERSION  ---"
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
