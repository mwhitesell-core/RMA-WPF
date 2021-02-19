echo "Running rat_audit_1.com ..."
echo 

cd $pb_data

$cmd/dump_rat

awk -f $cmd/pad_to_79_bytes.awk < ohip_rat_ascii.dump > $application_production/rat.ps

echo
echo Finished !
echo
echo
echo "You should now vi the rat.ps in production and then run rat_audit_2.com"A

cd $application_production

