#-------------------------------------------------------------------------------
# File 'checkf002tech_not_needed.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'checkf002tech_not_needed'
#-------------------------------------------------------------------------------

Set-Location $Env:root\charly\purge

#cd /foxtrot/purge    

echo "BEGIN NOW... $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:QTP checkf002tech_entire_file > checkf002.log

echo "ENDING.... $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
