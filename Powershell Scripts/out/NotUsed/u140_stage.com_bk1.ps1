#-------------------------------------------------------------------------------
# File 'u140_stage.com_bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u140_stage.com_bk1'
#-------------------------------------------------------------------------------

#file:  u140_stage1.com
# 04/jun/01 b.e. - original

clear
echo "Running `'processing of AFP Conversion Payment file - Stage 1`'"
echo ""
echo ""
echo "Setup of 101c environment"
. $Env:root\macros\setup_rmabill.com  101c

echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

echo ""
echo "recreating file f075 ..."
$pipedInput = @"
create file f075-afp-doc-mstr
"@

$pipedInput | qutil++

echo "running u140_a.qtc ..."

&$env:QTP u140_a

echo "Setup of MP environment"
. $Env:root\macros\setup_rmabill.com  mp

echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

echo "recreating file f075 ..."
$pipedInput = @"
create file f075-afp-doc-mstr
"@

$pipedInput | qutil++

echo "running u140_a.qtc ..."

&$env:QTP u140_a

echo "Return to 101c"
. $Env:root\macros\setup_rmabill.com  101c
echo "Continue by runningu140_stage2"
echo ""

echo "Done!"
