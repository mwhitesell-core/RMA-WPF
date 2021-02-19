
echo       ENTER 'Y' to run macro - otherwise job will TERMINATE!

read response
echo $response

if  [ "$response" = "Y" -o "$response" = "y" ]
then
	echo job will now start ...
	echo ...
else
	echo WARNING - job was TERMINATED AT YOUR REQUEST!
	echo Terminated!
fi

cd $application_production
rm check_elig_pat.log 1>/dev/null 2>&1
batch << BATCH_EXIT
$cmd/check_elig_corrected_patients  1>check_elig_pat.log 2>&1
BATCH_EXIT

