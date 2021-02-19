#-------------------------------------------------------------------------------
# File 'r140_verify.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r140_verify.com'
#-------------------------------------------------------------------------------

# r140_verify

echo "Setup of 101c environment"
. $root\macros\setup_rmabill.com  101c
echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl; Get-Location

Remove-Item r140w.txt  > $null

$pipedInput = @"
create file tmp-governance-payments-file
"@

$pipedInput | qutil++

#echo Runnin g r140v_1  in 101c
#qtp auto=$obj/r140v_1.qtc

#echo Running  r140v_2 in 101c
#qtp << EOJ_QTP
#exec $obj/r140v_2.qtc
#A
#EOJ_QTP

qtp++ $obj\r140w1
qtp++ $obj\r140w2


echo "Setup of SOLO environment"
. $root\macros\setup_rmabill.com  solo
echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl; Get-Location

#echo Running  r140v_2  in SOLO
#qtp << EOJ_QTP
#exec $obj/r140v_2.qtc
#C
#EOJ_QTP

qtp++ $obj\r140w2

echo "Returning to 101c environment"
. $root\macros\setup_rmabill.com  101c
echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl; Get-Location

#echo Running  r140v_3  in 101c
#quiz auto=$obj/r140v_3.qzc

quiz++ $obj\r140w3

#lp r140v.txt
