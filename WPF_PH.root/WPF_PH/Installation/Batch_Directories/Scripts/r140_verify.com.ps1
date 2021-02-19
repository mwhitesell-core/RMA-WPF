#-------------------------------------------------------------------------------
# File 'r140_verify.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'r140_verify.com'
#-------------------------------------------------------------------------------

# r140_verify

echo "Setup of 101c environment"
if($env:RMABILL_VERS -eq "101cd2") {
    rmabill 101cd2
}
else {
    rmabill 101c
}
echo ""
echo "Entering `'upload`' directory"
Set-Location $env:application_upl ; Get-Location

Remove-Item r140w.txt *> $null

#$pipedInput = @"
#create file tmp-governance-payments-file
#"@



$rcmd = $env:TRUNCATE+"tmp_governance_payments_file"
Invoke-Expression $rcmd



#echo Runnin g r140v_1  in 101c
#qtp auto=$obj/r140v_1.qtc

#echo Running  r140v_2 in 101c
#qtp << EOJ_QTP
#exec $obj/r140v_2.qtc
#A
#EOJ_QTP

$rcmd = $env:QTP + "r140w1"
Invoke-Expression $rcmd
$rcmd = $env:QTP + "r140w2"
Invoke-Expression $rcmd


echo "Setup of SOLO environment"
if($env:RMABILL_VERS -eq "101cd2") {
    rmabill solod2
}
else {
    rmabill solo
}
echo ""
echo "Entering `'upload`' directory"
Set-Location $env:application_upl ; Get-Location

#echo Running  r140v_2  in SOLO
#qtp << EOJ_QTP
#exec $obj/r140v_2.qtc
#C
#EOJ_QTP

$rcmd = $env:QTP + "r140w2"
Invoke-Expression $rcmd

echo "Returning to 101c environment"
if($env:RMABILL_VERS -eq "solod2") {
    rmabill 101cd2
}
else {
    rmabill 101c
}
echo ""
echo "Entering `'upload`' directory"
Set-Location $env:application_upl ; Get-Location

#echo Running  r140v_3  in 101c
#quiz auto=$obj/r140v_3.qzc

$rcmd = $env:QUIZ + "r140w3 DISC_r140w"
Invoke-Expression $rcmd

#lp r140v.txt
