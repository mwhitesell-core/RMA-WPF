#-------------------------------------------------------------------------------
# File 'u141_verify.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'u141_verify'
#-------------------------------------------------------------------------------

# 2015/Nov/10   MC              Automate miscellaneous payment batches/claims
#                               This is the first part - data verification
#                               This macro can be run as many times as needed to make sure data are correct
#                               before transaction creation

#cd $application_root/production
Set-Location $application_upl


Remove-Item r141*txt, u141*sf*

qtp++ $obj\u141a

quiz++ $obj\r141b1

quiz++ $obj\r141b2

#lp r141a_error.txt r141a_valid.txt
