#-------------------------------------------------------------------------------
# File 'utl0112.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'utl0112.com'
#-------------------------------------------------------------------------------

# utl0112.com    

# NOTE: clinic 22 - "normal" clinic 22 payroll
#       clinic 99 - "MP" / Manual Payments payroll
#       clinic 10 - "solo/solotest" payroll
#
# 14/Nov/25 M.C. - original  

echo "--- executing utl0112.qtc  ---"

Set-Location $env:application_root\production

Remove-Item utl00112.ps* *> $null

# If 101c, pass 101C 
if ($env:clinic_nbr -eq "22")
{

&$env:QTP utl0112 101C

} else {

# If MP, pass MP   
if ($env:clinic_nbr -eq "99")
{

&$env:QTP utl0112 MP

} else {

# If solo, pass SOLO 
if ($env:clinic_nbr -eq "10")
{

&$env:QTP utl0112 SOLO

}
}
}
