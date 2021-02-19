#-------------------------------------------------------------------------------
# File 'claims_subfile_80_91to96.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'claims_subfile_80_91to96'
#-------------------------------------------------------------------------------

## $cmd/claims_subfile_80_91to96
echo ""
echo "Start  Time of $env:cmd\claims_subfile_80_91to96  is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

echo ""
Get-Date
Push-Location
&$env:cmd\create_claims_subfile 37 20170630 201706
&$env:cmd\create_claims_subfile 68 20170630 201706
&$env:cmd\create_claims_subfile 69 20170630 201706
&$env:cmd\create_claims_subfile 78 20170630 201706
&$env:cmd\create_claims_subfile 79 20170630 201706
&$env:cmd\create_claims_subfile 80 20170630 201706
&$env:cmd\create_claims_subfile 84 20170630 201706
&$env:cmd\create_claims_subfile 87 20170630 201706
&$env:cmd\create_claims_subfile 88 20170630 201706
&$env:cmd\create_claims_subfile 89 20170630 201706
&$env:cmd\create_claims_subfile 91 20170630 201706
&$env:cmd\create_claims_subfile 92 20170630 201706
&$env:cmd\create_claims_subfile 93 20170630 201706
&$env:cmd\create_claims_subfile 94 20170630 201706
&$env:cmd\create_claims_subfile 95 20170630 201706
&$env:cmd\create_claims_subfile 96 20170630 201706
echo ""
Pop-Location
Get-Date

echo ""
echo "End   Time of $env:cmd\claims_subfile_80_91to96  is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
