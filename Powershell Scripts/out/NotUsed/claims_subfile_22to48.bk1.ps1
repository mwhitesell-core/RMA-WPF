#-------------------------------------------------------------------------------
# File 'claims_subfile_22to48.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'claims_subfile_22to48.bk1'
#-------------------------------------------------------------------------------

echo ""
Get-Date
&$env:cmd\create_claims_subfile 22 20150824 201508
&$env:cmd\create_claims_subfile 23 20150824 201508
&$env:cmd\create_claims_subfile 24 20150824 201508
&$env:cmd\create_claims_subfile 25 20150824 201508
&$env:cmd\create_claims_subfile 26 20150824 201508
&$env:cmd\create_claims_subfile 30 20150824 201508
&$env:cmd\create_claims_subfile 31 20150824 201508
&$env:cmd\create_claims_subfile 32 20150824 201508
&$env:cmd\create_claims_subfile 33 20150824 201508
&$env:cmd\create_claims_subfile 34 20150824 201508
&$env:cmd\create_claims_subfile 35 20150824 201508
&$env:cmd\create_claims_subfile 36 20150824 201508
&$env:cmd\create_claims_subfile 41 20150824 201508
&$env:cmd\create_claims_subfile 42 20150824 201508
&$env:cmd\create_claims_subfile 43 20150824 201508
&$env:cmd\create_claims_subfile 44 20150824 201508
&$env:cmd\create_claims_subfile 45 20150824 201508
&$env:cmd\create_claims_subfile 46 20150824 201508
&$env:cmd\create_claims_subfile 98 20150824 201508

Set-Location $pb_prod\22

Get-Content $pb_prod\23\claims_subfile_23_201508.sf | Add-Content claims_subfile_22_201508.sf
Get-Content $pb_prod\24\claims_subfile_24_201508.sf | Add-Content claims_subfile_22_201508.sf
Get-Content $pb_prod\25\claims_subfile_25_201508.sf | Add-Content claims_subfile_22_201508.sf
Get-Content $pb_prod\26\claims_subfile_26_201508.sf | Add-Content claims_subfile_22_201508.sf
Get-Content $pb_prod\30\claims_subfile_30_201508.sf | Add-Content claims_subfile_22_201508.sf
Get-Content $pb_prod\31\claims_subfile_31_201508.sf | Add-Content claims_subfile_22_201508.sf
Get-Content $pb_prod\32\claims_subfile_32_201508.sf | Add-Content claims_subfile_22_201508.sf
Get-Content $pb_prod\33\claims_subfile_33_201508.sf | Add-Content claims_subfile_22_201508.sf
Get-Content $pb_prod\34\claims_subfile_34_201508.sf | Add-Content claims_subfile_22_201508.sf
Get-Content $pb_prod\35\claims_subfile_35_201508.sf | Add-Content claims_subfile_22_201508.sf
Get-Content $pb_prod\36\claims_subfile_36_201508.sf | Add-Content claims_subfile_22_201508.sf
Get-Content $pb_prod\41\claims_subfile_41_201508.sf | Add-Content claims_subfile_22_201508.sf
Get-Content $pb_prod\42\claims_subfile_42_201508.sf | Add-Content claims_subfile_22_201508.sf
Get-Content $pb_prod\43\claims_subfile_43_201508.sf | Add-Content claims_subfile_22_201508.sf
Get-Content $pb_prod\44\claims_subfile_44_201508.sf | Add-Content claims_subfile_22_201508.sf
Get-Content $pb_prod\45\claims_subfile_45_201508.sf | Add-Content claims_subfile_22_201508.sf
Get-Content $pb_prod\46\claims_subfile_46_201508.sf | Add-Content claims_subfile_22_201508.sf
Get-Content $pb_prod\98\claims_subfile_98_201508.sf | Add-Content claims_subfile_22_201508.sf

echo ""
Get-Date
