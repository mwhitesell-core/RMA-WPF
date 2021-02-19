#-------------------------------------------------------------------------------
# File 'create_u030_autoadjfromnoadj.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_u030_autoadjfromnoadj'
#-------------------------------------------------------------------------------

echo "create autoadj from noadj in each clinic subdirectory"

&$env:QTP u030b_create_autoadj_from_noadj
&$env:QUIZ u030_autoadj_rpt
Get-Date

echo ""
echo "write inverted claim detail key to the adjusting claim detail record"
echo ""
&$env:COBOL u030c
echo ""

Get-Content autoadj.txt | Out-Printer

echo "Done!"
