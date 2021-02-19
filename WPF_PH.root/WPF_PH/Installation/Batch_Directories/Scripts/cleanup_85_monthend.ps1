#-------------------------------------------------------------------------------
# File 'cleanup_85_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'cleanup_85_monthend'
#-------------------------------------------------------------------------------

echo "********************************************************************"

echo "THIS PROGRAM WILL DELETE THE CLINIC 85 MONTEND REPORTS"
echo "MAKE SURE ALL THE REPORTS ARE PRINTED AND COPY MAG TAPE IS RUN"
echo ""
echo "********************************************************************"
echo ""
echo "**** HIT NEW LINE TO CONTINUE ****"
$garbage = Read-Host

Set-Location $env:application_production\85

Remove-Item r005 *> $null
Remove-Item r011 *> $null
Remove-Item r012 *> $null
Remove-Item r013 *> $null
Remove-Item r051ca *> $null
Remove-Item r051cb *> $null
Remove-Item r011_sort_work_mstr *> $null
Remove-Item r012_sort_work_mstr *> $null
Remove-Item r051wf *> $null
Remove-Item r051_sort_work_mstr *> $null
Remove-Item r934*.txt *> $null
Remove-Item u933*.sf* *> $null
Remove-Item claims_subfile*.sf* *> $null
