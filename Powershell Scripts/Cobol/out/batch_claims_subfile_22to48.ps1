#-------------------------------------------------------------------------------
# File 'batch_claims_subfile_22to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_claims_subfile_22to48'
#-------------------------------------------------------------------------------

##  $cmd/batch_claims_subfile_22to48
##  execute $cmd/claims_subfile_22to48 in batch

$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_claims_subfile_22to48" -InitializationScript $init -ScriptBlock {
  & $cmd\claims_subfile_22to48  > batch_claims_subfile_22to48.log
}
