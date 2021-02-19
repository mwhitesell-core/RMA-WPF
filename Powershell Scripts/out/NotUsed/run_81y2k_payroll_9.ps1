#-------------------------------------------------------------------------------
# File 'run_81y2k_payroll_9.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_81y2k_payroll_9'
#-------------------------------------------------------------------------------

# file: run_icu_payroll_9
#  ICU Payroll Run 9
#

echo ""
echo "Running `'run_icu_payroll_9`'"
echo ""
echo "Upon completion - verify results in log file: `'teb_icu.log`'"
echo ""
echo "Hit ENTER to start"
$garbage = Read-Host
echo "continuing ..."

Remove-Item teb_icu.log *> $null

echo "ICU Payroll Run 9 - starting - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > teb_icu.log

echo "--- generate_icu_payroll ---" >> teb_icu.log
&$env:cmd\generate_81y2k_payroll 200109 200101 >> teb_icu.log 2> teb_icu.log

echo "--- u090f (QTP RUN) ---" >> teb_icu.log
&$env:QTP u090f >> teb_icu.log 2> teb_icu.log

echo "ICU - Payroll Run 9 - ending - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> teb_icu.log
