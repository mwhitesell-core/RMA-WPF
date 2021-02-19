#-------------------------------------------------------------------------------
# File 'yearend_ar.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yearend_ar'
#-------------------------------------------------------------------------------

Remove-Item yearendr070.ls
&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "yearend_ar" -InitializationScript $init -ScriptBlock {
  & $env:cmd\yearendr070 *> yearendr070.ls
}
