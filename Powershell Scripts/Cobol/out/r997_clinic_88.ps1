#-------------------------------------------------------------------------------
# File 'r997_clinic_88.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r997_clinic_88'
#-------------------------------------------------------------------------------

Set-Location $application_production\88

# recopy back backup file before executing reports
Copy-Item u997_good_srt_bkp.sf u997_good_srt.sf

Remove-Item r997*_summ.txt
$pipedInput = @"
exec $obj/r997f_summ.qzc
exec $obj/r997g_summ.qzc
exec $obj/r997k_summ.qzc
"@

$pipedInput | quiz++
#lp r997f_summ.txt
#lp r997g_summ.txt
Get-Contents r997k_summ.txt| Out-Printer
