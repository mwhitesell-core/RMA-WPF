#-------------------------------------------------------------------------------
# File 'doc_rev_yearly_roll.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'doc_rev_yearly_roll'
#-------------------------------------------------------------------------------

if ( $env:networkprinter -ne 'null'  )
{
   &$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
   Start-Job -Name "doc_rev_yearly_roll" -InitializationScript $init -ScriptBlock {
     & $env:QTP purge_f050_f051 *> roll.ls
     & Get-Content roll.ls | Out-Printer -Name $env:networkprinter
   }
}
else
{
   &$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
   Start-Job -Name "doc_rev_yearly_roll" -InitializationScript $init -ScriptBlock {
     & $env:QTP purge_f050_f051 *> roll.ls
   }
}
