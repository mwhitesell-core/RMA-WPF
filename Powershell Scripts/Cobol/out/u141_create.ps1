#-------------------------------------------------------------------------------
# File 'u141_create.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'u141_create'
#-------------------------------------------------------------------------------

# 2015/Nov/16   MC              Automate miscellaneous payment batches/claims
#                               This is the second part - transactions creation

#cd $application_root/production
Set-Location $application_upl

qtp++ $obj\u141c

quiz++ $obj\r141d

Get-Contents r141b.txt| Out-Printer
