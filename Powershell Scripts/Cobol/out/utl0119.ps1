#-------------------------------------------------------------------------------
# File 'utl0119.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'utl0119.com'
#-------------------------------------------------------------------------------

# utl0119.com    

# NOTE: clinic 22 - "normal" clinic 22 payroll
#       clinic 99 - "MP" / Manual Payments payroll
#       clinic 10 - "solo/solotest" payroll
#
# 14/Nov/25 M.C. - original  

echo "--- executing utl0119.qtc  ---"

Set-Location $application_root\production

Remove-Item utl00119.ps*  > $null

# If 101c, pass 101C 
if ($clinic_nbr -eq "22")
{

$pipedInput = @"
execute $obj/utl0119
101C
"@

$pipedInput | qtp++

} else {

# If MP, pass MP   
if ($clinic_nbr -eq "99")
{

$pipedInput = @"
execute $obj/utl0119
MP   
"@

$pipedInput | qtp++

} else {

# If solo, pass SOLO 
if ($clinic_nbr -eq "10")
{

$pipedInput = @"
execute $obj/utl0119
SOLO
"@

$pipedInput | qtp++

}
}
}
