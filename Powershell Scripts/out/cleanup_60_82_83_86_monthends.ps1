#-------------------------------------------------------------------------------
# File 'cleanup_60_82_83_86_monthends.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'cleanup_60_82_83_86_monthends'
#-------------------------------------------------------------------------------

echo "********************************************************************"

echo "THIS PROGRAM WILL DELETE THE Clinics 82 and 83 and 61 to 65 reports"
echo "MAKE SURE ALL THE REPORTS ARE PRINTED AND COPY MAG TAPE IS RUN"
echo ""
echo "********************************************************************"
echo ""
echo "**** HIT NEW LINE TO CONTINUE ****"
$garbage = Read-Host
echo ""
Get-Date

Push-Location

&$env:cmd\cleanup_82_monthend
&$env:cmd\cleanup_86_monthend
&$env:cmd\cleanup_60_monthend
&$env:cmd\cleanup_70_monthend

Get-Date

Pop-Location