#-------------------------------------------------------------------------------
# File 'u140_stage1.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'u140_stage1.com'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

#file:  u140_stage1.com
# 04/jun/01 b.e. - original
# 08/sep/08 b.e. - running of u140 moved from u140_stage3.com to this macro
# 08/sep/18 M.C. - include qutil tmp-doctor-alpha before executing u140_a.qts

clear
echo "Running `'processing of AFP Conversion Payment file - Stage 1`'"
echo ""
echo ""

$filename = "$1"

echo "Setup of 101c environment"
. $root\macros\setup_rmabill.com 101c

echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl; Get-Location

echo ""
echo "recreating file f075 ..."
$pipedInput = @"
create file f075-afp-doc-mstr
create file tmp-doctor-alpha  
"@

$pipedInput | qutil++

echo ""
echo "renaming $filename to afp_fixed_payments.dat ..."
Move-Item $filename afp_fixed_payments.dat

echo "running u140.cbl ..."
cobrun++ $obj\u140

echo "renaming processed file as: $filename.done"
Move-Item afp_fixed_payments.dat $filename.done


echo "running u140_a.qtc ..."

$pipedInput = @"
exec $obj/u140_a.qtc
A
"@

$pipedInput | qtp++

echo "Setup of solo environment"
. $root\macros\setup_rmabill.com solo

echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl; Get-Location

echo "recreating file f075 ..."
$pipedInput = @"
create file f075-afp-doc-mstr
create file tmp-doctor-alpha  
"@

$pipedInput | qutil++

echo "running u140_a.qtc ..."

$pipedInput = @"
exec $obj/u140_a.qtc
C
"@

$pipedInput | qtp++

echo "Return to 101c"
. $root\macros\setup_rmabill.com 101c
echo "Continue by runningu140_stage2"
echo ""

echo "Done!"
