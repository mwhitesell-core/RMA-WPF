#-------------------------------------------------------------------------------
# File 'run_rats.com.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_rats.com.bk1'
#-------------------------------------------------------------------------------

#
# $cmd/runs_rat.com
# 2013/Sep/09 - MC  - formally called $cmd/run_rats, and now this macro will call from $cmd/run_rats
# 2013/Nov/06 - MC  - transfer the run of $cmd/u030_clinic_dtl_part2 to each individual clinic part1
#                     since now all clinics should run this step; actually modify $cmd/u030 to include
#                     the run of part2
#2014/Oct/17 - Yas    new clinic 30

Get-Date
&$env:cmd\application_of_rat_22_part1
&$env:cmd\application_of_rat_23_part1
&$env:cmd\application_of_rat_24_part1
&$env:cmd\application_of_rat_25_part1
&$env:cmd\application_of_rat_26_part1
&$env:cmd\application_of_rat_30_part1
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
####$cmd/application_of_rat_48_part1
&$env:cmd\application_of_rat_60_part1
####$cmd/application_of_rat_68_part1
&$env:cmd\application_of_rat_69_part1
&$env:cmd\application_of_rat_70_part1
&$env:cmd\application_of_rat_78_part1
####$cmd/application_of_rat_79_part1
&$env:cmd\application_of_rat_80_part1
&$env:cmd\application_of_rat_82_part1
&$env:cmd\application_of_rat_84_part1
####$cmd/application_of_rat_86_part1
&$env:cmd\application_of_rat_87_part1
&$env:cmd\application_of_rat_88_part1
&$env:cmd\application_of_rat_89_part1
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

Get-Content r031b_agep.txt | Out-Printer

&$env:cmd\r997_clinic_88
&$env:cmd\r997_clinic_78
&$env:cmd\r997_clinic_79
&$env:cmd\r997_clinic_68
&$env:cmd\r997_clinic_69

#-------------------

Set-Location $env:application_production

&$env:cmd\rat_dept7 > rat_dept7.log
Get-Date
&$env:cmd\r997_clinic22_84J
Get-Date
&$env:cmd\run_after_rat
Get-Date
