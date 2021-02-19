#-------------------------------------------------------------------------------
# File 'run_hold_mess_nopayment.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'run_hold_mess_nopayment'
#-------------------------------------------------------------------------------

echo "Start Time is$(udate)"

Remove-Item hold.ls  > $null
Get-Date  > hold.ls  2>&1
#$cmd/hold_claims_mess      1>>hold.ls  2>&1

$cmd\no_ohip_payment_claims  >> hold.ls  2>&1

#$cmd/hold_claims           1>>hold.ls  2>&1
#$cmd/hold81                1>>hold.ls  2>&1
Get-Date  >> hold.ls  2>&1
exit

echo "End Time is$(udate)"
