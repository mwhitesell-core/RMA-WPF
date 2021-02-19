#-------------------------------------------------------------------------------
# File 'runoscar_15.ps1'
# Converted to PowerShell by CORE Migration on 2019-05-14 14:16:18
# Original file name was 'runoscar_15'
#-------------------------------------------------------------------------------

&$env:cmd\recreate_clean_suspense

Copy-Item HJ254482.001_254482.rma.enc.dat f002_submit_disk_254482.in

&$env:cmd\u701oscar "254482"

$timeStamp = "20$(Get-Date -uformat `"%y_%m_%d")"
Move-Item -Force HJ254482.001_254482.rma.enc.dat HJ254482.001_254482.rma.enc.dat.done.$timeStamp

echo "Generate Audit Report"

$rcmd = $env:QUIZ + "suspend_dtl_emr"
Invoke-Expression $rcmd
	
&$env:cmd\suspend_dtl