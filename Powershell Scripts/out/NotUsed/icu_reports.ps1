#-------------------------------------------------------------------------------
# File 'icu_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'icu_reports'
#-------------------------------------------------------------------------------

#file: icu_reports 
# 00/???/?? M.C. - original
# 01/feb/15 B.E. - enhancments to u933 and changes in subfile names
# 01/apr/25 B.E. - runs u933a_part1 instead of u933
# 01/oct/22 M.C. - runs u931_icu    instead of u931
#                - runs u933a_part1_icu   instead of u933a_part1
# 03/sep/23 B.E. - 81y2k eliminated so conditional icu/81y2k compile no longer
#                  needed - u933a_part1_icu changed back to u933a_part1

echo "Running `'icu_reports`'"
echo ""
echo "NOTE: Run `'generate_icu_payroll`' in `'ICU Payroll Environment`'"
echo "after this process completes"
echo ""

# ensure running in correct environment
if (pwd -ne "\alpha\rmabill\rmabill101c\production\85")
{
  echo "`a`a`aERROR - you are in the wrong location to run this macro"
  echo "This macro must be run from the following directory:"
  echo "$Env:root\alpha\rmabill\rmabill101c\production\85"
} else {

echo ""

echo ""
echo ""
echo "Starting run ..... $(Get-Date -uformat `"%T`")"
Get-Content &1 |Remove-Item f119.sf*, 2 > $null

echo "create icu-app-file"
echo ""

Remove-Item icu_app_file.dat, icu_app_file_explode.dat *> $null

echo "Creating icu-app-file ..."
echo " "
$pipedInput = @"
create file icu-app-file
create file icu-app-file-explode
"@

$pipedInput | qutil++

Remove-Item icuapp.sf*, u933a.sf*, u933a.sf* *> $null
Remove-Item r934*.txt *> $null

echo "Copying u010 daily payroll feed file to '85' directory"
Copy-Item $env:application_production\u010daily_payroll_feed.sf* .

echo "Running u931_temp ..."
echo " "
&$env:QTP u931_temp

Remove-Item qkin.txt, qkout.txt, qkecho.txt *> $null

utouch qkin.txt
utouch qkout.txt
utouch qkecho.txt

#quick auto=$obj/icuapp.qkg term=d410 notermpoll
echo "Running m932.qkc ..."
echo " "
quick++ $obj\m932

&$env:QTP u933a_part1

echo "Finished Time $(Get-Date -uformat `"%T`")"
}
