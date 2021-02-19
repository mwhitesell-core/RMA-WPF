#-------------------------------------------------------------------------------
# File 'reload_suspend_hdr_addr.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_suspend_hdr_addr.com'
#-------------------------------------------------------------------------------

# reload_suspend_hdr_addr.com
# This script is used to reload suspend hdr & addr in selected web directories   


Set-Location $env:application_root\production\web2
&$env:QTP relof002_susp_hdr > relof002susphdr.log
&$env:QTP relof002_susp_addr > relof002suspaddr.log
Set-Location $env:application_root\production\web4
&$env:QTP relof002_susp_hdr > relof002susphdr.log
&$env:QTP relof002_susp_addr > relof002suspaddr.log
Set-Location $env:application_root\production\web8
&$env:QTP relof002_susp_hdr > relof002susphdr.log
&$env:QTP relof002_susp_addr > relof002suspaddr.log
Set-Location $env:application_root\production\web10
&$env:QTP relof002_susp_hdr > relof002susphdr.log
&$env:QTP relof002_susp_addr > relof002suspaddr.log

Set-Location $env:application_root\production
