#-------------------------------------------------------------------------------
# File 'fix_adj_file.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'fix_adj_file'
#-------------------------------------------------------------------------------

#  2013/Aug/20  MC      original ( fix_adj_file )

Set-Location $pb_data
Move-Item adj_claim_file.dat adj_claim_file.dat.bkp

$pipedInput = @"
create file adj-claim-file 
"@

$pipedInput | qutil++

Set-Location $application_root\production

qtp++ $src\fix_adj_claim_file_2

$cmd\verify_adj_file
