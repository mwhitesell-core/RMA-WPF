#-------------------------------------------------------------------------------
# File 'recreate_susp_hdr_addr.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'recreate_susp_hdr_addr'
#-------------------------------------------------------------------------------

# recreate_susp_hdr_addr
# This script is used to recreate suspend hdr & address in selected web directories


Set-Location $env:application_root\production\web2
&$env:cmd\recreate_suspend_hdr_addr
Set-Location $env:application_root\production\web4
&$env:cmd\recreate_suspend_hdr_addr
Set-Location $env:application_root\production\web8
&$env:cmd\recreate_suspend_hdr_addr
Set-Location $env:application_root\production\web10
&$env:cmd\recreate_suspend_hdr_addr

Set-Location $env:application_root\production
