#-------------------------------------------------------------------------------
# File 'run_monthend_ar_34.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthend_ar_34'
#-------------------------------------------------------------------------------

echo ""
echo ""
echo ""
echo "CONTRACT 34"
echo ""
echo "RUN MONTHEND REPORTS AND ACCOUNTS RECEIVABLE"
echo ""
echo ""

Set-Location $env:application_production\34

$rcmd = $env:COBOL + "r004a 34 Y"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r004b"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r004c Y"
Invoke-Expression $rcmd

#lp r004

$rcmd = $env:COBOL + "r005 34 Y"
Invoke-Expression $rcmd

#lp r005

$rcmd = $env:COBOL + "r011 34 Y"
Invoke-Expression $rcmd

#lp r011

$rcmd = $env:COBOL + "r012 34 Y"
Invoke-Expression $rcmd

#lp r012

$rcmd = $env:COBOL + "r013 34 Y"
Invoke-Expression $rcmd

#lp r013

$rcmd = $env:COBOL + "r051a 34 Y"
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
$rcmd = $env:COBOL + "r070a 34 Y Y"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r070b"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r070c N"
Invoke-Expression $rcmd

#lp r070_34
