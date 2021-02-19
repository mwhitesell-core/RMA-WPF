#-------------------------------------------------------------------------------
# File 'test_r004.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'test_r004'
#-------------------------------------------------------------------------------

echo " --- r004a (COBOL) --- "
&$env:COBOL r004a 22 Y

echo " --- r004b (COBOL) --- "
&$env:COBOL r004b

echo " --- r004c (COBOL) --- "
&$env:COBOL r004c Y

Move-Item -Force r004 r004_22

echo " --- r004a (COBOL) --- "
&$env:COBOL r004a 31 Y

echo " --- r004b (COBOL) --- "
&$env:COBOL r004b

echo " --- r004c (COBOL) --- "
&$env:COBOL r004c Y

Move-Item -Force r004 r004_31




# CONVERSION ERROR (unexpected, #36): Unknown command.
#  " --- r004a (COBOL) --- "
&$env:COBOL r004a 32 Y

echo " --- r004b (COBOL) --- "
&$env:COBOL r004b

echo " --- r004c (COBOL) --- "
&$env:COBOL r004c Y

Move-Item -Force r004 r004_32


echo " --- r004a (COBOL) --- "
&$env:COBOL r004a 33 Y

echo " --- r004b (COBOL) --- "
&$env:COBOL r004b

echo " --- r004c (COBOL) --- "
&$env:COBOL r004c Y

Move-Item -Force r004 r004_33


echo " --- r004a (COBOL) --- "
&$env:COBOL r004a 34 Y

echo " --- r004b (COBOL) --- "
&$env:COBOL r004b

echo " --- r004c (COBOL) --- "
&$env:COBOL r004c Y

Move-Item -Force r004 r004_34


echo " --- r004a (COBOL) --- "
&$env:COBOL r004a 35 Y

echo " --- r004b (COBOL) --- "
&$env:COBOL r004b

echo " --- r004c (COBOL) --- "
&$env:COBOL r004c Y

Move-Item -Force r004 r004_35


echo " --- r004a (COBOL) --- "
&$env:COBOL r004a 36 Y

echo " --- r004b (COBOL) --- "
&$env:COBOL r004b

echo " --- r004c (COBOL) --- "
&$env:COBOL r004c Y

Move-Item -Force r004 r004_36


echo " --- r004a (COBOL) --- "
&$env:COBOL r004a 41 Y

echo " --- r004b (COBOL) --- "
&$env:COBOL r004b

echo " --- r004c (COBOL) --- "
&$env:COBOL r004c Y

Move-Item -Force r004 r004_41

echo " --- r004a (COBOL) --- "
&$env:COBOL r004a 42 Y

echo " --- r004b (COBOL) --- "
&$env:COBOL r004b

echo " --- r004c (COBOL) --- "
&$env:COBOL r004c Y

Move-Item -Force r004 r004_42


echo " --- r004a (COBOL) --- "
&$env:COBOL r004a 43 Y

echo " --- r004b (COBOL) --- "
&$env:COBOL r004b

echo " --- r004c (COBOL) --- "
&$env:COBOL r004c Y

Move-Item -Force r004 r004_43


echo " --- r004a (COBOL) --- "
&$env:COBOL r004a 44 Y

echo " --- r004b (COBOL) --- "
&$env:COBOL r004b

echo " --- r004c (COBOL) --- "
&$env:COBOL r004c Y

Move-Item -Force r004 r004_44


echo " --- r004a (COBOL) --- "
&$env:COBOL r004a 45 Y

echo " --- r004b (COBOL) --- "
&$env:COBOL r004b

echo " --- r004c (COBOL) --- "
&$env:COBOL r004c Y

Move-Item -Force r004 r004_45


echo " --- r004a (COBOL) --- "
&$env:COBOL r004a 46 Y

echo " --- r004b (COBOL) --- "
&$env:COBOL r004b

echo " --- r004c (COBOL) --- "
&$env:COBOL r004c Y

Move-Item -Force r004 r004_46

echo " --- r004a (COBOL) --- "
&$env:COBOL r004a 48 Y

echo " --- r004b (COBOL) --- "
&$env:COBOL r004b

echo " --- r004c (COBOL) --- "
&$env:COBOL r004c Y

Move-Item -Force r004 r004_48
