#-------------------------------------------------------------------------------
# File 'temp.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'temp'
#-------------------------------------------------------------------------------

echo "****************** IMPORTANT *************************"
echo ""
echo "LOAD BACKUP_OHIP_TAPE ONTO THE TAPE DRIVE, BALANCE ALL REPORTS THEN"
echo "HIT `"NEWLINE`" TO RUN OHIP TAPE PROGRAMS"
echo "(U022, U020, BACKUP_OHIP_TAPE, U010 & U035A\B\C)"
$garbage = Read-Host

Remove-Item ohiptape.ls *> $null
&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "temp" -InitializationScript $init -ScriptBlock {
  & $env:cmd\run_ohip_submit_tape ${1} *> ohiptape.ls
}
