#-------------------------------------------------------------------------------
# File 'cleanup_80_91to96_monthends.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'cleanup_80_91to96_monthends'
#-------------------------------------------------------------------------------

echo "********************************************************************"

echo "THIS PROGRAM WILL DELETE THE Clinics 80 and 91 to 96 reports"
echo "MAKE SURE ALL THE REPORTS ARE PRINTED AND COPY MAG TAPE IS RUN"
echo ""
echo "********************************************************************"
echo ""
echo "**** HIT NEW LINE TO CONTINUE ****"
$garbage = Read-Host
echo ""
Push-Location
Get-Date

&$env:cmd\cleanup_37_monthend
&$env:cmd\cleanup_68_monthend
&$env:cmd\cleanup_69_monthend
&$env:cmd\cleanup_78_monthend
&$env:cmd\cleanup_79_monthend
&$env:cmd\cleanup_80_monthend
&$env:cmd\cleanup_84_monthend
&$env:cmd\cleanup_87_monthend
&$env:cmd\cleanup_88_monthend
&$env:cmd\cleanup_89_monthend
&$env:cmd\cleanup_91_monthend
&$env:cmd\cleanup_92_monthend
&$env:cmd\cleanup_93_monthend
&$env:cmd\cleanup_94_monthend
&$env:cmd\cleanup_95_monthend
&$env:cmd\cleanup_96_monthend

Get-Date

Pop-Location
