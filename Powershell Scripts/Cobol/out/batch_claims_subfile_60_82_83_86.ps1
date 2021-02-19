#-------------------------------------------------------------------------------
# File 'batch_claims_subfile_60_82_83_86.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_claims_subfile_60_82_83_86'
#-------------------------------------------------------------------------------

##  $cmd/batch_claims_subfile_60_82_83_86
##  execute $cmd/claims_subfile_60_82_83_86 in batch

$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_claims_subfile_60_82_83_86" -InitializationScript $init -ScriptBlock {
  & $cmd\claims_subfile_60_82_83_86  > batch_claims_subfile_60_82_83_86.log
}
