#-------------------------------------------------------------------------------
# File 'run_monthend_83.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthend_83'
#-------------------------------------------------------------------------------

echo ""
echo ""
echo "CONTRACT 83"
echo ""
echo "RUN MONTHEND REPORTS FOR CLINIC 8300"
echo ""
echo ""

Set-Location $env:application_production\83

&$env:COBOL r004a 83 Y

&$env:COBOL r004b

&$env:COBOL r004c Y

#lp r004

&$env:COBOL r005 83 Y

#lp r005

&$env:COBOL r011 83 Y

#lp r011

&$env:COBOL r012 83 Y

#lp r012

&$env:COBOL r051a 83 Y

&$env:COBOL r051b

&$env:COBOL r051c

#lp r051ca

&$env:COBOL r051b

&$env:COBOL r051c

#lp r051cb
