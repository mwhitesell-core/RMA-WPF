#-------------------------------------------------------------------------------
# File 'create_reverse_autoadj_22to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_reverse_autoadj_22to48'
#-------------------------------------------------------------------------------

echo "create rerun directory for u030"

Set-Location $env:application_production
##mkdir reverse_u030_autoadj  
Copy-Item u030bradadj.* reverse_u030_autoadj
Copy-Item part_adj_batch* reverse_u030_autoadj

Set-Location $env:application_production\31
##mkdir reverse_u030_autoadj  
Copy-Item u030bradadj.* reverse_u030_autoadj
Copy-Item part_adj_batch* reverse_u030_autoadj

Set-Location $env:application_production\32
##mkdir reverse_u030_autoadj  
Copy-Item u030bradadj.* reverse_u030_autoadj
Copy-Item part_adj_batch* reverse_u030_autoadj

Set-Location $env:application_production\33
##mkdir reverse_u030_autoadj  
Copy-Item u030bradadj.* reverse_u030_autoadj
Copy-Item part_adj_batch* reverse_u030_autoadj

Set-Location $env:application_production\34
##mkdir reverse_u030_autoadj  
Copy-Item u030bradadj.* reverse_u030_autoadj
Copy-Item part_adj_batch* reverse_u030_autoadj

Set-Location $env:application_production\35
##mkdir reverse_u030_autoadj  
Copy-Item u030bradadj.* reverse_u030_autoadj
Copy-Item part_adj_batch* reverse_u030_autoadj

Set-Location $env:application_production\36
##mkdir reverse_u030_autoadj  
Copy-Item u030bradadj.* reverse_u030_autoadj
Copy-Item part_adj_batch* reverse_u030_autoadj

Set-Location $env:application_production\41
##mkdir reverse_u030_autoadj  
Copy-Item u030bradadj.* reverse_u030_autoadj
Copy-Item part_adj_batch* reverse_u030_autoadj

Set-Location $env:application_production\42
##mkdir reverse_u030_autoadj  
Copy-Item u030bradadj.* reverse_u030_autoadj
Copy-Item part_adj_batch* reverse_u030_autoadj

Set-Location $env:application_production\43
##mkdir reverse_u030_autoadj  
Copy-Item u030bradadj.* reverse_u030_autoadj
Copy-Item part_adj_batch* reverse_u030_autoadj

Set-Location $env:application_production\44
##mkdir reverse_u030_autoadj  
Copy-Item u030bradadj.* reverse_u030_autoadj
Copy-Item part_adj_batch* reverse_u030_autoadj

Set-Location $env:application_production\45
##mkdir reverse_u030_autoadj  
Copy-Item u030bradadj.* reverse_u030_autoadj
Copy-Item part_adj_batch* reverse_u030_autoadj

Set-Location $env:application_production\46
##mkdir reverse_u030_autoadj  
Copy-Item u030bradadj.* reverse_u030_autoadj
Copy-Item part_adj_batch* reverse_u030_autoadj

Set-Location $env:application_production\48
##mkdir reverse_u030_autoadj  
Copy-Item u030bradadj.* reverse_u030_autoadj
Copy-Item part_adj_batch* reverse_u030_autoadj


echo "Done!"
