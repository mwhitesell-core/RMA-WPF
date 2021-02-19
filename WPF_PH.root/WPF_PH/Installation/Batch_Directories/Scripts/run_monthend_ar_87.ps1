#-------------------------------------------------------------------------------
# File 'run_monthend_ar_87.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthend_ar_87'
#-------------------------------------------------------------------------------

echo ""
echo ""
echo ""
echo "CONTRACT 87"
echo ""
echo "RUN MONTHEND REPORTS AND ACCOUNTS RECEIVABLE"
echo ""
echo ""

Set-Location $env:application_production\87

$rcmd = $env:COBOL + "r004a 87 Y"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r004b"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r004c Y"
Invoke-Expression $rcmd

#lp r004

$rcmd = $env:COBOL + "r005 87 Y"
Invoke-Expression $rcmd

#lp r005

$rcmd = $env:COBOL + "r011 87 Y"
Invoke-Expression $rcmd

Get-Content r011 | Out-Printer
#lp r011

$rcmd = $env:COBOL + "r012 87 Y"
Invoke-Expression $rcmd

#lp r012

$rcmd = $env:COBOL + "r013 87 Y"
Invoke-Expression $rcmd

#lp r013

$rcmd = $env:COBOL + "r051a 87 Y"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r051b"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r051c"
Invoke-Expression $rcmd

#lp r051ca

$rcmd = $env:COBOL + "r051b"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r051c"
Invoke-Expression $rcmd

#lp r051cb
$rcmd = $env:COBOL + "r070a 87 Y Y"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r070b"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r070c N"
Invoke-Expression $rcmd

#lp r070_87
