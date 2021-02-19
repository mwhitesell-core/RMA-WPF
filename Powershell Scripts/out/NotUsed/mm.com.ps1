#-------------------------------------------------------------------------------
# File 'mm.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'mm.com'
#-------------------------------------------------------------------------------

# mail merge pgm

&$env:QUIZ mm_a
&$env:QUIZ mm_b
&$env:QUIZ mm_c
Get-Content mm_a.sf, mm_b.sf, mm_c.sf | Set-Content mm.rtf
echo ""
echo "Download 'mm.rtf' for mail merge secondary (data) file ..."
