#-------------------------------------------------------------------------------
# File 'fix_adj_file.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'fix_adj_file'
#-------------------------------------------------------------------------------

#  2013/Aug/20  MC      original ( fix_adj_file )

Set-Location $pb_data
Move-Item -Force adj_claim_file.dat adj_claim_file.dat.bkp

$pipedInput = @"
create file adj-claim-file 
"@

$pipedInput | qutil++

Set-Location $env:application_root\production

&$env:QTP fix_adj_claim_file_2

&$env:cmd\verify_adj_file
