#-------------------------------------------------------------------------------
# File 'juneser.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'juneser'
#-------------------------------------------------------------------------------

&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "juneser" -InitializationScript $init -ScriptBlock {
  & Set-Location $Env:root\alpha\home\yasemin
  & Remove-Item claims_subfile.sf*
  & Move-Item -Force claims_subfile_jul.sfd claims_subfile.sfd
  & Move-Item -Force claims_subfile_jul.sf claims_subfile.sf
  & $env:QUIZ juneser
  & Remove-Item claims_subfile.sf*
  & Move-Item -Force claims_subfile_aug.sfd claims_subfile.sfd
  & Move-Item -Force claims_subfile_aug.sf claims_subfile.sf
  & $env:QUIZ juneser
  & Remove-Item claims_subfile.sf*
  & Move-Item -Force claims_subfile_sep.sfd claims_subfile.sfd
  & Move-Item -Force claims_subfile_sep.sf claims_subfile.sf
  & $env:QUIZ juneser
  & Remove-Item claims_subfile.sf*
  & Move-Item -Force claims_subfile_oct.sfd claims_subfile.sfd
  & Move-Item -Force claims_subfile_oct.sf claims_subfile.sf
  & $env:QUIZ juneser
  & $env:QUIZ juneser1
} *> juneser.ls
