#-------------------------------------------------------------------------------
# File 'run_rat_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_rat_reports'
#-------------------------------------------------------------------------------

# 2016/Apr/06  - somehow r997.txt was missing in each clinic, suspect user ran
#                $cmd/print_rats twice, recover the reports in each clinic

Get-Content r997f.txt | Add-Content r997.txt
Get-Content r997g.txt | Add-Content r997.txt
Get-Content r997h.txt | Add-Content r997.txt
Get-Content r997i.txt | Add-Content r997.txt
Get-Content r997j.txt | Add-Content r997.txt
Get-Content r997k.txt | Add-Content r997.txt
Get-Content r997_total.txt | Add-Content r997.txt
