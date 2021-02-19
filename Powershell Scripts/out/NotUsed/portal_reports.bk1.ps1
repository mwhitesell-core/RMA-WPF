#-------------------------------------------------------------------------------
# File 'portal_reports.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'portal_reports.bk1'
#-------------------------------------------------------------------------------

&$env:cmd\peds_billings
&$env:cmd\clinic26

Set-Location $Env:root\alpha\rmabill\rmabill101c\src\yas

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:QTP emergency_urgent_clmhdrid_44
&$env:QTP emergency_payroll_clmhdrid
&$env:QUIZ emergency_payroll_clmhdrid_1    ## (emergency_payroll_clmhdrid.qzs for all 3)
&$env:QUIZ emergency_payroll_clmhdrid_2
&$env:QUIZ emergency_payroll_clmhdrid_3

###qtp auto=$obj/yasclare.qtc
###quiz auto=$obj/yasclare_1.qzc                      ## (yasclare.qzs for all 3)
###quiz auto=$obj/yasclare_2.qzc
###quiz auto=$obj/yasclare_3.qzc

&$env:QTP g271_code
&$env:QUIZ g271_code

####qtp auto=$obj/draminaz_elig_rejects.qtc
####qtp auto=$obj/draminaz_rat_rejects.qtc

&$env:QUIZ drchaudhary_rejects

&$env:QTP dept44                         ## (emerg_dept44.qts)

&$env:QTP dept_average_docohip

### qtp auto=$obj/emerg_dept_41_42_44.qtc   #   one time only

### We are going to run the following from now on for Emerg analysis give it to Ross as requested
### MODIFY service dates and compile as requested

### qtp auto=$obj/ucc_patient_count_dtl.qtc   ###  modify service dates and compile as requested

###  RUN the following at YEAREND  Kathy will run - included in the monthend activity sheet for 22

#qtp auto=$obj/f119histtithe.qtc 
#qtp auto=$obj/costing_f119hist.qtc
#qtp auto=$obj/leenaclaims.qtc       ### (leena_claims.qts - rename excel to Batch control f001 total claims for yearend.xlsx)

echo "End Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

### qtp auto=$obj/f119hist_dept14.qtc CANCELLED added the extra columns to costing_f119hist.qts for Ross will have 
### all the departments for yearend
