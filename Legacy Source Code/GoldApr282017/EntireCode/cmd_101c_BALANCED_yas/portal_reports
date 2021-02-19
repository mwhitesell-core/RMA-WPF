## $cmd/portal_reports

cd /alpha/rmabill/rmabill101c/src/yas

echo Start Time of $cmd/portal_reports is `date`

$cmd/peds_billings
$cmd/clinic26
$cmd/dept54

qtp auto=$obj/emergency_urgent_clmhdrid_44.qtc
qtp auto=$obj/emergency_payroll_clmhdrid.qtc

## (emergency_payroll_clmhdrid.qzs for all 3)
quiz auto=$obj/emergency_payroll_clmhdrid_1.qzc   
quiz auto=$obj/emergency_payroll_clmhdrid_2.qzc
quiz auto=$obj/emergency_payroll_clmhdrid_3.qzc

qtp auto=$obj/yasclare.qtc                         ## run it december and yearend
quiz auto=$obj/yasclare_1.qzc                      ## (yasclare.qzs for all 3)
quiz auto=$obj/yasclare_2.qzc
quiz auto=$obj/yasclare_3.qzc

qtp auto=$obj/g271_code.qtc
quiz auto=$obj/g271_code.qzc
qtp auto=$obj/dept4_average.qtc     
quiz auto=$obj/advout.qzc    

####qtp auto=$obj/draminaz_elig_rejects.qtc
####qtp auto=$obj/draminaz_rat_rejects.qtc

quiz auto=$obj/drchaudhary_rejects.qzc

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

echo End Time of $cmd/portal_reports is `date`

