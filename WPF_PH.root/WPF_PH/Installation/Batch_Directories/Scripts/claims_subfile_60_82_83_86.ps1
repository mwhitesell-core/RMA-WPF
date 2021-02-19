#-------------------------------------------------------------------------------
# File 'claims_subfile_60_82_83_86.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'claims_subfile_60_82_83_86'
#-------------------------------------------------------------------------------

##  $cmd/claims_subfile_60_82_83_86
echo ""
echo "Start Time of $env:cmd\claims_subfile_60_82_83_86 is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Get-Date
Push-Location
&$env:cmd\create_claims_subfile 61 20170630 201706
&$env:cmd\create_claims_subfile 62 20170630 201706
&$env:cmd\create_claims_subfile 63 20170630 201706
&$env:cmd\create_claims_subfile 64 20170630 201706
&$env:cmd\create_claims_subfile 65 20170630 201706
&$env:cmd\create_claims_subfile 66 20170630 201706
&$env:cmd\create_claims_subfile 71 20170630 201706
&$env:cmd\create_claims_subfile 72 20170630 201706
&$env:cmd\create_claims_subfile 73 20170630 201706
&$env:cmd\create_claims_subfile 74 20170630 201706
&$env:cmd\create_claims_subfile 75 20170630 201706
&$env:cmd\create_claims_subfile 82 20170630 201706
&$env:cmd\create_claims_subfile 86 20170630 201706

Set-Location $env:pb_prod\60

Get-Content $env:pb_prod\61\claims_subfile_61_201706.sfd | Set-Content claims_subfile_60_201706.sfd

Get-Content $env:pb_prod\61\claims_subfile_61_201706.sf | Set-Content claims_subfile_60_201706.sf
Get-Content $env:pb_prod\62\claims_subfile_62_201706.sf | Add-Content claims_subfile_60_201706.sf
Get-Content $env:pb_prod\63\claims_subfile_63_201706.sf | Add-Content claims_subfile_60_201706.sf
Get-Content $env:pb_prod\64\claims_subfile_64_201706.sf | Add-Content claims_subfile_60_201706.sf
Get-Content $env:pb_prod\65\claims_subfile_65_201706.sf | Add-Content claims_subfile_60_201706.sf
Get-Content $env:pb_prod\66\claims_subfile_66_201706.sf | Add-Content claims_subfile_60_201706.sf

Set-Location $env:pb_prod\70

Get-Content $env:pb_prod\71\claims_subfile_71_201706.sfd | Set-Content claims_subfile_70_201706.sfd

Get-Content $env:pb_prod\71\claims_subfile_71_201706.sf | Set-Content claims_subfile_70_201706.sf
Get-Content $env:pb_prod\72\claims_subfile_72_201706.sf | Add-Content claims_subfile_70_201706.sf
Get-Content $env:pb_prod\73\claims_subfile_73_201706.sf | Add-Content claims_subfile_70_201706.sf
Get-Content $env:pb_prod\74\claims_subfile_74_201706.sf | Add-Content claims_subfile_70_201706.sf
Get-Content $env:pb_prod\75\claims_subfile_75_201706.sf | Add-Content claims_subfile_70_201706.sf

echo ""
Pop-Location
Get-Date

echo "End   Time of $env:cmd\claims_subfile_60_82_83_86 is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
