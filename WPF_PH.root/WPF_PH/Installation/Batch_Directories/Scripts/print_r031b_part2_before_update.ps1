#-------------------------------------------------------------------------------
# File 'print_r031b_part2_before_update.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'print_r031b_part2_before_update'
#-------------------------------------------------------------------------------

# macro: print_r031_part2_before_update
# 13/May/16 M.C. update tmp-doctor-alpha for tech/prof paid amt for each clinic for MOHD payments

#$pipedInput = @"
#create file tmp-doctor-alpha
#"@



$rcmd = $env:TRUNCATE+"tmp_doctor_alpha"
Invoke-Expression $rcmd

Set-Location $env:application_production
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd


Set-Location $env:application_production\23
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\24
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\25
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\31
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\32
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\33
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\34
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\35
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\36
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\37
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\41
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\42
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\43
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\44
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\45
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\46
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\61
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\62
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\63
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\64
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\65
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\66
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\71
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\72
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\73
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd
Set-Location $env:application_production\74
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\75
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\78
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\79
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\80
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\82
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\84
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\86
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\87
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\88
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\89
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\91
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\92
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\93
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\94
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\95
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\96
$rcmd = $env:QTP + "u030_dtl_tech_prof"
Invoke-Expression $rcmd

Set-Location $env:application_production\22

$rcmd = $env:QUIZ + "r031_part2_before_update"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r031_part2_before_update.txt > r031b_part2.txt

#lp r031b_part2.txt 

# save tmp_doctor_alpha  file for backup

Set-Location $env:pb_data
Copy-Item tmp_doctor_alpha.dat tmp_doctor_alpha_mohd.dat
Copy-Item tmp_doctor_alpha.idx tmp_doctor_alpha_mohd.idx

echo ""
echo "end of the run"
echo ""
Get-Date
