#-------------------------------------------------------------------------------
# File 'suspense_upload.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'suspense_upload'
#-------------------------------------------------------------------------------

# suspend_upload
$pipedInput = @"
create file f002-suspend-address
create file f002-suspend-hdr
create file f002-suspend-dtl
"@

$pipedInput | qutil++

&$env:QTP relof002_susp_addr
&$env:QTP relof002_susp_hdr
&$env:QTP relof002_susp_dtl
