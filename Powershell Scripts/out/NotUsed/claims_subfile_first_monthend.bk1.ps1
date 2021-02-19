#-------------------------------------------------------------------------------
# File 'claims_subfile_first_monthend.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'claims_subfile_first_monthend.bk1'
#-------------------------------------------------------------------------------

#  2015/Jul/14  M.C.    $cmd/claims_subfile_first_monthend
#  2015/Aug/11  MC1     Brad suggested to create subfiles in /foxtrot/bi directory
#                       and return back to $application_root/production when it's done

echo "Claims subfiles for all clinics that are run first monthend.."
echo ""
echo ""
echo ""

# MC1
#cd $application_root/production
Set-Location $Env:root\foxtrot\bi

&$env:cmd\claims_subfile_monthend.com  1 > claims_subfile_first_monthend.log

Move-Item -Force unlof002hdr_bi_sel.ps unlof002hdr_me_1.ps
Move-Item -Force unlof002hdr_bi_sel.psd unlof002hdr_me_1.psd
Move-Item -Force unlof002dtl_bi_sel.ps unlof002dtl_me_1.ps
Move-Item -Force unlof002dtl_bi_sel.psd unlof002dtl_me_1.psd

# MC1
Set-Location $env:application_root\production

echo ""
echo ""
