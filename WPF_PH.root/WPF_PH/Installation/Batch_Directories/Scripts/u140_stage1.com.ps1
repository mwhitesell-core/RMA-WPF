#-------------------------------------------------------------------------------
# File 'u140_stage1.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'u140_stage1.com'
#-------------------------------------------------------------------------------

#file:  u140_stage1.com
# 04/jun/01 b.e. - original
# 08/sep/08 b.e. - running of u140 moved from u140_stage3.com to this macro
# 08/sep/18 M.C. - include qutil tmp-doctor-alpha before executing u140_a.qts
Param(
    [string]$1
    )

Push-Location
clear
echo "Running `'processing of AFP Conversion Payment file - Stage 1`'"
echo ""
echo ""

$filename = "$1"

echo "Setup of 101c environment"
#. $Env:root\macros\setup_rmabill.com  101c

if($env:RMABILL_VERS -eq "101CD2") { 
	rmabill 101cd2
}	
else {
	rmabill 101c 
}
echo ""
echo "Entering `'upload`' directory"
Set-Location $env:application_upl ; Get-Location

echo ""
echo "recreating file f075 ..."
#$pipedInput = @"
#create file f075-afp-doc-mstr
#create file tmp-doctor-alpha  
#"@

#$pipedInput | qutil++
#New-Item -type file f075-afp-doc-mstr
#New-Item -type file tmp-doctor-alpha

$rcmd = $env:TRUNCATE+"f075_afp_doc_mstr"
Invoke-Expression $rcmd

$rcmd = $env:TRUNCATE+"tmp_doctor_alpha"
Invoke-Expression $rcmd

echo ""
echo "renaming $filename to afp_fixed_payments.dat ..."
Move-Item -Force $filename afp_fixed_payments.dat

echo "running u140.cbl ..."
$rcmd = $env:COBOL+"u140"
Invoke-Expression $rcmd

echo "renaming processed file as: $filename.done"
Move-Item -Force afp_fixed_payments.dat "$filename.done"


echo "running u140_a.qtc ..."

$rcmd = $env:QTP + "u140_a A"
Invoke-Expression $rcmd

echo "Setup of solo environment"
#. $Env:root\macros\setup_rmabill.com  solo
if($env:RMABILL_VERS -eq "101CD2") { 
	rmabill solod2
}	
else {
	rmabill solo
}

echo ""
echo "Entering `'upload`' directory"
Set-Location $env:application_upl ; Get-Location

echo "recreating file f075 ..."
#$pipedInput = @"
#create file f075-afp-doc-mstr
#create file tmp-doctor-alpha  
#"@

#$pipedInput | qutil++
#New-Item -type file f075-afp-doc-mstr
#New-Item -type file tmp-doctor-alpha

$rcmd = $env:TRUNCATE+"f075_afp_doc_mstr"
Invoke-Expression $rcmd

$rcmd = $env:TRUNCATE+"tmp_doctor_alpha"
Invoke-Expression $rcmd

echo "running u140_a.qtc ..."

$rcmd = $env:QTP+"u140_a C"
Invoke-Expression $rcmd

echo "Return to 101c"
#. $Env:root\macros\setup_rmabill.com  101c
if($env:RMABILL_VERS -eq "solod2") { 
	rmabill 101cd2
}	
else {
	rmabill 101c 
}
echo "Continue by runningu140_stage2"
echo ""

echo "Done!"
Pop-Location
