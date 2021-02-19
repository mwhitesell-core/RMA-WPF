#-------------------------------------------------------------------------------
# File 'recreate_susp_hdr_addr.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'recreate_susp_hdr_addr'
#-------------------------------------------------------------------------------

# recreate_susp_hdr_addr
# This script is used to recreate suspend hdr & address in selected web directories


Set-Location $application_root\production\web2
$cmd\recreate_suspend_hdr_addr
Set-Location $application_root\production\web4
$cmd\recreate_suspend_hdr_addr
Set-Location $application_root\production\web8
$cmd\recreate_suspend_hdr_addr
Set-Location $application_root\production\web10
$cmd\recreate_suspend_hdr_addr

Set-Location $application_root\production
