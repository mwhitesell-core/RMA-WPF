#-------------------------------------------------------------------------------
# File 'batch_claims_subfile_22to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_claims_subfile_22to48'
#-------------------------------------------------------------------------------

##  $cmd/batch_claims_subfile_22to48
##  execute $cmd/claims_subfile_22to48 in batch

<#$vers = $env:RMABILL_VERS
$path = Convert-Path .

$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_claims_subfile_22to48" -InitializationScript $init -ScriptBlock {
  
  param(
        [string]$version,
	    [string]$path
        )

  $env:srvname = $env:srvname + "." + [system.environment]::UserDomainName + ".LOCAL"
  &"\\$env:srvname\rma\scripts\rmabill" $version
  cd $path#>
  &$env:cmd\claims_subfile_22to48 > batch_claims_subfile_22to48.log
#} -ArgumentList $vers, $path
