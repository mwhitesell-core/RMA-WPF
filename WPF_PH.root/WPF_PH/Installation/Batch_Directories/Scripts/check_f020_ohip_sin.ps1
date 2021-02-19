#-------------------------------------------------------------------------------
# File 'check_f020_ohip_sin.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'check_f020_ohip_sin'
#-------------------------------------------------------------------------------

#  2015/Mar/03  MC      check_f020_ohip_sin 
#
#CORE - TESTING ENVIRONMENT CHANGES
$vers = $env:RMABILL_VERS

&$env:cmd\utl0119_all.com

echo "Setup of 101c environment"
#. $Env:root\macros\setup_rmabill.com  101c

if($vers -eq "101c") {
rmabill 101c
}
else {
echo "WARNING: TEST ENVIRONMENT DETECTED"
rmabill $vers
}

echo ""
echo "Entering `'production`' directory"
Set-Location $env:application_production ; Get-Location


Remove-Item check_ohip_sin.txt, utl0f020_count.sf*, utl0f020_ohip_sin.sf* *> $null

<#$pipedInput = @"
create file tmp-counters-alpha
"@

$pipedInput | qutil++#>

$rcmd = $env:TRUNCATE + "tmp_counters_alpha"
Invoke-Expression $rcmd


$rcmd = $env:QTP + "utl0f020_ohip_sin" 
Invoke-Expression $rcmd > check_f020_ohip_sin.log
$rcmd = $env:QUIZ + "utl0f020_ohip_sin" 
Invoke-Expression $rcmd >> check_f020_ohip_sin.log

Get-Content utl0f020_ohip_sin.txt | Out-Printer
