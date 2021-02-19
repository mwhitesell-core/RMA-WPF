#-------------------------------------------------------------------------------
# File 'print_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'print_disk'
#-------------------------------------------------------------------------------

# 2012/01/06 - comment out suspend_fee.txt - as per Linda O. Renee and Nancy

Get-Content dump_tech.txt | Out-Printer *> $null
Get-Content r710.txt | Out-Printer *> $null
Get-Content bg2215.001 | Out-Printer *> $null
Get-Content bg2215.002 | Out-Printer *> $null
Get-Content bg2215.003 | Out-Printer *> $null
Get-Content bg2215.004 | Out-Printer *> $null
Get-Content bg2215.005 | Out-Printer *> $null
Get-Content bg2215.006 | Out-Printer *> $null
Get-Content bg2215.007 | Out-Printer *> $null
Get-Content bg2215.008 | Out-Printer *> $null
Get-Content bg2215.009 | Out-Printer *> $null
Get-Content bg2215.010 | Out-Printer *> $null
Get-Content bg2215.011 | Out-Printer *> $null
Get-Content bg2215.012 | Out-Printer *> $null
Get-Content bg2215.013 | Out-Printer *> $null
Get-Content bg2215.014 | Out-Printer *> $null
Get-Content bg2215.015 | Out-Printer *> $null
Get-Content ru701_acr.txt | Out-Printer *> $null
Get-Content r715.txt | Out-Printer *> $null
Get-Content r712.txt | Out-Printer *> $null
Get-Content ru703a | Out-Printer *> $null
#lp >/dev/null  2>/dev/null suspdtl.txt
Get-Content suspend_agent.txt | Out-Printer *> $null
Get-Content suspend_desc.txt | Out-Printer *> $null
Get-Content suspend_suffix.txt | Out-Printer *> $null
#lp >/dev/null  2>/dev/null suspend_fee.txt
&$env:cmd\fix_dump_tech
