#-------------------------------------------------------------------------------
# File 'test_ph_r004.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'test_ph_r004'
#-------------------------------------------------------------------------------

echo " --- r004a\b\c\d (PH) --- "

Set-Location $env:application_production

&$env:QUIZ r004a 22000000 22ZZZ999 > r004.log
&$env:QUIZ r004b >> r004.log
&$env:QUIZ r004c >> r004.log
&$env:QUIZ r004d >> r004.log

Move-Item -Force r004c.txt r004c_22

Set-Location $env:application_production\31
&$env:QUIZ r004a 31000000 31ZZZ999 > r004.log
&$env:QUIZ r004b >> r004.log
&$env:QUIZ r004c >> r004.log
&$env:QUIZ r004d >> r004.log

Move-Item -Force r004c.txt r004c_31

Set-Location $env:application_production\32
&$env:QUIZ r004a 32000000 32ZZZ999 > r004.log
&$env:QUIZ r004b >> r004.log
&$env:QUIZ r004c >> r004.log
&$env:QUIZ r004d >> r004.log

Move-Item -Force r004c.txt r004c_32

Set-Location $env:application_production\33
&$env:QUIZ r004a 33000000 33ZZZ999 > r004.log
&$env:QUIZ r004b >> r004.log
&$env:QUIZ r004c >> r004.log
&$env:QUIZ r004d >> r004.log

Move-Item -Force r004c.txt r004c_33

Set-Location $env:application_production\34
&$env:QUIZ r004a 34000000 34ZZZ999 > r004.log
&$env:QUIZ r004b >> r004.log
&$env:QUIZ r004c >> r004.log
&$env:QUIZ r004d >> r004.log

Move-Item -Force r004c.txt r004c_34

Set-Location $env:application_production\35
&$env:QUIZ r004a 35000000 35ZZZ999 > r004.log
&$env:QUIZ r004b >> r004.log
&$env:QUIZ r004c >> r004.log
&$env:QUIZ r004d >> r004.log

Move-Item -Force r004c.txt r004c_35

Set-Location $env:application_production\36
&$env:QUIZ r004a 36000000 36ZZZ999 > r004.log
&$env:QUIZ r004b >> r004.log
&$env:QUIZ r004c >> r004.log
&$env:QUIZ r004d >> r004.log

Move-Item -Force r004c.txt r004c_36

Set-Location $env:application_production\41
&$env:QUIZ r004a 41000000 41ZZZ999 > r004.log
&$env:QUIZ r004b >> r004.log
&$env:QUIZ r004c >> r004.log
&$env:QUIZ r004d >> r004.log

Move-Item -Force r004c.txt r004c_41

Set-Location $env:application_production\42
&$env:QUIZ r004a 42000000 42ZZZ999 > r004.log
&$env:QUIZ r004b >> r004.log
&$env:QUIZ r004c >> r004.log
&$env:QUIZ r004d >> r004.log

Move-Item -Force r004c.txt r004c_42

Set-Location $env:application_production\43
&$env:QUIZ r004a 43000000 43ZZZ999 > r004.log
&$env:QUIZ r004b >> r004.log
&$env:QUIZ r004c >> r004.log
&$env:QUIZ r004d >> r004.log

Move-Item -Force r004c.txt r004c_43

Set-Location $env:application_production\44
&$env:QUIZ r004a 44000000 44ZZZ999 > r004.log
&$env:QUIZ r004b >> r004.log
&$env:QUIZ r004c >> r004.log
&$env:QUIZ r004d >> r004.log

Move-Item -Force r004c.txt r004c_44

Set-Location $env:application_production\45
&$env:QUIZ r004a 45000000 45ZZZ999 > r004.log
&$env:QUIZ r004b >> r004.log
&$env:QUIZ r004c >> r004.log
&$env:QUIZ r004d >> r004.log

Move-Item -Force r004c.txt r004c_45

Set-Location $env:application_production\46
&$env:QUIZ r004a 46000000 46ZZZ999 > r004.log
&$env:QUIZ r004b >> r004.log
&$env:QUIZ r004c >> r004.log
&$env:QUIZ r004d >> r004.log

Move-Item -Force r004c.txt r004c_46

Set-Location $env:application_production\48
&$env:QUIZ r004a 48000000 48ZZZ999 > r004.log
&$env:QUIZ r004b >> r004.log
&$env:QUIZ r004c >> r004.log
&$env:QUIZ r004d >> r004.log

Move-Item -Force r004c.txt r004c_48
