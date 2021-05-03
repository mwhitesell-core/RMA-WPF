#-------------------------------------------------------------------------------
# File 'run_monthend_ar_84.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthend_ar_84'
#-------------------------------------------------------------------------------

echo ""
echo ""
echo ""
echo "CONTRACT 84"
echo ""
echo "RUN MONTHEND REPORTS AND ACCOUNTS RECEIVABLE"
echo ""
echo ""

Set-Location $env:application_production\84

$rcmd = $env:COBOL + "r004a 84 Y"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r004b"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r004c Y"
Invoke-Expression $rcmd

#lp r004

$rcmd = $env:COBOL + "r005 84 Y"
Invoke-Expression $rcmd

#lp r005

$rcmd = $env:COBOL + "r011 84 Y"
Invoke-Expression $rcmd

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content r011 | Out-Printer -Name $env:networkprinter
}

$rcmd = $env:COBOL + "r012 84 Y"
Invoke-Expression $rcmd

#lp r012

$rcmd = $env:COBOL + "r013 84 Y"
Invoke-Expression $rcmd

#lp r013

$rcmd = $env:COBOL + "r051a 84 Y"
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
$rcmd = $env:COBOL + "r070a 84 Y Y"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r070b"
Invoke-Expression $rcmd

$rcmd = $env:COBOL + "r070c N"
Invoke-Expression $rcmd

#lp r070_84
