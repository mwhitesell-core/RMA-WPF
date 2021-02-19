#-------------------------------------------------------------------------------
# File 'run_rats.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_rats.bk1'
#-------------------------------------------------------------------------------

# file:  $cmd/run_rats     
# 2013/Sep/09  MC - original - call run_rats.com and capture all line details in log file
# 2013/Nov/07  MC - Yasemin requested to add Newline 3 times

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
echo "Process now run rats for all clinics - the log file run_rats.log  will be paged to your screen when its done"

echo "Run Rats for all clinics - starting - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > run_rats.log

&$env:cmd\run_rats.com >> run_rats.log 2> run_rats.log

echo "Run Rats for all clinics - ending   - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> run_rats.log


Get-Content run_rats.log
