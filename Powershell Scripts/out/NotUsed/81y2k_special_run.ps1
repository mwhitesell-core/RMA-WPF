#-------------------------------------------------------------------------------
# File '81y2k_special_run.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was '81y2k_special_run'
#-------------------------------------------------------------------------------

#file: 81y2k_reports 
echo "Running `'81y2k_reports`'"
echo ""
echo "NOTE: Run `'generate_81y2k_payroll`' in `'ICU Payroll Environment`'"
echo "after this process completes"
echo ""

# ensure running in correct environment
echo ""

echo ""
echo ""
echo "Starting run ..... $(Get-Date -uformat `"%T`")"
##########rm f119.sf* 1>/dev/null 2<&1

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
