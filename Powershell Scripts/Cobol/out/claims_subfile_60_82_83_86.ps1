#-------------------------------------------------------------------------------
# File 'claims_subfile_60_82_83_86.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'claims_subfile_60_82_83_86'
#-------------------------------------------------------------------------------

##  $cmd/claims_subfile_60_82_83_86
echo ""
echo "Start Time of $cmd\claims_subfile_60_82_83_86 is$(udate)"

Get-Date
$cmd\create_claims_subfile 61 20170216 201702
$cmd\create_claims_subfile 62 20170216 201702
$cmd\create_claims_subfile 63 20170216 201702
$cmd\create_claims_subfile 64 20170216 201702
$cmd\create_claims_subfile 65 20170216 201702
$cmd\create_claims_subfile 66 20170216 201702
$cmd\create_claims_subfile 71 20170216 201702
$cmd\create_claims_subfile 72 20170216 201702
$cmd\create_claims_subfile 73 20170216 201702
$cmd\create_claims_subfile 74 20170216 201702
$cmd\create_claims_subfile 75 20170216 201702
$cmd\create_claims_subfile 82 20170216 201702
$cmd\create_claims_subfile 86 20170216 201702

Set-Location $pb_prod\60

Get-Content $pb_prod\61\claims_subfile_61_201702.sfd  > claims_subfile_60_201702.sfd

Get-Content $pb_prod\61\claims_subfile_61_201702.sf  > claims_subfile_60_201702.sf
Get-Content $pb_prod\62\claims_subfile_62_201702.sf  >> claims_subfile_60_201702.sf
Get-Content $pb_prod\63\claims_subfile_63_201702.sf  >> claims_subfile_60_201702.sf
Get-Content $pb_prod\64\claims_subfile_64_201702.sf  >> claims_subfile_60_201702.sf
Get-Content $pb_prod\65\claims_subfile_65_201702.sf  >> claims_subfile_60_201702.sf
Get-Content $pb_prod\66\claims_subfile_66_201702.sf  >> claims_subfile_60_201702.sf

Set-Location $pb_prod\70

Get-Content $pb_prod\71\claims_subfile_71_201702.sfd  > claims_subfile_70_201702.sfd

Get-Content $pb_prod\71\claims_subfile_71_201702.sf  > claims_subfile_70_201702.sf
Get-Content $pb_prod\72\claims_subfile_72_201702.sf  >> claims_subfile_70_201702.sf
Get-Content $pb_prod\73\claims_subfile_73_201702.sf  >> claims_subfile_70_201702.sf
Get-Content $pb_prod\74\claims_subfile_74_201702.sf  >> claims_subfile_70_201702.sf
Get-Content $pb_prod\75\claims_subfile_75_201702.sf  >> claims_subfile_70_201702.sf

echo ""
Get-Date

echo "End   Time of $cmd\claims_subfile_60_82_83_86 is$(udate)"
