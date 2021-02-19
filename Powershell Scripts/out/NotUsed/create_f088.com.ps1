#-------------------------------------------------------------------------------
# File 'create_f088.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_f088.com'
#-------------------------------------------------------------------------------

$pipedInput = @"
create file f088-rat-rejected-claims-hist-hdr
create file f088-rat-rejected-claims-hist-dtl
"@

$pipedInput | qutil++
