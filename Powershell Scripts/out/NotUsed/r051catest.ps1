#-------------------------------------------------------------------------------
# File 'r051catest.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r051catest'
#-------------------------------------------------------------------------------

echo " --- r051a (COBOL) --- "
&$env:COBOL r051a 98 Y

echo " --- r051b (COBOL) --- "
&$env:COBOL r051b
echo " --- r051c (COBOL) --- "
&$env:COBOL r051c

#echo " --- r051b (COBOL) --- "
#cobrun $obj/r051b
#echo " --- r051c (COBOL) --- "
#cobrun $obj/r051c
