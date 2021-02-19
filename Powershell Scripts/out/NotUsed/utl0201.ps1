#-------------------------------------------------------------------------------
# File 'utl0201.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'utl0201.com'
#-------------------------------------------------------------------------------

# utl0201.com    

# NOTE: clinic 22 - "normal" clinic 22 payroll
#       clinic 99 - "MP" / Manual Payments payroll
#       clinic 10 - "solo/solotest" payroll
#
# 14/Nov/25 M.C. - original  
# 15/Oct/14 MC1  - delete additonal subfiles before running of programs

echo "--- executing utl0201.qtc  ---"

Set-Location $application_root\production

Remove-Item utl0201*.ps*, utl*audit*ps*, utl0f020.ps*, utl0201*.txt, utl0f191.ps*  -EA SilentlyContinue

# MC1
Remove-Item utl0f*.ps*, utlf*.ps*  -EA SilentlyContinue

# If 101c, pass 101C 
if ($env:clinic_nbr -eq "22")
{

$pipedInput = @"
execute $obj/utl0201
101C
"@

$pipedInput | qtp++

} else {

# If MP, pass MP   
if ($env:clinic_nbr -eq "99")
{

$pipedInput = @"
execute $obj/utl0201
MP   
"@

$pipedInput | qtp++

} else {

# If solo, pass SOLO 
if ($env:clinic_nbr -eq "10")
{

$pipedInput = @"
execute $obj/utl0201
SOLO
"@

$pipedInput | qtp++

}
}
}

quiz++ $obj\utl0201
