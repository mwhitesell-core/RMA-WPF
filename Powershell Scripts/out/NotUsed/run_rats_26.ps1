#-------------------------------------------------------------------------------
# File 'run_rats_26.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_rats_26'
#-------------------------------------------------------------------------------

Get-Date

Set-Location $env:application_production\26

&$env:cmd\application_of_rat_26_part1

Set-Location $env:application_production\26
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

&$env:QUIZ r997_portal_a > r997_portal.log
&$env:QUIZ r997_portal_b >> r997_portal.log
Move-Item -Force r997_portal.txt r997_portal_26.txt


Get-Date
