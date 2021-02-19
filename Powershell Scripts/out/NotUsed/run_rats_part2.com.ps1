#-------------------------------------------------------------------------------
# File 'run_rats_part2.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_rats_part2.com'
#-------------------------------------------------------------------------------

#
# $cmd/runs_rats_part2.com  (rerun of the missing clinics)

Get-Date


#-------------------

Set-Location $env:application_production\23
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\24
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\25
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

#-------------------

Set-Location $env:application_production\31
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\32
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\33
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\34
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\35
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\37
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

#-------------------

Set-Location $env:application_production\41
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\42
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\43
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\44
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\45
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

#-------------------

Set-Location $env:application_production\80
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\82
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\84
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\87
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\89
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

#####################

Set-Location $env:application_production\91
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\92
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\93
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\94
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\95
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

Set-Location $env:application_production\96
&$env:cmd\u030_clinic_dtl_part2 > u030_dtl_part2.log

#-------------------

Get-Date
