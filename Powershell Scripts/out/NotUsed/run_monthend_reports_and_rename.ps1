#-------------------------------------------------------------------------------
# File 'run_monthend_reports_and_rename.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthend_reports_and_rename'
#-------------------------------------------------------------------------------

echo " --- r011 (COBOL) --- "
&$env:COBOL r011 83 Y

Move-Item -Force r011 r011_83_after

echo " --- r011mohr (QUIZ) --- "
&$env:QUIZ r011mohr 83@

Move-Item -Force r011mohr.txt r011mohr_83_after

echo " --- r012 (COBOL) --- "
&$env:COBOL r012 83 Y

Move-Item -Force r012 r012_83_after

echo " --- r013 (COBOL) --- "
&$env:COBOL r013 83 Y

Move-Item -Force r013 r013_83_after

echo " --- r051a (COBOL) --- "
&$env:COBOL r051a 83 Y

echo " --- r051b (COBOL) --- "
&$env:COBOL r051b
echo " --- r051c (COBOL) --- "
&$env:COBOL r051c

Move-Item -Force r051ca r051ca_83_after

echo " --- r051b (COBOL) --- "
&$env:COBOL r051b
echo " --- r051c (COBOL) --- "
&$env:COBOL r051c

Move-Item -Force r051cb r051cb_83_after
