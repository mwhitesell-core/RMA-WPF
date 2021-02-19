#-------------------------------------------------------------------------------
# File 'run_monthend_ar_46.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthend_ar_46'
#-------------------------------------------------------------------------------

echo ""
echo ""
echo ""
echo "CONTRACT 46"
echo ""
echo "RUN MONTHEND REPORTS AND ACCOUNTS RECEIVABLE"
echo ""
echo ""

Set-Location $env:application_production\46

$rcmd = $env:COBOL + "r004a 46 Y"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r004b"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r004c Y"
Invoke-Expression $rcmd

#lp r004

$rcmd = $env:COBOL + "r005 46 Y"
Invoke-Expression $rcmd

#lp r005

$rcmd = $env:COBOL + "r011 46 Y"
Invoke-Expression $rcmd

#lp r011

$rcmd = $env:COBOL + "r012 46 Y"
Invoke-Expression $rcmd

#lp r012

$rcmd = $env:COBOL + "r013 46 Y"
Invoke-Expression $rcmd

#lp r013

$rcmd = $env:COBOL + "r051a 46 Y"
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
$rcmd = $env:COBOL + "r070a 46 Y Y"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r070b"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r070c N"
Invoke-Expression $rcmd

#lp r070_46
