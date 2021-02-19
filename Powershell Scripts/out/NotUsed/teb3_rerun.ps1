#-------------------------------------------------------------------------------
# File 'teb3_rerun.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'teb3_rerun'
#-------------------------------------------------------------------------------

if ($env:clinic_nbr -eq "22")
{

Set-Location $env:application_production

#MC3 - Inactive Doctors for last 3 ep nbr and have outstanding claims

Remove-Item r128*.sf*, r128.txt, r128_csv.txt *> $null

Remove-Item $pb_data\tmp_counters_alpha*

$pipedInput = @"
create file tmp-counters-alpha
"@

$pipedInput | qutil++

&$env:QTP r128a
&$env:QUIZ r128b
&$env:QUIZ r128b_csv

Get-Content r128.txt | Out-Printer

#MC2
#MC4
#rm r138_csv.txt r139*.sf* r139_csv.txt 1>/dev/null 2>&1
Remove-Item r138*.sf*, r138_csv.txt, r139*.sf*, r139_csv.txt *> $null

#####  Deficit Report
#MC4
&$env:QTP r138_csv
&$env:QUIZ r138_csv

#####  INCEXP minus TOTDED not equal to PAYEFT for pay code 2
&$env:QTP r139_csv
&$env:QUIZ r139_csv

##### Revenue Reports

echo "--- utl0020 ---"
#$cmd/utl0020.com

# MC3 - end

}
echo "Done!"

echo "Payroll teb3 -   ending - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
