#-------------------------------------------------------------------------------
# File 'claims_subfile_22to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'claims_subfile_22to48'
#-------------------------------------------------------------------------------

## $cmd/claims_subfile_22to48

echo "Start Time of $env:cmd\claims_subfile_22to48 is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

echo ""
Get-Date
Push-Location
&$env:cmd\create_claims_subfile 22 20170630 201706
&$env:cmd\create_claims_subfile 23 20170630 201706
&$env:cmd\create_claims_subfile 24 20170630 201706
&$env:cmd\create_claims_subfile 25 20170630 201706
&$env:cmd\create_claims_subfile 26 20170630 201706
&$env:cmd\create_claims_subfile 30 20170630 201706
&$env:cmd\create_claims_subfile 31 20170630 201706
&$env:cmd\create_claims_subfile 32 20170630 201706
&$env:cmd\create_claims_subfile 33 20170630 201706
&$env:cmd\create_claims_subfile 34 20170630 201706
&$env:cmd\create_claims_subfile 35 20170630 201706
&$env:cmd\create_claims_subfile 36 20170630 201706
&$env:cmd\create_claims_subfile 41 20170630 201706
&$env:cmd\create_claims_subfile 42 20170630 201706
&$env:cmd\create_claims_subfile 43 20170630 201706
&$env:cmd\create_claims_subfile 44 20170630 201706
&$env:cmd\create_claims_subfile 45 20170630 201706
&$env:cmd\create_claims_subfile 46 20170630 201706
&$env:cmd\create_claims_subfile 98 20170630 201706

Set-Location $env:pb_prod\22

Get-Content $env:pb_prod\23\claims_subfile_23_201706.sf | Add-Content claims_subfile_22_201706.sf
Get-Content $env:pb_prod\24\claims_subfile_24_201706.sf | Add-Content claims_subfile_22_201706.sf
Get-Content $env:pb_prod\25\claims_subfile_25_201706.sf | Add-Content claims_subfile_22_201706.sf
Get-Content $env:pb_prod\26\claims_subfile_26_201706.sf | Add-Content claims_subfile_22_201706.sf
Get-Content $env:pb_prod\30\claims_subfile_30_201706.sf | Add-Content claims_subfile_22_201706.sf
Get-Content $env:pb_prod\31\claims_subfile_31_201706.sf | Add-Content claims_subfile_22_201706.sf
Get-Content $env:pb_prod\32\claims_subfile_32_201706.sf | Add-Content claims_subfile_22_201706.sf
Get-Content $env:pb_prod\33\claims_subfile_33_201706.sf | Add-Content claims_subfile_22_201706.sf
Get-Content $env:pb_prod\34\claims_subfile_34_201706.sf | Add-Content claims_subfile_22_201706.sf
Get-Content $env:pb_prod\35\claims_subfile_35_201706.sf | Add-Content claims_subfile_22_201706.sf
Get-Content $env:pb_prod\36\claims_subfile_36_201706.sf | Add-Content claims_subfile_22_201706.sf
Get-Content $env:pb_prod\41\claims_subfile_41_201706.sf | Add-Content claims_subfile_22_201706.sf
Get-Content $env:pb_prod\42\claims_subfile_42_201706.sf | Add-Content claims_subfile_22_201706.sf
Get-Content $env:pb_prod\43\claims_subfile_43_201706.sf | Add-Content claims_subfile_22_201706.sf
Get-Content $env:pb_prod\44\claims_subfile_44_201706.sf | Add-Content claims_subfile_22_201706.sf
Get-Content $env:pb_prod\45\claims_subfile_45_201706.sf | Add-Content claims_subfile_22_201706.sf
Get-Content $env:pb_prod\46\claims_subfile_46_201706.sf | Add-Content claims_subfile_22_201706.sf
Get-Content $env:pb_prod\98\claims_subfile_98_201706.sf | Add-Content claims_subfile_22_201706.sf

echo ""
Pop-Location
Get-Date

echo "End    Time of $env:cmd\claims_subfile_22to48 is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
