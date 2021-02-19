#-------------------------------------------------------------------------------
# File 'run_rats_rerun.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_rats_rerun'
#-------------------------------------------------------------------------------

# file:  $cmd/run_rats_rerun     
# 2016/Jul/12  MC - original - call run_rats_rerun.com and capture all line details in log file

echo "HIT   `"NEWLINE`"  1st time  TO CONTINUE ..."
 $garbage = Read-Host

echo "HIT   `"NEWLINE`"  2nd time  TO CONTINUE ..."
 $garbage = Read-Host

echo "HIT   `"NEWLINE`"  3rd time  TO CONTINUE ..."
 $garbage = Read-Host

Set-Location $env:application_production
Remove-Item run_rats_rerun.log *> $null

echo ""
echo ""
echo "Process now run rats for clinics 22 to 33 - the log file run_rats_rerun.log"

&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "run_rats_rerun" -InitializationScript $init -ScriptBlock {
  & 
  & echo "Run Rats for clinics 22 to 33 - starting - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > run_rats_rerun.log
  & 
  & $env:cmd\run_rats_rerun.com >> run_rats_rerun.log 2> run_rats_rerun.log
  & 
  & echo "Run Rats for clinics 22 to 33 - ending   - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> run_rats_rerun.log
  & 
}
