#-------------------------------------------------------------------------------
# File 'u085e_fix_pat.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u085e_fix_pat'
#-------------------------------------------------------------------------------

# 2015/May/12   MC      u085e_fix_pat    
#                       run this macro only encounter error 'Record has been changed since you found it'
#                       when running u085e.qts from $cmd/print_elig_letters

Set-Location $env:application_root\production

echo "Start  - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:QTP u085e_fix_pat

echo "Finish - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
