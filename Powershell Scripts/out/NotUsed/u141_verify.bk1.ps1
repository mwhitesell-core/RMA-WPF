#-------------------------------------------------------------------------------
# File 'u141_verify.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u141_verify.bk1'
#-------------------------------------------------------------------------------

# 2015/Nov/10   MC              Automate miscellaneous payment batches/claims
#                               This is the first part - data verification
#                               This macro can be run as many times as needed to make sure data are correct
#                               before transaction creation

#cd $application_root/production
Set-Location $application_upl

&$env:QTP u141a

&$env:QUIZ r141b1

&$env:QUIZ r141b2

#lp r141a_error.txt r141a_valid.txt
