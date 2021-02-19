#-------------------------------------------------------------------------------
# File 'icu_app_22_ORIG.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'icu_app_22_ORIG'
#-------------------------------------------------------------------------------

echo "RUN_ICU_APP_REPORTS.................."
echo ""
Set-Location $pb_data
Remove-Item icu_app_file.dat, icu_app_file_explode.dat *> $null
$pipedInput = @"
create file icu-app-file
create file icu-app-file-explode
"@

$pipedInput | qutil++ *> $null
Remove-Item icuapp.sf*, u933a.sf*, payplan.sf*, r934?.txt *> $null
&$env:QTP u931_22
Remove-Item qkin.txt, qkout.txt, qkecho.txt *> $null
utouch qkin.txt
utouch qkout.txt
utouch qkecho.txt
quick++ $obj\icuapp
&$env:QTP u933_22
&$env:QUIZ r934b_22
echo "Finished time $(Get-Date -uformat `"%H:%M:%S`")"
