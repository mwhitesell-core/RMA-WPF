#-------------------------------------------------------------------------------
# File 'create_claims_subfile.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'create_claims_subfile'
#-------------------------------------------------------------------------------

Set-Location $application_production\${1}
echo ""
Get-Date
$pipedInput = @"
exe $obj/create_claims_suba
${1}
${2}
exe $obj/create_claims_subb
exe $obj/create_claims_subc
"@

$pipedInput | quiz++  > subfile.ls  2>&1

Move-Item claims_subfile.sf claims_subfile_${1}_${3}.sf
Move-Item claims_subfile.sfd claims_subfile_${1}_${3}.sfd

echo ""
Get-Date
