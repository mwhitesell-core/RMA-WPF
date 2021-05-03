#-------------------------------------------------------------------------------
# File 'run_monthend_ar_26.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthend_ar_26'
#-------------------------------------------------------------------------------

echo ""
echo ""
echo ""
echo "CONTRACT 26"
echo ""
echo "RUN MONTHEND REPORTS AND ACCOUNTS RECEIVABLE"
echo ""
echo ""

Set-Location $env:application_production\26

$rcmd = $env:COBOL + "r004a 26 Y"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r004b"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r004c Y"
Invoke-Expression $rcmd

#lp r004

$rcmd = $env:COBOL + "r005 26 Y"
Invoke-Expression $rcmd

#lp r005

$rcmd = $env:COBOL + "r011 26 Y"
Invoke-Expression $rcmd

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content r011 | Out-Printer -Name $env:networkprinter
}

$rcmd = $env:COBOL + "r012 26 Y"
Invoke-Expression $rcmd

#lp r012

$rcmd = $env:COBOL + "r013 26 Y"
Invoke-Expression $rcmd

#lp r013

$rcmd = $env:COBOL + "r051a 26 Y"
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
$rcmd = $env:COBOL + "r070a 26 Y Y"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r070b"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r070c N"
Invoke-Expression $rcmd

#lp r070_26
