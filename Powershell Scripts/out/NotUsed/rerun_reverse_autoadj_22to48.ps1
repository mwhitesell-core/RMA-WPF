#-------------------------------------------------------------------------------
# File 'rerun_reverse_autoadj_22to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rerun_reverse_autoadj_22to48'
#-------------------------------------------------------------------------------

echo "rerun u030b for clinic 22 to 48"

Set-Location $env:application_production\reverse_u030_autoadj
&$env:cmd\u030_auto_adj_reverse

Set-Location $env:application_production\31\reverse_u030_autoadj
&$env:cmd\u030_auto_adj_reverse

Set-Location $env:application_production\32\reverse_u030_autoadj
&$env:cmd\u030_auto_adj_reverse

Set-Location $env:application_production\33\reverse_u030_autoadj
&$env:cmd\u030_auto_adj_reverse

Set-Location $env:application_production\34\reverse_u030_autoadj
&$env:cmd\u030_auto_adj_reverse

Set-Location $env:application_production\35\reverse_u030_autoadj
&$env:cmd\u030_auto_adj_reverse

Set-Location $env:application_production\36\reverse_u030_autoadj
&$env:cmd\u030_auto_adj_reverse

Set-Location $env:application_production\41\reverse_u030_autoadj
&$env:cmd\u030_auto_adj_reverse

Set-Location $env:application_production\42\reverse_u030_autoadj
&$env:cmd\u030_auto_adj_reverse

Set-Location $env:application_production\43\reverse_u030_autoadj
&$env:cmd\u030_auto_adj_reverse

Set-Location $env:application_production\44\reverse_u030_autoadj
&$env:cmd\u030_auto_adj_reverse

Set-Location $env:application_production\45\reverse_u030_autoadj
&$env:cmd\u030_auto_adj_reverse

Set-Location $env:application_production\46\reverse_u030_autoadj
&$env:cmd\u030_auto_adj_reverse

Set-Location $env:application_production\48\reverse_u030_autoadj
&$env:cmd\u030_auto_adj_reverse


echo "Done!"
