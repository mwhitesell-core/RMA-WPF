#-------------------------------------------------------------------------------
# File 'claims_subfile_22to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'claims_subfile_22to48'
#-------------------------------------------------------------------------------

## $cmd/claims_subfile_22to48

echo "Start Time of $cmd\claims_subfile_22to48 is$(udate)"

echo ""
Get-Date
$cmd\create_claims_subfile 22 20170222 201702
$cmd\create_claims_subfile 23 20170222 201702
$cmd\create_claims_subfile 24 20170222 201702
$cmd\create_claims_subfile 25 20170222 201702
$cmd\create_claims_subfile 26 20170222 201702
$cmd\create_claims_subfile 30 20170222 201702
$cmd\create_claims_subfile 31 20170222 201702
$cmd\create_claims_subfile 32 20170222 201702
$cmd\create_claims_subfile 33 20170222 201702
$cmd\create_claims_subfile 34 20170222 201702
$cmd\create_claims_subfile 35 20170222 201702
$cmd\create_claims_subfile 36 20170222 201702
$cmd\create_claims_subfile 41 20170222 201702
$cmd\create_claims_subfile 42 20170222 201702
$cmd\create_claims_subfile 43 20170222 201702
$cmd\create_claims_subfile 44 20170222 201702
$cmd\create_claims_subfile 45 20170222 201702
$cmd\create_claims_subfile 46 20170222 201702
$cmd\create_claims_subfile 98 20170222 201702

Set-Location $pb_prod\22

Get-Content $pb_prod\23\claims_subfile_23_201702.sf  >> claims_subfile_22_201702.sf
Get-Content $pb_prod\24\claims_subfile_24_201702.sf  >> claims_subfile_22_201702.sf
Get-Content $pb_prod\25\claims_subfile_25_201702.sf  >> claims_subfile_22_201702.sf
Get-Content $pb_prod\26\claims_subfile_26_201702.sf  >> claims_subfile_22_201702.sf
Get-Content $pb_prod\30\claims_subfile_30_201702.sf  >> claims_subfile_22_201702.sf
Get-Content $pb_prod\31\claims_subfile_31_201702.sf  >> claims_subfile_22_201702.sf
Get-Content $pb_prod\32\claims_subfile_32_201702.sf  >> claims_subfile_22_201702.sf
Get-Content $pb_prod\33\claims_subfile_33_201702.sf  >> claims_subfile_22_201702.sf
Get-Content $pb_prod\34\claims_subfile_34_201702.sf  >> claims_subfile_22_201702.sf
Get-Content $pb_prod\35\claims_subfile_35_201702.sf  >> claims_subfile_22_201702.sf
Get-Content $pb_prod\36\claims_subfile_36_201702.sf  >> claims_subfile_22_201702.sf
Get-Content $pb_prod\41\claims_subfile_41_201702.sf  >> claims_subfile_22_201702.sf
Get-Content $pb_prod\42\claims_subfile_42_201702.sf  >> claims_subfile_22_201702.sf
Get-Content $pb_prod\43\claims_subfile_43_201702.sf  >> claims_subfile_22_201702.sf
Get-Content $pb_prod\44\claims_subfile_44_201702.sf  >> claims_subfile_22_201702.sf
Get-Content $pb_prod\45\claims_subfile_45_201702.sf  >> claims_subfile_22_201702.sf
Get-Content $pb_prod\46\claims_subfile_46_201702.sf  >> claims_subfile_22_201702.sf
Get-Content $pb_prod\98\claims_subfile_98_201702.sf  >> claims_subfile_22_201702.sf

echo ""
Get-Date

echo "End    Time of $cmd\claims_subfile_22to48 is$(udate)"
