#-------------------------------------------------------------------------------
# File 'recreate_suspense.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'recreate_suspense'
#-------------------------------------------------------------------------------

# recreate_suspense
# 00/oct/20 B.E. - changed delete of suspend files to not use * wildcard
#

Remove-Item f002_suspend_hdr
Remove-Item f002_suspend_hdr.idx
Remove-Item f002_suspend_dtl
Remove-Item f002_suspend_dtl.idx
Remove-Item f002_suspend_address
Remove-Item f002_suspend_address.idx
Remove-Item f002_suspend_desc
Remove-Item f002_suspend_desc.idx

&$env:COBOL createsusp
. $env:cmd\create_susp_links.com
