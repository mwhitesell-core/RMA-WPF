#-------------------------------------------------------------------------------
# File 'r997_clinic_79.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r997_clinic_79'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\79

# recopy back backup file before executing reports
Copy-Item u997_good_srt_bkp.sf u997_good_srt.sf

Remove-Item r997*_summ.txt
&$env:QUIZ r997f_summ
&$env:QUIZ r997g_summ
&$env:QUIZ r997k_summ
#lp r997f_summ.txt
#lp r997g_summ.txt

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content r997k_summ.txt | Out-Printer -Name $env:networkprinter
}
