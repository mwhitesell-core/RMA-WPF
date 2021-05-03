#-------------------------------------------------------------------------------
# File 'run_cycle_update.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_cycle_update'
#-------------------------------------------------------------------------------
param(
    [string]$1
     )
clear
echo "RUN_CYCLE_UPDATE"
echo ""
echo "Creation Automatic Adjustments $Env:root\ OHIP Tape Submittal $Env:root\ Doctor Rev. Update"
echo ""
echo "HitENTER to continue:"
$garbage = Read-Host

echo ""
&$env:cmd\run_ohip_submit_reports ${1} | Tee-Object ohip_submit_reports.log
echo ""
echo ""

Set-Location $env:application_production
Remove-Item ru701 *> $null
Move-Item -Force ru701_cycle ru701 *> $null
New-Item ru701_cycle -ItemType "file"

echo "****************** IMPORTANT *************************"
echo ""
echo "You MUST BALANCE all reports AND then hit new line to run the OHIP tape programs "
echo ""
echo "Hit `"NEWLINE`" to run ohip tape programs"
$garbage = Read-Host
echo "HIT   `"NEWLINE`"  2nd time  TO CONTINUE"
 $garbage = Read-Host
echo "HIT   `"NEWLINE`"  3rd time  TO CONTINUE"
 $garbage = Read-Host

Remove-Item ohiptape.ls *> $null
<#$path = Convert-Path .

$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "run_cycle_update" -InitializationScript $init -ScriptBlock {
  param(
	  [string]$path,
	  [string]$1
  )
  $env:srvname = $env:srvname + "." + [system.environment]::UserDomainName + ".LOCAL"
  &"\\$env:srvname\rma\scripts\rmabill" 101c
  cd $path#>
  & $env:cmd\run_ohip_submit_tape ${1} *> ohiptape.ls
#} -ArgumentList $path, $1
