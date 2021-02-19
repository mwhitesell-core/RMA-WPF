#-------------------------------------------------------------------------------
# File 'unload_suspend_hdr_addr.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'unload_suspend_hdr_addr.com'
#-------------------------------------------------------------------------------

# unload_suspend_hdr_addr.com
# This script is used to unload suspend hdr  & addr in selected web directories   


Set-Location $env:application_root\production\web2
Copy-Item f002_suspend_hdr, f002_suspend_hdr.idx backup
Copy-Item f002_suspend_address, f002_suspend_address.idx backup
&$env:QTP unlof002_susp_hdr > unlof002susphdr.log
&$env:QTP unlof002_susp_addr > unlof002suspaddr.log
Set-Location $env:application_root\production\web4
Copy-Item f002_suspend_hdr, f002_suspend_hdr.idx backup
Copy-Item f002_suspend_address, f002_suspend_address.idx backup
&$env:QTP unlof002_susp_hdr > unlof002susphdr.log
&$env:QTP unlof002_susp_addr > unlof002suspaddr.log
Set-Location $env:application_root\production\web8
Copy-Item f002_suspend_hdr, f002_suspend_hdr.idx backup
Copy-Item f002_suspend_address, f002_suspend_address.idx backup
&$env:QTP unlof002_susp_hdr > unlof002susphdr.log
&$env:QTP unlof002_susp_addr > unlof002suspaddr.log
Set-Location $env:application_root\production\web10
Copy-Item f002_suspend_hdr, f002_suspend_hdr.idx backup
Copy-Item f002_suspend_address, f002_suspend_address.idx backup
&$env:QTP unlof002_susp_hdr > unlof002susphdr.log
&$env:QTP unlof002_susp_addr > unlof002suspaddr.log

Set-Location $env:application_root\production
