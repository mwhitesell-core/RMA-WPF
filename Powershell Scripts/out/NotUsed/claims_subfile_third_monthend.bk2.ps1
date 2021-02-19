#-------------------------------------------------------------------------------
# File 'claims_subfile_third_monthend.bk2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'claims_subfile_third_monthend.bk2'
#-------------------------------------------------------------------------------

#  2015/Jul/14  M.C.    $cmd/claims_subfile_third_monthend

echo "Claims subfiles for all clinics that are run third monthend.."
echo ""
echo ""
echo ""

Set-Location $env:application_root\production

&$env:cmd\claims_subfile_monthend.com  3 > claims_subfile_third_monthend.log

Move-Item -Force unlof002hdr_bi_sel.ps unlof002hdr_me_3.ps
Move-Item -Force unlof002hdr_bi_sel.psd unlof002hdr_me_3.psd
Move-Item -Force unlof002dtl_bi_sel.ps unlof002dtl_me_3.ps
Move-Item -Force unlof002dtl_bi_sel.psd unlof002dtl_me_3.psd

echo ""
echo ""