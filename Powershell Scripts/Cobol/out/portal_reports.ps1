#-------------------------------------------------------------------------------
# File 'portal_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'portal_reports'
#-------------------------------------------------------------------------------

## $cmd/portal_reports

Set-Location $root\alpha\rmabill\rmabill101c\src\yas

echo "Start Time of $cmd\portal_reports is$(udate)"

$cmd\peds_billings
$cmd\clinic26
$cmd\dept54

qtp++ $obj\emergency_urgent_clmhdrid_44
qtp++ $obj\emergency_payroll_clmhdrid

## (emergency_payroll_clmhdrid.qzs for all 3)
quiz++ $obj\emergency_payroll_clmhdrid_1
quiz++ $obj\emergency_payroll_clmhdrid_2
quiz++ $obj\emergency_payroll_clmhdrid_3

qtp++ $obj\yasclare                         ## run it december and yearend
quiz++ $obj\yasclare_1                      ## (yasclare.qzs for all 3)
quiz++ $obj\yasclare_2
quiz++ $obj\yasclare_3

qtp++ $obj\g271_code
quiz++ $obj\g271_code
qtp++ $obj\dept4_average
quiz++ $obj\advout

####qtp auto=$obj/draminaz_elig_rejects.qtc
####qtp auto=$obj/draminaz_rat_rejects.qtc

quiz++ $obj\drchaudhary_rejects

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

echo "End Time of $cmd\portal_reports is$(udate)"
