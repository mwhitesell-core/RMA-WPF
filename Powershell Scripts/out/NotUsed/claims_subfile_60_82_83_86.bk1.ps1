#-------------------------------------------------------------------------------
# File 'claims_subfile_60_82_83_86.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'claims_subfile_60_82_83_86.bk1'
#-------------------------------------------------------------------------------

echo ""
Get-Date
&$env:cmd\create_claims_subfile 61 20150817 201508
&$env:cmd\create_claims_subfile 62 20150817 201508
&$env:cmd\create_claims_subfile 63 20150817 201508
&$env:cmd\create_claims_subfile 64 20150817 201508
&$env:cmd\create_claims_subfile 65 20150817 201508
&$env:cmd\create_claims_subfile 66 20150817 201508
&$env:cmd\create_claims_subfile 71 20150817 201508
&$env:cmd\create_claims_subfile 72 20150817 201508
&$env:cmd\create_claims_subfile 73 20150817 201508
&$env:cmd\create_claims_subfile 74 20150817 201508
&$env:cmd\create_claims_subfile 75 20150817 201508
&$env:cmd\create_claims_subfile 82 20150817 201508
&$env:cmd\create_claims_subfile 86 20150817 201508

Set-Location $pb_prod\60

Get-Content $pb_prod\61\claims_subfile_61_201508.sfd | Set-Content claims_subfile_60_201508.sfd

Get-Content $pb_prod\61\claims_subfile_61_201508.sf | Set-Content claims_subfile_60_201508.sf
Get-Content $pb_prod\62\claims_subfile_62_201508.sf | Add-Content claims_subfile_60_201508.sf
Get-Content $pb_prod\63\claims_subfile_63_201508.sf | Add-Content claims_subfile_60_201508.sf
Get-Content $pb_prod\64\claims_subfile_64_201508.sf | Add-Content claims_subfile_60_201508.sf
Get-Content $pb_prod\65\claims_subfile_65_201508.sf | Add-Content claims_subfile_60_201508.sf
Get-Content $pb_prod\66\claims_subfile_66_201508.sf | Add-Content claims_subfile_60_201508.sf

Set-Location $pb_prod\70

Get-Content $pb_prod\71\claims_subfile_71_201508.sfd | Set-Content claims_subfile_70_201508.sfd

Get-Content $pb_prod\71\claims_subfile_71_201508.sf | Set-Content claims_subfile_70_201508.sf
Get-Content $pb_prod\72\claims_subfile_72_201508.sf | Add-Content claims_subfile_70_201508.sf
Get-Content $pb_prod\73\claims_subfile_73_201508.sf | Add-Content claims_subfile_70_201508.sf
Get-Content $pb_prod\74\claims_subfile_74_201508.sf | Add-Content claims_subfile_70_201508.sf
Get-Content $pb_prod\75\claims_subfile_75_201508.sf | Add-Content claims_subfile_70_201508.sf

echo ""
Get-Date
