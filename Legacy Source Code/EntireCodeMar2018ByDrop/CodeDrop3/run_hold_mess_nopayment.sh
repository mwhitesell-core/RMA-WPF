echo Start Time is `date`

rm hold.ls                  1>/dev/null 2>&1
date                        1> hold.ls  2>&1
#$cmd/hold_claims_mess      1>>hold.ls  2>&1

$cmd/no_ohip_payment_claims 1>>hold.ls  2>&1

#$cmd/hold_claims           1>>hold.ls  2>&1
#$cmd/hold81                1>>hold.ls  2>&1
date                        1>>hold.ls  2>&1 
exit

echo End Time is `date`
