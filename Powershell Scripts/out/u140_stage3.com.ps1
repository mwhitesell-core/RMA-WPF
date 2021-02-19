#-------------------------------------------------------------------------------
# File 'u140_stage3.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'u140_stage3.com'
#-------------------------------------------------------------------------------

#file:  u140_stage3.com
# 04/jun/01 b.e. - original
# 08/aug/10 M.C. - substitute MP with Solotest
# 08/sep/08 b.e. - running of u140.cbl moved from this macro to u140_stage1.com
# 09/jun/16 M.C. - include r140_a_summ.txt

Push-Location
clear
echo "Running `'processing of AFP Conversion Payment file - Stage 3`'"
echo ""
echo "Entering `'upload`' directory"
Set-Location $env:application_upl ; Get-Location

#CORE - Added for testing environments
$orig = $env:RMABILL_VERS

#filename=$1
#echo 
#echo renaming $filename to afp_fixed_payments.dat ... 
#mv $filename afp_fixed_payments.dat
#
#echo running u140.cbl ...
#cobrun $obj/u140

echo "recreating file tmp_alpha_doctor ..."
#$pipedInput = @"
#create file tmp-doctor-alpha
#"@

#$pipedInput | qutil++
#New-Item -type file tmp-doctor-alpha

$rcmd = $env:TRUNCATE+"tmp_doctor_alpha"
Invoke-Expression $rcmd

echo "running u140_b $Env:root\ 140_c $Env:root\ u140_d ..."
$rcmd = $env:QTP+"u140_b" #" determine percentage RA payments "
Invoke-Expression $rcmd
$rcmd = $env:QTP+"u140_c" #" update f075 with a1f payment amt      "
Invoke-Expression $rcmd
#clear subfile before running so that values can accumulate between 101c and solo
#if  [ $RMABILL_VERSION = 101c ]
#then
# echo removing u140_d1 and _d1a subfiles
  Remove-Item u140_d1.sf*
#else
# echo bypassing the removal of u140_d1 subfile
#fi
$rcmd = $env:QTP +"u140_d" #" divy up AFP payment based upon RA percentage"
Invoke-Expression $rcmd

echo "running r140 reports ..."
echo "Running .. report group total amount"
echo "Running .. group conversion detail report"
echo "Running .. solo conversion detail report"
echo "Running .. total Conversion payment report"
echo "Running .. governance Total payment report"
$rcmd = $env:QUIZ + "r140_a1f"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r140_a2g"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r140_a2s"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r140_a3c"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r140_a4t"
Invoke-Expression $rcmd

#echo renaming processed file as: $filename.done
#mv afp_fixed_payments.dat $filename.done

echo ""
echo "Setup of Solotest environment"
#. $Env:root\macros\setup_rmabill.com  solo
if($orig -eq "101CD2") { 
	rmabill solod2
}	
else {
	rmabill solo 
}
echo ""
echo "Entering `'upload`' directory"
Set-Location $env:application_upl ; Get-Location

echo "recreating file tmp_alpha_doctor ..."
#$pipedInput = @"
#create file tmp-doctor-alpha
#"@

#$pipedInput | qutil++
#New-Item -type file tmp-doctor-alpha

$rcmd = $env:TRUNCATE+"tmp_doctor_alpha"
Invoke-Expression $rcmd

Remove-Item u140_d1.sf*
echo "Running stage3 in solo"
#$cmd/u140_stage3_mp.com
$rcmd = $env:QTP + "u140_b" #" determine percentage RA payments "
Invoke-Expression $rcmd
$rcmd = $env:QTP + "u140_c" #" update f075 with a1f payment amt      "
Invoke-Expression $rcmd
$rcmd = $env:QTP + "u140_d" #" divy up AFP payment based upon RA percentage"
Invoke-Expression $rcmd


echo ""
echo ""
echo "Return to 101c environment"
#. $Env:root\macros\setup_rmabill.com  101c
if($orig -eq "101CD2") { 
	rmabill 101cd2
    "" | Add-Content \\$env:root\alpha\rmabill\rmabill101cd2\upload\u140_d1.sf 
    Get-Content \\$env:root\alpha\rmabill\rmabillsolod2\upload\u140_d1.sf | Add-Content \\$env:root\alpha\rmabill\rmabill101cd2\upload\u140_d1.sf
}	
else {
	rmabill 101c
    "" | Add-Content \\$env:root\alpha\rmabill\rmabill101c\upload\u140_d1.sf 
    Get-Content \\$env:root\alpha\rmabill\rmabillsolo\upload\u140_d1.sf | Add-Content \\$env:root\alpha\rmabill\rmabill101c\upload\u140_d1.sf 
}
echo ""
echo "Entering `'upload`' directory"
Set-Location $env:application_upl ; Get-Location

echo "add Report only group entries to subfile"
$rcmd = $env:QUIZ + "u140_k"
Invoke-Expression $rcmd

echo "removing duplicates from u140_d1 subfile"
$rcmd = $env:QTP + "u140_d1_remove_dups"
Invoke-Expression $rcmd
Move-Item -Force u140_d1.sf u140_d1_with_dups.sf
Move-Item -Force u140_d1.sfd u140_d1_with_dups.sfd

Move-Item -Force u140_d2.sf u140_d1.sf
Move-Item -Force u140_d2.sfd u140_d1.sfd

echo "ensure that all docs in u140_d1 are also in f075"
echo "running u140_f.qtc"
$rcmd = $env:QTP + "u140_f"
Invoke-Expression $rcmd

echo "run reports"
# run reports
&$env:cmd\r140_reports

echo "Entering `'upload`' directory"
Set-Location $env:application_upl ; Get-Location

Get-ChildItem r140_a1f.txt, r140_a2g.txt, r140_a2s.txt, r140_a3c.txt, r140_a4t.txt, r140_a.txt, r140_a_summ.txt, `
  r140_b.txt
echo ""
echo ""
echo "Confirm the above reports are correct and then complete this process"
echo "by runningu140_stage4"
echo ""
echo "Done!"
Pop-Location
