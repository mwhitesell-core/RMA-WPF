#-------------------------------------------------------------------------------
# File 'u140_stage2.com_bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u140_stage2.com_bk1'
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
Set-Location $application_upl ; Get-Location

echo ""
echo "running u030b_1.qtc"

&$env:QTP u030b_1

echo ""
echo "Done!"
