#-------------------------------------------------------------------------------
# File 'batch_portal_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_portal_reports'
#-------------------------------------------------------------------------------

##  $cmd/batch_portal_reports
##  execute $cmd/portal_reports in batch
<#$path = Convert-Path .
$vers = $env:RMABILL_VERS

$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_portal_reports" -InitializationScript $init -ScriptBlock {
  param(
        [string]$path,
        [string]$vers
       )
  &"\\$env:srvname\rma\scripts\rmabill" $vers
  cd $path#>
  & $env:cmd\portal_reports > batch_portal_reports.log
#} -ArgumentList $path, $vers
