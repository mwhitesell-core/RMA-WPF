#-------------------------------------------------------------------------------
# File 'claims_subfile_60s_only.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'claims_subfile_60s_only'
#-------------------------------------------------------------------------------

echo ""
Get-Date
&$env:cmd\create_claims_subfile 61 20090817 200908
&$env:cmd\create_claims_subfile 62 20090817 200908
&$env:cmd\create_claims_subfile 63 20090817 200908
&$env:cmd\create_claims_subfile 64 20090817 200908
&$env:cmd\create_claims_subfile 65 20090817 200908

Set-Location $pb_prod\60

Get-Content $pb_prod\61\claims_subfile_61_200908.sfd | Set-Content claims_subfile_60_200908.sfd

Get-Content $pb_prod\61\claims_subfile_61_200908.sf | Set-Content claims_subfile_60_200908.sf
Get-Content $pb_prod\62\claims_subfile_62_200908.sf | Add-Content claims_subfile_60_200908.sf
Get-Content $pb_prod\63\claims_subfile_63_200908.sf | Add-Content claims_subfile_60_200908.sf
Get-Content $pb_prod\64\claims_subfile_64_200908.sf | Add-Content claims_subfile_60_200908.sf
Get-Content $pb_prod\65\claims_subfile_65_200908.sf | Add-Content claims_subfile_60_200908.sf

echo ""
Get-Date
