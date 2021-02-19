#-------------------------------------------------------------------------------
# File 'run_monthend_cycle_nodirect.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthend_cycle_nodirect'
#-------------------------------------------------------------------------------

clear
echo "RUN_MONTHEND_CYCLE_NODIRECT"
echo ""
echo "O H I P  T A P E  S U B M I T T A L   $Env:root\   D O C T O R   R E V .   U P D A T E"
echo ""
echo ""

&$env:cmd\run_ohip_submit_reports

echo ""
echo ""

Set-Location $env:application_production
Remove-Item ru701
Move-Item -Force ru701_cycle ru701
#touch ru701_cycle

echo "****************** IMPORTANT *************************"
echo ""
echo "LOAD BACKUP_OHIP_TAPE ONTO THE TAPE DRIVE, BALANCE ALL REPORTS THEN"
echo "HIT `"NEWLINE`" TO RUN OHIP TAPE PROGRAMS"
echo "(U022, U020, BACKUP_OHIP_TAPE, U010 & U035A\B\C)"
$garbage = Read-Host

Remove-Item ohiptape.ls *> $null
&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "run_monthend_cycle_nodirect" -InitializationScript $init -ScriptBlock {
  & $env:cmd\run_ohip_mth_tape_nodirect ${1} *> ohiptape.ls
}
