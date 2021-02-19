#-------------------------------------------------------------------------------
# File 'teb3.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'teb3.bk1'
#-------------------------------------------------------------------------------

# teb3
#
# MODIFICATION HISTORY
# 04/jan/23  b.e.   -new 
# 15/Mar/24  MC1    - include the run of utl0201_f119.qtc and utl0201.qzu for 3 enviroments
#                     note that this program must be run after u090f.qts (after increasing current-ep-nbr + 1)
# 15/Jun/11  yas    - utl0201_a.txt =  "Highest MTD Payment Amount by Dept"  and 
#                     utl0201_b.txt =  "Highest different MTD in Payment Amount from LAST MONTH  by Dept"         
#                     $cmd/utl0020.com  is for the revenue reports
# 15/Aug/12  MC2    - include the run of r138_csv.qzc, r139_csv.qtc/qzc for 101c only
#                   - r138_csv.txt = Defict report for Ross
#                   - r139_csv.txt = INCEXP minus TOTDED not equal PAYEFT for pay code 2
# 15/Sep/22  MC3    - transfer the run of r128 here from $cmd/teb2
#                   - r128.txt = Inactive Doctor with no activity for last 3 ep nbr and has outstanding claim
#                                for dept 14 or 15 with pay code 2, this report is printed for Helena,
#                   - r128_csv.txt = Inactive Doctor with no activity for last 3 ep nbr and has outstanding claim,
#                     this should be run for 101c only as solo and mp has no claims


echo "Payroll teb3 - starting - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

echo "Running CLINIC:  $env:clinic_nbr"

#------------------------------------------------------------------
#MC1

# NOTE: clinic 22 - "normal" clinic 22 payroll
#       clinic 99 - "MP" / Manual Payments payroll
#       clinic 10 - "solo/solotest" payroll
#

echo "--- executing utl0201_f119.qtc  ---"

Set-Location $env:application_root\production

Remove-Item utl0201_f119.ps*, utl0201*.txt, utl0201.sf* *> $null

# If 101c, pass 101C 
if ($env:clinic_nbr -eq "22")
{

&$env:QTP utl0201_f119 101C

} else {

# If MP, pass MP   
if ($env:clinic_nbr -eq "99")
{

&$env:QTP utl0201_f119 MP

} else {

# If solo, pass SOLO 
if ($env:clinic_nbr -eq "10")
{

&$env:QTP utl0201_f119 SOLO

}
}
}

&$env:QUIZ utl0201

Get-Content utl0201_a.txt | Out-Printer
Get-Content utl0201_b.txt | Out-Printer
Get-Content utl0201_a.txt | Out-Printer
Get-Content utl0201_b.txt | Out-Printer

#------------------------------------------------------------------
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
Remove-Item r138_csv.txt, r139*.sf*, r139_csv.txt *> $null

#####  Deficit Report
&$env:QUIZ r138_csv

#####  INCEXP minus TOTDED not equal to PAYEFT for pay code 2
&$env:QTP r139_csv
&$env:QUIZ r139_csv

##### Revenue Reports

echo "--- utl0020 ---"
&$env:cmd\utl0020.com

# MC3 - end

}
echo "Done!"

echo "Payroll teb3 -   ending - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
