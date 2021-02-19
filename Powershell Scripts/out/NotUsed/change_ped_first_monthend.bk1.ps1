#-------------------------------------------------------------------------------
# File 'change_ped_first_monthend.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'change_ped_first_monthend.bk1'
#-------------------------------------------------------------------------------

#  2014/Jul/14  M.C.    $cmd/change_ped_first_monthend

echo "Change cycle nbr and monthend date for clinics in first monthend.."
echo ""
echo ""
echo ""

Set-Location $env:application_root\production

&$env:cmd\change_ped_monthend.com  1 > change_ped_first_monthend.log

echo ""
echo ""
