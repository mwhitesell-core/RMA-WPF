#-------------------------------------------------------------------------------
# File 'run_rats_78.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_rats_78'
#-------------------------------------------------------------------------------

#### Yasemin Juanuary 6, 2011
#### Following is to run the rats just for clinic 78
#### u030 extract did not work there was a space after "01" month in the macro rat_copy for clinic 78
#### re extracted the program by using "rat_copy_78" make sure the u030*dat files are created correctly
#### re run "application_of_rat_78_part1  and check the u030_78.ls before running this macro 

Get-Date
####$cmd/rat_copy_78
####$cmd/application_of_rat_78_part1

########## create r997_ph_portal
Set-Location $env:application_production\78
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

&$env:QUIZ r997_portal_a > r997_portal.log
&$env:QUIZ r997_portal_b >> r997_portal.log
Move-Item -Force r997_portal.txt r997_portal_78.txt

########## run the agep report
Set-Location $env:application_production\78
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 78

Set-Location $env:application_production
&$env:QUIZ r031b_agep

Get-Content r031b_agep.txt | Out-Printer

####
Set-Location $env:application_production
&$env:cmd\r030_hm

####

&$env:cmd\r997_clinic_78

########## RUN part 2  for clinic 78 only
Set-Location $env:application_production\78
&$env:cmd\u030_clinic88_part2 > u030_88_part2.log

Get-Date
