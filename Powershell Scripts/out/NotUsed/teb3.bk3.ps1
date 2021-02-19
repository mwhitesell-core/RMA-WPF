#-------------------------------------------------------------------------------
# File 'teb3.bk3.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'teb3.bk3'
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

Remove-Item utl0201_f119.ps*, utl0201*.txt *> $null

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

#------------------------------------------------------------------
##### Revenue Reports

Set-Location $env:application_production

if ($env:clinic_nbr -eq "22")
{

echo "--- utl0020 ---"
&$env:cmd\utl0020.com

}
echo "Done!"

echo "Payroll teb3 -   ending - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
