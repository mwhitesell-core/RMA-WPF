#-------------------------------------------------------------------------------
# File 'yasr005.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yasr005'
#-------------------------------------------------------------------------------

echo " --- r005 (COBOL) --- "
&$env:COBOL r005 22 Y
Move-Item -Force r005 r005_22

echo " --- r005 (COBOL) --- "
&$env:COBOL r005 80 Y
Move-Item -Force r005 r005_80

echo " --- r005 (COBOL) --- "
&$env:COBOL r005 81 Y
Move-Item -Force r005 r005_81

echo " --- r005 (COBOL) --- "
&$env:COBOL r005 82 Y
Move-Item -Force r005 r005_82

echo " --- r005 (COBOL) --- "
&$env:COBOL r005 83 Y
Move-Item -Force r005 r005_83
