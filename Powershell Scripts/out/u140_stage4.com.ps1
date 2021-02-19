#-------------------------------------------------------------------------------
# File 'u140_stage4.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'u140_stage4.com'
#-------------------------------------------------------------------------------

#file:  process_afp_converion_payment_4.com
# 04/jun/01 b.e. - original
# 08/jun/15 b.e. - added delete of f119 and f119_tithe subfiles in both environmemts
# 08/aug/05 M.C. - change or pass parameter C for solo, B is for MP only
#                - removed delete of f119 and f119_tithe subfiles as these are no longer used (trans put into f114 instead)
# 08/oct/14 M.C. - comment the execution of delete_f114_afpcon.qts

echo "Setup of 101c environment"
#. $Env:root\macros\setup_rmabill.com  101c
if($env:RMABILL_VERS -eq "101cd2") {
    rmabill 101cd2
}
else {
    rmabill 101c
}

echo "Entering `'upload`' directory"
Set-Location $env:application_upl ; Get-Location

# removed delete of f119 and f119_tithe subfiles as these are no longer used (trans put into f114 instead)
##echo "Resetting subfiles file"
##rm f119.sf*
##rm f119_tithe.sf*
Remove-Item u140_e_audit.sf*

# one-time running - to be removed later
#qtp auto=$obj/delete_f114_afpcon.qtc

echo "running u140_e.qts ..."
$rcmd = $env:QTP + "u140_e A A"
Invoke-Expression $rcmd

echo "Setup of Solotest environment"
#. $Env:root\macros\setup_rmabill.com  solo
if($env:RMABILL_VERS -eq "101cd2") {
    rmabill solod2
}
else {
    rmabill solo
}

echo "Entering `'upload`' directory"
Set-Location $env:application_upl ; Get-Location

#rm f119.sf*
#rm f119_tithe.sf*

# one-time running - to be removed later
#qtp auto=$obj/delete_f114_afpcon.qtc

echo "running u140_e.qts ..."
$rcmd = $env:QTP + "u140_e C C"
Invoke-Expression $rcmd

echo ""
echo "Return to 101c"
#. $Env:root\macros\setup_rmabill.com  101c
if($env:RMABILL_VERS -eq "solod2") {
    rmabill 101cd2
}
else {
    rmabill 101c
}

echo "Entering `'upload`' directory"
Set-Location $env:application_upl ; Get-Location

$rcmd = $env:QUIZ + "r140_e"
Invoke-Expression $rcmd
#lp r140_e.txt

echo ""

echo "Running verification programs .."
&$env:cmd\r140_verify

echo "Done!"
