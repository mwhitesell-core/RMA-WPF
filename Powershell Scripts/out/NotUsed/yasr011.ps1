#-------------------------------------------------------------------------------
# File 'yasr011.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yasr011'
#-------------------------------------------------------------------------------

echo " --- r011.gnt for clinic 80 --- "
&$env:COBOL r011 80 Y
Get-ChildItem r011
Move-Item -Force r011 r011_80


echo " --- r011.gnt for clinic 81 --- "
&$env:COBOL r011 81 Y
Get-ChildItem r011
Move-Item -Force r011 r011_81


echo " --- r011.gnt for clinic 82 --- "
&$env:COBOL r011 82 Y
Get-ChildItem r011
Move-Item -Force r011 r011_82


echo " --- r011.gnt for clinic 83 --- "
&$env:COBOL r011 83 Y
Get-ChildItem r011
Move-Item -Force r011 r011_83


echo " --- r011.gnt for clinic 22 --- "
&$env:COBOL r011 22 Y
Get-ChildItem r011
Move-Item -Force r011 r011_22

echo " --- r011a.qzc, r011b.qzc, r011c.qzc for clinic 60 --- "
&$env:QUIZ r011a
&$env:QUIZ r011b
&$env:QUIZ r011c
Get-ChildItem r011a.txt, r011b.txt, r011c.txt
Get-Content r011b.txt, r011c.txt | Add-Content r011a.txt
Move-Item -Force r011a.txt r011_60
