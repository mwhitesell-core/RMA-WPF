#-------------------------------------------------------------------------------
# File 'utl0201_f020.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'utl0201_f020.com'
#-------------------------------------------------------------------------------

# utl0201_f020.com    

# NOTE: clinic 22 - "normal" clinic 22 payroll
#       clinic 99 - "MP" / Manual Payments payroll
#       clinic 10 - "solo/solotest" payroll
#
# 14/Nov/25 M.C. - original  
# 15/Oct/14 MC1  - delete additonal subfiles before running of programs

echo "--- executing utl0201_f020.qtc  ---"

Set-Location $env:application_root\production

Remove-Item utl0f020*ps*

# If 101c, pass 101C 
if ($env:clinic_nbr -eq "22")
{

&$env:QTP utl0201_f020 101C

} else {

# If MP, pass MP   
if ($env:clinic_nbr -eq "99")
{

&$env:QTP utl0201_f020 MP

} else {

# If solo, pass SOLO 
if ($env:clinic_nbr -eq "10")
{

&$env:QTP utl0201_f020 SOLO

}
}
}
