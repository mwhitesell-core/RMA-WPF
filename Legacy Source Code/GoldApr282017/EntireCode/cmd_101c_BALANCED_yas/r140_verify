# r140_verify

echo Running r140_verify
echo
echo if an error report is generated it will be paged out at end of run
echo if no records are selected then everything balances
echo
echo

$cmd/r140_verify.com > r140_verify.log
pg r140w.txt

echo
echo Done!
