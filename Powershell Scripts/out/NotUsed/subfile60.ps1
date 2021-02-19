#-------------------------------------------------------------------------------
# File 'subfile60.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'subfile60'
#-------------------------------------------------------------------------------

echo ""
Get-Date
&$env:cmd\create_claims_subfile 61 20150630 2015yr
&$env:cmd\create_claims_subfile 62 20150630 2015yr
&$env:cmd\create_claims_subfile 63 20150630 2015yr
&$env:cmd\create_claims_subfile 64 20150630 2015yr
&$env:cmd\create_claims_subfile 65 20150630 2015yr
&$env:cmd\create_claims_subfile 66 20150630 2015yr

Set-Location $pb_prod\60

Get-Content $pb_prod\61\claims_subfile_61_2015yr.sfd | Set-Content claims_subfile_60_2015yr.sfd

Get-Content $pb_prod\61\claims_subfile_61_2015yr.sf | Set-Content claims_subfile_60_2015yr.sf
Get-Content $pb_prod\62\claims_subfile_62_2015yr.sf | Add-Content claims_subfile_60_2015yr.sf
Get-Content $pb_prod\63\claims_subfile_63_2015yr.sf | Add-Content claims_subfile_60_2015yr.sf
Get-Content $pb_prod\64\claims_subfile_64_2015yr.sf | Add-Content claims_subfile_60_2015yr.sf
Get-Content $pb_prod\65\claims_subfile_65_2015yr.sf | Add-Content claims_subfile_60_2015yr.sf
Get-Content $pb_prod\66\claims_subfile_66_2015yr.sf | Add-Content claims_subfile_60_2015yr.sf


echo ""
Get-Date
