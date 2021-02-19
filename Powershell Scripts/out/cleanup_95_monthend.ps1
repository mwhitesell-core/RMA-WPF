#-------------------------------------------------------------------------------
# File 'cleanup_95_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'cleanup_95_monthend'
#-------------------------------------------------------------------------------

echo "********************************************************************"

echo "THIS PROGRAM WILL DELETE THE CLINIC 95 MONTEND REPORTS"
echo "MAKE SURE ALL THE REPORTS ARE PRINTED AND COPY MAG TAPE IS RUN"
echo ""
echo "********************************************************************"
echo ""
echo "**** HIT NEW LINE TO CONTINUE ****"
$garbage = Read-Host

Set-Location $env:application_production\95

Remove-Item r004 *> $null
Remove-Item r011 *> $null
Remove-Item r012 *> $null
Remove-Item r013 *> $null
Remove-Item r051ca *> $null
Remove-Item r051cb *> $null
Remove-Item r070 *> $null
Remove-Item r070_95 *> $null
Remove-Item r210 *> $null
Remove-Item r211 *> $null
Remove-Item f002_claims_history_tape_file *> $null
Remove-Item r004wf *> $null
Remove-Item r004_sort_work_mstr *> $null
Remove-Item r011_sort_work_mstr *> $null
Remove-Item r012_sort_work_mstr *> $null
Remove-Item r051wf *> $null
Remove-Item r051_sort_work_mstr *> $null
Remove-Item r070_srt_work_mstr_95 *> $null
Remove-Item r070_work_mstr_95 *> $null
Remove-Item filer001* *> $null
Remove-Item claims_subfile* *> $null
