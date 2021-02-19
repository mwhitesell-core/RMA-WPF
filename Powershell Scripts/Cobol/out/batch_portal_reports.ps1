#-------------------------------------------------------------------------------
# File 'batch_portal_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_portal_reports'
#-------------------------------------------------------------------------------

##  $cmd/batch_portal_reports
##  execute $cmd/portal_reports in batch

$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_portal_reports" -InitializationScript $init -ScriptBlock {
  & $cmd\portal_reports  > batch_portal_reports.log
}
