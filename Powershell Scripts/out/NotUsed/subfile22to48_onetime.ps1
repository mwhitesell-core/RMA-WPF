#-------------------------------------------------------------------------------
# File 'subfile22to48_onetime.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'subfile22to48_onetime'
#-------------------------------------------------------------------------------

Set-Location $pb_prod\22

Get-Content $pb_prod\31\claims_subfile_31_201006.sf | Add-Content claims_subfile_22_201006.sf
Get-Content $pb_prod\32\claims_subfile_32_201006.sf | Add-Content claims_subfile_22_201006.sf
Get-Content $pb_prod\33\claims_subfile_33_201006.sf | Add-Content claims_subfile_22_201006.sf
Get-Content $pb_prod\34\claims_subfile_34_201006.sf | Add-Content claims_subfile_22_201006.sf
Get-Content $pb_prod\35\claims_subfile_35_201006.sf | Add-Content claims_subfile_22_201006.sf
Get-Content $pb_prod\36\claims_subfile_36_201006.sf | Add-Content claims_subfile_22_201006.sf
Get-Content $pb_prod\41\claims_subfile_41_201006.sf | Add-Content claims_subfile_22_201006.sf
Get-Content $pb_prod\42\claims_subfile_42_201006.sf | Add-Content claims_subfile_22_201006.sf
Get-Content $pb_prod\43\claims_subfile_43_201006.sf | Add-Content claims_subfile_22_201006.sf
Get-Content $pb_prod\44\claims_subfile_44_201006.sf | Add-Content claims_subfile_22_201006.sf
Get-Content $pb_prod\45\claims_subfile_45_201006.sf | Add-Content claims_subfile_22_201006.sf
Get-Content $pb_prod\46\claims_subfile_46_201006.sf | Add-Content claims_subfile_22_201006.sf
Get-Content $pb_prod\48\claims_subfile_48_201006.sf | Add-Content claims_subfile_22_201006.sf
Get-Content $pb_prod\98\claims_subfile_98_201006.sf | Add-Content claims_subfile_22_201006.sf

echo ""
Get-Date
