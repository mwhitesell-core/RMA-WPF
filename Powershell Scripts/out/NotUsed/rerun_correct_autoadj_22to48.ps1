#-------------------------------------------------------------------------------
# File 'rerun_correct_autoadj_22to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rerun_correct_autoadj_22to48'
#-------------------------------------------------------------------------------

echo "rerun u030b for clinic 22 to 48"

Set-Location $env:application_production\correct_u030_autoadj
&$env:cmd\u030_create_correct_b_adj

Set-Location $env:application_production\31\correct_u030_autoadj
&$env:cmd\u030_create_correct_b_adj

Set-Location $env:application_production\32\correct_u030_autoadj
&$env:cmd\u030_create_correct_b_adj

Set-Location $env:application_production\33\correct_u030_autoadj
&$env:cmd\u030_create_correct_b_adj

Set-Location $env:application_production\34\correct_u030_autoadj
&$env:cmd\u030_create_correct_b_adj

Set-Location $env:application_production\35\correct_u030_autoadj
&$env:cmd\u030_create_correct_b_adj

Set-Location $env:application_production\36\correct_u030_autoadj
&$env:cmd\u030_create_correct_b_adj

Set-Location $env:application_production\41\correct_u030_autoadj
&$env:cmd\u030_create_correct_b_adj

Set-Location $env:application_production\42\correct_u030_autoadj
&$env:cmd\u030_create_correct_b_adj

Set-Location $env:application_production\43\correct_u030_autoadj
&$env:cmd\u030_create_correct_b_adj

Set-Location $env:application_production\44\correct_u030_autoadj
&$env:cmd\u030_create_correct_b_adj

Set-Location $env:application_production\45\correct_u030_autoadj
&$env:cmd\u030_create_correct_b_adj

Set-Location $env:application_production\46\correct_u030_autoadj
&$env:cmd\u030_create_correct_b_adj

Set-Location $env:application_production\48\correct_u030_autoadj
&$env:cmd\u030_create_correct_b_adj


echo "Done!"
