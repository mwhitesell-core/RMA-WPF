#-------------------------------------------------------------------------------
# File 'run_rats.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'run_rats'
#-------------------------------------------------------------------------------

# file:  $cmd/run_rats     
# 2013/Sep/09  MC - original - call run_rats.com and capture all line details in log file
# 2013/Nov/07  MC - Yasemin requested to add Newline 3 times
# 2015/Oct/01  MC1 - Yasemen requested to run in batch for $cmd/run_rats.com

echo "HIT   `"NEWLINE`"  1st time  TO CONTINUE ..."
 $garbage = Read-Host

echo "HIT   `"NEWLINE`"  2nd time  TO CONTINUE ..."
 $garbage = Read-Host

echo "HIT   `"NEWLINE`"  3rd time  TO CONTINUE ..."
 $garbage = Read-Host

Set-Location $env:application_production
Remove-Item run_rats.log *> $null

echo ""
echo ""
echo "Process now run rats for all clinics - the log file run_rats.log"

# MC1

$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "run_rats" -InitializationScript $init -ScriptBlock {
   
   param(
	[string]$vers
	)
   $env:srvname = $env:srvname + "." + [system.environment]::UserDomainName + ".LOCAL"

   &"\\$env:srvname\rma\scripts\rmabill" $vers

   cd $env:pb_prod

   echo "Run Rats for all clinics - starting - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > run_rats.log
   
   &$env:cmd\run_rats.com 2>&1 >> run_rats.log
   
   echo "Run Rats for all clinics - ending   - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> run_rats.log
  
} -ArgumentList $env:RMABILL_VERS
