#-------------------------------------------------------------------------------
# File '2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was '2'
#-------------------------------------------------------------------------------

&$env:cmd\peds_billings

Set-Location $Env:root\alpha\rmabill\rmabill101c\src\yas

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:QTP emergency_urgent_clmhdrid_44
&$env:QTP emergency_payroll_clmhdrid
&$env:QUIZ emergency_payroll_clmhdrid_1
&$env:QUIZ emergency_payroll_clmhdrid_2
&$env:QUIZ emergency_payroll_clmhdrid_3

&$env:QTP yasclare
&$env:QUIZ yasclare_1
&$env:QUIZ yasclare_2
&$env:QUIZ yasclare_3

####qtp auto=$obj/draminaz_elig_rejects.qtc
####qtp auto=$obj/draminaz_rat_rejects.qtc

&$env:QUIZ drchaudhary_rejects

&$env:QTP dept44

&$env:QTP dept_average_docohip

#qtp auto=$obj/emerg_dept_41_42_44.qtc   #   one time only

echo "End Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
