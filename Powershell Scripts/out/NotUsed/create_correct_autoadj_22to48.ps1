#-------------------------------------------------------------------------------
# File 'create_correct_autoadj_22to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_correct_autoadj_22to48'
#-------------------------------------------------------------------------------

echo "create rerun directory for u030"

Set-Location $env:application_production
##mkdir correct_u030_autoadj  
Copy-Item reverse_u030_autoadj\u030_adj_explan_57.* correct_u030_autoadj
Copy-Item part_adj_batch* correct_u030_autoadj

Set-Location $env:application_production\31
##mkdir correct_u030_autoadj  
Copy-Item reverse_u030_autoadj\u030_adj_explan_57.* correct_u030_autoadj
Copy-Item part_adj_batch* correct_u030_autoadj

Set-Location $env:application_production\32
##mkdir correct_u030_autoadj  
Copy-Item reverse_u030_autoadj\u030_adj_explan_57.* correct_u030_autoadj
Copy-Item part_adj_batch* correct_u030_autoadj

Set-Location $env:application_production\33
##mkdir correct_u030_autoadj  
Copy-Item reverse_u030_autoadj\u030_adj_explan_57.* correct_u030_autoadj
Copy-Item part_adj_batch* correct_u030_autoadj

Set-Location $env:application_production\34
##mkdir correct_u030_autoadj  
Copy-Item reverse_u030_autoadj\u030_adj_explan_57.* correct_u030_autoadj
Copy-Item part_adj_batch* correct_u030_autoadj

Set-Location $env:application_production\35
##mkdir correct_u030_autoadj  
Copy-Item reverse_u030_autoadj\u030_adj_explan_57.* correct_u030_autoadj
Copy-Item part_adj_batch* correct_u030_autoadj

Set-Location $env:application_production\36
##mkdir correct_u030_autoadj  
Copy-Item reverse_u030_autoadj\u030_adj_explan_57.* correct_u030_autoadj
Copy-Item part_adj_batch* correct_u030_autoadj

Set-Location $env:application_production\41
##mkdir correct_u030_autoadj  
Copy-Item reverse_u030_autoadj\u030_adj_explan_57.* correct_u030_autoadj
Copy-Item part_adj_batch* correct_u030_autoadj

Set-Location $env:application_production\42
##mkdir correct_u030_autoadj  
Copy-Item reverse_u030_autoadj\u030_adj_explan_57.* correct_u030_autoadj
Copy-Item part_adj_batch* correct_u030_autoadj

Set-Location $env:application_production\43
##mkdir correct_u030_autoadj  
Copy-Item reverse_u030_autoadj\u030_adj_explan_57.* correct_u030_autoadj
Copy-Item part_adj_batch* correct_u030_autoadj

Set-Location $env:application_production\44
##mkdir correct_u030_autoadj  
Copy-Item reverse_u030_autoadj\u030_adj_explan_57.* correct_u030_autoadj
Copy-Item part_adj_batch* correct_u030_autoadj

Set-Location $env:application_production\45
##mkdir correct_u030_autoadj  
Copy-Item reverse_u030_autoadj\u030_adj_explan_57.* correct_u030_autoadj
Copy-Item part_adj_batch* correct_u030_autoadj

Set-Location $env:application_production\46
##mkdir correct_u030_autoadj  
Copy-Item reverse_u030_autoadj\u030_adj_explan_57.* correct_u030_autoadj
Copy-Item part_adj_batch* correct_u030_autoadj

Set-Location $env:application_production\48
##mkdir correct_u030_autoadj  
Copy-Item reverse_u030_autoadj\u030_adj_explan_57.* correct_u030_autoadj
Copy-Item part_adj_batch* correct_u030_autoadj


echo "Done!"
