#-------------------------------------------------------------------------------
# File 'batch_update_f050_f051_f060.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'batch_update_f050_f051_f060'
#-------------------------------------------------------------------------------

#    SUBMIT A BATCH JOB AT NIGHT TO UPDATE DOCTOR REVENUE, DOCTOR
#    CASH  FILE FOR CLINIC NBR OR DEPT NO CHANGE.
# at -m 1130pm today - COMMENTED OUT BY BRAD - 'at' command not y2k
#                      compilant until we upgrade DGUX unix
&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_update_f050_f051_f060" -InitializationScript $init -ScriptBlock {
  & $env:cmd\update_f050_f051_f060 $1 $2 $3 *> update_f050.log
}

# replaced above logic with the creation of a permanent 11:30 cron'd job
# that looks for the existance of a 'flag' file and will run the job

echo "$1" >> $pb_data\batch_update_f050_f051_f060.flg
echo "$2" >> $pb_data\batch_update_f050_f051_f060.flg
echo "$3" >> $pb_data\batch_update_f050_f051_f060.flg
