#-------------------------------------------------------------------------------
# File 'yasclaims70.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yasclaims70'
#-------------------------------------------------------------------------------

echo ""
Get-Date
&$env:cmd\create_claims_subfile 71 20080617 200806
&$env:cmd\create_claims_subfile 72 20080617 200806
&$env:cmd\create_claims_subfile 73 20080617 200806
&$env:cmd\create_claims_subfile 74 20080617 200806
&$env:cmd\create_claims_subfile 75 20080617 200806

Set-Location $pb_prod\70

Get-Content $pb_prod\71\claims_subfile_71_200806.sfd | Set-Content claims_subfile_70_200806.sfd

Get-Content $pb_prod\71\claims_subfile_71_200806.sf | Set-Content claims_subfile_70_200806.sf
Get-Content $pb_prod\72\claims_subfile_72_200806.sf | Add-Content claims_subfile_70_200806.sf
Get-Content $pb_prod\73\claims_subfile_73_200806.sf | Add-Content claims_subfile_70_200806.sf
Get-Content $pb_prod\74\claims_subfile_74_200806.sf | Add-Content claims_subfile_70_200806.sf
Get-Content $pb_prod\75\claims_subfile_75_200806.sf | Add-Content claims_subfile_70_200806.sf

echo ""
Get-Date
