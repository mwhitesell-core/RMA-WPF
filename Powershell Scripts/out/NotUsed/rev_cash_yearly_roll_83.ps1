#-------------------------------------------------------------------------------
# File 'rev_cash_yearly_roll_83.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rev_cash_yearly_roll_83'
#-------------------------------------------------------------------------------

echo " --- r011.gnt for clinic 80 --- "
Remove-Item r011_22_before
Remove-Item r011_31_before
Remove-Item r011_32_before
Remove-Item r011_33_before
Remove-Item r011_34_before
Remove-Item r011_35_before
Remove-Item r011_36_before
Remove-Item r011_41_before
Remove-Item r011_42_before
Remove-Item r011_43_before
Remove-Item r011_44_before
Remove-Item r011_45_before
Remove-Item r011_46_before
Remove-Item r011_48_before
Remove-Item r011_48_before
Remove-Item r011_60_before
Remove-Item r011_81_before
Remove-Item r011_80_before
Remove-Item r011_82_before
Remove-Item r011_83_before
Remove-Item r011_84_before
Remove-Item r011_85_before
Remove-Item r011_86_before
Remove-Item r011_91_before
Remove-Item r011_92_before
Remove-Item r011_93_before
Remove-Item r011_94_before
Remove-Item r011_95_before
Remove-Item r011_96_before

echo " --- r011.gnt for clinic 31 --- "
&$env:COBOL r011 31 Y
Get-ChildItem r011
Move-Item -Force r011 r011_31_before
#lp r011_31_before

echo " --- r011.gnt for clinic 32 --- "
&$env:COBOL r011 32 Y
Get-ChildItem r011
Move-Item -Force r011 r011_32_before
#lp r011_32_before

echo " --- r011.gnt for clinic 33 --- "
&$env:COBOL r011 33 Y
Get-ChildItem r011
Move-Item -Force r011 r011_33_before
#lp r011_33_before

echo " --- r011.gnt for clinic 34 --- "
&$env:COBOL r011 34 Y
Get-ChildItem r011
Move-Item -Force r011 r011_34_before
#lp r011_34_before

echo " --- r011.gnt for clinic 35 --- "
&$env:COBOL r011 35 Y
Get-ChildItem r011
Move-Item -Force r011 r011_35_before
#lp r011_35_before

echo " --- r011.gnt for clinic 36 --- "
&$env:COBOL r011 36 Y
Get-ChildItem r011
Move-Item -Force r011 r011_36_before
#lp r011_36_before

echo " --- r011.gnt for clinic 41 --- "
&$env:COBOL r011 41 Y
Get-ChildItem r011
Move-Item -Force r011 r011_41_before
#lp r011_41_before

echo " --- r011.gnt for clinic 42 --- "
&$env:COBOL r011 42 Y
Get-ChildItem r011
Move-Item -Force r011 r011_42_before
#lp r011_42_before

echo " --- r011.gnt for clinic 43 --- "
&$env:COBOL r011 43 Y
Get-ChildItem r011
Move-Item -Force r011 r011_43_before
#lp r011_43_before

echo " --- r011.gnt for clinic  44 --- "
&$env:COBOL r011 44 Y
Get-ChildItem r011
Move-Item -Force r011 r011_44_before
#lp r011_44_before

echo " --- r011.gnt for clinic 45 --- "
&$env:COBOL r011 45 Y
Get-ChildItem r011
Move-Item -Force r011 r011_45_before
#lp r011_45_before

echo " --- r011.gnt for clinic 46 --- "
&$env:COBOL r011 46 Y
Get-ChildItem r011
Move-Item -Force r011 r011_46_before
#lp r011_46_before

echo " --- r011.gnt for clinic 48 --- "
&$env:COBOL r011 48 Y
Get-ChildItem r011
Move-Item -Force r011 r011_48_before
#lp r011_48_before

echo " --- r011.gnt for clinic 80 --- "
&$env:COBOL r011 80 Y
Get-ChildItem r011
Move-Item -Force r011 r011_80_before
#lp r011_80_before

echo " --- r011.gnt for clinic 81 --- "
&$env:COBOL r011 81 Y
Get-ChildItem r011
Move-Item -Force r011 r011_81_before
#lp r011_81_before

echo " --- r011.gnt for clinic 82 --- "
&$env:COBOL r011 82 Y
Get-ChildItem r011
Move-Item -Force r011 r011_82_before
#lp r011_82_before

echo " --- r011.gnt for clinic 83 --- "
&$env:COBOL r011 83 Y
Get-ChildItem r011
Move-Item -Force r011 r011_83_before
Get-Content r011_83_before | Out-Printer

echo " --- r011.gnt for clinic 84 --- "
&$env:COBOL r011 84 Y
Get-ChildItem r011
Move-Item -Force r011 r011_84_before
#lp r011_84_before

echo " --- r011.gnt for clinic 85 --- "
&$env:COBOL r011 85 Y
Get-ChildItem r011
Move-Item -Force r011 r011_85_before
#lp r011_85_before

echo " --- r011.gnt for clinic 86 --- "
&$env:COBOL r011 86 Y
Get-ChildItem r011
Move-Item -Force r011 r011_86_before
#lp r011_86_before

echo " --- r011.gnt for clinic 91 --- "
&$env:COBOL r011 91 Y
Get-ChildItem r011
Move-Item -Force r011 r011_91_before
#lp r011_91_before

echo " --- r011.gnt for clinic 92 --- "
&$env:COBOL r011 92 Y
Get-ChildItem r011
Move-Item -Force r011 r011_92_before
#lp r011_92_before

echo " --- r011.gnt for clinic 93 --- "
&$env:COBOL r011 93 Y
Get-ChildItem r011
Move-Item -Force r011 r011_93_before
#lp r011_93_before

echo " --- r011.gnt for clinic 94 --- "
&$env:COBOL r011 94 Y
Get-ChildItem r011
Move-Item -Force r011 r011_94_before
#lp r011_94_before

echo " --- r011.gnt for clinic 95 --- "
&$env:COBOL r011 95 Y
Get-ChildItem r011
Move-Item -Force r011 r011_95_before
#lp r011_95_before

echo " --- r011.gnt for clinic 96 --- "
&$env:COBOL r011 96 Y
Get-ChildItem r011
Move-Item -Force r011 r011_96_before
#lp r011_96_before

echo " --- r011.gnt for clinic 22 --- "
&$env:COBOL r011 22 Y
Get-ChildItem r011
Move-Item -Force r011 r011_22_before
#lp r011_22_before

echo " --- r011a.qzc, r011b.qzc, r011c.qzc for clinic 60 --- "
&$env:QUIZ r011a
&$env:QUIZ r011b
&$env:QUIZ r011c

Get-ChildItem r011a.txt, r011b.txt, r011c.txt
Get-Content r011b.txt, r011c.txt | Add-Content r011a.txt
Move-Item -Force r011a.txt r011_60_before
#lp r011_60_before

echo " ---- run purge_f050f051_83 ---- "
&$env:QTP purge_f050f051_83

Remove-Item r011_22_after
Remove-Item r011_31_after
Remove-Item r011_32_after
Remove-Item r011_33_after
Remove-Item r011_34_after
Remove-Item r011_35_after
Remove-Item r011_36_after
Remove-Item r011_41_after
Remove-Item r011_42_after
Remove-Item r011_43_after
Remove-Item r011_44_after
Remove-Item r011_45_after
Remove-Item r011_46_after
Remove-Item r011_48_after
Remove-Item r011_60_after
Remove-Item r011_80_after
Remove-Item r011_81_after
Remove-Item r011_82_after
Remove-Item r011_83_after
Remove-Item r011_84_after
Remove-Item r011_85_after
Remove-Item r011_86_after
Remove-Item r011_91_after
Remove-Item r011_92_after
Remove-Item r011_93_after
Remove-Item r011_94_after
Remove-Item r011_95_after
Remove-Item r011_96, after


echo " --- r011.gnt for clinic 31 --- "
&$env:COBOL r011 31 Y
Get-ChildItem r011
Move-Item -Force r011 r011_31_after
#lp r011_31_after

echo " --- r011.gnt for clinic 32 --- "
&$env:COBOL r011 32 Y
Get-ChildItem r011
Move-Item -Force r011 r011_32_after
#lp r011_32_after

echo " --- r011.gnt for clinic 33 --- "
&$env:COBOL r011 33 Y
Get-ChildItem r011
Move-Item -Force r011 r011_33_after
#lp r011_33_after

echo " --- r011.gnt for clinic 34 --- "
&$env:COBOL r011 34 Y
Get-ChildItem r011
Move-Item -Force r011 r011_34_after
#lp r011_34_after

echo " --- r011.gnt for clinic 35 --- "
&$env:COBOL r011 35 Y
Get-ChildItem r011
Move-Item -Force r011 r011_35_after
#lp r011_35_after

echo " --- r011.gnt for clinic 36 --- "
&$env:COBOL r011 36 Y
Get-ChildItem r011
Move-Item -Force r011 r011_36_after
#lp r011_36_after

echo " --- r011.gnt for clinic 41 --- "
&$env:COBOL r011 41 Y
Get-ChildItem r011
Move-Item -Force r011 r011_41_after
#lp r011_41_after

echo " --- r011.gnt for clinic 42 --- "
&$env:COBOL r011 42 Y
Get-ChildItem r011
Move-Item -Force r011 r011_42_after
#lp r011_42_after

echo " --- r011.gnt for clinic 43 --- "
&$env:COBOL r011 43 Y
Get-ChildItem r011
Move-Item -Force r011 r011_43_after
#lp r011_43_after

echo " --- r011.gnt for clinic  44 --- "
&$env:COBOL r011 44 Y
Get-ChildItem r011
Move-Item -Force r011 r011_44_after
#lp r011_44_after

echo " --- r011.gnt for clinic 45 --- "
&$env:COBOL r011 45 Y
Get-ChildItem r011
Move-Item -Force r011 r011_45_after
#lp r011_45_after

echo " --- r011.gnt for clinic 46 --- "
&$env:COBOL r011 46 Y
Get-ChildItem r011
Move-Item -Force r011 r011_46_after
#lp r011_46_after

echo " --- r011.gnt for clinic 48 --- "
&$env:COBOL r011 48 Y
Get-ChildItem r011
Move-Item -Force r011 r011_48_after

echo " --- r011.gnt for clinic 80 --- "
&$env:COBOL r011 80 Y
Get-ChildItem r011
Move-Item -Force r011 r011_80_after
#lp r011_80_after

echo " --- r011.gnt for clinic 81 --- "
&$env:COBOL r011 81 Y
Get-ChildItem r011
Move-Item -Force r011 r011_81_after
#lp r011_81_after


echo " --- r011.gnt for clinic 82 --- "
&$env:COBOL r011 82 Y
Get-ChildItem r011
Move-Item -Force r011 r011_82_after
#lp r011_82_after


echo " --- r011.gnt for clinic 83 --- "
&$env:COBOL r011 83 Y
Get-ChildItem r011
Move-Item -Force r011 r011_83_after
Get-Content r011_83_after | Out-Printer

echo " --- r011.gnt for clinic 84 --- "
&$env:COBOL r011 84 Y
Get-ChildItem r011
Move-Item -Force r011 r011_84_after
#lp r011_84_after

echo " --- r011.gnt for clinic 85 --- "
&$env:COBOL r011 85 Y
Get-ChildItem r011
Move-Item -Force r011 r011_85_after
#lp r011_85_after 

echo " --- r011.gnt for clinic 86 --- "
&$env:COBOL r011 86 Y
Get-ChildItem r011
Move-Item -Force r011 r011_86_before
#lp r011_86_before

echo " --- r011.gnt for clinic 91 --- "
&$env:COBOL r011 91 Y
Get-ChildItem r011
Move-Item -Force r011 r011_91_after
#lp r011_91_after

echo " --- r011.gnt for clinic 92 --- "
&$env:COBOL r011 92 Y
Get-ChildItem r011
Move-Item -Force r011 r011_92_after
#lp r011_92_after

echo " --- r011.gnt for clinic 93 --- "
&$env:COBOL r011 93 Y
Get-ChildItem r011
Move-Item -Force r011 r011_93_after
#lp r011_93_after

echo " --- r011.gnt for clinic 94 --- "
&$env:COBOL r011 94 Y
Get-ChildItem r011
Move-Item -Force r011 r011_94_after
#lp r011_94_after

echo " --- r011.gnt for clinic 95 --- "
&$env:COBOL r011 95 Y
Get-ChildItem r011
Move-Item -Force r011 r011_95_after
#lp r011_95_after 

echo " --- r011.gnt for clinic 96 --- "
&$env:COBOL r011 96 Y
Get-ChildItem r011
Move-Item -Force r011 r011_96_after
#lp r011_96_after

echo " --- r011.gnt for clinic 22 --- "
&$env:COBOL r011 22 Y
Get-ChildItem r011
Move-Item -Force r011 r011_22_after
#lp r011_22_after

echo " --- r011a.qzc, r011b.qzc, r011c.qzc for clinic 60 --- "
&$env:QUIZ r011a
&$env:QUIZ r011b
&$env:QUIZ r011c
Get-ChildItem r011a.txt, r011b.txt, r011c.txt
Get-Content r011b.txt, r011c.txt | Add-Content r011a.txt
Move-Item -Force r011a.txt r011_60_after
#lp r011_60_after

echo "DONE!"
