#-------------------------------------------------------------------------------
# File 'check_elig_pat.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'check_elig_pat'
#-------------------------------------------------------------------------------

echo "ENTER Y to run macro - otherwise job will TERMINATE!"

$response = Read-Host
echo "$response"

if  ("$response" -eq "Y" -or "$response" -eq "y")
{
        echo "job will now start ..."
        echo "..."
} else {
        echo `
          "`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`aWARNING - job was TERMINATED AT YOUR REQUEST!"
        echo "Terminated!"
}

Set-Location $env:application_production
Remove-Item check_elig_pat.log *> $null
#CORE - Changed to run in active shell instead of background
<#$path = Convert-Path .
$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "check_elig_pat" -InitializationScript $init -ScriptBlock {
  $env:srvname = [system.environment]::MachineName + "." + [system.environment]::UserDomainName + ".LOCAL"
  &"\\$env:srvname\rma\scripts\rmabill" 101c
  cd $path#>
  &$env:cmd\check_elig_corrected_patients *> check_elig_pat.log
#} -ArgumentList $path
