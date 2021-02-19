#-------------------------------------------------------------------------------
# File 'u140_stage2.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'u140_stage2.com'
#-------------------------------------------------------------------------------

#file:  u140_stage2.com
# 04/jun/01 b.e. - original

clear
echo ""
echo "Running `'processing of AFP Conversion Payment file - Stage 2`'"
echo ""
echo "Consolidating subfile u030_paid_amt into `'upload`' directory"
echo ""
&$env:cmd\consolidate_u030_paid_amt_subfile

echo "Entering `'upload`' directory"
Set-Location $env:application_upl ; Get-Location

echo ""
echo "running u030b_1.qtc"
$rcmd = $env:QTP + "u030b_1"
Invoke-Expression $rcmd

echo ""
echo "Done!"
