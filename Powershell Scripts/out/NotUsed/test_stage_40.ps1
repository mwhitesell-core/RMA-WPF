#-------------------------------------------------------------------------------
# File 'test_stage_40.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'test_stage_40'
#-------------------------------------------------------------------------------

echo " --- r004a (COBOL) --- "
&$env:COBOL r004a 22 Y

echo " --- r004b (COBOL) --- "
&$env:COBOL r004b

echo " --- r004c (COBOL) --- "
&$env:COBOL r004c Y

#lp r004

echo " --- r005 (COBOL) --- "
&$env:COBOL r005 22 Y

#lp r005

echo " --- r011 (COBOL) --- "
&$env:COBOL r011 22 Y

#lp r011

echo " --- r011mohr (QUIZ) --- "
&$env:QUIZ r011mohr 22@

#lp r011mohr.txt

echo " --- r012 (COBOL) --- "
&$env:COBOL r012 22 Y

#lp r012

echo " --- r013 (COBOL) --- "
&$env:COBOL r013 22 Y

#lp r013

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

#lp r051cb

echo " --- r070a (COBOL) ---  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
&$env:COBOL r070a 22 Y Y

echo " --- r070b (COBOL) ---  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
&$env:COBOL r070b

echo " --- r070c (COBOL) ---  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
&$env:COBOL r070c N
