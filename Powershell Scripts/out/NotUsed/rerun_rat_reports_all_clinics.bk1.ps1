#-------------------------------------------------------------------------------
# File 'rerun_rat_reports_all_clinics.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rerun_rat_reports_all_clinics.bk1'
#-------------------------------------------------------------------------------

Set-Location $env:application_production
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\23
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\24
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\25
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\30
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\31
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\32
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\33
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\34
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\35
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\36
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\37
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\41
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\42
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\43
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\44
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\45
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\46
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\61
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\62
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\63
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\64
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\66
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\69
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\71
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\72
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\73
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\74
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\75
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\78
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\80
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\82
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\84
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\87
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\88
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\89
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\91
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\92
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\93
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\94
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\95
&$env:cmd\rerun_rat_reports

Set-Location $env:application_production\96
&$env:cmd\rerun_rat_reports

#-------------------

Set-Location $env:application_production
&$env:cmd\r997_ph_portal_all_clinics

Set-Location $env:application_production
Remove-Item r031a_agep.sf*
&$env:cmd\copy_u030_rec_67

Set-Location $env:application_production

Get-Content r031b_agep.txt | Out-Printer

&$env:cmd\r997_clinic_88
&$env:cmd\r997_clinic_78
&$env:cmd\r997_clinic_79
&$env:cmd\r997_clinic_68
&$env:cmd\r997_clinic_69

#-------------------

Set-Location $env:application_production

&$env:cmd\rat_dept7 > rat_dept7.log
Get-Date
&$env:cmd\r997_clinic22_84J
Get-Date
