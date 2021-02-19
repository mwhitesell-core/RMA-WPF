#-------------------------------------------------------------------------------
# File 'teb.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'teb.bk1'
#-------------------------------------------------------------------------------

# teb3
#
# MODIFICATION HISTORY
# 04/jan/23  b.e.   -new 

echo "Running CLINIC:  $env:clinic_nbr"

Set-Location $env:application_production

if ($env:clinic_nbr -eq "22")
{

echo "--- utl0020 ---"
&$env:cmd\utl0020.com

}
echo "Done!"
