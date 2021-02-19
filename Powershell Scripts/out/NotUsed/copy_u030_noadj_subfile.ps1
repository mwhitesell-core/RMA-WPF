#-------------------------------------------------------------------------------
# File 'copy_u030_noadj_subfile.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_u030_noadj_subfile'
#-------------------------------------------------------------------------------

echo "copy u030_no_adj subfiles to each clinic subdirectory"

Set-Location $env:application_production
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\31
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\32
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\33
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\34
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\35
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\36
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\37
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\41
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\42
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\43
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\44
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\45
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\46
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\61
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\62
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\63
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\64
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

##cd $application_production/65  
##mkdir autoadj
##cp u030_no_adj.sf* autoadj

Set-Location $env:application_production\71
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\72
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\73
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\74
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\75
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\78
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\79
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\80
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\82
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\84
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\86
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\87
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\88
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

# 2010/12/07 -include clinic 89
Set-Location $env:application_production\89
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\91
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\92
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\93
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\94
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\95
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++

Set-Location $env:application_production\96
New-Item -ItemType directory -Force -Path autoadj
Copy-Item u030_no_adj.sf* autoadj
Set-Location autoadj
$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++


Set-Location $env:application_production

echo "Done!"
