#-------------------------------------------------------------------------------
# File 'run_rats_rerun.com-moira.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_rats_rerun.com-moira'
#-------------------------------------------------------------------------------

###
###  clinic 22 to 33 requires rerun due to errors        
###  clinic 34 to 96 have been run successfully after recompile of u030b_part2.qts
###  Require to run the remaining macros after clinic 33  

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

Set-Location $env:application_production
&$env:cmd\r997_ph_portal_all_clinics

Set-Location $env:application_production
Remove-Item r031a_agep.sf*
&$env:cmd\copy_u030_rec_67

Set-Location $env:application_production

Get-Content r031b_agep.txt | Out-Printer

&$env:cmd\r997_clinic_88
&$env:cmd\r997_clinic_78
&$env:cmd\r997_clinic_69

#-------------------

Set-Location $env:application_production

&$env:cmd\rat_dept7 > rat_dept7.log
Get-Date
&$env:cmd\r997_clinic22_84J
Get-Date
&$env:cmd\run_after_rat
Get-Date

# MC1
Set-Location $Env:root\foxtrot\bi
Move-Item -Force unlof002hdr_rat_payment.ps bi_f002hdr_rat_payment.ps
Move-Item -Force unlof002hdr_rat_payment.psd bi_f002hdr_rat_payment.psd
# MC1 - end
