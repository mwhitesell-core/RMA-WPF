#-------------------------------------------------------------------------------
# File 'r997_clinic_88.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'r997_clinic_88'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\88

# recopy back backup file before executing reports
Copy-Item u997_good_srt_bkp.sf u997_good_srt.sf

Remove-Item r997*_summ.txt
$rcmd = $env:QUIZ + "r997f_summ"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r997g_summ"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r997k_summ"
invoke-expression $rcmd
#lp r997f_summ.txt
#lp r997g_summ.txt
Get-Content r997k_summ.txt | Out-Printer
