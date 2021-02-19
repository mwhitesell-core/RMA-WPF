#-------------------------------------------------------------------------------
# File 'batch_icu_app_report_ORIG.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_icu_app_report_ORIG'
#-------------------------------------------------------------------------------

# 00/nov/15 B.E. - new icu pgms to automatically create payments
echo "Job:     batch_icu_app_report"
echo "Command: run_icu_app_report"
echo ""
echo "Starting run ..... $(Get-Date -uformat `"%T`")"
echo "create icu-app-file"
echo ""
#cd $pb_data

Remove-Item icu_app_file.dat, icu_app_file_explode.dat *> $null
echo "Creating icu-app-file ..."
echo " "
$pipedInput = @"
create file icu-app-file
create file icu-app-file-explode
"@

$pipedInput | qutil++ *> $null

Remove-Item icuapp.sf*, u933a.sf*, payplan.sf* *> $null
Remove-Item r934*.txt *> $null

echo "Running u931 ..."
echo " "
&$env:QTP u931

Remove-Item qkin.txt, qkout.txt, qkecho.txt *> $null

utouch qkin.txt
utouch qkout.txt
utouch qkecho.txt

#quick auto=$obj/icuapp.qkg term=d410 notermpoll
echo "Running m932.qkc ..."
echo " "
quick++ $obj\m932

echo "Running u933.qtc ..."
echo " "
&$env:QTP u933 4.4 1.30 2>&1
echo "Running quiz r934a\b ..."
echo " "
&$env:QUIZ r934a
&$env:QUIZ r934b

Get-Content r934a.txt | Out-Printer
Get-Content r934a.txt | Out-Printer
Get-Content r934b.txt | Out-Printer
Get-Content r934b.txt | Out-Printer
#echo "Running u933b ..."
#echo " "
#qtp auto=$obj/u933b.qtc
#
#echo "Running u933c ..."
#echo " "
#qtp auto=$obj/u933c.qtc


echo "Finished Time $(Get-Date -uformat `"%T`")"
