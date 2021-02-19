#-------------------------------------------------------------------------------
# File 'claims_subfile_22_to_48.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'claims_subfile_22_to_48'
#-------------------------------------------------------------------------------

echo ""
Get-Date

Set-Location $env:application_production
echo ""
Get-Date
$rcmd = $env:QUIZ +"create_claims_suba `"choose key-clm-type 'B', key-clm-batch-nbr '22@' to '48@'`" 22 20040721" 
Invoke-Expression $rcmd *> subfile.ls
$rcmd = $env:QUIZ +"create_claims_subb" 
Invoke-Expression $rcmd *>> subfile.ls
$rcmd = $env:QUIZ +"create_claims_subc" 
Invoke-Expression $rcmd *>> subfile.ls

Move-Item -Force claims_subfile.sf claims_subfile_22_200407.sf
Move-Item -Force claims_subfile.sfd claims_subfile_22_200407.sfd

echo ""
Get-Date
