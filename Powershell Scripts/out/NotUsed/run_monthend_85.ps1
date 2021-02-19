#-------------------------------------------------------------------------------
# File 'run_monthend_85.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthend_85'
#-------------------------------------------------------------------------------

echo ""
echo "CONTRACT 85"
echo ""
echo "RUN Revenue Reports r005\r011\r012\r013\r051ca\r051cb"
echo ""
echo "HIT `"NEWLINE`" TO CONTINUE ..."
$garbage = Read-Host
echo ""

Set-Location $env:application_production\85


&$env:COBOL r005 85 Y

#lp r005

&$env:COBOL r011 85 Y

#lp r011

&$env:COBOL r012 85 Y

#lp r012

&$env:COBOL r013 85 Y

#lp r013

&$env:COBOL r051a 85 Y

&$env:COBOL r051b
&$env:COBOL r051c

#lp r051ca

&$env:COBOL r051b
&$env:COBOL r051c

#lp r051cb
