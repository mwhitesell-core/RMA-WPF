#-------------------------------------------------------------------------------
# File 'run_rats_bkp1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_rats_bkp1'
#-------------------------------------------------------------------------------

Get-Date
&$env:cmd\application_of_rat_22_part1
&$env:cmd\application_of_rat_31_part1
&$env:cmd\application_of_rat_32_part1
&$env:cmd\application_of_rat_33_part1
&$env:cmd\application_of_rat_34_part1
&$env:cmd\application_of_rat_35_part1
&$env:cmd\application_of_rat_36_part1
&$env:cmd\application_of_rat_37_part1
&$env:cmd\application_of_rat_41_part1
&$env:cmd\application_of_rat_42_part1
&$env:cmd\application_of_rat_43_part1
&$env:cmd\application_of_rat_44_part1
&$env:cmd\application_of_rat_45_part1
&$env:cmd\application_of_rat_46_part1
&$env:cmd\application_of_rat_60_part1
&$env:cmd\application_of_rat_70_part1
&$env:cmd\application_of_rat_80_part1
&$env:cmd\application_of_rat_82_part1
&$env:cmd\application_of_rat_84_part1
&$env:cmd\application_of_rat_86_part1
&$env:cmd\application_of_rat_87_part1
&$env:cmd\application_of_rat_88_part1
&$env:cmd\application_of_rat_91_part1
&$env:cmd\application_of_rat_92_part1
&$env:cmd\application_of_rat_93_part1
&$env:cmd\application_of_rat_94_part1
&$env:cmd\application_of_rat_95_part1
&$env:cmd\application_of_rat_96_part1

Set-Location $env:application_production
&$env:cmd\r997_ph_portal_all_clinics

Set-Location $env:application_production
Remove-Item r031a_agep.sf*
&$env:cmd\copy_u030_rec_67

Set-Location $env:application_production
&$env:cmd\r030_hm

Get-Content r031b_agep.txt | Out-Printer

&$env:cmd\r997_clinic_88

Set-Location $env:application_production

Get-Date
