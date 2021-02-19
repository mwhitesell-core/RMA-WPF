#-------------------------------------------------------------------------------
# File 'copy_f050_f051_f001_f002_to_charly.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_f050_f051_f001_f002_to_charly'
#-------------------------------------------------------------------------------

Set-Location $pb_data

Copy-Item f050_doc_revenue_mstr $Env:root\charly\purge\101c
Copy-Item f050_doc_revenue_mstr.idx $Env:root\charly\purge\101c
Copy-Item f050tp_doc_revenue_mstr $Env:root\charly\purge\101c
Copy-Item f050tp_doc_revenue_mstr.idx $Env:root\charly\purge\101c

# 2009/10/27 - history files have moved to /charly
Set-Location $Env:root\charly\rmabill\rmabill101c\data

Copy-Item f050_doc_revenue_mstr_history.dat $Env:root\charly\purge\101c
Copy-Item f050_doc_revenue_mstr_history.idx $Env:root\charly\purge\101c
Copy-Item f050tp_doc_revenue_mstr_history.dat $Env:root\charly\purge\101c
Copy-Item f050tp_doc_revenue_mstr_history.idx $Env:root\charly\purge\101c

#cp f010_pat_mstr                         /charly/purge/101c
#cp f010_pat_mstr.idx                     /charly/purge/101c

Set-Location $pb_data

Copy-Item f051_doc_cash_mstr $Env:root\charly\purge\101c
Copy-Item f051_doc_cash_mstr.idx $Env:root\charly\purge\101c
Copy-Item f051tp_doc_cash_mstr $Env:root\charly\purge\101c
Copy-Item f051tp_doc_cash_mstr.idx $Env:root\charly\purge\101c

Copy-Item f001_batch_control_file $Env:root\charly\purge\101c
Copy-Item f001_batch_control_file.idx $Env:root\charly\purge\101c

#cp f002_claims_mstr                      /charly/purge/101c
#cp f002_claims_mstr.idx                  /charly/purge/101c

#cp f002_claim_shadow                     /charly/purge/101c
#cp f002_claim_shadow.idx                 /charly/purge/101c

Set-Location $pb_prod
