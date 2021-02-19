#-------------------------------------------------------------------------------
# File 'u141_verify.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u141_verify'
#-------------------------------------------------------------------------------

# 2015/Nov/10   MC              Automate miscellaneous payment batches/claims
#                               This is the first part - data verification
#                               This macro can be run as many times as needed to make sure data are correct
#                               before transaction creation

#cd $application_root/production
Set-Location $env:application_upl


Remove-Item r141*txt, u141*sf*

Set-Location $env:pb_data

$rcmd = $env:QTP + "u141a"
Invoke-Expression $rcmd

#Core - Added to move subfile to upload folder
move-item U141A_VALID.sf $env:application_upl\U141A_VALID.sf

#Core - Added to move subfile definition to upload folder
move-item U141A_VALID.sfd $env:application_upl\U141A_VALID.sfd

#Core - Added to move subfile to upload folder
move-item U141A_ERROR.sf $env:application_upl\U141A_ERROR.sf

#Core - Added to move subfile definition to upload folder
move-item U141A_ERROR.sfd $env:application_upl\U141A_ERROR.sfd

Set-Location $env:application_upl

$rcmd = $env:QUIZ + "r141b1 DISC_r141a_error"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r141b2 DISC_r141a_valid"
Invoke-Expression $rcmd

#lp r141a_error.txt r141a_valid.txt
