#-------------------------------------------------------------------------------
# File 'yearendr011_61.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yearendr011_61'
#-------------------------------------------------------------------------------

echo " --- r011a.qzc, r011b.qzc, r011c.qzc for clinic 60 --- "
&$env:QUIZ r011a
&$env:QUIZ r011b
&$env:QUIZ r011c
Get-ChildItem r011a.txt, r011b.txt, r011c.txt
Get-Content r011b.txt, r011c.txt | Add-Content r011a.txt
Move-Item -Force r011a.txt r011_60
#lp r011_60

echo " --- r011a.qzc, r011b.qzc, r011c.qzc for clinic 70 --- "
&$env:QUIZ r011a_70
&$env:QUIZ r011b_70
&$env:QUIZ r011c_70
Get-ChildItem r011a_70.txt, r011b_70.txt, r011c_70.txt
Get-Content r011b_70.txt, r011c_70.txt | Add-Content r011a_70.txt
Move-Item -Force r011a_70.txt r011_70
#lp r011_70
