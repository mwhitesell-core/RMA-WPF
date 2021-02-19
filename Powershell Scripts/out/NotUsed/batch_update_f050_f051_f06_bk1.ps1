#-------------------------------------------------------------------------------
# File 'batch_update_f050_f051_f06_bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_update_f050_f051_f06_bk1'
#-------------------------------------------------------------------------------

#    SUBMIT A BATCH JOB AT NIGHT TO UPDATE DOCTOR REVENUE, DOCTOR
#    CASH  FILE FOR CLINIC NBR OR DEPT NO CHANGE.
#    at -m 1130pm today
&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_update_f050_f051_f06_bk1" -InitializationScript $init -ScriptBlock {
  & $env:cmd\update_f050_f051_f060 $1 $2 *> update_f050.log
}
