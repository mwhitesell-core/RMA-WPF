#-------------------------------------------------------------------------------
# File 'cleanup_22to48_monthends.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'cleanup_22to48_monthends'
#-------------------------------------------------------------------------------

echo "********************************************************************"

echo "THIS PROGRAM WILL DELETE THE Clinics 22 to 48 reports"
echo "MAKE SURE ALL THE REPORTS ARE PRINTED AND COPY MAG TAPE IS RUN"
echo ""
echo "********************************************************************"
echo ""
echo "**** HIT NEW LINE TO CONTINUE ****"
$garbage = Read-Host
echo ""
Get-Date
Push-Location
&$env:cmd\cleanup_22_monthend
&$env:cmd\cleanup_23_monthend
&$env:cmd\cleanup_24_monthend
&$env:cmd\cleanup_25_monthend
&$env:cmd\cleanup_26_monthend
&$env:cmd\cleanup_30_monthend
&$env:cmd\cleanup_31_monthend
&$env:cmd\cleanup_32_monthend
&$env:cmd\cleanup_33_monthend
&$env:cmd\cleanup_34_monthend
&$env:cmd\cleanup_35_monthend
&$env:cmd\cleanup_36_monthend
&$env:cmd\cleanup_41_monthend
&$env:cmd\cleanup_42_monthend
&$env:cmd\cleanup_43_monthend
&$env:cmd\cleanup_44_monthend
&$env:cmd\cleanup_45_monthend
&$env:cmd\cleanup_46_monthend
&$env:cmd\cleanup_48_monthend
&$env:cmd\cleanup_98_monthend
Pop-Location
Get-Date
