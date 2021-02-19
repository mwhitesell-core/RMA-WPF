#-------------------------------------------------------------------------------
# File 'create_u030_autoadj_from_noadj.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_u030_autoadj_from_noadj'
#-------------------------------------------------------------------------------

echo "create autoadj from noadj in each clinic subdirectory"

Set-Location $env:application_production\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\31\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\32\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\33\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\34\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\35\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\36\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\37\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\41\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\42\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\43\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\44\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\45\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\46\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\61\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\62\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\63\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\64\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

##cd $application_production/65  
##autoadj
##cp u030_no_adj.sf* autoadj

Set-Location $env:application_production\71\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\72\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\73\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\74\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\75\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\78\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\79\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\80\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\82\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\84\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\86\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\87\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\88\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

# 2010/12/07 - include clinic 89
Set-Location $env:application_production\89\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\91\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\92\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\93\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\94\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\95\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log

Set-Location $env:application_production\96\autoadj
Remove-Item u030_autoadj.log *> $null
&$env:cmd\create_u030_autoadjfromnoadj *> u030_autoadj.log


Set-Location $env:application_production

echo "Done!"
