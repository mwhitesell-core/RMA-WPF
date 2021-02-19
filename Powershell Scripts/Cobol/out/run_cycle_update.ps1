#-------------------------------------------------------------------------------
# File 'run_cycle_update.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'run_cycle_update'
#-------------------------------------------------------------------------------

clear
echo "RUN_CYCLE_UPDATE"
echo ""
echo "Creation Automatic Adjustments $root\ OHIP Tape Submittal $root\ Doctor Rev. Update"
echo ""
echo "HitENTER to continue:"
$garbage = Read-Host

echo ""
$cmd\run_ohip_submit_reports ${1}
echo ""
echo ""

Set-Location $application_production
Remove-Item ru701  > $null
Move-Item ru701_cycle ru701  > $null
utouch ru701_cycle

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

Remove-Item ohiptape.ls  > $null
$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "run_cycle_update" -InitializationScript $init -ScriptBlock {
  & $cmd\run_ohip_submit_tape ${1}  > ohiptape.ls  2>&1
}
