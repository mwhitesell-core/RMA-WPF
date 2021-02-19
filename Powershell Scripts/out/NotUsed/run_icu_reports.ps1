#-------------------------------------------------------------------------------
# File 'run_icu_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_icu_reports'
#-------------------------------------------------------------------------------

#file: run_icu_reports
#
if (pwd -ne "\alpha\rmabill\rmabill101c\production\85")
{
  echo "`a`a`a`a`a`a`a`a`a ERROR - you are in the wrong location to run this macro"
  echo "You must be in `'\alpha\rmabill\rmabill101c\production\85`'"
} else {

echo ""
echo "Running `'run_icu_reports`'"
echo ""
echo "Upon completion - check log `'icu_reports.log`' for errors!"
echo ""
echo "NOTE: Run the appropirate `'run_icu_payroll_xx`' macro in `'ICU Payroll Environment`'  next"
echo ""
echo ""
echo "Hit ENTER to start"
$garbage = Read-Host
echo "continuing ..."

Remove-Item icu_reports.log *> $null

echo "ICU Reports - starting - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > icu_reports.log
&$env:cmd\icu_reports >> icu_reports.log

echo "ICU Reports - ending   - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> icu_reports.log
}
