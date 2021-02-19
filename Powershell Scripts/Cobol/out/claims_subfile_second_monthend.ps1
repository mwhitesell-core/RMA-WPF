#-------------------------------------------------------------------------------
# File 'claims_subfile_second_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'claims_subfile_second_monthend'
#-------------------------------------------------------------------------------

#  2015/Jul/14  M.C.    $cmd/claims_subfile_second_monthend
#  2015/Aug/11  MC1     Brad suggested to create subfiles in /foxtrot/bi directory
#                       and return back to $application_root/production when it's done
# 2015/Oct/08   MC2     rename the ps files with bi_xxxxxx.ps so that we know they are used for BI purpose

echo "Claims subfiles for all clinics that are run second monthend.."
echo ""
echo ""
echo ""

# MC1
#cd $application_root/production
Set-Location $root\foxtrot\bi

$cmd\claims_subfile_monthend.com  2  > claims_subfile_second_monthend.log

# MC2
##mv unlof002hdr_bi_sel.ps        unlof002hdr_me_2.ps
##mv unlof002hdr_bi_sel.psd       unlof002hdr_me_2.psd
##mv unlof002dtl_bi_sel.ps        unlof002dtl_me_2.ps
##mv unlof002dtl_bi_sel.psd       unlof002dtl_me_2.psd
Move-Item unlof002hdr_bi_sel.ps bi_f002hdr_me_2.ps
Move-Item unlof002hdr_bi_sel.psd bi_f002hdr_me_2.psd
Move-Item unlof002dtl_bi_sel.ps bi_f002dtl_me_2.ps
Move-Item unlof002dtl_bi_sel.psd bi_f002dtl_me_2.psd

# MC1
Set-Location $application_root\production

echo ""
echo ""
