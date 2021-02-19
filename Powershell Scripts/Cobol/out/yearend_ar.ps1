#-------------------------------------------------------------------------------
# File 'yearend_ar.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'yearend_ar'
#-------------------------------------------------------------------------------

Remove-Item yearendr070.ls
$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "yearend_ar" -InitializationScript $init -ScriptBlock {
  & $cmd\yearendr070  > yearendr070.ls  2>&1
}
