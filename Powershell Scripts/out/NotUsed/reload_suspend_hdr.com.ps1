#-------------------------------------------------------------------------------
# File 'reload_suspend_hdr.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_suspend_hdr.com'
#-------------------------------------------------------------------------------

# reload_suspend_hdr.com
# This script is used to reload suspend hdr in selected web directories   


Set-Location $env:application_root\production\web2
&$env:QTP relof002_susp_hdr > relof002susphdr.log
Set-Location $env:application_root\production\web3
&$env:QTP relof002_susp_hdr > relof002susphdr.log
Set-Location $env:application_root\production\web5
&$env:QTP relof002_susp_hdr > relof002susphdr.log
Set-Location $env:application_root\production\web7
&$env:QTP relof002_susp_hdr > relof002susphdr.log
Set-Location $env:application_root\production\web8
&$env:QTP relof002_susp_hdr > relof002susphdr.log


Set-Location $env:application_root\production
