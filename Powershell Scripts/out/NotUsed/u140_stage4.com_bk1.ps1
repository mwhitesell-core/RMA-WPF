#-------------------------------------------------------------------------------
# File 'u140_stage4.com_bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u140_stage4.com_bk1'
#-------------------------------------------------------------------------------

#file:  process_afp_converion_payment_4.com
# 04/jun/01 b.e. - original

echo "Setup of 101c environment"
. $Env:root\macros\setup_rmabill.com  101c

echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

echo "Resetting audit file"
Remove-Item u140_e_audit.sf*

echo "running u140_e.qts ..."
&$env:QTP u140_e A

echo "Setup of MP environment"
. $Env:root\macros\setup_rmabill.com  mp

echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

echo "running u140_e.qts ..."
&$env:QTP u140_e B

echo ""
echo "Return to 101c"
. $Env:root\macros\setup_rmabill.com  101c

echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

&$env:QUIZ r140_e
Get-Content r140_e.txt | Out-Printer

echo ""

echo "Running verification programs .."
&$env:cmd\r140_verify

echo "Done!"
