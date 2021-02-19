#-------------------------------------------------------------------------------
# File 'run_icu_payroll_13.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_icu_payroll_13'
#-------------------------------------------------------------------------------

# file: run_icu_payroll_13
#  ICU Payroll Run 13
#

echo ""
echo "Running `'run_icu_payroll_13`'"
echo ""
echo "Upon completion - verify results in log file: `'teb_icu.log`'"
echo ""
echo "Hit ENTER to start"
$garbage = Read-Host
echo "continuing ..."

Remove-Item teb_icu.log *> $null

echo "ICU Payroll Run 13 - starting - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > teb_icu.log

echo "--- generate_icu_payroll ---" >> teb_icu.log
&$env:cmd\generate_icu_payroll 200313 200301 >> teb_icu.log 2> teb_icu.log

echo "--- u090f (QTP RUN) ---" >> teb_icu.log
&$env:QTP u090f >> teb_icu.log 2> teb_icu.log

echo "ICU - Payroll Run 13 - ending - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> teb_icu.log
