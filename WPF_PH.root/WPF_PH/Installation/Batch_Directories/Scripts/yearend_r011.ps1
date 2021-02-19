#-------------------------------------------------------------------------------
# File 'yearend_r011.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yearend_r011'
#-------------------------------------------------------------------------------

Remove-Item yearendr011.ls
$path = Convert-Path .

#$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
#Start-Job -Name "yearend_r011" -InitializationScript $init -ScriptBlock {
#  $env:srvname = [system.environment]::MachineName + "." + [system.environment]::UserDomainName + ".LOCAL"
#  &"\\$env:srvname\rma\scripts\rmabill" 101c
  cd $path
  & $env:cmd\yearendr011 *> yearendr011.ls
#} -ArgumentList $path
