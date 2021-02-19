#-------------------------------------------------------------------------------
# File 'recreate_suspense_hdr.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'recreate_suspense_hdr'
#-------------------------------------------------------------------------------

Remove-Item f002_suspend_hdr*

&$env:COBOL createsusp
. $env:cmd\create_susp_links.com
