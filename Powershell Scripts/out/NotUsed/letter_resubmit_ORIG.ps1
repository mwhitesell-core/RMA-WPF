#-------------------------------------------------------------------------------
# File 'letter_resubmit_ORIG.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'letter_resubmit_ORIG'
#-------------------------------------------------------------------------------

Set-Location $env:application_production
Remove-Item resubmit.ls *> $null
&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "letter_resubmit_ORIG" -InitializationScript $init -ScriptBlock {
  & $env:cmd\letters_resubmits *> resubmit.ls
}
