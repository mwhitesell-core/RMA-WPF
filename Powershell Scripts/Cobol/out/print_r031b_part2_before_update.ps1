#-------------------------------------------------------------------------------
# File 'print_r031b_part2_before_update.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'print_r031b_part2_before_update'
#-------------------------------------------------------------------------------

# macro: print_r031_part2_before_update
# 13/May/16 M.C. update tmp-doctor-alpha for tech/prof paid amt for each clinic for MOHD payments

$pipedInput = @"
create file tmp-doctor-alpha
"@

$pipedInput | qutil++

Set-Location $application_production
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\23
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\24
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\25
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\31
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\32
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\33
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\34
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\35
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\36
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\37
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\41
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\42
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\43
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\44
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\45
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\46
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\61
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\62
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\63
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\64
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\65
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\66
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\71
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\72
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\73
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\74
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\75
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\78
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\79
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\80
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\82
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\84
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\86
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\87
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\88
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\89
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\91
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\92
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\93
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\94
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\95
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\96
qtp++ $obj\u030_dtl_tech_prof

Set-Location $application_production\22

quiz++ $obj\r031_part2_before_update

#lp r031b_part2.txt 

# save tmp_doctor_alpha  file for backup

Set-Location $pb_data
Copy-Item tmp_doctor_alpha.dat tmp_doctor_alpha_mohd.dat
Copy-Item tmp_doctor_alpha.idx tmp_doctor_alpha_mohd.idx

echo ""
echo "end of the run"
echo ""
Get-Date
