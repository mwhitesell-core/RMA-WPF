#-------------------------------------------------------------------------------
# File 'print_man_cheque_audit.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'print_man_cheque_audit'
#-------------------------------------------------------------------------------

echo "PRINT_MAN_CHEQUE_AUDIT"
echo ""
echo ""
echo "HIT  `"NEWLINE`"  TO SORT D101 WORK FILE"
$garbage = Read-Host

Set-Location $Env:root\production
Remove-Item f101wf
# CONVERSION ERROR (unexpected, #9): :/production/f101wf//v  not identifiers or numbers.
# mv :production f101wf /v 
Set-Location $application_upl
&$env:COBOL r101b

echo ""
echo "HIT  `"NEWLINE`"  TO EXECUTE R101C"
$garbage = Read-Host

&$env:COBOL r101c

echo ""
echo "HIT  `"NEWLINE`"  TO PRINT REPORT"
$garbage = Read-Host
echo ""

Get-Content rd101 | Out-Printer
