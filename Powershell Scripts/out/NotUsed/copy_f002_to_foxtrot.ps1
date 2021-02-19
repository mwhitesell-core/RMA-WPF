#-------------------------------------------------------------------------------
# File 'copy_f002_to_foxtrot.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_f002_to_foxtrot'
#-------------------------------------------------------------------------------

Set-Location $pb_data

Copy-Item f002_claims_mstr $Env:root\foxtrot\purge\101c
Copy-Item f002_claims_mstr.idx $Env:root\foxtrot\purge\101c


Set-Location $pb_prod
