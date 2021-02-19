#-------------------------------------------------------------------------------
# File 'copy_f050_f051_f001_f002_to_foxtrot.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_f050_f051_f001_f002_to_foxtrot'
#-------------------------------------------------------------------------------

#Set-Location $env:pb_data

#Copy-Item f050_doc_revenue_mstr \\$Env:root\foxtrot\purge\101c
#Copy-Item f050_doc_revenue_mstr.idx \\$Env:root\foxtrot\purge\101c
#Copy-Item f050tp_doc_revenue_mstr \\$Env:root\foxtrot\purge\101c
#Copy-Item f050tp_doc_revenue_mstr.idx \\$Env:root\foxtrot\purge\101c

# 2009/10/27 - history files have moved to /charly
#Set-Location \\$Env:root\charly\rmabill\rmabill101c\data

#Copy-Item f050_doc_revenue_mstr_history.dat \\$Env:root\foxtrot\purge\101c
#Copy-Item f050_doc_revenue_mstr_history.idx \\$Env:root\foxtrot\purge\101c
#Copy-Item f050tp_doc_revenue_mstr_history.dat \\$Env:root\foxtrot\purge\101c
#Copy-Item f050tp_doc_revenue_mstr_history.idx \\$Env:root\foxtrot\purge\101c

#cp f010_pat_mstr                         /foxtrot/purge/101c
#cp f010_pat_mstr.idx                     /foxtrot/purge/101c

#Set-Location $env:pb_data

#Copy-Item f051_doc_cash_mstr \\$Env:root\foxtrot\purge\101c
#Copy-Item f051_doc_cash_mstr.idx \\$Env:root\foxtrot\purge\101c
#Copy-Item f051tp_doc_cash_mstr \\$Env:root\foxtrot\purge\101c
#Copy-Item f051tp_doc_cash_mstr.idx \\$Env:root\foxtrot\purge\101c

#Copy-Item f001_batch_control_file \\$Env:root\foxtrot\purge\101c
#Copy-Item f001_batch_control_file.idx \\$Env:root\foxtrot\purge\101c

#cp f002_claims_mstr                      /foxtrot/purge/101c
#cp f002_claims_mstr.idx                  /foxtrot/purge/101c

#Copy-Item f002_claim_shadow \\$Env:root\foxtrot\purge\101c
#Copy-Item f002_claim_shadow.idx \\$Env:root\foxtrot\purge\101c

Set-Location $env:pb_prod

$out = $null
$rcmd = $env:QTP + "backup_earnings_daily 1 backup_f050_f051_f001_f002"
Invoke-Expression $rcmd | Tee-Object -Variable out
$out | Add-Content $env:pb_data/backup_earnings_daily$1.ls
