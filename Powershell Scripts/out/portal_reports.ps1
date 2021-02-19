#-------------------------------------------------------------------------------
# File 'portal_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'portal_reports'
#-------------------------------------------------------------------------------

## $cmd/portal_reports

Set-Location \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\src\yas

echo "Start Time of $env:cmd\portal_reports is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:cmd\peds_billings
&$env:cmd\clinic26
&$env:cmd\dept54

$rcmd = $env:QTP + "emergency_urgent_clmhdrid_44"
Invoke-Expression $rcmd
$rcmd = $env:QTP + "emergency_payroll_clmhdrid"
Invoke-Expression $rcmd

## (emergency_payroll_clmhdrid.qzs for all 3)
$rcmd = $env:QUIZ + "emergency_payroll_clmhdrid_1 DISC_ctas-m.rf"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "emergency_payroll_clmhdrid_2 DISC_ctas-g.rf"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "emergency_payroll_clmhdrid_3 DISC_ctas-h.rf"
Invoke-Expression $rcmd

$rcmd = $env:QTP + "yasclare"
Invoke-Expression $rcmd                         ## run it december and yearend
$rcmd = $env:QUIZ + "yasclare_1"                      ## (yasclare.qzs for all 3)
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content yasclare_1.txt > plastic_surgery.txt

$rcmd = $env:QUIZ + "yasclare_2"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content yasclare_2.txt > ortho_surgery.txt

$rcmd = $env:QUIZ + "yasclare_3"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content yasclare_3.txt > opthalmologist.txt

$rcmd = $env:QTP + "g271_code"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "g271_code"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content g271_code.txt > g271.txt

$rcmd = $env:QTP + "dept4_average"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "advout"
Invoke-Expression $rcmd

####qtp auto=$obj/draminaz_elig_rejects.qtc
####qtp auto=$obj/draminaz_rat_rejects.qtc

$rcmd = $env:QUIZ + "drchaudhary_rejects DISC_drchaudhary_rejects.rf"
Invoke-Expression $rcmd

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

Set-Location \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\Production
