#-------------------------------------------------------------------------------
# File 'create_rerun_autoadj_22to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_rerun_autoadj_22to48'
#-------------------------------------------------------------------------------

echo "create rerun directory for u030"

Set-Location $env:application_production
##mkdir rerun_u030_autoadj  
Copy-Item u030_auto_adj.* rerun_u030_autoadj
Copy-Item part_paid_dtl* rerun_u030_autoadj
Copy-Item part_adj_batch* rerun_u030_autoadj

Set-Location $env:application_production\31
##mkdir rerun_u030_autoadj  
Copy-Item u030_auto_adj.* rerun_u030_autoadj
Copy-Item part_paid_dtl* rerun_u030_autoadj
Copy-Item part_adj_batch* rerun_u030_autoadj

Set-Location $env:application_production\32
##mkdir rerun_u030_autoadj  
Copy-Item u030_auto_adj.* rerun_u030_autoadj
Copy-Item part_paid_dtl* rerun_u030_autoadj
Copy-Item part_adj_batch* rerun_u030_autoadj

Set-Location $env:application_production\33
##mkdir rerun_u030_autoadj  
Copy-Item u030_auto_adj.* rerun_u030_autoadj
Copy-Item part_paid_dtl* rerun_u030_autoadj
Copy-Item part_adj_batch* rerun_u030_autoadj

Set-Location $env:application_production\34
##mkdir rerun_u030_autoadj  
Copy-Item u030_auto_adj.* rerun_u030_autoadj
Copy-Item part_paid_dtl* rerun_u030_autoadj
Copy-Item part_adj_batch* rerun_u030_autoadj

Set-Location $env:application_production\35
##mkdir rerun_u030_autoadj  
Copy-Item u030_auto_adj.* rerun_u030_autoadj
Copy-Item part_paid_dtl* rerun_u030_autoadj
Copy-Item part_adj_batch* rerun_u030_autoadj

Set-Location $env:application_production\36
##mkdir rerun_u030_autoadj  
Copy-Item u030_auto_adj.* rerun_u030_autoadj
Copy-Item part_paid_dtl* rerun_u030_autoadj
Copy-Item part_adj_batch* rerun_u030_autoadj

Set-Location $env:application_production\41
##mkdir rerun_u030_autoadj  
Copy-Item u030_auto_adj.* rerun_u030_autoadj
Copy-Item part_paid_dtl* rerun_u030_autoadj
Copy-Item part_adj_batch* rerun_u030_autoadj

Set-Location $env:application_production\42
##mkdir rerun_u030_autoadj  
Copy-Item u030_auto_adj.* rerun_u030_autoadj
Copy-Item part_paid_dtl* rerun_u030_autoadj
Copy-Item part_adj_batch* rerun_u030_autoadj

Set-Location $env:application_production\43
##mkdir rerun_u030_autoadj  
Copy-Item u030_auto_adj.* rerun_u030_autoadj
Copy-Item part_paid_dtl* rerun_u030_autoadj
Copy-Item part_adj_batch* rerun_u030_autoadj

Set-Location $env:application_production\44
##mkdir rerun_u030_autoadj  
Copy-Item u030_auto_adj.* rerun_u030_autoadj
Copy-Item part_paid_dtl* rerun_u030_autoadj
Copy-Item part_adj_batch* rerun_u030_autoadj

Set-Location $env:application_production\45
##mkdir rerun_u030_autoadj  
Copy-Item u030_auto_adj.* rerun_u030_autoadj
Copy-Item part_paid_dtl* rerun_u030_autoadj
Copy-Item part_adj_batch* rerun_u030_autoadj

Set-Location $env:application_production\46
##mkdir rerun_u030_autoadj  
Copy-Item u030_auto_adj.* rerun_u030_autoadj
Copy-Item part_paid_dtl* rerun_u030_autoadj
Copy-Item part_adj_batch* rerun_u030_autoadj

Set-Location $env:application_production\48
##mkdir rerun_u030_autoadj  
Copy-Item u030_auto_adj.* rerun_u030_autoadj
Copy-Item part_paid_dtl* rerun_u030_autoadj
Copy-Item part_adj_batch* rerun_u030_autoadj


echo "Done!"