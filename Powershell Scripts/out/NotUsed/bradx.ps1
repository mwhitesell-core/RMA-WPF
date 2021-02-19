#-------------------------------------------------------------------------------
# File 'bradx.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'bradx'
#-------------------------------------------------------------------------------


echo " --- r051a (COBOL) --- "
&$env:COBOL r051a 22 Y

echo " --- r051b (COBOL) --- "
&$env:COBOL r051b
echo " --- r051c (COBOL) --- "
&$env:COBOL r051c

#lp r051ca

echo " --- r051b (COBOL) --- "
&$env:COBOL r051b
echo " --- r051c (COBOL) --- "
&$env:COBOL r051c

Get-Content r051cb | Out-Printer
