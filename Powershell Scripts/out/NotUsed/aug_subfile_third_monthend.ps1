#-------------------------------------------------------------------------------
# File 'aug_subfile_third_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'aug_subfile_third_monthend'
#-------------------------------------------------------------------------------

#  2015/Oct/14  M.C.    $cmd/aug_subfile_third_monthend

echo "Claims subfiles for all clinics that are run third monthend.."
echo ""
echo ""
echo ""

&$env:cmd\aug_subfile_monthend.com  3 > aug_subfile_third_monthend.log

Set-Location $Env:root\foxtrot\bi

Move-Item -Force unlof002hdr_bi_sel.ps bi_f002hdr_me_3.ps
Move-Item -Force unlof002hdr_bi_sel.psd bi_f002hdr_me_3.psd
Move-Item -Force unlof002dtl_bi_sel.ps bi_f002dtl_me_3.ps
Move-Item -Force unlof002dtl_bi_sel.psd bi_f002dtl_me_3.psd


echo ""
echo ""
