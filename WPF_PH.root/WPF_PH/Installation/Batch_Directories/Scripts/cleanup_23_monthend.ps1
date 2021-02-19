#-------------------------------------------------------------------------------
# File 'cleanup_23_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'cleanup_23_monthend'
#-------------------------------------------------------------------------------

echo "********************************************************************"

echo "THIS PROGRAM WILL DELETE THE CLINIC 23 MONTEND REPORTS"
echo "MAKE SURE ALL THE REPORTS ARE PRINTED AND COPY MAG TAPE IS RUN"
echo ""
echo "********************************************************************"
echo ""
echo "**** HIT NEW LINE TO CONTINUE ****"
$garbage = Read-Host

Set-Location $env:application_production\23

Remove-Item r004  -EA SilentlyContinue
Remove-Item r011  -EA SilentlyContinue
Remove-Item r012  -EA SilentlyContinue
Remove-Item r013  -EA SilentlyContinue
Remove-Item r051ca  -EA SilentlyContinue
Remove-Item r051cb  -EA SilentlyContinue
Remove-Item r070  -EA SilentlyContinue
Remove-Item r070_23  -EA SilentlyContinue
Remove-Item r210  -EA SilentlyContinue
Remove-Item r211  -EA SilentlyContinue
Remove-Item f002_claims_history_tape_file  -EA SilentlyContinue
Remove-Item r004wf  -EA SilentlyContinue
Remove-Item r004_sort_work_mstr  -EA SilentlyContinue
Remove-Item r011_sort_work_mstr  -EA SilentlyContinue
Remove-Item r012_sort_work_mstr  -EA SilentlyContinue
Remove-Item r051wf  -EA SilentlyContinue
Remove-Item r051_sort_work_mstr  -EA SilentlyContinue
Remove-Item r070_srt_work_mstr_23  -EA SilentlyContinue
Remove-Item r070_work_mstr_23  -EA SilentlyContinue
Remove-Item filer001*  -EA SilentlyContinue
Remove-Item claims_subfile*  -EA SilentlyContinue
