#-------------------------------------------------------------------------------
# File 'u141_create.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u141_create'
#-------------------------------------------------------------------------------

# 2015/Nov/16   MC              Automate miscellaneous payment batches/claims
#                               This is the second part - transactions creation

#cd $application_root/production
Set-Location $env:application_upl

$rcmd = $env:QTP + "u141c"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r141d DISC_r141b"
Invoke-Expression $rcmd

#Get-Content r141b.txt | Out-Printer
