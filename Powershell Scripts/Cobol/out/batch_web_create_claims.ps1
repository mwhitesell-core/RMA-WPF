#-------------------------------------------------------------------------------
# File 'batch_web_create_claims.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_web_create_claims'
#-------------------------------------------------------------------------------

##  $cmd/batch_web_create_claims
##  execute $cmd/web_create_claims in batch
##  user should pass   the date below before running this macro

$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_web_create_claims" -InitializationScript $init -ScriptBlock {
  & $cmd\web_create_claims  $1  > web.ls
}
