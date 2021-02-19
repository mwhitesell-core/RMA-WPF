#-------------------------------------------------------------------------------
# File 'daily_icu_payroll_update.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'daily_icu_payroll_update'
#-------------------------------------------------------------------------------

#! /bin/ksh 
# 2002/01/21 B.E. - original
# 2002/08/28 yas  - change percent to 1.40 as per Leena request      

echo "Runningdaily_icu_payroll_update"
echo ""

echo "Creating icu app files ..."
echo " "
$pipedInput = @"
create file icu-app-file
create file icu-app-file-explode
"@

$pipedInput | qutil++

Remove-Item icuapp.sf*, u933a.sf*, u933a.sf* *> $null

echo "Running u931_temp ..."
Get-Date
echo " "
&$env:QTP u931_temp

Remove-Item qkin.txt, qkout.txt, qkecho.txt *> $null

utouch qkin.txt
utouch qkout.txt
utouch qkecho.txt

echo "Running m932.qkc ..."
Get-Date
echo " "
quick++ $obj\m932

echo ""

echo ""
echo "Running u933a_part1 and u933a_part2"
Get-Date
&$env:QTP u933a_part1
&$env:QTP u933a_part2 0.0 1.40

echo ""
echo "date"
echo "Done!"
