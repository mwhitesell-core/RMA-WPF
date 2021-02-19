#-------------------------------------------------------------------------------
# File 'yas83.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yas83'
#-------------------------------------------------------------------------------

echo ""
echo ""
echo "CONTRACT 83"
echo ""
echo "RUN MONTHEND REPORTS FOR CLINIC 8300"
echo ""
echo "HIT `"NEWLINE`" TO CONTINUE ..."
$garbage = Read-Host
echo ""

Set-Location $env:application_production


&$env:COBOL r051a 83 Y

&$env:COBOL r051b

&$env:COBOL r051c

#lp r051ca

&$env:COBOL r051b

&$env:COBOL r051c

Get-Content r051cb | Out-Printer
