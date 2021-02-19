#-------------------------------------------------------------------------------
# File 'verify_payroll_ok_to_run_nolonger_needed.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'verify_payroll_ok_to_run_nolonger_needed'
#-------------------------------------------------------------------------------

echo "Running verify_payroll_ok_to_run ..."
echo ""
Get-Date
echo ""
Remove-Item u100.txt

&$env:QTP u100
##quiz auto=$obj/u100.qzc -comment by MC on 2009/oct/06
&$env:QUIZ u100
echo "The following report should be blank - otherwise DONT run payoll!"
Get-Content u100.txt
