#-------------------------------------------------------------------------------
# File 'print_diskettes.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'print_diskettes'
#-------------------------------------------------------------------------------

# 20050503 - don't print r707 ru703b and ru703c - as per Linda O. and Renee 
# 2012/01/06 - comment out suspend_fee.txt - as per Linda O. Renee and Nancy

Get-Contents dump_tech.txt| Out-Printer  > $null
Get-Contents r715.txt| Out-Printer  > $null
Get-Contents r712.txt| Out-Printer  > $null
Get-Contents r717.txt| Out-Printer  > $null
Get-Contents ru703a| Out-Printer  > $null
Get-Contents suspend_agent.txt| Out-Printer  > $null
Get-Contents suspend_desc.txt| Out-Printer  > $null
Get-Contents suspend_suffix.txt| Out-Printer  > $null
Get-Contents ru701_acr.txt| Out-Printer  > $null
Get-Contents suspdtl.txt| Out-Printer  > $null

$cmd\fix_dump_tech

#lp >/dev/null  2>/dev/null suspend_fee.txt
#lp >/dev/null  2>/dev/null r710.txt             
#lp >/dev/null  2>/dev/null bg2215.001
#lp >/dev/null  2>/dev/null r711.txt
#lp >/dev/null  2>/dev/null r707.txt
#lp >/dev/null  2>/dev/null ru703b
#lp >/dev/null  2>/dev/null ru703c

echo ""
echo "PRINT - lpc suspend_agent_detail.txt"
echo ""
