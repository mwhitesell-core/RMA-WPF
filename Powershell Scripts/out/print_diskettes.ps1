#-------------------------------------------------------------------------------
# File 'print_diskettes.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'print_diskettes'
#-------------------------------------------------------------------------------

# 20050503 - don't print r707 ru703b and ru703c - as per Linda O. and Renee 
# 2012/01/06 - comment out suspend_fee.txt - as per Linda O. Renee and Nancy

Get-Content dump_tech.txt | Out-Printer *> $null
Get-Content r715.txt | Out-Printer *> $null
Get-Content r712.txt | Out-Printer *> $null
Get-Content r717.txt | Out-Printer *> $null
Get-Content ru703a | Out-Printer *> $null
Get-Content suspend_agent.txt | Out-Printer *> $null
Get-Content suspend_desc.txt | Out-Printer *> $null
Get-Content suspend_suffix.txt | Out-Printer *> $null
Get-Content ru701_acr.txt | Out-Printer *> $null
Get-Content suspdtl.txt | Out-Printer *> $null

&$env:cmd\fix_dump_tech

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
