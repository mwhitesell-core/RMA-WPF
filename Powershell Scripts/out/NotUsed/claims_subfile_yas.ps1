#-------------------------------------------------------------------------------
# File 'claims_subfile_yas.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'claims_subfile_yas'
#-------------------------------------------------------------------------------

echo ""
Get-Date
&$env:cmd\create_claims_subfile 22 20110923 201109
&$env:cmd\create_claims_subfile 34 20110923 201109

Set-Location $pb_prod\22

Get-Content $pb_prod\23\claims_subfile_23_201109.sf | Add-Content claims_subfile_22_201109.sf
Get-Content $pb_prod\31\claims_subfile_31_201109.sf | Add-Content claims_subfile_22_201109.sf
Get-Content $pb_prod\32\claims_subfile_32_201109.sf | Add-Content claims_subfile_22_201109.sf
Get-Content $pb_prod\33\claims_subfile_33_201109.sf | Add-Content claims_subfile_22_201109.sf
Get-Content $pb_prod\34\claims_subfile_34_201109.sf | Add-Content claims_subfile_22_201109.sf
Get-Content $pb_prod\35\claims_subfile_35_201109.sf | Add-Content claims_subfile_22_201109.sf
Get-Content $pb_prod\36\claims_subfile_36_201109.sf | Add-Content claims_subfile_22_201109.sf
Get-Content $pb_prod\41\claims_subfile_41_201109.sf | Add-Content claims_subfile_22_201109.sf
Get-Content $pb_prod\42\claims_subfile_42_201109.sf | Add-Content claims_subfile_22_201109.sf
Get-Content $pb_prod\43\claims_subfile_43_201109.sf | Add-Content claims_subfile_22_201109.sf
Get-Content $pb_prod\44\claims_subfile_44_201109.sf | Add-Content claims_subfile_22_201109.sf
Get-Content $pb_prod\45\claims_subfile_45_201109.sf | Add-Content claims_subfile_22_201109.sf
Get-Content $pb_prod\46\claims_subfile_46_201109.sf | Add-Content claims_subfile_22_201109.sf
Get-Content $pb_prod\98\claims_subfile_98_201109.sf | Add-Content claims_subfile_22_201109.sf

echo ""
Get-Date
