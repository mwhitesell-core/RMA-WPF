#-------------------------------------------------------------------------------
# File 'portal_reports_yas.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'portal_reports_yas'
#-------------------------------------------------------------------------------

Set-Location $Env:root\alpha\rmabill\rmabill101c\src\yas

echo "Start Time of $env:cmd\portal_reports is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:cmd\dept54

&$env:QTP emergency_urgent_clmhdrid_44
&$env:QTP emergency_payroll_clmhdrid

## (emergency_payroll_clmhdrid.qzs for all 3)
&$env:QUIZ emergency_payroll_clmhdrid_1
&$env:QUIZ emergency_payroll_clmhdrid_2
&$env:QUIZ emergency_payroll_clmhdrid_3

&$env:QTP yasclare                         ## run it december and yearend
&$env:QUIZ yasclare_1                      ## (yasclare.qzs for all 3)
&$env:QUIZ yasclare_2
&$env:QUIZ yasclare_3

&$env:QTP g271_code
&$env:QUIZ g271_code
&$env:QTP dept4_average
&$env:QUIZ advout

####qtp auto=$obj/draminaz_elig_rejects.qtc
####qtp auto=$obj/draminaz_rat_rejects.qtc

&$env:QUIZ drchaudhary_rejects

## (emerg_dept44.qts)
##qtp auto=$obj/dept44.qtc   cancelled Ross does not need it anymore    

###qtp auto=$obj/dept_average_docohip.qtc  cancelled Ross does not need  it

### qtp auto=$obj/emerg_dept_41_42_44.qtc   #   one time only

### We are going to run the following from now on for Emerg analysis give it to Ross as requested
### MODIFY service dates and compile as requested

### qtp auto=$obj/ucc_patient_count_dtl.qtc   ###  modify service dates and compile as requested

###  RUN the following at YEAREND  Kathy will run - included in the monthend activity sheet for 22

#qtp auto=$obj/f119histtithe.qtc      MODIFY and recompile
#qtp auto=$obj/costing_f119hist.qtc   MODIFY and recompile
#qtp auto=$obj/leenaclaims.qtc       ### (leena_claims.qts - rename excel to Batch control f001 total claims for yearend.xlsx)

### qtp auto=$obj/f119hist_dept14.qtc CANCELLED added the extra columns to costing_f119hist.qts for Ross will have 
### all the departments for yearend

echo "End Time of $env:cmd\portal_reports is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
