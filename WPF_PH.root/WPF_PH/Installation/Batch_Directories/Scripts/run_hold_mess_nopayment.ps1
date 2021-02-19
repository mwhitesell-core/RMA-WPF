#-------------------------------------------------------------------------------
# File 'run_hold_mess_nopayment.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_hold_mess_nopayment'
#-------------------------------------------------------------------------------

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Remove-Item hold.ls *> $null
Get-Date *> hold.ls
#$cmd/hold_claims_mess      1>>hold.ls  2>&1

&$env:cmd\no_ohip_payment_claims 2>&1 >> hold.ls

#$cmd/hold_claims           1>>hold.ls  2>&1
#$cmd/hold81                1>>hold.ls  2>&1
Get-Date 2>&1 >> hold.ls
exit

echo "End Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
