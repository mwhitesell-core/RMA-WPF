#-------------------------------------------------------------------------------
# File 'batch_create_new_doctors.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_create_new_doctors'
#-------------------------------------------------------------------------------

Remove-Item newdoc.ls *> $null
&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_create_new_doctors" -InitializationScript $init -ScriptBlock {
  & $env:cmd\create_new_doctors *> newdoc.ls
}
exit
