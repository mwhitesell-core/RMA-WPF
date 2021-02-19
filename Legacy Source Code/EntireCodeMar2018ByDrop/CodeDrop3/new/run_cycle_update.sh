clear
echo RUN_CYCLE_UPDATE
echo
echo Creation Automatic Adjustments / OHIP Tape Submittal / Doctor Rev. Update
echo 
echo Hit "ENTER" to continue:
read garbage

echo
$cmd/run_ohip_submit_reports ${1}
echo
echo

cd $application_production
rm ru701 1>/dev/null 2>&1
mv ru701_cycle ru701 1>/dev/null 2>&1
touch ru701_cycle

echo "****************** IMPORTANT *************************"
echo
echo 'You MUST BALANCE all reports AND then hit new line to run the OHIP tape programs '
echo
echo 'Hit "NEWLINE" to run ohip tape programs'
read garbage
echo   'HIT   "NEWLINE"  2nd time  TO CONTINUE'
 read garbage
echo   'HIT   "NEWLINE"  3rd time  TO CONTINUE'
 read garbage

rm ohiptape.ls 1>/dev/null 2>&1
batch << BATCH_EXIT
$cmd/run_ohip_submit_tape ${1} 1>ohiptape.ls 2>&1
BATCH_EXIT
